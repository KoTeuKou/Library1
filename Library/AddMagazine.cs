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
    public partial class AddMagazine : Form
    {
        public AddMagazine()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public List<Publication> publications;
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tmp = "нет";
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox3.Text)
               && !String.IsNullOrWhiteSpace(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox5.Text))
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
                                if (textBox5.Text.All(char.IsDigit))
                                {
                                    if (radioButton1.Checked)
                                    {
                                        tmp = "да";
                                    }
                                    String[] authors = textBox3.Text.Split(',');
                                    publications.Add(new Magazine(textBox1.Text, textBox2.Text, authors, short.Parse(textBox4.Text), int.Parse(textBox5.Text), tmp));

                                    /*
                                    StreamWriter writer = new StreamWriter(@"library.txt", true, Encoding.Default);
                                    writer.WriteLine("magazine|" + textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "|" + textBox5.Text + "|" + tmp);
                                    writer.Close();    
                                    */
                                    Publication.Rewrite(publications);
                                    textBox1.Text = "";
                                    textBox2.Text = "";
                                    textBox3.Text = "";
                                    textBox4.Text = "";
                                    textBox5.Text = "";
                                    MessageBox.Show("Журнал успешно добавлен.");
                                }
                                else
                                {
                                    textBox5.Text = "";
                                    MessageBox.Show("Количество журналов может быть только числом.");
                                }
                            }
                            else
                            {
                                textBox4.Text = "";
                                MessageBox.Show("Номер выпуска журанала может быть только числом.");
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
                    MessageBox.Show("Название журанала может состоять только из букв.");
                }
            }
            else
            {
                MessageBox.Show("Ни одно из полей не может быть пустым.");
            }       
                     
            
        }
    }
}
