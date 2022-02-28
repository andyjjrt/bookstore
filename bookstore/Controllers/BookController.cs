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
        private BookTxtRepository _bookTxtRepository;

        public BookController()
        {
            _bookTxtRepository = new BookTxtRepository();  
        }

        // GET: Index
        public ActionResult Index()
        {
            List<Book> books = _bookTxtRepository.GetAll();
            return View(books);
        }

        // GET: Detail
        public ActionResult Detail(int id)
        {   
            Book book = _bookTxtRepository.Get(id);
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
            bool success = _bookTxtRepository.Create(book);
            if(!success) return View(book);
            return RedirectToAction("Index");
        }

        // GET: Edit
        public ActionResult Edit(int id)
        {
            Book book = _bookTxtRepository.Get(id);
            return View(book);
        }

        // POST: Edit
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            bool success = _bookTxtRepository.Edit(book);
            if (!success) return View(book);
            return RedirectToAction("Index");
        }

        // GET: Delete
        public ActionResult Delete(int id)
        {
            Book book = _bookTxtRepository.Get(id);
            return View(book);
        }

        //Post: Delete
        [HttpPost]
        public ActionResult Delete(Book book)
        {
            bool success = _bookTxtRepository.Delete(book);
            if(!success) return View(book);
            return RedirectToAction("Index");
        }
    }
}