using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _repo;
        /*        [Author("Admin")]*/
        public OrderController(IOrderService repo)
        {
            _repo = repo;
        }
        // GET: api/<OrderDetailController>
        [HttpGet]
        [Author("Admin")]
        public IEnumerable<Order> GetOrderDetail()
        {
            var borrowRequests = _repo.GetAll(b => b.OrderDetail, b => b.User).AsEnumerable();
            return borrowRequests;            
        }

        // GET api/<OrderDetailController>/5
        [HttpGet("{id}")]
        public IEnumerable<Order> Get(string id)
        {
            return _repo.GetOne(id, o=> o.OrderDetail, o=>o.User).AsEnumerable();
        }
        [HttpGet("user/{id}")]
        public IEnumerable<Order> GetAllByUser(string id)
        {
            return _repo.GetAllOrderByUser(id, b => b.User, b => b.OrderDetail).Where(b => b.UserId == id).AsEnumerable();
        }
        // POST api/<OrderDetailController>
        [HttpPost("{userId}")]
        public IActionResult Insert(Order order, string userId)
        {
            var checkBorrowInMonth = _repo.GetAll().Count(br => br.UserId == userId && br.CreateAt.Month == DateTime.Now.Month);
            Console.WriteLine(checkBorrowInMonth);
            if (checkBorrowInMonth < 3)
            {
                if (order.OrderDetail.Count <= 5)
                {
                    order.Id = Util.generateID();
                    order.Name= Util.generateID();
                    order.CreateAt = DateTime.Now;
                    order.Status = true;
                    order.UserId = userId;
                    _repo.Insert(order);
                    return Ok(order);
                }
                return Ok(
                new
                {
                    error = "Ban ko the muon 5 cuon sach 1 luc"
                });
            }
            return Ok(
                new
                {
                    error = "Ban ko the muon qua 3 lan trong 1 thang"
                });
        }

        // PUT api/<OrderDetailController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Order order)
        {
            order.UpdateAt = DateTime.Now;
            _repo.Update(order);
        }

        // DELETE api/<OrderDetailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
