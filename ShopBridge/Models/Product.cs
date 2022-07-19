using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        [MaxLength(50,ErrorMessage = "Product Name should contain maximum 50 characters.")]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Display(Name ="Price (Rs.)")]
        public float Price { get; set; }

        [MaxLength(200, ErrorMessage = "Description should contain maximum 200 characters.")]
        public string Description { get; set; }


    }
}
