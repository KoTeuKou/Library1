using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;


namespace Library
{
    [Serializable] //xml & binary
    [DataContract] //json
    public class Reader
        {
            [DataMember]
            public string name;
            [DataMember]
            public string surname;
            [DataMember]
            public string patronymic;
            [DataMember]
            public string phone_number;    
            [DataMember]
            public bool acces;
            public List<DateTime> timeoftaken = new List<DateTime>();
            [DataMember]
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
        public Reader()
        { }
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
            var binaryFormatter = new BinaryFormatter();
            using (var fs = new FileStream("Readers.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, readers);
            }
            //Json
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Reader>));
 
            using (var fs = new FileStream("readers.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, readers);
            }
            //Xml
            var XmlFormatter = new XmlSerializer(typeof(List<Reader>));
            
            using (var fs = new FileStream("readers.xml", FileMode.OpenOrCreate))
            {
                XmlFormatter.Serialize(fs, readers);
            }
        }

            public static List<Reader> Input()
        {
            /*
            //Json
            
            using (var fs = new FileStream("readers.json", FileMode.OpenOrCreate))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Json deserialization: ").AppendLine();
                var jsonFormatter = new DataContractJsonSerializer(typeof(List<Reader>));
                var jsonReaders = (List<Reader>)jsonFormatter.ReadObject(fs);
 
                foreach (var r in jsonReaders)
                {
                    stringBuilder.Append(r.Show()).AppendLine();
                }

                MessageBox.Show(stringBuilder.ToString());
            }
            //Xml
            using (var fs = new FileStream("readers.xml", FileMode.OpenOrCreate))
            {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Xml deserialization: ").AppendLine();
                var XmlFormatter = new XmlSerializer(typeof(List<Reader>));
                var XmlReaders = (List<Reader>)XmlFormatter.Deserialize(fs);
                System.Console.WriteLine("Xml deserialization: ");
                foreach (var r in XmlReaders)
                {
                    stringBuilder.Append(r.Show()).AppendLine();
                }
                MessageBox.Show(stringBuilder.ToString());
            }
            
            //Txt
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
            //Binary
            using (var fs = new FileStream("Readers.dat", FileMode.OpenOrCreate))
            {
                var binaryFormatter = new BinaryFormatter();     
                return (List<Reader>)binaryFormatter.Deserialize(fs); 
            }
        }
        
    }
}
