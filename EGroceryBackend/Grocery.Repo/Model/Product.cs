using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;


namespace Grocery.Repo.Model
{
    public class Product 
    {
        [key]
        [Required]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "Product Name is required")]
        public string? Name { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Product Brand is required")]
        public string? Brand { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Product Category is required")]
        public string? Category { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Product Units is required")]
        public string? Unit { get; set; } //EG. pounds, kilograms, pieces, etc.

        [Required]
        public int? PackSize { get; set; } //e.g., 500g, 1 liter, etc.

        [Required]
        public int VendorId { get; set; }

        [Required]
        public int AddedBy { get; set; }

        [Required]
        public double StockQty { get; set; } //The current quantity of the product available in the inventory.

        //Navigation Properties
        //[ForeignKey("VendorId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual Vendor? VendorTab { get; set; }

        //[ForeignKey("AddedBy"), DeleteBehavior(DeleteBehavior.Restrict)]

        //[JsonIgnore]
        //public virtual User? UserAdded { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<OrderItem>? OrderDetails { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<CartItem>? ProductDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<ProductImage>? ProductImages { get; set; }
    }

}
