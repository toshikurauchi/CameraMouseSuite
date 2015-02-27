using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace MAGICGazeTrackingSuite
{
    public partial class PupilPanel : UserControl
    {
        public PupilPanel()
        {
            InitializeComponent();
        }

        public PupilGazeTracker EyeTracker { get; set; }

        private void startClient_Click(object sender, EventArgs e)
        {
            string ip = ip1.Text + "." + ip2.Text + "."  + ip3.Text + "." + ip4.Text;
            if (ip.Contains(" "))
            {
                ip = ip.Replace(" ", "");
            }
            IPAddress ipAddress;
            if (IPAddress.TryParse(ip, out ipAddress) && !port.Text.Equals(""))
            {
                EyeTracker.StartClient(ip, port.Text);
            }
            startClient.Enabled = false;
        }

        private void serverAddress_TextChanged(object sender, EventArgs e)
        {
            startClient.Enabled = true;
        }
    }
}
