using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Мектеп.Forms
{
    public partial class CameraUPR : Form
    {
        public CameraUPR()
        {
            InitializeComponent();
        }
        Form1 form1 = new Form1();
        bool a1 = false, a2 = false;
        bool a3 = false, a4 = false;
        bool a5 = false, a6 = false;
        bool a7 = false, a8 = false;
        VtorMonitor vtorMonitor= new VtorMonitor();
        static private SQLiteConnection sql_con;
        static private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=C:\\ProgramData\\WindowsTK\\basa.db;Version=3;New=False;Compress=True");
        }
       
        private SQLiteCommand sql_cmd;
        private void ExcuteQuery(int i)
        {
            string textQuery;
            if (i == 1)
            {

                 textQuery= "UPDATE Split SET nomer='1' WHERE id='1'";
            }
            else
            {
                textQuery = "UPDATE Split SET nomer='0' WHERE id='1'";

            }

            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = textQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private int ReadQuery()
        {
            SetConnection();
            int i = 0;
            sql_con.Open();
            string sql2 = "select * from Split";
            SQLiteCommand command2 = new SQLiteCommand(sql2, sql_con);
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
               
                 i = Convert.ToInt16( reader2[1]);
                
            }

            sql_con.Close();
            return i;
        }
        
            private void VtorMon(string s)
        {


            string fileName = s;

            if (System.Windows.Forms.SystemInformation.MonitorCount == 1)
            {
                MessageBox.Show("Экинчи монитор жок!");

            }else
            { 
            if (label1.Text=="1")
            {
                vtorMonitor.Close();
                vtorMonitor = new VtorMonitor();
                vtorMonitor.Show();
                vtorMonitor.axVLCPlugin1.stop();
                vtorMonitor.axVLCPlugin1.playlistClear();
                 fileName = s;
                vtorMonitor.axVLCPlugin1.MRL = fileName;
                vtorMonitor.axVLCPlugin1.addTarget(fileName, "null", AXVLC.VLCPlaylistMode.VLCPlayListAppend, 0);
                vtorMonitor.axVLCPlugin1.play();
                vtorMonitor.pictureBox1.Show();
                vtorMonitor.timer1.Enabled = true;
                label1.Text = "0";
            }
            else { 
                
                vtorMonitor.Show();
                vtorMonitor.axVLCPlugin1.stop();
                vtorMonitor.axVLCPlugin1.playlistClear();
                
                vtorMonitor.axVLCPlugin1.MRL = fileName;
                vtorMonitor.axVLCPlugin1.addTarget(fileName, "null", AXVLC.VLCPlaylistMode.VLCPlayListAppend, 0);
                vtorMonitor.axVLCPlugin1.play();
                vtorMonitor.pictureBox1.Show();
                vtorMonitor.timer1.Enabled = true;
            label1.Text = "0";
            }
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {
                   
                   form1.Otp("2");
                   Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {
                    
                    VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c1/s0/live");

                }


                button1.FlatAppearance.BorderColor = Color.Red;
                button1.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("1", "1"));
                //MessageBox.Show(camera.getNum("1", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;


                
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;


                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;

                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;

                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {

                if (a1 == false)
                {
                    button1.FlatAppearance.BorderColor = Color.Red;
                    button1.FlatAppearance.BorderSize = 5;
                    a1 = true;
                    
                    form1.Otp(Camera.getNum("1", "1"));
                }
                else
                {
                    button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a1 = false;
                    button1.FlatAppearance.BorderSize = 3;

                    form1.Otp(Camera.getNum("1", "0"));
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {

                    form1.Otp("2");
                    Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {

                    VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c3/s0/live");

                }

                button3.FlatAppearance.BorderColor = Color.Red;
                button3.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("3", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {



                if (a3 == false)
                {
                    button3.FlatAppearance.BorderColor = Color.Red;
                    button3.FlatAppearance.BorderSize = 5;
                    a3 = true;
                   
                    form1.Otp(Camera.getNum("3", "1"));
                }
                else
                {
                    button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a3 = false;
                    button3.FlatAppearance.BorderSize = 3;
                    
                    form1.Otp(Camera.getNum("3", "0"));
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {

               
                    if (label1.Text == "1")
                    {

                        form1.Otp("2");
                        Thread.Sleep(3000);
                        timer1.Enabled = true;
                        //label1.Text = "1";

                    }
                    else
                    {

                        VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c6/s0/live");

                    }

                    button6.FlatAppearance.BorderColor = Color.Red;
                button6.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("6", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {


                if (a6 == false)
                {
                    button6.FlatAppearance.BorderColor = Color.Red;
                    button6.FlatAppearance.BorderSize = 5;
                    a6 = true;
                    
                    form1.Otp(Camera.getNum("6", "1"));
                }
                else
                {
                    button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a6 = false;
                    button6.FlatAppearance.BorderSize = 3;

                    form1.Otp(Camera.getNum("6", "0"));
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
              
                    if (label1.Text == "1")
                    {

                        form1.Otp("2");
                        Thread.Sleep(3000);
                        timer1.Enabled = true;
                        //label1.Text = "1";

                    }
                    else
                    {

                        VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c5/s0/live");

                    }
                    button5.FlatAppearance.BorderColor = Color.Red;
                button5.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("5", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {

                if (a5 == false)
                {
                    button5.FlatAppearance.BorderColor = Color.Red;
                    button5.FlatAppearance.BorderSize = 5;
                    a5 = true;
                    form1.Otp(Camera.getNum("5", "1"));
                }
                else
                {
                    button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a5 = false;
                    button5.FlatAppearance.BorderSize = 3;
                    form1.Otp(Camera.getNum("5", "0"));
                }
            }
        }

        private void CameraUPR_Load(object sender, EventArgs e)
        {
            string ad = Camera.Display();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            form1.Otp( Camera.DisplayVKL());
            button9.FlatAppearance.BorderColor = Color.Red;
            button9.FlatAppearance.BorderSize = 5;
            button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button7.FlatAppearance.BorderSize = 3;
            button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button10.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button1.FlatAppearance.BorderSize = 3;
            button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button3.FlatAppearance.BorderSize = 3;
            button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button4.FlatAppearance.BorderSize = 3;
            button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button5.FlatAppearance.BorderSize = 3;
            button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button6.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button2.FlatAppearance.BorderSize = 3;
            button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button8.FlatAppearance.BorderSize = 3;
            button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button13.FlatAppearance.BorderSize = 3;
            button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button11.FlatAppearance.BorderSize = 3;
            button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button12.FlatAppearance.BorderSize = 3;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            //if (ReadQuery() == 1)
            //{
            //    ExcuteQuery(0);

            //}
            label1.Text = "1";
            form1.Otp("2");
            vtorMonitor.Close();
            
            
            button10.FlatAppearance.BorderColor = Color.Red;
            button10.FlatAppearance.BorderSize = 5;
            button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button7.FlatAppearance.BorderSize = 3;
            button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button1.FlatAppearance.BorderSize = 3;
            button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button3.FlatAppearance.BorderSize = 3;
            button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button4.FlatAppearance.BorderSize = 3;
            button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button5.FlatAppearance.BorderSize = 3;
            button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button6.FlatAppearance.BorderSize = 3;
            button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button2.FlatAppearance.BorderSize = 3;
            button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button8.FlatAppearance.BorderSize = 3;
            button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button9.FlatAppearance.BorderSize = 3;
            button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button13.FlatAppearance.BorderSize = 3;
            button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button11.FlatAppearance.BorderSize = 3;
            button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
            button12.FlatAppearance.BorderSize = 3;
            Thread.Sleep(1000);
            form1.Otp(Camera.Display());

        }
        int y = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            y++;
            if (y == 2) { 
            VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c1/s0/live");
                y = 0;
                timer1.Enabled = false;
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {

                    form1.Otp("2");
                    Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {

                    VtorMon("rtsp://admin:qwer1234@192.168.1.108:554/cam/realmonitor?channel=9&subtype=0");

                }
                button11.FlatAppearance.BorderColor = Color.Red;
                button11.FlatAppearance.BorderSize = 5;
                string s = Camera.Display();
                form1.Otp(Camera.getNum("4", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;

                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {

                if (a4 == false)
                {
                    button4.FlatAppearance.BorderColor = Color.Red;
                    button4.FlatAppearance.BorderSize = 5;
                    a4 = true;
                    form1.Otp(Camera.getNum("4", "1"));
                }
                else
                {
                    button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a4 = false;
                    button4.FlatAppearance.BorderSize = 3;

                    form1.Otp(Camera.getNum("4", "0"));
                }
            }
        }

        private void Button12_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {

                    form1.Otp("2");
                    Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {

                    VtorMon("rtsp://admin:qwer1234@192.168.1.108:554/cam/realmonitor?channel=10&subtype=0");

                }
                button12.FlatAppearance.BorderColor = Color.Red;
                button12.FlatAppearance.BorderSize = 5;
                string s = Camera.Display();
                form1.Otp(Camera.getNum("4", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;
            }
            else
            {

                if (a4 == false)
                {
                    button4.FlatAppearance.BorderColor = Color.Red;
                    button4.FlatAppearance.BorderSize = 5;
                    a4 = true;
                    form1.Otp(Camera.getNum("4", "1"));
                }
                else
                {
                    button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a4 = false;
                    button4.FlatAppearance.BorderSize = 3;

                    form1.Otp(Camera.getNum("4", "0"));
                }
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {

                    form1.Otp("2");
                    Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {

                    VtorMon("rtsp://admin:qwer1234@192.168.1.108:554/cam/realmonitor?channel=11&subtype=0");

                }
                button13.FlatAppearance.BorderColor = Color.Red;
                button13.FlatAppearance.BorderSize = 5;
                string s = Camera.Display();
                form1.Otp(Camera.getNum("4", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {

                    form1.Otp("2");
                    Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {

                    VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c4/s0/live");

                }
                button4.FlatAppearance.BorderColor = Color.Red;
                button4.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("4", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {

                if (a4 == false)
                {
                    button4.FlatAppearance.BorderColor = Color.Red;
                    button4.FlatAppearance.BorderSize = 5;
                    a4 = true;
                     form1.Otp(Camera.getNum("4", "1"));
                }
                else
                {
                    button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a4 = false;
                    button4.FlatAppearance.BorderSize = 3;
                    
                    form1.Otp(Camera.getNum("4", "0"));
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
               
                    if (label1.Text == "1")
                    {

                        form1.Otp("2");
                        Thread.Sleep(3000);
                        timer1.Enabled = true;
                        //label1.Text = "1";

                    }
                    else
                    {

                        VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c7/s0/live");

                    }
                    button7.FlatAppearance.BorderColor = Color.Red;
                button7.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("7", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;

                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {
                if (a7 == false)
                {
                    button7.FlatAppearance.BorderColor = Color.Red;
                    button7.FlatAppearance.BorderSize = 5;
                    a7 = true;

                    form1.Otp(Camera.getNum("7", "1"));
                }
                else
                {
                    button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a7 = false;
                    button7.FlatAppearance.BorderSize = 3;
                    
                    form1.Otp(Camera.getNum("7", "0"));
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked == false)
            {
               
                    if (label1.Text == "1")
                    {

                        form1.Otp("2");
                        Thread.Sleep(3000);
                        timer1.Enabled = true;
                        //label1.Text = "1";

                    }
                    else
                    {

                        VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c8/s0/live");

                    }
                    button8.FlatAppearance.BorderColor = Color.Red;
                button8.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("8", "1"));
                button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button2.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;
            }
            else
            {
                if (a8 == false)
                {
                    button8.FlatAppearance.BorderColor = Color.Red;
                    button8.FlatAppearance.BorderSize = 5;
                    a8 = true;
                    form1.Otp(Camera.getNum("8", "1"));
                }
                else
                {
                    button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a8 = false;
                    button8.FlatAppearance.BorderSize = 3;
                    form1.Otp(Camera.getNum("8", "1"));
                }
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                if (label1.Text == "1")
                {

                    form1.Otp("2");
                    Thread.Sleep(3000);
                    timer1.Enabled = true;
                    //label1.Text = "1";

                }
                else
                {

                    VtorMon("rtsp://admin:1234qwer@192.168.1.108/unicast/c2/s0/live");

                }
                button2.FlatAppearance.BorderColor = Color.Red;
                button2.FlatAppearance.BorderSize = 5;
                string s=Camera.Display();
                form1.Otp(Camera.getNum("2", "1"));
                button1.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button1.FlatAppearance.BorderSize = 3;
                button3.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button3.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button4.FlatAppearance.BorderSize = 3;
                button5.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button5.FlatAppearance.BorderSize = 3;
                button6.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button6.FlatAppearance.BorderSize = 3;
                button7.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button7.FlatAppearance.BorderSize = 3;
                button8.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button8.FlatAppearance.BorderSize = 3;
                button12.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button12.FlatAppearance.BorderSize = 3;
                button11.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button11.FlatAppearance.BorderSize = 3;
                button10.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button10.FlatAppearance.BorderSize = 3;
                button9.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button9.FlatAppearance.BorderSize = 3;
                button13.FlatAppearance.BorderColor = Color.DarkTurquoise;
                button13.FlatAppearance.BorderSize = 3;

            }
            else
            {
                if (a2 == false)
                {
                    button2.FlatAppearance.BorderColor = Color.Red;
                    button2.FlatAppearance.BorderSize = 5;
                    a2 = true;
                    form1.Otp(Camera.getNum("2", "1"));
                }
                else
                {
                    button2.FlatAppearance.BorderColor = Color.DarkTurquoise;
                    a2 = false;
                    button2.FlatAppearance.BorderSize = 3;
                    form1.Otp(Camera.getNum("2", "0"));
                }
            }
        }
    }
}
