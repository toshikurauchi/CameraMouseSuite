using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAGICGazeTrackingSuite
{
    public partial class EyeTribePanel : UserControl, ICalibrationStatusListener
    {
        public EyeTribeGazeTracker EyeTracker { get; set; }

        public EyeTribePanel()
        {
            InitializeComponent();
        }

        public void CalibrationStatusChanged(CalibrationStatus newStatus)
        {
            calibrationStatus.Text = newStatus;
        }

        private void calibrateEyeTracker_Click(object sender, EventArgs e)
        {
            EyeTracker.Calibrate();
        }

    }
}
