﻿using AspNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace AspNetCore.Filters
{
    public class ValidFirstName : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context) // ilgili action çalışmadan önce çalışır. Executed çalıştıktan spnra mesela
        {
            var dictionary = context.ActionArguments.FirstOrDefault(I => I.Key == "customer");
            var customer = dictionary.Value as Customer;
            if (customer.FirstName == "Songül") 
            { 
                context.Result = new RedirectResult("/Home/Index"); 
            }

            //base.OnActionExecuting(context);
        }
    }
}
