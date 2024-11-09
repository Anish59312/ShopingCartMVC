using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ShopingCartMVC.Models
{
    public class Products
    {
        [DisplayName("Category Id")]
        public byte CategoryId { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Product Id")]
        public string ProductId { get; set; }

        [DisplayName("Product Name")]
        [MinLength(3, ErrorMessage = "Product Name should have at least 3 characters")]
        [StringLength(100, ErrorMessage = "Product Name should not exceed 100 characters")]
        public string ProductName { get; set; }

        [Range(0, int.MaxValue)]
        [DisplayName("Quantity Available")]
        public int QuantityAvailable { get; set; }
    }

}
