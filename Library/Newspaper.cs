using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    [Serializable]
    public class Newspaper:Publication
    {
        
        public Newspaper(string tittle, string publisher, string[] authors, int quantity_available,  string rare_literature)
                                        : base(tittle, publisher, authors, quantity_available, rare_literature)
        {          
        }
        public override string Show()
        {
            string aut = "";
            foreach (var a in authors)
            {
                aut += a + " ";
            }
            string rare = "";
            if (rare_literature == false)
            {
                rare = "Нет";
            }
            else rare = "Да";
            return ($" Название газеты: {tittle}  \n Издательство: {publisher}" +
                $"\n Авторы: {aut}  \n Количество в наличии: {quantity_available} \n Редкая ли литература: {rare} ");
        }
    }
    }

