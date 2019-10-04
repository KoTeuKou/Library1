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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            TopMost = true;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
        }
        AddBook f4 = new AddBook();        
        AddNewspaper f5 = new AddNewspaper();
        AddMagazine f6 = new AddMagazine();
        RegistrationNewReader f7 = new RegistrationNewReader();        
        InfoPublication f8 = new InfoPublication();
        InfoReader f9 = new InfoReader();
        public List<Publication> publications;
        public List<Reader> readers;

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
      
        private void Form3_Load(object sender, EventArgs e)
        {            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void вывестиСписокВсехЧитателейToolStripMenuItem_Click(object sender, EventArgs e)
        {                        
            listView1.Clear();            
           
            foreach (var elem in readers)
            {
                listView1.Items.Add(elem.Show());
            }
          
        }

        private void вывестиТолькоДолжниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            foreach (var elem in readers)
            {
                if (elem.IsDept(publications))
                    listView1.Items.Add(elem.Show());
            }
           
        }

        private void ДобавитьКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f4.Owner = this;
            f4.publications = publications;
            this.Hide();
            f4.ShowDialog();
            this.Show();
        }
        private void ДобавитьГазетуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5.Owner = this;
            f5.publications = publications;
            this.Hide();
            f5.ShowDialog();
            this.Show();
        }

        private void ДобавитьЖурналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f6.Owner = this;
            f6.publications = publications;
            this.Hide();
            f6.ShowDialog();
            this.Show();
        }

        private void ЗарегистрироватьНовогоЧитателяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f7.Owner = this;
            f7.readers = readers;
            this.Hide();
            f7.ShowDialog();
            this.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems.Count != 0)
            {
                f9.readers = readers;
                f9.publications = publications;
                f9.num = listView1.SelectedItems[0].Index;               
                this.Hide();
                f9.ShowDialog();
                this.Show();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }
    }
}
