using System;
using System.Drawing;
using System.Windows.Forms;

namespace MAGICGazeTrackingSuite
{
    public interface IGazeTracker
    {
        bool Active { get; set; }
        string Name { get; }
        PointF CurrentGaze();
        void Start();
        bool Started { get; }
        UserControl EyeTrackerTab { get; }
        void Stop();
    }
}
