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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _repo;

        public CategoryController(ICategoryService repo)
        {
            _repo = repo;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            /* IEnumerable<Category> list = _repo.GetAlIncludeSomething();*/
            return _repo.GetAll(b => b.Books).AsEnumerable();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IEnumerable<Category> Get(string id)
        {
            return _repo.GetOne(id, c=> c.Books);
        }
        [Author("Admin")]
        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post(Category cate)
        {
            cate.Id = Util.generateID();
            cate.CreateAt = DateTime.Now;
            _repo.Insert(cate);
            return Ok(new
            {
                message = "Add New Category Success !!!"
            });
        }
        [Author("Admin")]
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Category cate)
        {
            cate.Id = id;
            cate.UpdateAt = DateTime.Now;
            _repo.Update(cate);
        }

        [Author("Admin")]
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            IEnumerable<Category> cate = _repo.GetOne(id, c => c.Books);
            _repo.Remove(cate);
        }
    }
}
