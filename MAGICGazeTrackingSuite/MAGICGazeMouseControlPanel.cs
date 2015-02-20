/*                         Camera Mouse Suite
 *  Copyright (C) 2014, Samual Epstein
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using CameraMouseSuite;

namespace MAGICGazeTrackingSuite
{
    public partial class MAGICGazeMouseControlPanel : UserControl, CMSConfigPanel
    {
        public MAGICGazeMouseControlPanel()
        {
            InitializeComponent();
        }

        private MAGICGazeMouseControlModule magicGazeMouseControlModule = null;
        public void SetMouseControl(MAGICGazeMouseControlModule magicMouseControl)
        {
            this.magicGazeMouseControlModule = magicMouseControl;
            LoadFromControls();
        }

        private bool loadingControls = false;

        private void eyeTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            if (this.magicGazeMouseControlModule.SelectedGazeTracker.Started)
            {
                this.magicGazeMouseControlModule.SelectedGazeTracker.Stop();
            }
            this.magicGazeMouseControlModule.SelectedGazeTrackerId = comboBox.SelectedIndex;
            this.magicGazeMouseControlModule.SelectedGazeTracker.Start();
            this.eyeStatusHost.Child = this.magicGazeMouseControlModule.SelectedGazeTracker.EyeStatus;
        }

        private void calibrateEyeTracker_Click(object sender, EventArgs e)
        {
            this.magicGazeMouseControlModule.SelectedGazeTracker.Calibrate();
        }

        private void Horiz_gain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.loadingControls)
            {
                double val = 1;
                string temp = this.Horiz_gain.SelectedItem.ToString();
                if (temp.Equals("Very Low"))
                    val = 3;
                else if (temp.Equals("Low"))
                    val = 4.5;
                else if (temp.Equals("Med"))
                    val = 6.0;
                else if (temp.Equals("Med High"))
                    val = 7.5;
                else if (temp.Equals("High"))
                    val = 9.0;
                else if (temp.Equals("Very High"))
                    val = 10.5;
                else if (temp.Equals("Extreme"))
                    val = 12.0;
                magicGazeMouseControlModule.UserHorizontalGain = val;
                sendLogAdvancedTracker();
            }
        }

        private void vert_gain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                double val = 1;
                string temp = this.vert_gain.SelectedItem.ToString();
                if (temp.Equals("Very Low"))
                    val = 3;
                else if (temp.Equals("Low"))
                    val = 4.5;
                else if (temp.Equals("Med"))
                    val = 6.0;
                else if (temp.Equals("Med High"))
                    val = 7.5;
                else if (temp.Equals("High"))
                    val = 9.0;
                else if (temp.Equals("Very High"))
                    val = 10.5;
                else if (temp.Equals("Extreme"))
                    val = 12.0;
                magicGazeMouseControlModule.UserVerticalGain = val;
                sendLogAdvancedTracker();
            }
        }

        private void smooth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                string val = smooth.SelectedItem.ToString();
                if (val.Equals("Off"))
                    magicGazeMouseControlModule.Damping = 1.0;
                else if (val.Equals("Very Low"))
                    magicGazeMouseControlModule.Damping = 0.95;
                else if (val.Equals("Low"))
                    magicGazeMouseControlModule.Damping = 0.80;
                else if (val.Equals("Med"))
                    magicGazeMouseControlModule.Damping = 0.65;
                else if (val.Equals("Med High"))
                    magicGazeMouseControlModule.Damping = 0.5;
                else if (val.Equals("High"))
                    magicGazeMouseControlModule.Damping = 0.3;
                else if (val.Equals("Very High"))
                    magicGazeMouseControlModule.Damping = 0.15;
                else if (val.Equals("Extreme"))
                    magicGazeMouseControlModule.Damping = 0.05;
                sendLogAdvancedTracker();
            }
        }

        private void exclude_N_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                string s = exclude_N.SelectedItem.ToString();
                s = s.Substring(0, s.Length - 1);
                if (s.Length == 1)
                    s = "0.0" + s;
                else
                    s = "0." + s;
                magicGazeMouseControlModule.NorthLimit = Double.Parse(s, CultureInfo.InvariantCulture);
                sendLogAdvancedTracker();
            }
        }

        private void exclude_W_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                string s = exclude_W.SelectedItem.ToString();
                s = s.Substring(0, s.Length - 1);
                if (s.Length == 1)
                    s = "0.0" + s;
                else
                    s = "0." + s;
                magicGazeMouseControlModule.WestLimit = Double.Parse(s, CultureInfo.InvariantCulture);
                sendLogAdvancedTracker();
            }
        }

        private void exclude_E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                string s = exclude_E.SelectedItem.ToString();
                s = s.Substring(0, s.Length - 1);
                if (s.Length == 1)
                    s = "0.0" + s;
                else
                    s = "0." + s;
                magicGazeMouseControlModule.EastLimit = Double.Parse(s, CultureInfo.InvariantCulture);
                sendLogAdvancedTracker();
            }
        }

        private void exclude_S_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                string s = exclude_S.SelectedItem.ToString();
                s = s.Substring(0, s.Length - 1);
                if (s.Length == 1)
                    s = "0.0" + s;
                else
                    s = "0." + s;
                magicGazeMouseControlModule.SouthLimit = Double.Parse(s, CultureInfo.InvariantCulture);
                sendLogAdvancedTracker();
            }
        }

        private void ReverseMouse_CheckedChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                magicGazeMouseControlModule.ReverseHorizontal = this.checkBoxReverseMouse.Checked;
                sendLogAdvancedTracker();
            }
        }

        private void moveMouseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if( !loadingControls )
            {
                bool check = moveMouseCheckBox.Checked;
                magicGazeMouseControlModule.MoveMouse = check;
                ChangeMouseControlItemsEnabled(check);
                sendLogAdvancedTracker();
            }
        }

        private void useGridCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!loadingControls)
            {
                bool check = useGridCheckBox.Checked;
                magicGazeMouseControlModule.UseGrid = check;
                sendLogAdvancedTracker();
            }
        }

        private void ChangeMouseControlItemsEnabled(bool enabled)
        {
            smooth.Enabled = enabled;
            vert_gain.Enabled = enabled;
            Horiz_gain.Enabled = enabled;
            exclude_E.Enabled = enabled;
            exclude_N.Enabled = enabled;
            exclude_S.Enabled = enabled;
            exclude_W.Enabled = enabled;
            checkBoxReverseMouse.Enabled = enabled;
        }

        #region CMSConfigPanel Members

        public void LoadFromControls()
        {
            loadingControls = true;

            eyeTracker.DataSource = magicGazeMouseControlModule.GazeTrackers;
            eyeTracker.DisplayMember = "Name";

            moveMouseCheckBox.Checked = magicGazeMouseControlModule.MoveMouse;
            useGridCheckBox.Checked = magicGazeMouseControlModule.UseGrid;
            ChangeMouseControlItemsEnabled(magicGazeMouseControlModule.MoveMouse);

            double val = Math.Round(100.0F * magicGazeMouseControlModule.EastLimit);
            string temp = ((int)(val)).ToString() + "%";
            this.exclude_E.SelectedItem = temp;

            val = Math.Round(100.0F * magicGazeMouseControlModule.WestLimit);
            temp = ((int)(val)).ToString() + "%";
            this.exclude_W.SelectedItem = temp;

            val = Math.Round(100.0F * magicGazeMouseControlModule.NorthLimit);
            temp = ((int)(val)).ToString() + "%";
            this.exclude_N.SelectedItem = temp;

            val = Math.Round(100.0F * magicGazeMouseControlModule.SouthLimit);
            temp = ((int)(val)).ToString() + "%";
            this.exclude_S.SelectedItem = temp;

            val = magicGazeMouseControlModule.UserHorizontalGain;
            if (val == 3.0)
                this.Horiz_gain.SelectedItem = "Very Low";
            else if (val == 4.5)
                this.Horiz_gain.SelectedItem = "Low";
            else if (val == 6.0)
                this.Horiz_gain.SelectedItem = "Med";
            else if (val == 7.5)
                this.Horiz_gain.SelectedItem = "Med High";
            else if (val == 9.0)
                this.Horiz_gain.SelectedItem = "High";
            else if (val == 10.5)
                this.Horiz_gain.SelectedItem = "Very High";
            else if (val == 12.0)
                this.Horiz_gain.SelectedItem = "Extreme";

            val = magicGazeMouseControlModule.UserVerticalGain;
            if (val == 3.0)
                this.vert_gain.SelectedItem = "Very Low";
            else if (val == 4.5)
                this.vert_gain.SelectedItem = "Low";
            else if (val == 6.0)
                this.vert_gain.SelectedItem = "Med";
            else if (val == 7.5)
                this.vert_gain.SelectedItem = "Med High";
            else if (val == 9.0)
                this.vert_gain.SelectedItem = "High";
            else if (val == 10.5)
                this.vert_gain.SelectedItem = "Very High";
            else if (val == 12.0)
                this.vert_gain.SelectedItem = "Extreme";

            val = magicGazeMouseControlModule.Damping;
            if (val == 1.0)
                this.smooth.SelectedItem = "Off";
            else if (val == 0.95)
                this.smooth.SelectedItem = "Very Low";
            else if (val == 0.8)
                this.smooth.SelectedItem = "Low";
            else if (val == 0.65)
                this.smooth.SelectedItem = "Med";
            else if (val == 0.5)
                this.smooth.SelectedItem = "Med High";
            else if (val == 0.3)
                this.smooth.SelectedItem = "High";
            else if (val == 0.15)
                this.smooth.SelectedItem = "Very High";
            else if (val == 0.05)
                this.smooth.SelectedItem = "Extreme";
            loadingControls = false;
        }

        SendLogAdvancedTracker sendLogAdvancedTracker = null;

        public void Init(SendLogAdvancedTracker sendLogAdvancedTracker)
        {
            this.sendLogAdvancedTracker = sendLogAdvancedTracker;
        }

        #endregion
    }
}
