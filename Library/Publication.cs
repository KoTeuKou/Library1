using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
namespace Library
{
    [Serializable]
    public abstract class Publication
    {
        
        public string tittle;
        public string publisher;
        public string[] authors;
        
        public List<string> id = new List<string>();
        public int quantity_available;
        public bool rare_literature;
        public Publication(string tittle, string publisher, string[] authors, int quantity_available, string rare_literature)
        {
            this.tittle = tittle;           
            this.publisher = publisher;
            this.authors = authors;
            this.quantity_available = quantity_available;            
            if (rare_literature.ToLower() == ("да"))
            {
                this.rare_literature = true;
            }
            else
            {
                this.rare_literature = false;
            }
            for (int i = 0; i < quantity_available; i++)
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
                    if (this.quantity_available > 1)
                        return true;
                    else
                        return false;
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
            using (FileStream fs = new FileStream("Publications.dat", FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                List<Publication> array = (List<Publication>)formatter.Deserialize(fs);
                return array;
            }
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
        }
        public abstract string Show();
    }
}
