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
        private PointF gaze = new PointF(-1, -1);

        public EyeTribeGazeTracker()
        {
            // Connect client
            GazeManager.Instance.Activate(GazeManager.ApiVersion.VERSION_1_0, GazeManager.ClientMode.Push);
            GazeManager.Instance.AddGazeListener(this);
        }

        public void Calibrate()
        {
            CalibrationRunner calRunner = new CalibrationRunner();
            calRunner.OnResult += onCalibrationResult;
            calRunner.Start();
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

        public void Stop()
        {
            GazeManager.Instance.Deactivate();
        }

        private void onCalibrationResult(object sender, CalibrationRunnerEventArgs e)
        {
            // May do something here in the future
        }
    }
}
