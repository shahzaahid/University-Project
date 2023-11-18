using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;
namespace Grocery.Repo.Model
{
    [Index(nameof(OrderId), IsUnique = false)]
    [Index(nameof (OrderId),nameof(ProductId), IsUnique = true, Name = "OrderProduct")]
    public class OrderItem : BaseEntity
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        [Required, Column(TypeName = "decimal(10,2)")]
        public decimal SubTotal { get; set; }

        //Nav Properties.

        //[ForeignKey("OrderId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual Order? OrderDetails { get; set; }

        //[ForeignKey("ProductId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual Product? ProductDetails { get; set; }
    }
}
