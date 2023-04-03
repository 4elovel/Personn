using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Prs
{
    internal class Person
    {

        Person(int b, int c, string d, string e, string f, string g, string h, string i)
        {
            ids = id;
            id++;
            id_code = b;
            pass_num = c;
            name = d;
            surname = e;
            number = f;
            e_adress = g;
            gender = h;
            birth_date = i;
        }
        ~Person()
        {
            string text =$"{ids};{id_code};{pass_num};{name};{surname};{number};{e_adress};{gender};{birth_date}.";
            byte[] buffer = Encoding.Default.GetBytes(text);
            using (FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
        }
        void print()
        {
            Console.WriteLine($"\nid - {ids}\nidentificial code - {id_code}");
            Console.WriteLine($"pasport number - {pass_num}\nname - {name}\nsurname - {surname}\nnumber - {number}\nemail - {e_adress}\ngender - {gender}\nbirth date - {birth_date}\n");
        }

        public static int id;
        int ids;
        int id_code;
        int pass_num;
        string name;
        string surname;
        string number;
        string e_adress;
        string gender;
        string birth_date;

        static void Main(string[] args)
        {
            Person.id = 0;
            using (FileStream fs = new FileStream("data.txt", FileMode.Truncate, FileAccess.Write, FileShare.None))
                fs.Close();
            Person obj = new Person(147672, 356353, "Vova", "Andreev", "0501567511", "qertuyn@gmail.com", "male", "01.11.1999");
            obj.print();
            Person obj2 = new Person(7537375, 123123, "Sanya", "Hordey", "0501698423", "qwerty@gmail.com", "male", "05.12.1991");
            obj2.print();
            Person obj3 = new Person(147672, 356353, "Zhenya", "Melnyk", "0664263972", "heyymen@gmail.com", "female", "02.03.2001");
            obj3.print();
            

            Console.ReadKey();
        }

    }
}
