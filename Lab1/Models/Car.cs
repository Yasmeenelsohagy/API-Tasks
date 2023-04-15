using Lab1.Validations;
namespace Lab1.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Name { get; set; }=string.Empty;
        public int Model { get; set; }
        public double price  { get; set; }
        public string type { get; set; } = string.Empty;

        [PublishedDateMustBeInPast]
        public DateTime ProductionDate { get; set; }

    }

 
}
