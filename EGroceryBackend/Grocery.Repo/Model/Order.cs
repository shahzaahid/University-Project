using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    public class Order 
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string? CustomerName { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? State { get; set; }

        [Required, Column(TypeName = "Decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Order Status is required")]
        public string? Status { get; set; }
        [Required]
        public string? Month  { get; set; }

    }
}
