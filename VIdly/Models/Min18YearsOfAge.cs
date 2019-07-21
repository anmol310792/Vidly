using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VIdly.Models
{
    public class Min18YearsOfAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknow || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Please Enter Birthdate");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Minimum Age for Membership is 18 years");
        }
    }
}