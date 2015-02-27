using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TETControls.Calibration;
using TETCSharpClient;
using TETCSharpClient.Data;

namespace MAGICGazeTrackingSuite
{
    public class EyeTribeGazeTracker : IGazeTracker, IGazeListener
    {
        private bool active = true;
        private bool started = false;
        private PointF gaze = PointF.Empty;
        private List<TETCSharpClient.Data.GazeData> previousData;
        private long timeWindowDur = 500;
        private HashSet<ICalibrationStatusListener> calibStatusListeners = new HashSet<ICalibrationStatusListener>();
        private CalibrationStatus calibStatus = CalibrationStatus.NotCalibrated;
        private EyeTribePanel panel;

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
            if ((gazeData.State & TETCSharpClient.Data.GazeData.STATE_TRACKING_GAZE) != 0)
            {
                previousData.Add(gazeData);
            }
            if (previousData.Count == 0)
            {
                gaze = PointF.Empty;
            }
            else
            {
                double x = previousData.Median(data => data.RawCoordinates.X);
                double y = previousData.Median(data => data.RawCoordinates.Y);
                gaze = new PointF((float) x, (float) y);
            }
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

        public void AddCalibrationStatusListener(ICalibrationStatusListener listener)
        {
            calibStatusListeners.Add(listener);
            listener.CalibrationStatusChanged(calibStatus);
        }

        public void RemoveCalibrationStatusListener(ICalibrationStatusListener listener)
        {
            calibStatusListeners.Remove(listener);
        }

        private void onCalibrationResult(object sender, CalibrationRunnerEventArgs e)
        {
            if (e.Result == CalibrationRunnerResult.Success)
            {
                int goodPoints = 0;
                foreach (CalibrationPoint calibPoint in e.CalibrationResult.Calibpoints)
                {
                    goodPoints += calibPoint.Accuracy.Average < 1.0 ? 1 : 0;
                }
                calibStatus = (int) Math.Round((CalibrationStatus.N_Status - 1.0) * goodPoints / e.CalibrationResult.Calibpoints.Length);
                foreach (ICalibrationStatusListener l in calibStatusListeners)
                {
                    l.CalibrationStatusChanged(calibStatus);
                }
                if (!GazeManager.Instance.HasGazeListener(this))
                {
                    GazeManager.Instance.AddGazeListener(this);
                }
            }
        }


        public UserControl EyeTrackerTab
        {
            get 
            {
                if (panel == null)
                {
                    panel = new EyeTribePanel();
                    panel.EyeTracker = this;
                    AddCalibrationStatusListener(panel);
                }
                return panel; 
            }
        }
    }
}
