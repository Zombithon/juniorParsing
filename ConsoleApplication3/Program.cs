using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int file = 0;
            
            Console.WriteLine("Input a # 1-8");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    file = 1;
                    break;
                case 2:
                    file = 2;
                    break;
                case 3:
                    file = 3;
                    break;
                case 4:
                    file = 4;
                    break;
                case 5:
                    file = 5;
                    break;
                case 6:
                    file = 6;
                    break;
                case 7:
                    file = 7;
                    break;
                case 8:
                    file = 8;
                    break;
            }
            string raw = "", line="";
            using (StreamReader reader = new StreamReader("files/" + file + ".txt"))
            {
                raw = reader.ReadToEnd();
                raw = raw.Replace("\r\nBegin", "Begin");
                raw = raw.Replace("End\r\n", "End");
                //while ((line = reader.ReadLine()) != null)
                //{
                //    raw += line;
                //}
            }
            int cStartPos = 0;
            int cEndPos = 0;

            while (raw.Contains("/*"))
            {
                cStartPos = raw.IndexOf("/*");
                cEndPos = raw.IndexOf("*/");
                if (cStartPos != -1)
                {
                    if (cEndPos == -1)
                    {
                        crash("No end comment found");
                        break;
                    }
                    raw = raw.Remove(cStartPos, ((cEndPos - cStartPos) + 2));
                }
            }
            string[] subArr; 
            if (raw.Contains("Begin")&& raw.IndexOf("Begin")==0)
            {
                if (raw.Contains("End") && raw.IndexOf("End") == raw.Length - 3)
                {
                    raw = raw.Replace("\n", "");
                    raw = raw.Replace("\t", "");
                    subArr = raw.Split('\r');







                }
                else
                {
                    crash("No \"End\" statement found");
                }
            }
            else
            {
                crash("No \"Begin\" statement found");
            }
            Console.WriteLine(raw);
            Console.ReadKey();
        }
        static void crash(string z)
        {
            Console.WriteLine(z);
        }
    }
}
