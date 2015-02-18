using System;
using System.Drawing;

namespace MAGICGazeTrackingSuite
{
    interface IGazeTracker
    {
        bool Active { get; set; }
        PointF CurrentGaze();
        void Stop();
    }
}
