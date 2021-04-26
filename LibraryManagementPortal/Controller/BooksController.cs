using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementPortal.Data;
using LibraryManagementPortal.Models;
using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using ManagerStudent.Fillter;

namespace LibraryManagementPortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;
/*        [Author("Admin")]*/

        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBook()
        {
            return _repo.GetAll(b => b.Auth, b => b.Cate).Select(b => new Book
            {
                Id = b.Id,
                Name = b.Name,
                Auth = b.Auth != null ? new Author
                {
                    Id = b.Auth.Id,
                    Name = b.Auth.Name,
                    Description = b.Auth.Description
                } : null,
                Cate = b.Cate != null ? new Category
                {
                    Id = b.Cate.Id,
                    Name = b.Cate.Name,
                    Description = b.Cate.Description
                } : null,
                UpdateAt = b.UpdateAt,
                CountBook = b.CountBook,
                CreateAt = b.CreateAt
            });
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IEnumerable<Book> GetBook(string id)
        {
            var book =_repo.GetOne(id, b=>b.Auth, b=>b.Cate, b=>b.OrderDetail);
            return book;
        }
        [Author("Admin")]
        // PUT: api/Books/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book book)
        {
            book.Id = id;
            _repo.Update(book);

        }
        [Author("Admin")]
        // POST: api/Books
        [HttpPost]
        public void Post(Book book)
        {
            book.Id = Util.generateID();
            book.CreateAt = DateTime.Now;
            _repo.Insert(book);
        }
        [Author("Admin")]
        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public void DeleteBook(string id)
        {
            IEnumerable<Book> book = _repo.GetOne(id, b=> b.Auth, b => b.Cate, b => b.OrderDetail);
            _repo.Remove(book);
        }

/*        private bool BookExists(string id)
        {
            return _repo.Any(e => e.Id == id);
        }*/
    }
}
