namespace MAGICGazeTrackingSuite
{
    partial class PupilPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.startClient = new System.Windows.Forms.Button();
            this.ip1 = new System.Windows.Forms.TextBox();
            this.ip2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ip3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ip4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            // 
            // startClient
            // 
            this.startClient.Location = new System.Drawing.Point(8, 35);
            this.startClient.Name = "startClient";
            this.startClient.Size = new System.Drawing.Size(75, 23);
            this.startClient.TabIndex = 2;
            this.startClient.Text = "Start Pupil";
            this.startClient.UseVisualStyleBackColor = true;
            this.startClient.Click += new System.EventHandler(this.startClient_Click);
            // 
            // ip1
            // 
            this.ip1.Location = new System.Drawing.Point(63, 7);
            this.ip1.Name = "ip1";
            this.ip1.Size = new System.Drawing.Size(35, 20);
            this.ip1.TabIndex = 3;
            this.ip1.TextChanged += new System.EventHandler(this.serverAddress_TextChanged);
            // 
            // ip2
            // 
            this.ip2.Location = new System.Drawing.Point(104, 7);
            this.ip2.Name = "ip2";
            this.ip2.Size = new System.Drawing.Size(35, 20);
            this.ip2.TabIndex = 4;
            this.ip2.TextChanged += new System.EventHandler(this.serverAddress_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = ".";
            // 
            // ip3
            // 
            this.ip3.Location = new System.Drawing.Point(145, 7);
            this.ip3.Name = "ip3";
            this.ip3.Size = new System.Drawing.Size(35, 20);
            this.ip3.TabIndex = 6;
            this.ip3.TextChanged += new System.EventHandler(this.serverAddress_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = ".";
            // 
            // ip4
            // 
            this.ip4.Location = new System.Drawing.Point(186, 7);
            this.ip4.Name = "ip4";
            this.ip4.Size = new System.Drawing.Size(35, 20);
            this.ip4.TabIndex = 8;
            this.ip4.TextChanged += new System.EventHandler(this.serverAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = ":";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(227, 7);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(35, 20);
            this.port.TabIndex = 10;
            this.port.TextChanged += new System.EventHandler(this.serverAddress_TextChanged);
            // 
            // PupilPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ip4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ip3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ip2);
            this.Controls.Add(this.ip1);
            this.Controls.Add(this.startClient);
            this.Controls.Add(this.label1);
            this.Name = "PupilPanel";
            this.Size = new System.Drawing.Size(325, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startClient;
        private System.Windows.Forms.TextBox ip1;
        private System.Windows.Forms.TextBox ip2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ip3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ip4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox port;
    }
}
