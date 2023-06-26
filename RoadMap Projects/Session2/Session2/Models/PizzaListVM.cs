using Session2.Constants;

namespace Session2.Models
{
    public class PizzaListVM
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public PizzaSize Size { get; set; }
        public double Price { get; set; }
    }
}
