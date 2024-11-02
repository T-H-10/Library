using library.Entities;
using library.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly BookService _bookService= new BookService();
        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<List<Book>> Get()
        {
            List<Book> result=_bookService.GetBooks();
            if(result == null) { return NotFound(); }
            return Ok(result);
        }

        // GET api/<BooksController>/5
        [HttpGet("{code}")]
        public ActionResult<Book> GetById(int code)
        {
            Book result= _bookService.GetBook(code);
            if (result == null) { return NotFound(); }
            return Ok(result);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Book book)
        {
            return _bookService.PostBook(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{code}")]
        public ActionResult<bool> Put(int code, [FromBody] Book book)
        {
            return _bookService.PutBook(code, book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{code}")]
        public ActionResult<bool> Delete(int code)
        {
            return _bookService.DeleteBook(code);
        }
    }
}
