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
    public partial class AddBook : Form
    {
        public AddBook()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public List<Publication> publications;

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
                            if (textBox4.Text.All(char.IsLetter))
                            {
                                if (textBox5.Text.All(char.IsDigit))
                                {
                                    if (textBox6.Text.All(char.IsDigit))
                                    {
                                        if (radioButton1.Checked)
                                        {
                                            tmp = "да";
                                        }
                                        foreach (Publication s in publications)
                                        {
                                            Console.WriteLine(s.Show());
                                        }
                                        String[] authors = textBox3.Text.Split(',');
                                        publications.Add(new Book(textBox1.Text, textBox2.Text, authors, textBox4.Text, short.Parse(textBox5.Text), int.Parse(textBox6.Text), tmp));
                                        /*
                                        StreamWriter writer = new StreamWriter(@"library.txt", true, Encoding.Default);
                                        writer.WriteLine("book|" + textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "|" + textBox5.Text + "|" + textBox6.Text + "|" + tmp);
                                        writer.Close(); 
                                        */
                                        Publication.Rewrite(publications);
                                        textBox1.Text = "";
                                        textBox2.Text = "";
                                        textBox3.Text = "";
                                        textBox4.Text = "";
                                        textBox5.Text = "";
                                        textBox6.Text = "";
                                        MessageBox.Show("Книга успешно добавлена.");
                                    }
                                    else
                                    {
                                        textBox6.Text = "";
                                        MessageBox.Show("Количество книг может быть только числом.");
                                    }
                                }
                                else
                                {
                                    textBox5.Text = "";
                                    MessageBox.Show("Год написания книги может быть только числом.");
                                }
                            }
                            else
                            {
                                textBox4.Text = "";
                                MessageBox.Show("Жанр книги может состоять только из букв.");
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
                    MessageBox.Show("Название книги может состоять только из букв.");
                }
            }
            else
            {
                MessageBox.Show("Ни одно из полей не может быть пустым.");
            }           
         
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
