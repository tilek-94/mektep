using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мектеп
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string lisenzia = Мектеп.Properties.Settings.Default.lisenzia;
            string lisenzia2 = Мектеп.Properties.Settings.Default.lisenzia2;
            DateTime thisDay = DateTime.Today;
            if (Convert.ToDateTime(lisenzia2) <= thisDay)
            {
                if (Convert.ToDateTime(lisenzia) > thisDay)
                {
                    Мектеп.Properties.Settings.Default.lisenzia2 = Convert.ToString(thisDay);
                    Мектеп.Properties.Settings.Default.Save();
                    Application.Run(new Form1());
                }
                    
                    else
                    {
                    //Application.Run(new VtorMonitor());
                    Application.Run(new Form1());
                    //Application.Run(new Activator());
                }
                }
                else
                {
                Application.Run(new Form1());
                //Application.Run(new Activator());
            }

            }
        }
}
