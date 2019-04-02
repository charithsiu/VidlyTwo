using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyTwo.Models
{
    public class Min18IfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayasYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.BDate == null)
            {
                return new ValidationResult("Birthday is required");
            }
            var age = DateTime.Today.Year - customer.BDate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be atleast 18 years old to use this facility.");
            
           
        }
    }
}