using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;
namespace Grocery.Repo.Model
{

    [Index(nameof(Id), IsUnique = true, Name = "WishlistProduct")]
    public class WishListItem
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int WishListId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal Quantity { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

       // Navigation Property

        //[ForeignKey("WishListId")]
        //[JsonIgnore]
        //public virtual WishList? WishListDetails { get; set; }

        //[ForeignKey("ProductId")]
        //[JsonIgnore]
        //public virtual Product? ProductDetails { get; set; }

    }
}