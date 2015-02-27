namespace MAGICGazeTrackingSuite
{
    partial class EyeTribePanel : ICalibrationStatusListener
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.eyeStatusHost = new System.Windows.Forms.Integration.ElementHost();
            this.eyeStatusControl1 = new MAGICGazeTrackingSuite.EyeStatusControl();
            this.calibrationStatus = new System.Windows.Forms.Label();
            this.calibrateEyeTracker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eyeStatusHost
            // 
            this.eyeStatusHost.Location = new System.Drawing.Point(3, 3);
            this.eyeStatusHost.Name = "eyeStatusHost";
            this.eyeStatusHost.Size = new System.Drawing.Size(317, 263);
            this.eyeStatusHost.TabIndex = 12;
            this.eyeStatusHost.Text = "eyeStatusHost";
            this.eyeStatusHost.Child = this.eyeStatusControl1;
            // 
            // calibrationStatus
            // 
            this.calibrationStatus.AutoSize = true;
            this.calibrationStatus.Location = new System.Drawing.Point(84, 277);
            this.calibrationStatus.Name = "calibrationStatus";
            this.calibrationStatus.Size = new System.Drawing.Size(74, 13);
            this.calibrationStatus.TabIndex = 14;
            this.calibrationStatus.Text = "Not Calibrated";
            // 
            // calibrateEyeTracker
            // 
            this.calibrateEyeTracker.Location = new System.Drawing.Point(3, 272);
            this.calibrateEyeTracker.Name = "calibrateEyeTracker";
            this.calibrateEyeTracker.Size = new System.Drawing.Size(75, 23);
            this.calibrateEyeTracker.TabIndex = 13;
            this.calibrateEyeTracker.Text = "Calibrate";
            this.calibrateEyeTracker.UseVisualStyleBackColor = true;
            this.calibrateEyeTracker.Click += new System.EventHandler(this.calibrateEyeTracker_Click);
            // 
            // EyeTribePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.calibrationStatus);
            this.Controls.Add(this.calibrateEyeTracker);
            this.Controls.Add(this.eyeStatusHost);
            this.Name = "EyeTribePanel";
            this.Size = new System.Drawing.Size(325, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost eyeStatusHost;
        private System.Windows.Forms.Label calibrationStatus;
        private System.Windows.Forms.Button calibrateEyeTracker;
        private EyeStatusControl eyeStatusControl1;
    }
}
