using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    [Serializable]
    public class Magazine:Publication
    {        
        public short release_num;
        public Magazine(string tittle, string publisher, string[] authors,  short release_num, int quantity_available, string rare_literature)
                                        : base(tittle, publisher, authors, quantity_available,  rare_literature)
        {
            
            this.release_num = release_num;
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
            return ($" Название журнала: {tittle}  \n Издательство: {publisher} \n Номер выпуска: {release_num}" +
                $"\n Авторы: {aut}  \n Количество в наличии: {quantity_available} \n Редкая ли литература: {rare} ");
        }
    }
}
