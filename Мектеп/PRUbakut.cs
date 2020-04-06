using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using NAudio;
using System.Data.SQLite;
using System.IO.Ports;
namespace Мектеп
{
    static class PRUbakut
    {
        static public int s = 0;
        static public int VrSound(string sound)
        {


            WaveOutEvent waveOut = new WaveOutEvent();
            Mp3FileReader mp3Reader = new Mp3FileReader(@"C:\Program Files (x86)\WindowsTK\WindowsTK\Sound\" + sound);
            waveOut.Init(mp3Reader);
            TimeSpan tm = mp3Reader.TotalTime;

            return Convert.ToInt16(tm.Seconds.ToString()) + (Convert.ToInt16(tm.Minutes.ToString()) * 60);

        }
        static public void Povtor(string sound, int second)
        {
            // metka = met;
            WaveOutEvent waveOut = new WaveOutEvent();
            Mp3FileReader mp3Reader = new Mp3FileReader(@"C:\Program Files (x86)\WindowsTK\WindowsTK\Sound\" + sound + ".mp3");
            waveOut.Init(mp3Reader);
            TimeSpan tm = mp3Reader.TotalTime;

            if (second >= (Convert.ToInt16(tm.Seconds.ToString()) + (Convert.ToInt16(tm.Minutes.ToString()) * 60)))
            {
                waveOut.Stop();

                s = 0;
            }
            if (second == 1)
            {
                waveOut.Play();
                s = 1;
            }


            //MessageBox.Show(tm.Seconds.ToString());
        }
        static public void Vremia(string vrem, int shotchik, string sound)
        {
            WaveOutEvent waveOut = new WaveOutEvent();
            Mp3FileReader mp3Reader = new Mp3FileReader(@"C:\Program Files (x86)\WindowsTK\WindowsTK\Sound\Пожарная_Синвлизация.mp3");
            //waveOut.Init(mp3Reader);
            //waveOut.Play();
            //mp3Reader.CurrentTime = TimeSpan.FromSeconds(1.0);
            TimeSpan tm = mp3Reader.TotalTime;

           // MessageBox.Show(tm.Seconds.ToString());


        }


    }
}
