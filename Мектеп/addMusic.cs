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
    public partial class addMusic : Form
    {
        public event Action<string> ValueChanged;
        bool g2 = false;
        public addMusic()
        {
            InitializeComponent();
        }
        //Signal Signal = new Signal();
        string s = "";
        private void Button3_Click(object sender, EventArgs e)
        {
            if (s != "")
            {
                if (g2 == false)
            {
               Signal.Stop();

                g2 = true;
                button3.Image = Properties.Resources.Iconic_e049_0__32;
                Signal.stopPause = true;
                button3.Text = "Токтотуу";
                Signal.Sound(s);
            }
            else
            {
                Signal.Stop();
                Signal.stopPause = false;
                g2 = false;
                button3.Image = Properties.Resources.Iconic_e047_1__32;
                button3.Text = "Угуу";

            }
            }
            else
            {
                MessageBox.Show("Выберите музуку!");
            }
        }


        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=C:\\ProgramData\\WindowsTK\\basa.db;Version=3;New=False;Compress=True");
        }
        private void ExcuteQuery(string textQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = textQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        private void AddMusic_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            SetConnection();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            int i1 = 0;
            dataGridView1.ColumnCount = 2;

            dataGridView1.Columns[0].Name = "№";
            dataGridView1.Columns[1].Name = "Название музики";
            dataGridView1.Columns[1].Width = 20;
            dataGridView1.Columns[1].Width = 260;

            sql_con.Open();
            string sql2 = "select * from music order by id desc";
            SQLiteCommand command2 = new SQLiteCommand(sql2, sql_con);
            SQLiteDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[1, i1].Value = reader2[1].ToString();
                dataGridView1[0, i1].Value = Convert.ToString(i1 + 1);
                i1++;

            }

            sql_con.Close();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog filedialog = new OpenFileDialog();
                filedialog.Filter = ("(*.mp3)|*.mp3");
                if (filedialog.ShowDialog() == DialogResult.OK)
                {
                    if (filedialog.OpenFile() != null)
                    {
                        string fileName = filedialog.SafeFileName; //Получили имя файла
                        ExcuteQuery("insert into music('name') values ('" + fileName + "')");
                        string sourcePath = filedialog.FileName; //Получили абсолютный путь
                        string targetPath = @"C:\Program Files (x86)\WindowsTK\WindowsTK\Sound";

                        string destFile = System.IO.Path.Combine(targetPath, fileName); // \Music\<fileName>
                        System.IO.File.Copy(sourcePath, destFile, true); //Копируем выбраный в OpenFileDialog файл в корень программы, в папку Music
                    }
                }

            }
            catch
            {

            }
            load();
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    s = row.Cells[1].Value.ToString();

                }
            }
            catch
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (s != "")
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ExcuteQuery("DELETE FROM music WHERE name='" + s + "'");
                }
                load();
            }
            else
            {
                MessageBox.Show("Выберите музуку!");
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (s != "")
            {
                Music.vbrat = s;
                ExcuteQuery("UPDATE os_tab SET music='" + s + "' WHERE button='" + Music.upd + "'");

                switch (Music.upd)
                {
                    case "vh":
                        if (ValueChanged != null)
                            ValueChanged(s);

                        break;
                    case "vh2":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                    case "gimn":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                    case "til":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                    case "poj":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                    case "av":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                    case "zem":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                    case "ob":
                        if (ValueChanged != null)
                            ValueChanged(s);
                        break;
                }

                this.Close();

            }
            else
            {
                MessageBox.Show("Выберите музуку!");
            }
            if (Signal.stopPause == true)
            {
                Signal.Stop();
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
