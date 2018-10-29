using Asp.Net_Identity.Models;
using Asp.Net_Identity.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        [Display(Name = "SubScribe?")]
        public bool IsSubscribedToNewsLetter { get; set; }
       

        [Display(Name = "MemberShip Type")]
        public byte MemberShipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DOB { get; set; }

        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
    }
}