using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    public class UserAddress
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Address Type is Required")]
        public string? AddressType { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Address is Required")]
        public string? Address { get; set;}

        [Required, MaxLength(50, ErrorMessage = "Tehsil is Required"), MinLength(3, ErrorMessage = "Tehsil cannot be shorter than 3 chars")]
        public string? Tehsil { get; set; }

        [Required, MaxLength(50, ErrorMessage = "District is Required"), MinLength(3, ErrorMessage = "District cannot be shorter than 3 chars")]
        public string? District { get; set; }

        [Required, MaxLength(50, ErrorMessage = "Postoffice is Required"), MinLength(3, ErrorMessage = "PostOffice cannot be shorter than 3 chars")]
        public string? PostOffice { get; set; }

        [Required, MaxLength(6, ErrorMessage = "6 Digit pincode is required"), MinLength(6, ErrorMessage = "Enter 6 Digit Pincode")]
        public string? Pincode { get; set; }

        [Required, MaxLength(50, ErrorMessage = "State is Required"), MinLength(3, ErrorMessage = "State name cannot be shorter than 3 chars")]
        public string? State { get; set; }

        //Navigation Propertiess
        //[ForeignKey("UserId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual User? AddedUser { get;set; }

        //[JsonIgnore]
        //public virtual ICollection<Vendor>? Addresses { get; set; }

    }
}
