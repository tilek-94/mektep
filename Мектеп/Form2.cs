using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public partial class Form2 : Form
    {
        //public static event Action<string> ValueForm2;
        public Form2()
        {
            InitializeComponent();
        }
       Form1 form1 = new Form1();
        //public void form1.Otp(string s)
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

        //            serialPort1.WriteLine(s);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Апарат туташкан эмес");
        //    }

        //}
        //Signal Signal = new Signal();
        bool g = false, g2 = false, g3 = false;
        private void StyleButton()
        {
            button3.FlatAppearance.BorderColor = Color.Black;
            button3.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderColor = Color.Black;
            button4.FlatAppearance.BorderSize = 1;
            button6.FlatAppearance.BorderColor = Color.Black;
            button6.FlatAppearance.BorderSize = 1;
            button7.FlatAppearance.BorderColor = Color.Black;
            button7.FlatAppearance.BorderSize = 1;
            button8.FlatAppearance.BorderColor = Color.Black;
            button8.FlatAppearance.BorderSize = 1;
            button9.FlatAppearance.BorderColor = Color.Black;
            button9.FlatAppearance.BorderSize = 1;
            button10.FlatAppearance.BorderColor = Color.Black;
            button10.FlatAppearance.BorderSize = 1;
            button11.FlatAppearance.BorderColor = Color.Black;
            button11.FlatAppearance.BorderSize = 1;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (g2 == false)
            {
                Signal.Stop();
                StyleButton();
                g2 = true;
                button6.FlatAppearance.BorderColor = Color.Red;
                button6.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                Signal.Sound2("vh2");
               form1.Otp(Camera.DisplayVKL());
                
                //if (ValueForm2 != null)  ValueForm2(Camera.DisplayVKL());
                
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button6.FlatAppearance.BorderColor = Color.Black;
                button6.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (g2 == false)
            {
                if (Signal.stopPause == true)
                {
                    Signal.Stop();
                }
                StyleButton();
                Signal.Sound2("gimn");
                g2 = true;
                button3.FlatAppearance.BorderColor = Color.Red;
                button3.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button3.FlatAppearance.BorderColor = Color.Black;
                button3.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            if (g == false)
            {
                if (Signal.stopPause == true)
                {
                    Signal.Stop();
                }
                StyleButton();
                Signal.Sound2("til");
                g = true;
                button7.FlatAppearance.BorderColor = Color.Red;
                button7.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g = false;
                button7.FlatAppearance.BorderColor = Color.Black;
                button7.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        
    }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (g2 == false)
            {
                if (Signal.stopPause == true)
                {
                    Signal.Stop();
                }
                StyleButton();
                Signal.Sound2("poj");
                g2 = true;
                button8.FlatAppearance.BorderColor = Color.Red;
                button8.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button8.FlatAppearance.BorderColor = Color.Black;
                button8.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            if (g2 == false)
            {
                if (Signal.stopPause == true)
                {
                    Signal.Stop();
                }
                StyleButton();
                Signal.Sound2("av");
                g2 = true;
                button11.FlatAppearance.BorderColor = Color.Red;
                button11.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button11.FlatAppearance.BorderColor = Color.Black;
                button11.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {

            if (g2 == false)
            {
                if (Signal.stopPause == true)
                {
                    Signal.Stop();
                }
                StyleButton();
                Signal.Sound2("zem");
                g2 = true;
                button9.FlatAppearance.BorderColor = Color.Red;
                button9.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button9.FlatAppearance.BorderColor = Color.Black;
                button9.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        }

        private void Button10_Click(object sender, EventArgs e)
        {

            if (g2 == false)
            {
                if (Signal.stopPause == true)
                {
                    Signal.Stop();
                }
                StyleButton();
                Signal.Sound2("ob");
                g2 = true;
                button10.FlatAppearance.BorderColor = Color.Red;
                button10.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button10.FlatAppearance.BorderColor = Color.Black;
                button10.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }
        }

        private static void Display(string s)
        {
            MessageBox.Show(s);

        }
        private void Button4_Click(object sender, EventArgs e)
        {

            if (g3 == false)
            {

                Signal.Stop();

                StyleButton();
                Signal.Sound2("vh");
                g3 = true;
                button4.FlatAppearance.BorderColor = Color.Red;
                button4.FlatAppearance.BorderSize = 5;
                Signal.stopPause = true;
                form1.Otp(Camera.DisplayVKL());

                // if (ValueForm2 != null) ValueForm2(Camera.DisplayVKL());
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g3 = false;
                button4.FlatAppearance.BorderColor = Color.Black;
                button4.FlatAppearance.BorderSize = 1;
                form1.Otp(Camera.Display());
            }

        }
    }
}
