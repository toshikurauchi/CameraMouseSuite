using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using TETControls.Calibration;
using TETCSharpClient;

namespace MAGICGazeTrackingSuite
{
    public class EyeTribeGazeTracker : IGazeTracker, IGazeListener
    {
        private bool active = true;
        private bool started = false;
        private PointF gaze = PointF.Empty;
        private List<TETCSharpClient.Data.GazeData> previousData;
        private long timeWindowDur = 500;

        public EyeTribeGazeTracker()
        {
        }

        public string Name
        {
            get { return "TheEyeTribe"; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public PointF CurrentGaze()
        {
            return gaze;
        }

        public void OnGazeUpdate(TETCSharpClient.Data.GazeData gazeData)
        {
            previousData.RemoveAll(data => gazeData.TimeStamp - data.TimeStamp > timeWindowDur);
            previousData.Add(gazeData);
            double x = previousData.Median(data => data.RawCoordinates.X);
            double y = previousData.Median(data => data.RawCoordinates.Y);
            gaze = new PointF((float) x, (float) y);
        }

        public void Start()
        {
            GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);
            previousData = new List<TETCSharpClient.Data.GazeData>();
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
            GazeManager.Instance.Deactivate();
        }

        public void Calibrate()
        {
            CalibrationRunner calRunner = new CalibrationRunner();
            calRunner.OnResult += onCalibrationResult;
            calRunner.Start();
        }

        private void onCalibrationResult(object sender, CalibrationRunnerEventArgs e)
        {
            if (e.Result == CalibrationRunnerResult.Success && !GazeManager.Instance.HasGazeListener(this))
            {
                GazeManager.Instance.AddGazeListener(this);
            }
        }

        public UserControl EyeStatus
        {
            get { return new EyeStatusControl(); }
        }
    }
}
