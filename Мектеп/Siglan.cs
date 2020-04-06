using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Мектеп
{
    static class Signal
    {
       static  public bool stopPause { get; set; } = false;
        static public bool stopPause2 { get; set; } = false;
        static private SQLiteConnection sql_con;
        //private SQLiteCommand sql_cmd;
        //private SQLiteDataAdapter DB;
        // private DataSet DS = new DataSet();
        //private DataTable DT = new DataTable();
        static private NAudio.Wave.BlockAlignReductionStream stream = null;
        static private NAudio.Wave.DirectSoundOut output = null;

        static public void Sound(string name)
        {
            try
            {
                stopPause2 = true;
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(@"C:\Program Files (x86)\WindowsTK\WindowsTK\Sound\" + name));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
            }
            catch
            {
               // MessageBox.Show("Музыка нет в фонетике!");
                stopPause = false;

            }
        }
        static private void SetConnection()
        {
            sql_con = new SQLiteConnection("Data Source=C:\\ProgramData\\WindowsTK\\basa.db;Version=3;New=False;Compress=True");
        }
        static public void Sound2(string s)
        {
            try
            {
                string sound = "";

                SetConnection();
                sql_con.Open();
                string sql = "select * from os_tab where button='" + s + "'";
                SQLiteCommand command = new SQLiteCommand(sql, sql_con);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sound = reader[2].ToString();
                }
                sql_con.Close();
                stopPause2 = true;
                stopPause = true;
                NAudio.Wave.WaveStream pcm = NAudio.Wave.WaveFormatConversionStream.CreatePcmStream(new NAudio.Wave.Mp3FileReader(@"C:\Program Files (x86)\WindowsTK\WindowsTK\Sound\" + sound));
                stream = new NAudio.Wave.BlockAlignReductionStream(pcm);
                output = new NAudio.Wave.DirectSoundOut();
                output.Init(stream);
                output.Play();
            }
            catch
            {
                stopPause = false;
               // MessageBox.Show("Ошибка: музыка удален! ");

            }
        }
        static public string NameSound(string s)
        {
            string sound = "";

            SetConnection();
            sql_con.Open();
            string sql = "select * from os_tab where button='" + s + "'";
            SQLiteCommand command = new SQLiteCommand(sql, sql_con);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sound = reader[2].ToString();
            }
            sql_con.Close();
            return sound;
        }

        static public void Stop()
        {
            if (stopPause == true)
            {
                output.Stop();
            }
        }
    }
}
