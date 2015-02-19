using System;
using System.Drawing;

namespace MAGICGazeTrackingSuite
{
    public interface IGazeTracker
    {
        bool Active { get; set; }
        string Name { get; }
        PointF CurrentGaze();
        void Start();
        void Calibrate();
        void Stop();
    }
}
