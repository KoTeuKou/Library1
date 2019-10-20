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
            Autorization authorize = new Autorization();
            MenuReader readerMenu = new MenuReader();
            MenuAdmin adminMenu = new MenuAdmin();           
            readerMenu.publications = libr;
            adminMenu.publications = libr;           
            adminMenu.readers = readers;
            Application.Run(authorize);
            if (authorize.DialogResult == DialogResult.OK)                
                Application.Run(readerMenu);
            else if (authorize.DialogResult == DialogResult.No)
                Application.Run(adminMenu);
        }
    }
}
