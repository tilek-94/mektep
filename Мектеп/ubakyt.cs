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
    public partial class ubakyt : Form
    {
        public ubakyt()
        {
            InitializeComponent();
        }

        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        int id1;
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
        private void LoadList()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            dataGridView2.ColumnCount = 4;
            dataGridView2.Columns[0].Name = "id";
            dataGridView2.Columns[1].Name = "№";
            dataGridView2.Columns[2].Name = "Вход";
            dataGridView2.Columns[3].Name = "Выход";
            dataGridView2.Columns["id"].Visible = false;
            //dataGridView2.Columns[2].Name = "Переключение";
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
                dataGridView2.Rows.Add(reader[0].ToString(), i, reader[1].ToString(), reader[2].ToString());
            }
            sql_con.Close();

            dataGridView2.Columns[0].Width = 0;
            dataGridView2.Columns[1].Width = 50;
            dataGridView2.Columns[2].Width = 150;
            dataGridView2.Columns[3].Width = 150;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void DataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (s != "")
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ExcuteQuery("DELETE FROM raspisanie WHERE id='" + s + "'");
                    LoadList();
                }

            }
            else
            {
                MessageBox.Show("Выберите время!");
            }
        }
        string s = "";
        private void Ubakyt_Load(object sender, EventArgs e)
        {
            LoadList();

            SetConnection();
            sql_con.Open();
            string sql = "select * from info WHERE name='vrem'";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text = reader[2].ToString();
                Peremenyi.vremia = Convert.ToInt16(reader[2].ToString());
            }
            sql_con.Close();
        }

        private void DataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].Cells["id"].Value == null)
            {
                id1 = 0;

            }
            else
            {
                id1 = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value.ToString());

            }

            if (id1 == 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells["Вход"].Value != null && dataGridView2.Rows[e.RowIndex].Cells["Выход"].Value != null)
                {
                    ExcuteQuery("insert into raspisanie('time_n','time_k') values('" + dataGridView2.Rows[e.RowIndex].Cells["Вход"].Value.ToString() + "','" + dataGridView2.Rows[e.RowIndex].Cells["Выход"].Value.ToString() + "')");
                }
                else if (dataGridView2.Rows[e.RowIndex].Cells["Вход"].Value != null)
                {
                    ExcuteQuery("insert into raspisanie('time_n') values('" + dataGridView2.Rows[e.RowIndex].Cells["Вход"].Value.ToString() + "')");

                }
                else
                {
                    ExcuteQuery("insert into raspisanie('time_k') values('" + dataGridView2.Rows[e.RowIndex].Cells["Выход"].Value.ToString() + "')");

                }
                LoadList();
            }
            else
            {
                // MessageBox.Show(id1.ToString());
                try
                {
                    ExcuteQuery("update raspisanie set time_n='" + dataGridView2.Rows[e.RowIndex].Cells["Вход"].Value.ToString() + "', time_k='" + dataGridView2.Rows[e.RowIndex].Cells["Выход"].Value.ToString() + "' where id =" + id1 + "");
                    LoadList();
                }
                catch
                {

                }
            }
        }

        private void TextBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                ExcuteQuery("update info set value00='" + Convert.ToInt16(textBox1.Text) + "' where name ='vrem'");
                // MessageBox.Show("Время успешно сохранен!");
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
            catch
            {

            }
        }

        private void DataGridView2_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                    s = row.Cells[0].Value.ToString();
                    //MessageBox.Show(s);
                }
            }
            catch
            {

            }
        }
    }
}
