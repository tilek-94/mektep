using NAudio.Wave;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using NAudio;
using System.Data.SQLite;
using System.IO.Ports;


namespace Мектеп
{
    public partial class Form1 : Form
    {

        private Button CurrentButton;
        private Form activForm;
        private Panel activPanel;
        
        //Signal Signal = new Signal();
        //PRUbakut PRUbakut = new PRUbakut();
        public Form1()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
       
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=C:\\ProgramData\\WindowsTK\\basa.db;Version=3;New=False;Compress=True");
        }

        private void LoadList()
        {
            int i = 0;
            SetConnection();
            sql_con.Open();
            string sql = "select * from raspisanie";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                Ubakyt2.kiruu[i] = reader[1].ToString();
                Ubakyt2.chyguu[i] = reader[2].ToString();
                // listBox1.Items.Add(reader[0].ToString());
                //dataGridView2.Rows.Add(reader[0].ToString(), i, reader[1].ToString(), reader[2].ToString());
            }
            sql_con.Close();
        }

        private const int cGrip = 16;
        private const int cCaption = 32;
        public void Otp(string s)
        {
            try
            {


                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = "COM26";
                    serialPort1.Open();

                }
                if (serialPort1.IsOpen)
                {
                    serialPort1.WriteLine(s);
                    
                }
                serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("Апарат туташкан эмес");
            }

        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private Color SelectThemColor()
        {
             //tempIndex = 1;
            string color = ThemColor.ColorList[1];
            return ColorTranslator.FromHtml(color);

        }

        private void ActivButton(object btnSender)
        {
            if (btnSender != null)
            {
               
                if (CurrentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemColor();
                    CurrentButton = (Button)btnSender;
                    CurrentButton.BackColor = color;
                    CurrentButton.ForeColor = Color.White;
                    CurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                }

            }

        }
        private void DisableButton()
        {
            foreach (Control previosBtn in MenuPanel.Controls)
            {
                if (previosBtn.GetType() == typeof(Button))
                {
                    previosBtn.BackColor = Color.FromArgb(255, 255,255);
                    previosBtn.ForeColor = Color.Black;
                    previosBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                }

            }

        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }

            if (activForm != null)
            {
                activForm.Close();

            }
            ActivButton(btnSender);
            activForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.osPanel.Controls.Add(childForm);
            this.osPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void OpenChildForm3(Form childForm)
        {
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }
            if (activForm != null)
            {
                activForm.Close();

            }
           // ActivButton(btnSender);
            activForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.osPanel.Controls.Add(childForm);
            this.osPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void EnabledButton()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }
        private void OpenChildForm2(Panel childForm)
        {
            //EnabledButton();

            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }

            if (activForm != null)
            {
                activForm.Close();

            }
            activPanel = childForm;
           // childForm.TopLevel = false;
            //childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.osPanel.Controls.Add(childForm);
            this.osPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

           


        }

        //--------->

        
        private void Timer2_Tick(object sender, EventArgs e)
        {

        }

        //------------->


           private void loadPer()
        {
            SetConnection();
            sql_con.Open();
            string sql = "select * from info WHERE name='vrem'";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Peremenyi.vremia = Convert.ToInt16(reader[2].ToString());
            }
            sql_con.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel4.Hide();
          OpenChildForm3(new Forms.CameraUPR());

            LoadList();
            loadPer();

            // button1.Enabled = false;
            //MenuPanel.BackColor = Color.FromArgb(51, 51, 76);
        }

        //public void Test()
        //{

        //    try
        //    {


        //        if (!serialPort1.IsOpen)
        //        {
        //            serialPort1.PortName = "COM26";
        //            serialPort1.Open();

        //        }
        //        if (serialPort1.IsOpen)
        //        {

        //    Form2.ValueForm2 += new Action<string>((x) =>//подписываемся на событие
        //    {
        //        serialPort1.WriteLine(x);
        //    });

        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Апарат туташкан эмес");
        //    }



        //}
        private void Button2_Click(object sender, EventArgs e)
        {
           
            OpenChildForm(new Form2(), sender);

            if (Signal2.stopPause == true)
            {
                Signal2.Stop();
            }
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.CameraUPR(), sender);
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }
            if (Signal2.stopPause == true)
            {
                Signal2.Stop();
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ubakyt(), sender);
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }
            if (Signal2.stopPause == true)
            {
                Signal2.Stop();
            }
        }

             int tim = 0, tim3 = 0, metka = 1, metka4 = 0;
         int timch = 0, tim3ch = 0, metkach = 1, metka4ch = 0;
        static string labVrem = "", labVrem2 = "";
        static string labVremCh = "", labVrem2Ch = "";
        private void Timer2_Tick_1(object sender, EventArgs e)
        {
             

            labVrem = label1.Text + label2.Text;
            labVremCh = label1.Text + label2.Text;

            if (Ubakyt2.kiruu.Contains(labVrem))
            {
               // tim3 = 0;
               // label3.Text = tim3.ToString();
                loadPer();

                if (labVrem2 == "")
                {
                    //MessageBox.Show("1111");
                    labVrem2 = labVrem;
                    tim3 = 0;
                    metka = 1;
                    metka4 = 1;

                }

                if (labVrem2 != labVrem)
                {
                    labVrem2 = "";


                }


            }

            //------------------
            if (metka4 == 1)
            {

                if (tim3 <= Peremenyi.vremia)
                {

                    tim3++;
                    //label3.Text = tim3.ToString();

                    if (metka == 1)
                    {
                        if (Signal2.stopPause == true)
                        {
                            Signal2.Stop();
                        }
                        Signal2.Sound2("vh");
                        //panel4.Show();
                        OpenChildForm2(panel4);
                        panel4.Show();
                        Otp(Camera.DisplayVKL());


                        metka = 0;
                       
                        tim = 0;
                    }

                    if (tim <= PRUbakut.VrSound(Signal2.NameSound("vh")))
                    {
                        tim++;

                    }
                    else
                    {
                        if (Signal2.stopPause == true)
                        {
                            Signal2.Stop();
                        }
                        Signal2.Sound2("vh");
                        tim = 0;
                        OpenChildForm2(panel4);
                        panel4.Show();
                        Otp(Camera.DisplayVKL());

                    }
                }
                else
                {
                    if (Signal2.stopPause == true)
                    {
                        Signal2.Stop();
                    }
                   
                    metka4 = 0;
                    OpenChildForm3(new Forms.ubakyt());
                    panel4.Hide();
                    Otp(Camera.Display());
                   // MessageBox.Show("123");
                }

            }
            // 
            //----------------------

            if (Ubakyt2.chyguu.Contains(labVremCh))
            {
                
                if (labVrem2Ch == "")
                {
                    labVrem2Ch = labVremCh;
                    tim3ch = 0;
                    metkach = 1;
                    metka4ch = 1;

                }
                if (labVrem2Ch != labVremCh)
                {
                    labVrem2Ch = "";


                }


            }

            //------------------
            if (metka4ch == 1)
            {
                if (tim3ch <= Peremenyi.vremia)
                {
                    tim3ch++;
                    if (metkach == 1)
                    {
                        if (Signal2.stopPause == true)
                        {
                            Signal2.Stop();
                        }
                        Signal2.Sound2("vh2");
                        OpenChildForm2(panel4);
                        panel4.Show();
                        metkach = 0;
                        timch = 0;
                    }

                    if (timch <= PRUbakut.VrSound(Signal2.NameSound("vh")))
                    {
                        timch++;

                    }
                    else
                    {
                        if (Signal2.stopPause == true)
                        {
                            Signal2.Stop();
                        }
                        Signal2.Sound2("vh2");
                        timch = 0;
                        OpenChildForm2(panel4);
                        panel4.Show();
                    }
                }
                else
                {
                    if (Signal2.stopPause == true)
                    {
                        Signal2.Stop();
                    }
                    metka4ch = 0;
                    OpenChildForm3(new Forms.ubakyt());
                    panel4.Hide();
                    Otp(Camera.Display());
                }


            }

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            
        }
        private void ButtonVisabled()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            panel4.Show();

        }
        private void Button8_Click_1(object sender, EventArgs e)
        {
            if (Signal2.stopPause == true)
            {
                Signal2.Stop();
                panel4.Hide();
                tim3 = 0;
                metka4 = 0;
                tim3ch = 0;
                metka4ch = 0;
                OpenChildForm3(new Forms.ubakyt());


            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":";
            label2.Text = DateTime.Now.Minute.ToString("00");
            label4.Text = ":" + DateTime.Now.Second.ToString("00");
            
            }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.ynTuuraloo(), sender);
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }
            if (Signal2.stopPause == true)
            {
                Signal2.Stop();
            }
        }
        Point lastPoint;
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
    
   
    class Music
    {
        public static string vbrat = "";
        public static string upd = "";
    }

}
