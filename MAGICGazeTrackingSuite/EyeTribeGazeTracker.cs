using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TETControls.Calibration;
using TETCSharpClient;

namespace MAGICGazeTrackingSuite
{
    public class EyeTribeGazeTracker : IGazeTracker, IGazeListener
    {
        private bool active = true;
        private bool started = false;
        private PointF gaze = new PointF(-1, -1);

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
            if (gazeData.hasRawGazeCoordinates())
            {
                gaze = new PointF((float) gazeData.SmoothedCoordinates.X, (float) gazeData.SmoothedCoordinates.Y);
            }
            else
            {
                gaze = new PointF((float) gazeData.RawCoordinates.X, (float) gazeData.RawCoordinates.Y);
            }
        }

        public void Start()
        {
            GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);
            if (!GazeManager.Instance.IsCalibrated)
            {
                Calibrate();
            }
            Active = true;
            started = true;
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
    }
}
