using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Library
{
    [Serializable] //xml & binary
    [DataContract] //json
    public  class Book : Publication
     {            
         [DataMember]
        public new List<string> id = new List<string>();
        [DataMember]
       public string genre;
       [DataMember]
       public short date_of_written;

       public Book()
       {}

       public Book(string tittle, string publisher, string[] authors,string genre, short date_of_written, int quantity_available, string rare_literature)
                                        : base(tittle, publisher, authors, quantity_available, rare_literature)
        {            
            
            this.genre = genre;
            this.date_of_written = date_of_written;
            for (int i = 0; i < quantity_available; i++) {
                id.Add(tittle + i); }
            
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
            return ($" Название книги: {tittle}  \n Издательство: {publisher} \n Жанр: {genre}" +
                $"\n Авторы: {aut} \n Год написания книги: {date_of_written}  \n Количество в наличии: {quantity_available}" +
                $"\n Редкая ли литература: {rare} ");            
        }
       
    }
}
