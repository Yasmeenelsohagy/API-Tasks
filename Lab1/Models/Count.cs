namespace Lab1.Models
{
    public class Count
    {
        public  static int counter { get; set; } = 0;

        public int CalcCounter()
        {
            counter++;
            return counter;
        }
    }
}
