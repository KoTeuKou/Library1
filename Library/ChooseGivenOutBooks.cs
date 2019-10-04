using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Library
{
    public partial class Form10 : Form
    {
        public int num;
        public List<Reader> readers;
        public List<Publication> publications;
        public Form10()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {                
                string cut = "ListViewItem: {";
                string[] text;
                int index = 0;
                text = listView1.SelectedItems[0].ToString().Split(',');
                for (int k = 0; k < publications.Count; k++)
                {
                    if (publications[k].tittle == text[0].Replace(cut, ""))
                    {

                        index = k;
                    }
                }
                if (publications[index].GetType().ToString() == "Library.Book")
                {
                    if (publications[index].quantity_available > 1)
                    {
                        if (publications[index].rare_literature == true)
                        {
                            if (readers[num].acces == true)
                            {
                                int lastind = publications[index].id.Count-1;
                                readers[num].timeoftaken.Add(DateTime.Today);
                                readers[num].taken.Add(publications[index].id[lastind]);
                                publications[index].id.RemoveAt(lastind);
                                publications[index].quantity_available--;
                                MessageBox.Show("Данная книга успешно выдана.");
                                //перезапись данного читателя(обновление выданных ему книг)
                                Reader.Rewrite(readers);
                                /*
                                string ids = "";
                                foreach (var i in readers[num].taken) {
                                    ids += i + ',';
                                }
                                ids = ids.Substring(0, ids.Length - 1);
                                string acc = "нет";
                                if (readers[num].acces)
                                {
                                    acc = "да";
                                }
                                
                                string[] readUsers = File.ReadAllLines(@"readers.txt", Encoding.Default);
                                string tmp = readers[num].surname + "|" + readers[num].name + "|" + 
                                    readers[num].patronymic + "|" + readers[num].phone_number + "|" + acc +
                                        "|" + ids;
                                readUsers[num] = tmp;
                                File.WriteAllLines(@"readers.txt", readUsers, Encoding.Default);
                                */
                                //перезапись данной книги(обновление количества экземпляров данной книги)
                                Publication.Rewrite(publications);
                                /*
                                string[] readText = File.ReadAllLines(@"library.txt", Encoding.Default);
                                Book k = (Book)publications[index];
                                string aut = "";
                                foreach (var elem in k.authors)
                                {
                                    aut += elem + ',';
                                }
                                aut = aut.Substring(0, aut.Length - 1);
                                string rare = "нет";
                                if (k.rare_literature)
                                {
                                    rare = "да";
                                }
                                string temp = "book|" + k.tittle + "|" +
                                                        k.publisher + "|" + aut + "|" +
                                                        k.genre + "|" + k.date_of_written +
                                                        "|" + k.quantity_available + "|" + rare;

                                readText[index] = temp;                               
                                File.WriteAllLines(@"library.txt", readText, Encoding.Default);
                                */
                                //
                                InfoReader main = this.Owner as InfoReader;
                                main.readers = readers;
                                main.publications = publications;
                                main.label1.Text = readers[num].Show(publications);
                                main.Refresh();

                            }
                            else
                            {
                                MessageBox.Show("У данного читателя нет доступа к этой книге.");
                            }
                        }
                        else
                        {

                            int lastind = publications[index].id.Count-1;
                            readers[num].timeoftaken.Add(DateTime.Today);
                            readers[num].taken.Add(publications[index].id[lastind]);
                            publications[index].id.RemoveAt(lastind);
                            publications[index].quantity_available--;
                            MessageBox.Show("Данная книга успешно выдана.");
                            //перезапись данного читателя(обновление выданных ему книг)
                            string ids = "";
                            foreach (var i in readers[num].taken)
                            {
                                ids += i + ',';
                            }
                            ids = ids.Substring(0, ids.Length - 1);
                            string acc = "нет";
                            if (readers[num].acces)
                            {
                                acc = "да";
                            }
                            string[] readUsers = File.ReadAllLines(@"readers.txt", Encoding.Default);
                            string tmp = readers[num].surname + "|" + readers[num].name + "|" +
                                readers[num].patronymic + "|" + readers[num].phone_number + "|" + acc +
                                    "|" + ids;
                            readUsers[num] = tmp;
                            File.WriteAllLines(@"readers.txt", readUsers, Encoding.Default);

                            //перезапись данной книги(обновление количества экземпляров данной книги)
                            string[] readText = File.ReadAllLines(@"library.txt", Encoding.Default);

                            Book k = (Book)publications[index];
                            string aut = "";
                            foreach (var elem in k.authors)
                            {
                                aut += elem + ',';
                            }
                            aut = aut.Substring(0, aut.Length - 1);
                            string rare = "нет";
                            if (k.rare_literature)
                            {
                                rare = "да";
                            }
                            string temp = "book|" + k.tittle + "|" +
                                                    k.publisher + "|" + aut + "|" +
                                                    k.genre + "|" + k.date_of_written +
                                                    "|" + k.quantity_available + "|" + rare;

                            readText[index] = temp;                            
                            File.WriteAllLines(@"library.txt", readText, Encoding.Default);
                           
                        }

                    }
                    else
                    {
                        MessageBox.Show("Выдача книги невозможна, т.к. это последний экземпляр.");
                    }
                }
                else {
                    MessageBox.Show("Выдача журналов и книг невозможна, их можно только просматривать в читальном зале.");
                }
            }         

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            string aut = "";
            listView1.Clear();
            foreach (var elem in publications)
            {
                aut = "";
                foreach (var a in elem.authors)
                {
                    aut += a + " ";
                }
                listView1.Items.Add(elem.tittle + ',' + aut);
            }
        }
    }
}
