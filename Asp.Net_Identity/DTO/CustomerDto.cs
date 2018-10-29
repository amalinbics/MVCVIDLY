using Asp.Net_Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.DTO
{
    public class CustomerDto
    {
        //test test
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MemberShipTypeId { get; set; }

        public MemberShipTypeDto MemberShipType { get; set; }

        public DateTime? DOB { get; set; }
    }
}