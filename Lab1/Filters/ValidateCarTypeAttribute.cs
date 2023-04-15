using Microsoft.AspNetCore.Mvc.Filters;
using Lab1.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Filters
{
    public class ValidateCarTypeAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Car? car = context.ActionArguments["car"] as Car;
            var regex = new Regex("^(Electric,Gas,Diesel and Hypird)$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2));

            if (car == null && !regex.IsMatch(car.type) )
            {
                context.ModelState.AddModelError("type", "Type isn't available");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
