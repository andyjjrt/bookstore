using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace bookstore.Models
{
    public class BookTxtRepository
    {
        private readonly string _app_data;
        public BookTxtRepository()
        {
            _app_data = HttpContext.Current.Server.MapPath("~/App_Data");
        }
        public List<Book> GetAll()
        {
            List<Book> books = new List<Book>();
            string[] files = Directory.GetFiles(_app_data, "*.txt", SearchOption.TopDirectoryOnly);
            foreach (string item in files)
            {
                string[] lines = File.ReadAllLines(item);
                books.Add(new Book()
                {
                    id = Int32.Parse(lines[0]),
                    Author = lines[1],
                    Price = Int32.Parse(lines[2]),
                });
            }

            return books;
        }
        public Book Get(int id)
        {   
            string fn = Path.Combine(_app_data, id.ToString() + ".txt");
            if(!File.Exists(fn)) return new Book();
            string[] lines = System.IO.File.ReadAllLines(fn);
            Book book = new Book()
            {
                id = Int32.Parse(lines[0]),
                Author = lines[1],
                Price = Int32.Parse(lines[2]),
            };

            return book;
        }
        public bool Create(Book book)
        {
            string fn = Path.Combine(_app_data, book.id.ToString() + ".txt");
            if (File.Exists(fn)) return false;
            string content = $"{book.id}\n{book.Author}\n{book.Price}";
            File.WriteAllText(fn, content);

            return true;
        }
        public bool Edit(Book book)
        {
            string fn = Path.Combine(_app_data, book.id.ToString() + ".txt");
            if (!File.Exists(fn)) return false;
            string content = $"{book.id}\n{book.Author}\n{book.Price}";
            File.WriteAllText(fn, content);

            return true;
        }
        public bool Delete(Book book)
        {
            string fn = Path.Combine(_app_data, book.id.ToString() + ".txt");
            if (!File.Exists(fn)) return false;
            File.Delete(fn);

            return true;
        }
    }
}