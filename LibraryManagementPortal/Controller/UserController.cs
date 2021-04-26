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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAll(b => b.Orders).AsEnumerable();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IEnumerable<User> Get(string id)
        {
            return _repo.GetOne(id, o=> o.Orders).AsEnumerable();
        }
        [Author("Admin")]
        // POST api/<CategoryController>
        [HttpPost]
        public void Post(User user)
        {
            user.Id = Util.generateID();
            user.CreateAt = DateTime.Now;
            _repo.Insert(user);
        }
        [Author("Admin")]
        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User user)
        {
            user.Id = id;
            user.UpdateAt = DateTime.Now;
            _repo.Update(user);
        }
        [Author("Admin")]
        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            IEnumerable<User> user = _repo.GetOne(id, u => u.Orders);
            _repo.Remove(user);
        }
    }
}
