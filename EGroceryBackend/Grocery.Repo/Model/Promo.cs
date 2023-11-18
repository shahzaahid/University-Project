using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    public class Promo : BaseEntity
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public double DiscountPercentage { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public int UpdatedBy { get; set; }

        //Navigation Properties
        [ForeignKey("ProductId"), DeleteBehavior(DeleteBehavior.Restrict)]
        [JsonIgnore]
        public virtual Product? PromoProduct { get; set; }

        [ForeignKey("CreatedBy"), DeleteBehavior(DeleteBehavior.Restrict)]
        [JsonIgnore]
        public virtual User? AddedUser { get; set; }

        [ForeignKey("UpdatedBy"), DeleteBehavior(DeleteBehavior.Restrict)]
        [JsonIgnore]
        public virtual User? UserAssigned { get; set; }
    }
}
