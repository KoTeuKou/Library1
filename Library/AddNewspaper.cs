using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Library
{
    public partial class AddNewspaper : Form
    {
        public AddNewspaper()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public List<Publication> publications;
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = "нет";
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox3.Text)
               && !String.IsNullOrWhiteSpace(textBox4.Text))
            {
                if (textBox1.Text.All(char.IsLetter))
                {
                    if (textBox2.Text.All(char.IsLetter))
                    {
                        if (textBox3.Text.All(char.IsDigit))
                        {
                            textBox3.Text = "";
                            MessageBox.Show("В поле авторов не может быть цифр.");
                        }
                        else
                        {                            
                                if (textBox4.Text.All(char.IsDigit))
                                {
                                    if (radioButton1.Checked)
                                    {
                                        tmp = "да";
                                    }
                                String[] authors = textBox3.Text.Split(',');
                                publications.Add(new Newspaper(textBox1.Text, textBox2.Text, authors, int.Parse(textBox4.Text), tmp));

                                /*
                                StreamWriter writer = new StreamWriter(@"library.txt", true, Encoding.Default);
                                writer.WriteLine("newspaper|" + textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "|" + tmp);
                                writer.Close();
                                */

                                Publication.Rewrite(publications);
                                textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    MessageBox.Show("Газета успешно добавлена.");
                                }
                                else
                                {
                                    textBox4.Text = "";
                                    MessageBox.Show("Количество газет может быть только числом.");
                                }
                            }
                            
                        }

                    else
                    {
                        textBox2.Text = "";
                        MessageBox.Show("Название издательства может состоять только из букв.");
                    }
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Название газеты может состоять только из букв.");
                }
            }
            else
            {
                MessageBox.Show("Ни одно из полей не может быть пустым.");
            }          
                      
        }
    }
}
