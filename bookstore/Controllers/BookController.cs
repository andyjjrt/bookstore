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
        private BookTxtReepository _bookTxtReepository;

        public BookController()
        {
            _bookTxtReepository = new BookTxtReepository();  
        }

        // GET: Index
        public ActionResult Index()
        {
            List<Book> books = _bookTxtReepository.GetAll();
            return View(books);
        }

        // GET: Detail
        public ActionResult Detail(int id)
        {   
            Book book = _bookTxtReepository.Get(id);
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
            _bookTxtReepository.Create(book);
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            Book book = _bookTxtReepository.Get(id);
            return View(book);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            _bookTxtReepository.Edit(book);
            return RedirectToAction("Index");
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            Book book = _bookTxtReepository.Get(id);
            return View(book);
        }

        //Post: Delete
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            _bookTxtReepository.Delete(book);
            return RedirectToAction("Index");
        }
    }
}