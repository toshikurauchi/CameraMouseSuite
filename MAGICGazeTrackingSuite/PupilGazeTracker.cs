﻿/*                         Camera Mouse Suite
 *  Copyright (C) 2014, Samual Epstein
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Collections;
using Castle.Zmq;
using System.Windows.Controls;

namespace MAGICGazeTrackingSuite
{
    public class PupilGazeTracker : IGazeTracker
    {
        private Context context;
        private Socket client;

        private Thread clientThread;
        private ManualResetEvent stopEvent;
        private ArrayList latestData;
        private static int FILTER_TIME_WINDOW = 100; // In milliseconds
        private bool active = true;
        private bool started = false;
        private float screenWidth = 0;
        private float screenHeight = 0;

        public PupilGazeTracker(float screenWidth, float screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public string Name
        {
            get { return "Pupil-Labs"; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public PointF CurrentGaze()
        {
            if (!started)
            {
                return PointF.Empty;
            }
            if (clientThread == null)
            {
                stopEvent = new ManualResetEvent(false);
                clientThread = new Thread(new ThreadStart(ReceiveGazeData));
                clientThread.Priority = ThreadPriority.AboveNormal;
                clientThread.Start();
            }

            UpdateLatestData();
            PointF gaze = MedianFilteredGazeData();
            if (gaze.IsEmpty)
            {
                return PointF.Empty;
            }
            gaze = PointFExtension.Multiply(gaze, screenWidth, screenHeight);
            gaze.Y = screenHeight - gaze.Y; // Adjusting coordinate system
            return gaze;
        }

        private PointF MedianFilteredGazeData()
        {
            ArrayList xValues = new ArrayList(latestData.Count);
            ArrayList yValues = new ArrayList(latestData.Count);
            foreach (GazeData data in latestData)
            {
                xValues.Add(data.GazeOnScreen.X);
                yValues.Add(data.GazeOnScreen.Y);
            }
            xValues.Sort();
            yValues.Sort();
            if (xValues.Count == 0 || yValues.Count == 0)
            {
                return PointF.Empty;
            }
            return new PointF((float)xValues[xValues.Count / 2], (float)yValues[yValues.Count / 2]);
        }

        private void UpdateLatestData()
        {
            for (int i = latestData.Count - 1; i >= 0; i--)
            {
                GazeData data = (GazeData)latestData[i];
                if (data == null || !data.GazeIsOnScreen() || DateTime.Now.Subtract(data.LocalTimestamp).Milliseconds >= FILTER_TIME_WINDOW)
                {
                    latestData.RemoveAt(i);
                }
            }
        }

        public void ReceiveGazeData()
        {
            while(!stopEvent.WaitOne(0, true))
            {
                if (context == null)
                {
                    context = new Context();
                }
                if (client == null)
                {
                    client = (Castle.Zmq.Socket)context.CreateSocket(SocketType.Sub);
                    client.Connect("tcp://127.0.0.1:5000");
                    client.SetOption(SocketOpt.SUBSCRIBE, new byte[0]);
                }
                try
                {
                    byte[] reply = client.Recv(RecvFlags.DoNotWait);
                    if (reply != null)
                    {
                        string msg = Encoding.ASCII.GetString(reply);
                        if (msg.StartsWith("Pupil"))
                        {
                            latestData.Add(new GazeData(msg));
                        }
                    }
                }
                catch (Castle.Zmq.ZmqException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Start()
        {
            latestData = ArrayList.Synchronized(new ArrayList());
            Active = true;
            started = true;
        }

        public bool Started
        {
            get { return started; }
        }

        public void Calibrate()
        {
        }

        public void Stop()
        {
            started = false;
            if (clientThread != null)
            {
                stopEvent.Set();
                clientThread.Join();
                stopEvent.Close();
                clientThread = null;
                stopEvent = null;
            }
        }

        public UserControl EyeStatus
        { 
            get { return null; } 
        }
    }
}