using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;
using Session2.Constants;

namespace Session2.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PizzaSize Size { get; set; }
        
        [Range(100,double.MaxValue,ErrorMessage = "Price should be greater than ₹100")]
        public double Price { get; set; }
    }
}
