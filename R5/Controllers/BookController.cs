using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using R5.Models;
using R5.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace R5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BookController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<BookModel> Get()
        {
            return _repository.GetAll(b => b.Author, b => b.Category).Select(b => new BookModel
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author != null ? new AuthorModel
                {
                    Id = b.Author.Id,
                    Name = b.Author.Name
                } : null,
                Category = b.Category != null ? new CategoryModel
                {
                    Id = b.Category.Id,
                    Name = b.Category.Name
                } : null
            });
        }

        // GET: api/<BookController>?authorId=[id]
        [HttpGet("author")]
        public IEnumerable<Book> GetByAuthorId(int authorId)
        {
            return _repository.GetAllByAuthorId(authorId);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookController>
        [HttpPost]
        public ActionResult Post(BookInputModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var entity = new Book
                {
                    Title = model.Title,
                    AuthorId = model.AuthorId,
                    CategoryId = model.CategoryId,
                    CreatedDate = DateTime.Now
                };
                _repository.Insert(entity);

                return new JsonResult(entity);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
