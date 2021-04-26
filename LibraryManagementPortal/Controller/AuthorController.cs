using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;
using LibraryManagementPortal.Repositories;
using LibraryManagementPortal.Utility;
using ManagerStudent.Fillter;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryManagementPortal.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _repo;

        public AuthorController(IAuthorRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _repo.GetAll(b => b.Books).AsEnumerable();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IEnumerable<Author> Get(string id)
        {
            return _repo.GetOne(id, a=>a.Books).AsEnumerable();
        }

        [Author("Admin")]
        // POST api/<CategoryController>
        [HttpPost]
        public void Post(Author author)
        {
            author.Id = Util.generateID();
            author.CreateAt = DateTime.Now;
            _repo.Insert(author);
        }
        [Author("Admin")]
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Author author)
        {
            author.Id = id;
            author.UpdateAt = DateTime.Now;
            _repo.Update(author);
        }
        [Author("Admin")]
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            IEnumerable<Author> author = _repo.GetOne(id, a => a.Books);
            _repo.Remove(author);
        }
    }
}
