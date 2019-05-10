﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vividly.DTOs;

namespace Vividly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == MembershipType.Unknown || customer.MembershipTypeID == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            
            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of Birth is required");

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult(@"Customer should be at least 
                                                                            18 years old to go on a membership");

        }
    }
}