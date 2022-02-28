using bookstore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookstore.Controllers
{
    public class BookController : Controller
    {

        // GET: Index
        public ActionResult Index()
        {
            List<Book> books = new List<Book>();
            string[] files = Directory.GetFiles(Server.MapPath("~/App_Data"), "*.txt", SearchOption.TopDirectoryOnly);
            foreach (string item in files)
            {
                string[] lines = System.IO.File.ReadAllLines(item);
                books.Add(new Book()
                {
                    id = Int32.Parse(lines[0]),
                    Author = lines[1],
                    Price = Int32.Parse(lines[2]),
                });
            }
            return View(books);
        }

        // GET: Detail
        public ActionResult Detail(int id)
        {   
            string[] lines = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/" + id + ".txt"));
            Book book = new Book()
            {
                id = Int32.Parse(lines[0]),
                Author = lines[1],
                Price = Int32.Parse(lines[2]),
            };
            return View(book);
        }

        // GET: Create
        public ActionResult Create()
        {
            Book book = new Book();
            return View(book);
        }

        // POST: Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            string content = $"{book.id}\n{book.Author}\n{book.Price}";
            System.IO.File.WriteAllText(Server.MapPath("~/App_Data/" + book.id + ".txt"), content);

            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            string[] lines = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/" + id + ".txt"));
            Book book = new Book()
            {
                id = Int32.Parse(lines[0]),
                Author = lines[1],
                Price = Int32.Parse(lines[2]),
            };
            return View(book);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            string content = $"{book.id}\n{book.Author}\n{book.Price}";
            System.IO.File.WriteAllText(Server.MapPath("~/App_Data/" + book.id + ".txt"), content);

            return RedirectToAction("Index");
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            string[] lines = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/" + id + ".txt"));
            Book book = new Book()
            {
                id = Int32.Parse(lines[0]),
                Author = lines[1],
                Price = Int32.Parse(lines[2]),
            };
            return View(book);
        }

        //Post: Delete
        [HttpPost]
        public ActionResult Delete(FormCollection form)
        {
            string Id = form["id"];
            string fn = Server.MapPath("~/App_Data/" + Id + ".txt");
            if (System.IO.File.Exists(fn))
            {
                System.IO.File.Delete(fn);
            }
            return RedirectToAction("Index");
        }
    }
}