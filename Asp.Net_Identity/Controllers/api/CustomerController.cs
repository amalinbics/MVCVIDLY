using Asp.Net_Identity.DTO;
using Asp.Net_Identity.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
namespace Asp.Net_Identity.Controllers.api
{
    
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetCustomer()
        {
            return Ok(_context.Customers.Include(c => c.MemberShipType).ToList().Select(Mapper.Map<Customer, CustomerDto>));
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.Id == id);
            _context.Customers.Remove(customerInDb);
            return Ok();
        }
    }
}
