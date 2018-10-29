using Asp.Net_Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Asp.Net_Identity.ValidationAttributes
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipType.PayAsYouGo || customer.MemberShipTypeId == MemberShipType.NonMember)
                return ValidationResult.Success;
            if (customer.DOB == null)
                return new ValidationResult("Data of Birth is required");
            var age = DateTime.Now.Year - customer.DOB.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old to be a member");


        }
    }
}