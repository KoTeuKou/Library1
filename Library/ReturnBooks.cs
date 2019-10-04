using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Library
{
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public int num;
        public List<Reader> readers;
        public List<Publication> publications;
        private void Form11_Load(object sender, EventArgs e)
        {
            Reader temp = readers[num];
            string aut = "";
            listView1.Clear();
            foreach (var elem in publications)
            {
                foreach (var k in temp.taken)
                {
                    if (k.Contains(elem.tittle))
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                string cut = "ListViewItem: {";
                string[] text;
                int index = 0;
                text = listView1.SelectedItems[0].ToString().Split(',');
                for (int l = 0; l < publications.Count; l++)
                {
                    if (publications[l].tittle == text[0].Replace(cut, ""))
                    {

                        index = l;
                    }
                }
                string req = "";
                foreach (var i in readers[num].taken)
                {
                    if (i.Contains(publications[index].tittle))
                    {
                        req = i;
                        break;
                    }
                }               
                publications[index].quantity_available++;
                publications[index].id.Add(req);
                readers[num].taken.Remove(req);
                MessageBox.Show("Книга была успешно возвращена в библиотеку");
                //перезапись данного читателя(обновление выданных ему книг)
                Reader.Rewrite(readers);
                /*
                string ids = "";
                foreach (var i in readers[num].taken)
                {
                    ids += i + ',';
                }
                if (ids.Length != 0)
                {
                    ids = ids.Substring(0, ids.Length - 1);
                }
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
                string aut = "";
                /*
                string[] readText = File.ReadAllLines(@"library.txt", Encoding.Default);
                Book k = (Book)publications[index];
                
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
                Reader r = readers[num];
                aut = "";
                listView1.Clear();
                foreach (var elem in publications)
                {
                    foreach (var q in r.taken)
                    {
                        if (q.Contains(elem.tittle))
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
                InfoReader main = this.Owner as InfoReader;
                main.readers = readers;
                main.publications = publications;
                main.label1.Text = readers[num].Show(publications);
                main.Refresh();
            }

        }
    }
}
