using System.ComponentModel.DataAnnotations;

namespace BlazorServer.AppLogic.Models
{
    public class ProductModel
    { 
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
    }
}
