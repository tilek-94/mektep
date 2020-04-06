using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мектеп
{
    public partial class VtorMonitor : Form
    {
        public VtorMonitor()
        {
            InitializeComponent();
        }

        private void VtorMonitor_Load(object sender, EventArgs e)
        {
            if (System.Windows.Forms.SystemInformation.MonitorCount == 1) { 
            MessageBox.Show("Экинчи монитор жок!");
                this.Hide();
            }
            else { 
           
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;


            Screen primaryFormScreen = Screen.FromControl(this);
            Screen secondaryFormScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(primaryFormScreen)) ?? primaryFormScreen;

            this.Left = secondaryFormScreen.Bounds.Width;
            this.Top = secondaryFormScreen.Bounds.Height;

            this.StartPosition = FormStartPosition.Manual;
            this.Location = secondaryFormScreen.Bounds.Location;
            Point p = new Point(secondaryFormScreen.Bounds.Location.X, secondaryFormScreen.Bounds.Location.Y);
            this.Location = p;
            this.WindowState = FormWindowState.Maximized;
            }
        }

        private void AxVLCPlugin1_Enter(object sender, EventArgs e)
        {

        }
        int s = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            s++;
            if (s > 1)
            {
                pictureBox1.Hide();
                timer1.Enabled = false;
                s = 0;
            }

        }
    }
}
