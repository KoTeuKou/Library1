using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace Library
{
    [Serializable]
    public class Reader
        {
            public string name;
            public string surname;
            public string patronymic;
            public string phone_number;    
            public bool acces;
            public List<DateTime> timeoftaken = new List<DateTime>();
            public List<string> taken = new List<string>();
        public Reader(string surname, string name, string patronymic, string phone_number, string acces, string taken)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.phone_number = phone_number;
            this.acces = acces.ToLower() == ("да");
            if (taken != "")
            {
                string[] text = taken.Split(',');
                foreach(var t in text)
                {
                    this.taken.Add(t);
                }

            }
           
            }
        public bool IsDept(List<Publication> libr)   //является ли должником
        {
            if (timeoftaken.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var i in timeoftaken)
                {
                    if (i.AddDays(10) < DateTime.Today) //10 - кол-во дней на которое выдается книга
                    { return true; }

                }
            }

            return false;
           
        }
        public string Show()
        {
            return ($"ФИО: {surname} {name} {patronymic}" +
               $"\n Контактный телефон: {phone_number}");
        }
        public string Show(List<Publication> libr)
        {
            string books = "";
            if (taken.Count != 0)
            {
                foreach (var a in taken)
                {
                    foreach (var k in libr.OfType<Book>())
                    {
                        foreach (var elem in k.id)
                            if (a == elem)
                            {
                                books += k.tittle + " ";
                            }
                    }
                }
            }
           
            return ($"ФИО: {surname} {name} {patronymic}" +
                $"\n Контактный телефон: {phone_number} \n Список взятых книг:"+
                $"\n {books}");
        }

        public static void Rewrite(List<Reader> readers)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Readers.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, readers);
            }
        }

            public static List<Reader> Input()
        {
            using (FileStream fs = new FileStream("Readers.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Reader> deserilizePeople = (List<Reader>)formatter.Deserialize(fs);                              
                return deserilizePeople;
            }
            /*
            using (StreamReader fileIn = new StreamReader(@"readers.txt", System.Text.Encoding.Default))
            {                
                List<Reader> array = new List<Reader>();               
                while (!fileIn.EndOfStream)
                {
                    string[] text = fileIn.ReadLine().Split('|');
                  array.Add(new Reader(text[0], text[1], text[2], text[3], text[4],text[5]));                          

                }
                return array;
            }
            */
        }
        
    }
}
