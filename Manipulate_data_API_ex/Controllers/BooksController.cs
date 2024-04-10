using Manipulate_data_API_ex.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manipulate_data_API_ex.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_db.Books.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var result = _db.Books.Find(id);

            if (result == null) 
            {
                return NotFound($"The book with id {id} was not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostBook(Book book) 
        {
            var bookExist = _db.Books.Any(b => b.Id == book.Id);

            if (bookExist)
            {
                return BadRequest($"The book with id {book.Id} already exist.");
            }

            _db.Books.Add(book);
            _db.SaveChanges();

            return CreatedAtAction("GetBook",new { id = book.Id }, book);

            //return CreatedAtActionResult
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book) 
        {
            var bookExist = _db.Books.Find(id);

            if (bookExist == null)
            {
                return NotFound();
            }

            if (id != book.Id)
            {
                return BadRequest("You can not edit id!");
            }

            _db.Entry(bookExist).CurrentValues.SetValues(book);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult DeleteBook(int id)
        {
            var bookExist = _db.Books.Find(id);

            if (bookExist == null)
            {
                return BadRequest($"The book with id {id} already exist.");
            }

            _db.Books.Remove(bookExist);
            _db.SaveChanges();

            return NoContent();

        }
    }
}
