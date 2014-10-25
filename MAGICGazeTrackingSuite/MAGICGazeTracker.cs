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
using Castle.Zmq;

namespace MAGICGazeTrackingSuite
{
    public class MAGICGazeTracker
    {
        private Context context;
        private Socket client;

        private Thread clientThread;
        private ManualResetEvent stopEvent;
        private GazeData gazeData;

        public PointF ProcessMouse(PointF cursor, PointF cursorDirection, double screenWidth, double screenHeight)
        {
            cursorDirection = PointFHelper.Divide(cursorDirection, (float)screenWidth, (float)screenHeight);
            if (PointFHelper.NormSqr(cursorDirection) < 1e-5)
            {
                return cursor;
            }
            if (clientThread == null)
            {
                stopEvent = new ManualResetEvent(false);
                clientThread = new Thread(new ThreadStart(ReceiveGazeData));
                clientThread.Priority = ThreadPriority.AboveNormal;
                clientThread.Start();
            }
            if (gazeData != null && gazeData.GazeIsOnScreen() && DateTime.Now.Subtract(gazeData.LocalTimestamp).Milliseconds < 500)
            {
                PointF normCursor = PointFHelper.Divide(cursor, (float)screenWidth);
                PointF gaze = gazeData.GazeOnScreen;
                gaze.Y = 1 - gaze.Y; // Adjusting coordinate system
                double maxDist = 1.0/3;
                double sqrDist = PointFHelper.NormSqr(PointFHelper.Subtract(normCursor, gaze));
                if (sqrDist > maxDist * maxDist)
                {
                    return PointFHelper.Multiply(gaze, (float)screenWidth, (float)screenHeight);
                }
            }
            return cursor;
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
                            gazeData = new GazeData(msg);
                        }
                    }
                }
                catch (Castle.Zmq.ZmqException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void stop()
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
    }
}