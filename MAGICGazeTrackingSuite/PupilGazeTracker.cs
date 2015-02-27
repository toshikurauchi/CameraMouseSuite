/*                         Camera Mouse Suite
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
using System.Windows.Forms;
using NetMQ;
using NetMQ.Sockets;
using NetMQ.zmq;
using System.Collections.Concurrent;

namespace MAGICGazeTrackingSuite
{
    public class PupilGazeTracker : IGazeTracker
    {
        private Thread clientThread;
        private ManualResetEvent stopEvent;
        private ConcurrentQueue<GazeData> latestData;
        private static int FILTER_TIME_WINDOW = 100; // In milliseconds
        private bool active = true;
        private bool started = false;
        private float screenWidth = 0;
        private float screenHeight = 0;

        private string connectionString;

        private PupilPanel panel;

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
            if (clientThread == null)
            {
                return PointF.Empty;
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
                if (!data.GazeOnScreen.IsEmpty)
                {
                    xValues.Add(data.GazeOnScreen.X);
                    yValues.Add(data.GazeOnScreen.Y);
                }
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
            bool removing = true;
            while (removing)
            {
                GazeData first;
                if (latestData.TryPeek(out first))
                {
                    if (DateTime.Now.Subtract(first.LocalTimestamp).TotalMilliseconds >= FILTER_TIME_WINDOW)
                    {
                        latestData.TryDequeue(out first);
                    }
                    else
                    {
                        removing = false;
                    }
                }
                else
                {
                    removing = false;
                }
            }
        }

        public void ReceiveGazeData()
        {
            using (NetMQContext context = NetMQContext.Create())
            using (var client = context.CreateSubscriberSocket())
            {
                client.Connect(connectionString);
                client.Subscribe("Gaze");

                while (!stopEvent.WaitOne(0, true))
                {
                    try
                    {
                        string msg = client.ReceiveString(SendReceiveOptions.DontWait);
                        latestData.Enqueue(new GazeData(msg));
                    }
                    catch (NetMQException e) {}
                }
                Console.WriteLine("OUT!");
            }
        }

        public void Start()
        {
            latestData = new ConcurrentQueue<GazeData>();
            Active = true;
            started = true;
        }

        public bool Started
        {
            get { return started; }
        }

        public void Stop()
        {
            started = false;
            StopClient();
        }

        public void StartClient(string serverIP, string port)
        {
            string newConnectionString = "tcp://" + serverIP + ":" + port;
            if (connectionString != null && !connectionString.Equals(newConnectionString))
            {
                StopClient();
            }
            if (clientThread == null)
            {
                connectionString = newConnectionString;
                stopEvent = new ManualResetEvent(false);
                clientThread = new Thread(new ThreadStart(ReceiveGazeData));
                clientThread.Priority = ThreadPriority.AboveNormal;
                clientThread.Start();
            }
        }

        public void StopClient()
        {
            if (clientThread != null)
            {
                stopEvent.Set();
                clientThread.Join();
                stopEvent.Close();
                clientThread = null;
                stopEvent = null;
            }
        }

        public UserControl EyeTrackerTab
        { 
            get 
            {
                if (panel == null)
                {
                    panel = new PupilPanel();
                    panel.EyeTracker = this;
                }
                return panel; 
            } 
        }
    }
}