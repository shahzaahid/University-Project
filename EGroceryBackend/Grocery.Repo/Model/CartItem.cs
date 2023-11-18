using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Grocery.Repo.Model
{
    [Index(nameof(Id), IsUnique = true, Name = "CartProduct")]
    public class CartItem
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        // Navigation Properties

        //[ForeignKey("CartId")]
        //[JsonIgnore]
        //public virtual Cart? CartDetails { get; set; }

        //[ForeignKey("ProductId")]
        //[JsonIgnore]
        //public virtual Product? ProductDetails { get; set; }
    }
}
