using Asp.Net_Identity.DTO;
using Asp.Net_Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Asp.Net_Identity.Controllers.api
{
    public class RentalController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
       public IHttpActionResult Save(RentalDto rentalDto)
        {

            var customer = _context.Customers.Single(c => c.Id == rentalDto.CustomerId);

            var Movies = _context.Movies.Where(
                m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (var item in Movies)
            {
                if (item.NoInAvailable == 0)
                    return BadRequest("Movie is not Available");

                var rental = new Rental {
                    Customer = customer,
                    Movie = item,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }
            _context.SaveChanges();
          
            return Ok();
        }

    }
}
