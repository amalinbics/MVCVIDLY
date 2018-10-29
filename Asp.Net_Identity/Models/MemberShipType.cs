using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.Models
{
    public class MemberShipType
    {
        public byte Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationMonth { get; set; }
        public byte Discount { get; set; }

        public readonly static int NonMember = 0;
        public readonly static int PayAsYouGo = 1;
    }
}