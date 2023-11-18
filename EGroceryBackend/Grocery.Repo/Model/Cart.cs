using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    [Index(nameof(CustomerId), IsUnique = true, Name = "Customer")]
    public class Cart 

    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int CartId { get; set; }

        //[Required, Column(TypeName = "decimal(10,2)")]
        //public decimal TotalAmount { get; set; }

        //Navigation Property
        //[ForeignKey("CustomerId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual User? Customer { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<CartItem>? CartDetails { get; set; }
    }
}