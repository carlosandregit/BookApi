using BookApi.Model;
using BookApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Book>> GetBooks()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _repository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var createBook = await _repository.Create(book);
            return CreatedAtAction(nameof(GetBook), new { id = createBook.IdBook }, createBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var deleteBook = await _repository.Get(id);

            if (deleteBook == null)
                return NotFound();

            await _repository.Delete(deleteBook.IdBook);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutBook(int id, [FromBody] Book book)
        {
            if (id != book.IdBook)
                return BadRequest();

            await _repository.Upadte(book);
            return NoContent();
        }

    }
}
