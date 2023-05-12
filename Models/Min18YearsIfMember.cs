using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace blackBox.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            //check if MembershipId is 0 (to avoid error msg diplayed too early) or 1 (pay as you go plan) | not triggered assume user has membership
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            //check if birthdate is null (validationResult display Birthdate needs to be provided!)
            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birthdate is required to have a membership plan");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

           return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer needs to be 18 or older to have a membership plan");
            //get age from user, their age.Year - today.Year |ternary operater check age >= 18 ? validation.success : validationResult("age 18 or over to be member")
        }
    }
}