using System;
using System.Drawing;
using System.Windows.Controls;

namespace MAGICGazeTrackingSuite
{
    public interface IGazeTracker
    {
        bool Active { get; set; }
        string Name { get; }
        PointF CurrentGaze();
        void Start();
        bool Started { get; }
        UserControl EyeStatus { get; }
        void Calibrate();
        void AddCalibrationStatusListener(ICalibrationStatusListener listener);
        void RemoveCalibrationStatusListener(ICalibrationStatusListener listener);
        void Stop();
    }
}
