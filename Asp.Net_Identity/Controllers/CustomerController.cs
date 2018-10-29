using Asp.Net_Identity.DTO;
using Asp.Net_Identity.Models;
using Asp.Net_Identity.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.Net_Identity.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var customerViewModel = new CustomerViewModel
            {
                Id = 0,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm",customerViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var customerViewModel = new CustomerViewModel
            {

                Id = customer.Id,
                Name = customer.Name,
                MemberShipTypeId = customer.MemberShipTypeId,
                IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter,
                DOB = customer.DOB,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };
            return View("CustomerForm",customerViewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                var customerViewModel = new CustomerViewModel
                {
                    Id = customerDto.Id,
                    Name = customerDto.Name,
                    MemberShipTypeId = customerDto.MemberShipTypeId,
                    IsSubscribedToNewsLetter = customerDto.IsSubscribedToNewsLetter,
                    DOB = customerDto.DOB,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };
                return View(customerViewModel);
            }
            
            if (customerDto.Id == 0)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                _context.Customers.Add(customer);
            }                
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customerDto.Id);
                Mapper.Map(customerDto,customerInDb);
            }
            _context.SaveChanges();

            return RedirectToAction("Index");            
            
        }
    }
}