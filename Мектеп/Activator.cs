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
    public partial class Activator : Form
    {
        public Activator()
        {
            InitializeComponent();
        }
        private string Encryption(string v1, int v2)
        {
            string temp = String.Empty;
            foreach (char c in v1)
            {
                temp = temp + Convert.ToString((char)((int)(c) ^ v2));
            }
            return temp;
        }
        Random randSHifr = new Random();
        int sd = 0;

        private void Button1_Click(object sender, EventArgs e)
        {
           
            DateTime thisDay = DateTime.Today;
            try
            {
                string sd1 = textBox1.Text;
                string sd2 = sd1.Remove(sd1.Length - 10);
                string sd3 = Encryption(sd2, 2);
                string sd4 = sd1.Remove(0, 4);
                string d = Encryption(sd4, 96);
                if (sd3 == shifr[sd])
                {

                    if (Convert.ToDateTime(d) > thisDay)
                    {
                        MessageBox.Show("Ключ продукта действительно до " + d);
                        Form1 f3 = new Form1();
                        f3.Show();
                        Мектеп.Properties.Settings.Default.lisenzia = d;
                        Мектеп.Properties.Settings.Default.lisenzia2 = Convert.ToString(thisDay);
                        Мектеп.Properties.Settings.Default.Save();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Недействительный ключ продукта!");
                    }
                }
                else
                {
                    MessageBox.Show("Шифр продукта изменён");
                }
                //MessageBox.Show(Convert.ToString(thisDay));
            }
            catch
            {
                MessageBox.Show("Недействительный ключ продукта");
            }

        }
        string[] shifr = new string[] { "ARXC","ASPO",
            "ASDF",
            "ASDC",
            "CDFV",
            "CVVF",
            "VBCX",
            "DFGV",
            "SDJG",
            "ZXCV",
            "SXDC",
            "AZAX",
            "LKJH",
            "PASM",
            "AQWS",
            "AZXC",
            "SZDA",
            "RETS",
            "FQWX",
            "ALZX",
            "XVCD",
            "QLSX",
            "WXXS",
            "AXCP",
            "ZDSR",
            "GHGJ",
            "KSUF",
            "KGOE",
            "LPGJ",
            "RWSC"
        };
        
private void Activator_Load(object sender, EventArgs e)
        {
            sd = randSHifr.Next(0, 29);
            textBox2.Text = shifr[sd];
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
