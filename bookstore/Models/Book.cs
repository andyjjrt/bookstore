using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class Book
    {
        public int id;
        public string Author;
        public int Price;

        public Book()
        {

        }
        public Book(int _id, string author, int price)
        {
            id = _id;
            Author = author;
            Price = price; 
        }
    }
}