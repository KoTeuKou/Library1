using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Library
{
    public partial class RegistrationNewReader : Form
    {
        public RegistrationNewReader()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        private void Form7_Load(object sender, EventArgs e)
        {
            

        }
        public List<Reader> readers;

       

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
                        if (textBox3.Text.All(char.IsLetter))
                        {
                            if (textBox4.Text.All(char.IsDigit) && textBox4.Text.Length == 10)
                            {
                                if (radioButton1.Checked)
                                {
                                    tmp = "да";
                                }
                                readers.Add(new Reader(textBox1.Text, textBox2.Text, textBox3.Text, 8 + textBox4.Text, tmp, ""));
                                /*
                                StreamWriter writer = new StreamWriter(@"readers.txt", true, Encoding.Default);
                                writer.WriteLine(textBox1.Text + "|" + textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "|" + tmp + "|");
                                writer.Close();
                                */
                                Reader.Rewrite(readers);
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox3.Text = "";
                                textBox4.Text = "";
                                MessageBox.Show("Читатель успешно добавлен.");
                                MenuAdmin main = this.Owner as MenuAdmin;
                                if (main != null)
                                {                                    
                                    main.readers = readers;
                                }
                            }
                            else
                            {
                                textBox4.Text = "";
                                MessageBox.Show("Некорректный формат телефонного номера.");
                            }
                        }
                        else
                        {
                            textBox3.Text = "";
                            MessageBox.Show("Отчество может состоять только из букв.");
                        }
                    }
                    else
                    {
                        textBox2.Text = "";
                        MessageBox.Show("Имя может состоять только из букв.");
                    }
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Фамилия может состоять только из букв.");
                }
            }
            else
            {
                MessageBox.Show("Ни одно из полей не может быть пустым.");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
