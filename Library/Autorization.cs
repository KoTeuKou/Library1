using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Library
{
    public partial class Autorization : Form
    {
         string pathTextLogPass = @"pass.txt";

        public Autorization()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        Registration f = new Registration();
        private void button1_Click(object sender, EventArgs e)
        {
            string login;
            string password;

            if (File.Exists(pathTextLogPass))
            {
                string[] lines = File.ReadAllLines(pathTextLogPass, Encoding.Default);
                foreach (string line in lines)
                {
                    string[] linesDec =line.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                    login = linesDec[0];
                    password = linesDec[1];

                    if (login.ToLower() == tbxLogin.Text.ToLower() && password == tbxPasword.Text)
                    {
                        if (login.ToLower() == "admin")
                        {
                            Start2();
                        }
                        else
                        {
                            Start();
                        }

                    }
                        
                }
            }

          MessageBox.Show("Такого логина или пароля не существует. \n Повторите ввод или зарегистрируйтесь!");
        }

      

        void Start()
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        void Start2()
        {
            this.DialogResult = DialogResult.No;
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        

    }
}
