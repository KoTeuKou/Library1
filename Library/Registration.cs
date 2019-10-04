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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(textBox3.Text)
                && !String.IsNullOrWhiteSpace(textBox4.Text) && !String.IsNullOrWhiteSpace(textBox5.Text) && !String.IsNullOrWhiteSpace(textBox6.Text)
                && !String.IsNullOrWhiteSpace(textBox7.Text))
            {
                if (textBox1.Text.All(char.IsLetterOrDigit))
                {
                    if (textBox2.Text.All(char.IsLetterOrDigit) && textBox2.Text.Length > 5)
                    {
                        if (textBox3.Text == textBox2.Text)
                        {
                            if (textBox4.Text.All(char.IsLetter))
                            {
                                if (textBox5.Text.All(char.IsLetter))
                                {
                                    if (textBox6.Text.All(char.IsLetter))
                                    {
                                        if (textBox7.Text.All(char.IsDigit) && textBox7.Text.Length == 10)
                                        {
                                            bool b = true;
                                            string[] lines = File.ReadAllLines(@"pass.txt", Encoding.Default);
                                            foreach (string line in lines)
                                            {
                                                if ((line).Split('|')[0].ToLower() == textBox1.Text.ToLower())
                                                {
                                                    b = false;
                                                    MessageBox.Show("Такой логин уже занят, придумайте другой.");
                                                }
                                            }
                                            if (b)
                                            {
                                                StreamWriter writer = new StreamWriter(@"regs.txt", true, Encoding.Default);
                                                writer.WriteLine(textBox4.Text + "|" + textBox5.Text + "|" + textBox6.Text + "|" + textBox7.Text + "|");
                                                writer.Close();
                                                StreamWriter logs = new StreamWriter(@"pass.txt", true, Encoding.Default);
                                                logs.WriteLine(textBox1.Text + "|" + textBox2.Text);
                                                logs.Close();
                                                textBox1.Text = "";
                                                textBox2.Text = "";
                                                textBox3.Text = "";
                                                textBox4.Text = "";
                                                textBox5.Text = "";
                                                textBox6.Text = "";
                                                textBox7.Text = "";
                                                MessageBox.Show("Вы успешно зарегистрировались. Вам доступен просмотр публикаций библиотеки, используя логин и пароль." +
                                                    " Ваша заявка на оформление читательского билета принята и будет обработана в ближайшее время.");
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            textBox7.Text = "";
                                            MessageBox.Show("Некорректный формат телефонного номера.");
                                        }
                                    }
                                    else
                                    {
                                        textBox6.Text = "";
                                        MessageBox.Show("Отчество может состоять только из букв.");
                                    }
                                }
                                else
                                {
                                    textBox5.Text = "";
                                    MessageBox.Show("Имя может состоять только из букв.");
                                }
                            }
                            else
                            {
                                textBox4.Text = "";
                                MessageBox.Show("Фамилия может состоять только из букв.");
                            }
                        }
                        else
                        {
                            textBox3.Text = "";
                            MessageBox.Show("Пароли не совпадают. Проверьте правильность ввода.");
                        }
                                 }
                    else
                    {
                        textBox2.Text = "";
                        textBox3.Text = "";
                        MessageBox.Show("Пароль может состоять только из букв и цифр и должен быть не менее 6 символов.");
                    }
                }
                else
                {
                    textBox1.Text = "";
                    MessageBox.Show("Логин может состоять только из букв и цифр.");
                }
            }
            else
            {
                MessageBox.Show("Ни одно из полей не может быть пустым.");
            }
        }
    }
}
