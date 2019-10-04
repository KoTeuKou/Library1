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
    public partial class InfoPublication : Form
    {
        public string temp;
        public InfoPublication()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
           
        }        
        
                
        private void Form8_Load(object sender, EventArgs e)
        {
            label1.Text = temp;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
