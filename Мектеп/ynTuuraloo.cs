using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Мектеп.Forms
{
    public partial class ynTuuraloo : Form
    {
        public ynTuuraloo()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Music.upd = "vh";
           addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label1.Text = x;
                
            });
            AddMusic.ShowDialog();
        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Music.upd = "vh2";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label2.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Music.upd = "gimn";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label3.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            Music.upd = "til";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label4.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Music.upd = "poj";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label8.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Music.upd = "av";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label7.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Music.upd = "zem";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label6.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Music.upd = "ob";
            addMusic AddMusic = new addMusic();

            AddMusic.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                label5.Text = x;
            });
            AddMusic.ShowDialog();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;

        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=C:\\ProgramData\\WindowsTK\\basa.db;Version=3;New=False;Compress=True");
        }
        string[] f = new string[50];
        private void LoadList()
        {
            int i = 0;
            SetConnection();
            sql_con.Open();
            string sql = "select * from os_tab";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                i++;
                f[i] = reader[2].ToString();
                
                 }
            sql_con.Close();

            label1.Text = f[1];
            label2.Text = f[2];
            label3.Text = f[3];
            label4.Text = f[4];
            label5.Text = f[8];
            label6.Text = f[7];
            label7.Text = f[6];
            label8.Text = f[5];
        }

        private void YnTuuraloo_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void Button8_Click(object sender, EventArgs e)
        {

        }
    }
}
