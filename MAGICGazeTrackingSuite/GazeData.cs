﻿using System;
using System.Drawing;

namespace MAGICGazeTrackingSuite
{
    class GazeData
    {
        private double timestamp = -1;
        private double confidence = -1;
        private PointF normGaze = new PointF(-1, -1);
        private PointF gazeOnScreen = new PointF(-1, -1);
        private DateTime localTimestamp;

        public GazeData(string fromMsg)
        {
            LocalTimestamp = DateTime.Now;
            string[] entries = fromMsg.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            bool ignoreEntry = true;
            foreach (string entry in entries)
            {
                if (ignoreEntry)
                {
                    ignoreEntry = false;
                    continue;
                }
                string[] keyAndValue = entry.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (keyAndValue.Length < 2)
                {
                    continue;
                }
                string[] values = keyAndValue[1].Split(new char[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                SetValues(keyAndValue[0], values);
            }
        }

        public double Timestamp
        {
            get
            {
                return this.timestamp;
            }
            set
            {
                this.timestamp = value;
            }
        }
        public double Confidence
        {
            get
            {
                return this.confidence;
            }
            set
            {
                this.confidence = value;
            }
        }
        public PointF NormGaze
        {
            get
            {
                return this.normGaze;
            }
            set
            {
                this.normGaze = value;
            }
        }
        public PointF GazeOnScreen
        {
            get
            {
                return this.gazeOnScreen;
            }
            set
            {
                this.gazeOnScreen = value;
            }
        }
        public DateTime LocalTimestamp
        {
            get
            {
                return this.localTimestamp;
            }
            set
            {
                this.localTimestamp = value;
            }
        }

        private bool CheckNone(string[] values)
        {
            foreach (string value in values)
            {
                if (value == null || value.Equals("None") || value.Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetValues(string key, string[] values)
        {
            if (CheckNone(values) || key == null)
            {
                return;
            }
            if (key.Equals("timestamp") && values.Length >= 1)
            {
                this.timestamp = Convert.ToDouble(values[0]);
            }
            else if (key.Equals("confidence") && values.Length >= 1)
            {
                this.confidence = Convert.ToDouble(values[0]);
            }
            else if (key.Equals("norm_pos") && values.Length >= 2)
            {
                this.normGaze = new PointF(Convert.ToSingle(values[0]), Convert.ToSingle(values[1]));
            }
            else if (key.Equals("realtime gaze on screen") && values.Length >= 2)
            {
                this.gazeOnScreen = new PointF(Convert.ToSingle(values[0]), Convert.ToSingle(values[1]));
            }
        }

        public override string ToString()
        {
            return String.Format("GazeData: timestamp: {0}, confidence: {1}, normGaze: ({2},{3}), gazeOnScreen: ({4},{5})", timestamp, confidence, normGaze.X, normGaze.Y, gazeOnScreen.X, gazeOnScreen.Y);
        }
    }
}
