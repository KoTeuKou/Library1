using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Library
{

    public partial class MenuReader : System.Windows.Forms.Form
    {
      
        public MenuReader()
        {
            TopMost = true;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;            
        }
  
        InfoPublication f8 = new InfoPublication();
        public List<Publication> publications;
        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
      

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();           
                    
        }

        private void вывестиВсеПубликацииБиблиотекиToolStripMenuItem_Click(object sender, EventArgs e)
        {
                   
            string aut = "";
            listView1.Clear();
            foreach(var elem in publications)
            {
                aut = "";
                foreach (var a in elem.authors)
                {
                    aut += a + " ";
                }
                listView1.Items.Add(elem.tittle + ", " + aut);
            }
           
        }


        private void вывестиВсеГазетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            string aut = "";
            listView1.Clear();
            foreach (var elem in publications.OfType<Newspaper>())
            {
                aut = "";
                foreach (var a in elem.authors)
                {
                    aut += a + " ";
                }
                listView1.Items.Add(elem.tittle + ", " + aut);
            }
           
        }

        private void вывестиНаЭкранВсеКнигиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string aut = "";
            listView1.Clear();
            foreach (var elem in publications.OfType<Book>())
            {
                aut = "";
                foreach (var a in elem.authors)
                {
                    aut += a + " ";
                }
                listView1.Items.Add(elem.tittle + ", " + aut);
            }
           
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            string aut = "";
            listView1.Clear();
            foreach (var elem in publications.OfType<Magazine>())
            {
                aut = "";
                foreach (var a in elem.authors)
                {
                    aut += a + " ";
                }
                listView1.Items.Add(elem.tittle + ", " + aut);
            }
            
        }
        
       

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string aut = "";
            listView1.Clear();
            string req = toolStripTextBox1.Text;
            if (String.IsNullOrEmpty(req)) listView1.Clear();
            else
            {
                foreach (var elem in publications)
                {
                    foreach (var k in elem.authors)
                    {
                        aut = "";
                        if (k.Contains(req))
                        {
                            foreach (var a in elem.authors)
                            {
                                aut += a + " ";
                            }
                            listView1.Items.Add(elem.tittle + ", " + aut);
                        }
                    }
                }
            }
        }

        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            string aut = "";
            listView1.Clear();
            string req = toolStripTextBox3.Text;
            if (String.IsNullOrEmpty(req)) listView1.Clear();
            else
            {
                foreach (var elem in publications.OfType<Newspaper>())
                {
                    foreach (var k in elem.authors)
                    {
                        aut = "";
                        if (k.Contains(req))
                        {
                            foreach (var a in elem.authors)
                            {
                                aut += a + " ";
                            }
                            listView1.Items.Add(elem.tittle + ", " + aut);
                        }
                    }
                }
            }
           
        }

        private void toolStripTextBox4_TextChanged(object sender, EventArgs e)
        {
            string aut = "";
            listView1.Clear();
            string req = toolStripTextBox4.Text;
            if (String.IsNullOrEmpty(req)) listView1.Clear();
            else
            {
                foreach (var elem in publications.OfType<Book>())
                {
                    foreach (var k in elem.authors)
                    {
                        aut = "";
                        if (k.Contains(req))
                        {
                            foreach (var a in elem.authors)
                            {
                                aut += a + " ";
                            }
                            listView1.Items.Add(elem.tittle + ", " + aut);
                        }
                    }
                }
            }
           
        }

        private void toolStripTextBox7_TextChanged(object sender, EventArgs e)
        {
            string aut = "";
            listView1.Clear();
            string req = toolStripTextBox7.Text;
            if (String.IsNullOrEmpty(req)) listView1.Clear();
            else
            {
                foreach (var elem in publications.OfType<Magazine>())
                {
                    foreach (var k in elem.authors)
                    {
                        aut = "";
                        if (k.Contains(req))
                        {
                            foreach (var a in elem.authors)
                            {
                                aut += a + " ";
                            }
                            listView1.Items.Add(elem.tittle + ", " + aut);
                        }
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
                for (int k = 0; k < publications.Count; k++)                {
                            
                    
                        if (publications[k].tittle == text[0].Replace(cut, ""))
                        {
                        
                            index = k;
                        }                     
                }

                f8.temp = publications[index].Show();                
                this.Hide();
                f8.ShowDialog();
                this.Show();
            }
                       
        }
            
             
    }
    
}
