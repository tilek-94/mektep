using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Мектеп
{
    static class Camera
    {


        static string[] shot = new string[12];
        static public string getNum(string a, string b)
        {
            switch (a)
            {
                case "1":
                    shot[1] = b;
                    break;
                case "2":
                    shot[2] = b;
                    break;
                case "3":
                    shot[3] = b;
                    break;
                case "4":
                    shot[4] = b;
                    break;
                case "5":
                    shot[5] = b;
                    break;
                case "6":
                    shot[6] = b;
                    break;
                case "7":
                    shot[7] = b;
                    break;
                case "8":
                    shot[8] = b;
                    break;
                case "9":
                    shot[9] = b;
                    break;
                case "10":
                    shot[10] = b;
                    break;


            }
            return shot[1] + shot[2] + shot[3] + shot[4] + shot[5] + shot[6] + shot[7] + shot[8] + shot[9] + shot[10];

        }
        static public string Display()
        {
            for (int i = 1; i < 11; i++)
            {
                shot[i] = "0";
            }
            return shot[1] + shot[2] + shot[3] + shot[4] + shot[5] + shot[6] + shot[7] + shot[8] + shot[9] + shot[10];
        }
        static public string DisplayVKL()
        {
            for (int i = 1; i < 11; i++)
            {
                shot[i] = "1";
            }
            return shot[1] + shot[2] + shot[3] + shot[4] + shot[5] + shot[6] + shot[7] + shot[8] + shot[9] + shot[10];
        }
    }
}
