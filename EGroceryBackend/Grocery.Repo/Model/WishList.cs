using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    [Index(nameof(CustomerId), IsUnique = true, Name = "WishListCustomer")]
    public class WishList : BaseEntity
    {
        [Required]
        public int CustomerId { get; set; }
        public int WishlistId { get; set; }
        //[Required, Column(TypeName = "decimal(10,2)")]
        //public decimal TotalAmount { get; set; }

        //Navigation Property
        //[ForeignKey("CustomerId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual User? Customer { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<WishListItem>? WishListDetails { get; set; }
    }
}