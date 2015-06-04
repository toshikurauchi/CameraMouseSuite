using System.Windows.Forms.Integration;
namespace MAGICGazeTrackingSuite
{
    partial class MAGICGazeMouseControlPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAGICGazeMouseControlPanel));
            this.label4 = new System.Windows.Forms.Label();
            this.vert_gain = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Horiz_gain = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.smooth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.startEyeTracker = new System.Windows.Forms.Button();
            this.eyeTrackerPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.eyeTracker = new System.Windows.Forms.ComboBox();
            this.warpPointerCheckBox = new System.Windows.Forms.CheckBox();
            this.moveMouseCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBoxReverseMouse = new System.Windows.Forms.CheckBox();
            this.exclude_S = new System.Windows.Forms.ComboBox();
            this.exclude_E = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.exclude_N = new System.Windows.Forms.ComboBox();
            this.exclude_W = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mAGICGazeMouseControlPanelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAGICGazeMouseControlPanelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(43, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Vertical Gain";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vert_gain
            // 
            this.vert_gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.vert_gain.FormattingEnabled = true;
            this.vert_gain.Items.AddRange(new object[] {
            "Very Low",
            "Low",
            "Med",
            "Med High",
            "High",
            "Very High",
            "Extreme"});
            this.vert_gain.Location = new System.Drawing.Point(46, 132);
            this.vert_gain.Name = "vert_gain";
            this.vert_gain.Size = new System.Drawing.Size(72, 21);
            this.vert_gain.TabIndex = 4;
            this.vert_gain.SelectedIndexChanged += new System.EventHandler(this.vert_gain_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(43, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Horizontal Gain";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Horiz_gain
            // 
            this.Horiz_gain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Horiz_gain.FormattingEnabled = true;
            this.Horiz_gain.Items.AddRange(new object[] {
            "Very Low",
            "Low",
            "Med",
            "Med High",
            "High",
            "Very High",
            "Extreme"});
            this.Horiz_gain.Location = new System.Drawing.Point(46, 90);
            this.Horiz_gain.Name = "Horiz_gain";
            this.Horiz_gain.Size = new System.Drawing.Size(72, 21);
            this.Horiz_gain.TabIndex = 2;
            this.Horiz_gain.SelectedIndexChanged += new System.EventHandler(this.Horiz_gain_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.ImageKey = "0.bmp";
            this.label2.ImageList = this.imageList1;
            this.label2.Location = new System.Drawing.Point(6, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 23);
            this.label2.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "0.bmp");
            this.imageList1.Images.SetKeyName(1, "1.bmp");
            this.imageList1.Images.SetKeyName(2, "2.bmp");
            this.imageList1.Images.SetKeyName(3, "3.bmp");
            this.imageList1.Images.SetKeyName(4, "4.bmp");
            this.imageList1.Images.SetKeyName(5, "5.bmp");
            this.imageList1.Images.SetKeyName(6, "6.bmp");
            // 
            // label1
            // 
            this.label1.ImageIndex = 1;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(6, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 23);
            this.label1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(185, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Smoothing";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // smooth
            // 
            this.smooth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.smooth.FormattingEnabled = true;
            this.smooth.Items.AddRange(new object[] {
            "Off",
            "Very Low",
            "Low",
            "Med",
            "Med High",
            "High",
            "Very High",
            "Extreme"});
            this.smooth.Location = new System.Drawing.Point(188, 90);
            this.smooth.Name = "smooth";
            this.smooth.Size = new System.Drawing.Size(80, 21);
            this.smooth.TabIndex = 1;
            this.smooth.SelectedIndexChanged += new System.EventHandler(this.smooth_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.ImageIndex = 4;
            this.label6.ImageList = this.imageList1;
            this.label6.Location = new System.Drawing.Point(145, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 31);
            this.label6.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.startEyeTracker);
            this.groupBox7.Controls.Add(this.eyeTrackerPanel);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.eyeTracker);
            this.groupBox7.Controls.Add(this.warpPointerCheckBox);
            this.groupBox7.Controls.Add(this.moveMouseCheckBox);
            this.groupBox7.Controls.Add(this.smooth);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.checkBoxReverseMouse);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.exclude_S);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.exclude_E);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.vert_gain);
            this.groupBox7.Controls.Add(this.exclude_N);
            this.groupBox7.Controls.Add(this.exclude_W);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.Horiz_gain);
            this.groupBox7.Location = new System.Drawing.Point(7, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(650, 319);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            // 
            // startEyeTracker
            // 
            this.startEyeTracker.Location = new System.Drawing.Point(204, 13);
            this.startEyeTracker.Name = "startEyeTracker";
            this.startEyeTracker.Size = new System.Drawing.Size(75, 23);
            this.startEyeTracker.TabIndex = 11;
            this.startEyeTracker.Text = "Start";
            this.startEyeTracker.UseVisualStyleBackColor = true;
            this.startEyeTracker.Click += new System.EventHandler(this.startEyeTracker_Click);
            // 
            // eyeTrackerPanel
            // 
            this.eyeTrackerPanel.Location = new System.Drawing.Point(319, 13);
            this.eyeTrackerPanel.Name = "eyeTrackerPanel";
            this.eyeTrackerPanel.Size = new System.Drawing.Size(325, 300);
            this.eyeTrackerPanel.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Eye Tracker";
            // 
            // eyeTracker
            // 
            this.eyeTracker.FormattingEnabled = true;
            this.eyeTracker.Location = new System.Drawing.Point(77, 13);
            this.eyeTracker.Name = "eyeTracker";
            this.eyeTracker.Size = new System.Drawing.Size(121, 21);
            this.eyeTracker.TabIndex = 8;
            this.eyeTracker.SelectedIndexChanged += new System.EventHandler(this.eyeTracker_SelectedIndexChanged);
            // 
            // warpPointerCheckBox
            // 
            this.warpPointerCheckBox.AutoSize = true;
            this.warpPointerCheckBox.Location = new System.Drawing.Point(9, 63);
            this.warpPointerCheckBox.Name = "warpPointerCheckBox";
            this.warpPointerCheckBox.Size = new System.Drawing.Size(87, 17);
            this.warpPointerCheckBox.TabIndex = 7;
            this.warpPointerCheckBox.Text = "Warp pointer";
            this.warpPointerCheckBox.UseVisualStyleBackColor = true;
            this.warpPointerCheckBox.CheckedChanged += new System.EventHandler(this.useGridCheckBox_CheckedChanged);
            // 
            // moveMouseCheckBox
            // 
            this.moveMouseCheckBox.AutoSize = true;
            this.moveMouseCheckBox.Location = new System.Drawing.Point(9, 40);
            this.moveMouseCheckBox.Name = "moveMouseCheckBox";
            this.moveMouseCheckBox.Size = new System.Drawing.Size(128, 17);
            this.moveMouseCheckBox.TabIndex = 6;
            this.moveMouseCheckBox.Text = "Enable Cursor Control";
            this.moveMouseCheckBox.UseVisualStyleBackColor = true;
            this.moveMouseCheckBox.CheckedChanged += new System.EventHandler(this.moveMouseCheckBox_CheckedChanged);
            // 
            // checkBoxReverseMouse
            // 
            this.checkBoxReverseMouse.Location = new System.Drawing.Point(188, 125);
            this.checkBoxReverseMouse.Name = "checkBoxReverseMouse";
            this.checkBoxReverseMouse.Size = new System.Drawing.Size(120, 34);
            this.checkBoxReverseMouse.TabIndex = 1;
            this.checkBoxReverseMouse.Text = "Reverse Horizontal Movement";
            this.checkBoxReverseMouse.UseVisualStyleBackColor = true;
            this.checkBoxReverseMouse.CheckedChanged += new System.EventHandler(this.ReverseMouse_CheckedChanged);
            // 
            // exclude_S
            // 
            this.exclude_S.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exclude_S.FormattingEnabled = true;
            this.exclude_S.Items.AddRange(new object[] {
            "0%",
            "1%",
            "2%",
            "3%",
            "4%",
            "5%",
            "6%",
            "7%",
            "8%",
            "9%",
            "10%",
            "11%",
            "12%",
            "13%",
            "14%",
            "15%",
            "16%",
            "17%",
            "18%",
            "19%",
            "20%",
            "21%",
            "22%",
            "23%",
            "24%",
            "25%",
            "26%",
            "27%",
            "28%",
            "29%",
            "30%",
            "31%",
            "32%",
            "33%",
            "34%",
            "35%",
            "36%",
            "37%",
            "38%",
            "39%",
            "40%"});
            this.exclude_S.Location = new System.Drawing.Point(151, 235);
            this.exclude_S.Name = "exclude_S";
            this.exclude_S.Size = new System.Drawing.Size(56, 21);
            this.exclude_S.TabIndex = 4;
            this.exclude_S.SelectedIndexChanged += new System.EventHandler(this.exclude_S_SelectedIndexChanged);
            // 
            // exclude_E
            // 
            this.exclude_E.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exclude_E.FormattingEnabled = true;
            this.exclude_E.Items.AddRange(new object[] {
            "0%",
            "1%",
            "2%",
            "3%",
            "4%",
            "5%",
            "6%",
            "7%",
            "8%",
            "9%",
            "10%",
            "11%",
            "12%",
            "13%",
            "14%",
            "15%",
            "16%",
            "17%",
            "18%",
            "19%",
            "20%",
            "21%",
            "22%",
            "23%",
            "24%",
            "25%",
            "26%",
            "27%",
            "28%",
            "29%",
            "30%",
            "31%",
            "32%",
            "33%",
            "34%",
            "35%",
            "36%",
            "37%",
            "38%",
            "39%",
            "40%"});
            this.exclude_E.Location = new System.Drawing.Point(215, 219);
            this.exclude_E.Name = "exclude_E";
            this.exclude_E.Size = new System.Drawing.Size(56, 21);
            this.exclude_E.TabIndex = 3;
            this.exclude_E.SelectedIndexChanged += new System.EventHandler(this.exclude_E_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.ImageIndex = 5;
            this.label8.ImageList = this.imageList1;
            this.label8.Location = new System.Drawing.Point(144, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 23);
            this.label8.TabIndex = 0;
            // 
            // exclude_N
            // 
            this.exclude_N.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exclude_N.FormattingEnabled = true;
            this.exclude_N.Items.AddRange(new object[] {
            "0%",
            "1%",
            "2%",
            "3%",
            "4%",
            "5%",
            "6%",
            "7%",
            "8%",
            "9%",
            "10%",
            "11%",
            "12%",
            "13%",
            "14%",
            "15%",
            "16%",
            "17%",
            "18%",
            "19%",
            "20%",
            "21%",
            "22%",
            "23%",
            "24%",
            "25%",
            "26%",
            "27%",
            "28%",
            "29%",
            "30%",
            "31%",
            "32%",
            "33%",
            "34%",
            "35%",
            "36%",
            "37%",
            "38%",
            "39%",
            "40%"});
            this.exclude_N.Location = new System.Drawing.Point(151, 203);
            this.exclude_N.Name = "exclude_N";
            this.exclude_N.Size = new System.Drawing.Size(56, 21);
            this.exclude_N.TabIndex = 2;
            this.exclude_N.SelectedIndexChanged += new System.EventHandler(this.exclude_N_SelectedIndexChanged);
            // 
            // exclude_W
            // 
            this.exclude_W.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exclude_W.FormattingEnabled = true;
            this.exclude_W.Items.AddRange(new object[] {
            "0%",
            "1%",
            "2%",
            "3%",
            "4%",
            "5%",
            "6%",
            "7%",
            "8%",
            "9%",
            "10%",
            "11%",
            "12%",
            "13%",
            "14%",
            "15%",
            "16%",
            "17%",
            "18%",
            "19%",
            "20%",
            "21%",
            "22%",
            "23%",
            "24%",
            "25%",
            "26%",
            "27%",
            "28%",
            "29%",
            "30%",
            "31%",
            "32%",
            "33%",
            "34%",
            "35%",
            "36%",
            "37%",
            "38%",
            "39%",
            "40%"});
            this.exclude_W.Location = new System.Drawing.Point(87, 219);
            this.exclude_W.Name = "exclude_W";
            this.exclude_W.Size = new System.Drawing.Size(56, 21);
            this.exclude_W.TabIndex = 1;
            this.exclude_W.SelectedIndexChanged += new System.EventHandler(this.exclude_W_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(12, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 48);
            this.label5.TabIndex = 0;
            // 
            // mAGICGazeMouseControlPanelBindingSource
            // 
            this.mAGICGazeMouseControlPanelBindingSource.DataSource = typeof(MAGICGazeTrackingSuite.MAGICGazeMouseControlPanel);
            // 
            // MAGICGazeMouseControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox7);
            this.Name = "MAGICGazeMouseControlPanel";
            this.Size = new System.Drawing.Size(665, 329);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mAGICGazeMouseControlPanelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox vert_gain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Horiz_gain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox smooth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox exclude_S;
        private System.Windows.Forms.ComboBox exclude_E;
        private System.Windows.Forms.ComboBox exclude_N;
        private System.Windows.Forms.ComboBox exclude_W;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxReverseMouse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox moveMouseCheckBox;
        private System.Windows.Forms.CheckBox warpPointerCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox eyeTracker;
        private System.Windows.Forms.BindingSource mAGICGazeMouseControlPanelBindingSource;

        private System.Windows.Forms.Panel eyeTrackerPanel;
        private System.Windows.Forms.Button startEyeTracker;
    }
}
