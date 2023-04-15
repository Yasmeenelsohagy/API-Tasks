using System.ComponentModel.DataAnnotations;

namespace Lab1.Validations
{
    public class PublishedDateMustBeInPastAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is DateTime date && date < DateTime.Now;
        }
    }
}
