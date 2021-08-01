using System;
using System.Collections.Generic;
using System.Linq;
using Books.Models;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private static List<Book> _books = new()
       {
        new Book{id = Guid.NewGuid(), title = "Война и мир", author = "Толстой Л.Н.",genre = "Исторические произведение"},
        new Book{id = Guid.NewGuid(), title = "Отцы и дети", author = "Тургенев И.С.",genre = "Роман"},
        new Book{id = Guid.NewGuid(), title = "Декабристы", author = "Толстой Л.Н.",genre = "Исторические произведение"},
        new Book{id = Guid.NewGuid(), title = "Бедная Лиза", author = "Карамзин Н.М.",genre = "Повесть"},
        new Book{id = Guid.NewGuid(), title = "Хаджи-Мурат", author = "Толстой Л.Н.",genre = "Исторические произведение"},
        };
        
            // GET
        [HttpGet]
        public List<Book> Get()
        {
            return _books;
        }

        [HttpGet("{author}")]
        public List<Book> Get(string author)
        {
            List<Book> foundBooks = _books.FindAll(item => item.author==author);
            return foundBooks;
        }
        
        [HttpPost]
        public void Post([FromBody]Book value)
        {
            _books.Add(value);
        }

        [HttpDelete("{author}")]
        public ActionResult Delete(string author, string title)
        {
            Guid passId = default;
            List<Book> foundBooks = _books.FindAll(item => item.author==author && item.title == title);
            foreach (var book in foundBooks)
            {
                passId = book.id;
            }
            _books.Remove(_books.Single(item=>item.id==passId));
            return Ok();
        }
    }
}