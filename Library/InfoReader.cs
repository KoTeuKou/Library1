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
    public partial class InfoReader : Form
    {
       
        public int num;    
        public InfoReader()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        
        Form10 f10 = new Form10();
        ReturnBooks f11 = new ReturnBooks();
        public List<Publication> publications;
        public List<Reader> readers;
        private void Form9_Load(object sender, EventArgs e)
        {            
            label1.Text = readers[num].Show(publications);            
        }

        private void button1_Click(object sender, EventArgs e)
        {         
            f10.Owner = this;
            f10.readers = readers;
            f10.publications = publications;
            f10.num = num;          
            this.Hide();
            f10.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (readers[num].taken.Count > 0)
            {
                f11.Owner = this;
                f11.readers = readers;
                f11.publications = publications;
                f11.num = num;
                this.Hide();
                f11.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Читатель еще не получал книг.");
        }
    }
}
