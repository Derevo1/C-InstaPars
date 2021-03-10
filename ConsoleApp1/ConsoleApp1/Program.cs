using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string res = "";
            Console.WriteLine("Input user URL");
            string a = Console.ReadLine();            
            WebClient web = new WebClient();           
            string connect = web.DownloadString(a);         
            Match match = Regex.Match(connect, "<meta content=(.*?)>");
            Console.WriteLine(match.Groups[1].Value);
            res = match.Groups[1].Value;
            WriteFile(res);
            UserList();
            Console.ReadKey();
        }
        static void UserList()
        {
            FileStream fstream = new FileStream("1.txt", FileMode.OpenOrCreate);
            byte[] arr = new byte[fstream.Length];
            fstream.Read(arr, 0, arr.Length);
            string textFromFile = System.Text.Encoding.Default.GetString(arr);
            Console.WriteLine("\n User info:");
            Console.WriteLine("\n"+textFromFile);

            
        }

        static void WriteFile(string c)
        {
            FileStream fstream = new FileStream("1.txt", FileMode.OpenOrCreate);
            byte[] text = System.Text.Encoding.Default.GetBytes(c);
            fstream.Write(text, 0, text.Length);
            fstream.Close();
        }
        
    }
}
