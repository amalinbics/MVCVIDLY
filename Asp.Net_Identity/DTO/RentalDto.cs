using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.DTO
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}