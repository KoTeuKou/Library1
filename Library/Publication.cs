using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace Library

{
    [Serializable] //xml & binary
    [DataContract] //json
    [XmlInclude(typeof(Book)),
     XmlInclude(typeof(Magazine)),
     XmlInclude(typeof(Newspaper)),
     XmlType]
    public abstract class Publication
    {
        [DataMember]
        public string tittle;
        [DataMember]
        public string publisher;
        [DataMember]
        public string[] authors;
        [DataMember]
        public List<string> id = new List<string>();
        [DataMember]
        public int quantity_available;
        [DataMember]
        public bool rare_literature;
        protected Publication(){}
        protected Publication(string tittle, string publisher, string[] authors, int quantity_available, string rare_literature)
        {
            this.tittle = tittle;           
            this.publisher = publisher;
            this.authors = authors;
            this.quantity_available = quantity_available;            
            this.rare_literature = rare_literature.ToLower() == ("да");
            for (var i = 0; i < quantity_available; i++)
            {
                id.Add(tittle + i);
            }
        }
        public bool Available_to_take(Reader temp)
        {
            if (Convert.ToString(GetType()) == "Book")
            {
                if (rare_literature == false)
                {
                    return this.quantity_available > 1;
                }
                else if (temp.acces == true)
                {
                    return true;
                }
                else return false;

            }
            else return false;
        }
        public static List<Publication> Input()
        {
            var types = new Type[] {typeof(Book), typeof(Newspaper), typeof(Magazine)};
            
            //Json
                JsonSerializerSettings settings = new JsonSerializerSettings() {
                    TypeNameHandling = Newtonsoft.Json.TypeNameHandling.All 
                };
                var stringBuilder = new StringBuilder();
                stringBuilder.Append("Json deserialization: ").AppendLine();
                string s = System.IO.File.ReadAllText(@"publications.json", Encoding.UTF8);
                List<Publication> jsonPublications = JsonConvert.DeserializeObject<List<Publication>>(s, settings);

                foreach (var r in jsonPublications)
                {
                    stringBuilder.Append(r.Show()).AppendLine();
                }

                MessageBox.Show(stringBuilder.ToString());
            
            
            //Xml
            using (var fs = new FileStream("publications.xml", FileMode.OpenOrCreate))
            {
                stringBuilder = new StringBuilder();
                stringBuilder.Append("Xml deserialization: ").AppendLine();
                
                var XmlFormatter = new XmlSerializer(typeof(List<Publication>), types);
                var xmlPublications = (List<Publication>)XmlFormatter.Deserialize(fs);
                foreach (var r in xmlPublications)
                {
                    stringBuilder.Append(r.Show()).AppendLine();
                }
                MessageBox.Show(stringBuilder.ToString());
            }
            
            //binary
            using (FileStream fs = new FileStream("Publications.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                List<Publication> array = (List<Publication>)binaryFormatter.Deserialize(fs);
                return array;
            }
            //txt
            /*
            using (StreamReader fileIn = new StreamReader(@"library.txt", Encoding.Default))
            {
                List<Publication> array = new List<Publication>();

                int i = 0;
                while (!fileIn.EndOfStream)
                {
                    string[] text = fileIn.ReadLine().Split('|');
                    switch (text[0])
                    {
                        case "book":                            
                            array.Add(new Book(text[1], text[2],text[3].Split(','),text[4], short.Parse(text[5]), int.Parse(text[6]),text[7]));
                            i++;
                            break;
                        case "magazine":
                            array.Add(new Magazine(text[1], text[2], text[3].Split(','), short.Parse(text[4]), int.Parse(text[5]), text[6]));
                            i++;
                            break;
                        case "newspaper":
                            array.Add(new Newspaper(text[1], text[2], text[3].Split(','), int.Parse(text[4]), text[5]));
                            i++;
                            break;
                    }
                
                }
               
                return array;
               
        }
         */
        }
        public static void Rewrite(List<Publication> publications)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("Publications.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, publications);
            }          
            //Json
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            using (var sw = new StreamWriter("publications.json", true))
            {
                string serialized = JsonConvert.SerializeObject(publications, settings);
                sw.Write(serialized);
            }
            
            //Xml
            var types = new Type[] {typeof(Book), typeof(Newspaper), typeof(Magazine)};
            var XmlFormatter = new XmlSerializer(typeof(List<Publication>), types);
            
            using (var fs = new FileStream("publications.xml", FileMode.OpenOrCreate))
            {
                XmlFormatter.Serialize(fs, publications);
            }
            
        }
        public abstract string Show();
    }
}
