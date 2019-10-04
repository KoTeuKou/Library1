using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Library
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<Publication> libr = new List<Publication>(); //создание каталога из имеющихся уже книг
            libr = Publication.Input();       
            List<Reader> readers = new List<Reader>(); //создание списка существующих читателей
            readers = Reader.Input();            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);       
            Autorization form2 = new Autorization();
            MenuReader form1 = new MenuReader();
            MenuAdmin form3 = new MenuAdmin();           
            form1.publications = libr;
            form3.publications = libr;           
            form3.readers = readers;
            Application.Run(form2);
            if (form2.DialogResult == DialogResult.OK)                
                Application.Run(form1);
            else if (form2.DialogResult == DialogResult.No)
                Application.Run(form3);
        }
    }
}
