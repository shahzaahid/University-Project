using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    [Index(nameof(MobileNo), IsUnique = true, Name = "MobileLogger"), Index(nameof(EmailId), Name = "EmailLogger", IsUnique = true)]
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30, ErrorMessage = "First Name is Required")]
        public string? FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "Middle name cannot be more than 30 Characters")]
        public string? MiddleName { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Last Name is Required")]
        public string? LastName { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Parentage is Required")]
        public string? Parentage { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Mobile No is Required")]
        [MinLength(10, ErrorMessage = "Enter 10 Digits Mobile Number")]
        public string? MobileNo { get; set; }

        [Required, MaxLength(60, ErrorMessage = "Email Id is Required")]
        [MinLength(10, ErrorMessage = "Email Id cannot be shorter than 10 characters")]
        public string? EmailId { get; set; }

        [Required, MaxLength(40, ErrorMessage = "Password field is required")]
        public string? Password { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Gender is Required")]
        public string? Gender { get; set; } // Change the data type to varchar

        public DateOnly Dob { get; set; }

        public int AddedBy { get; set; }

        [MaxLength(30, ErrorMessage = "Status is required")]
        public string? Status { get; set; }

        //Navigation Properties
        //[ForeignKey("RoleId"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual Role? Roles { get; set; }

        //[ForeignKey("AddedBy"), DeleteBehavior(DeleteBehavior.Restrict)]
        //[JsonIgnore]
        //public virtual User? UserAdded { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<UserAddress>? AddedUser { get; }

        //[JsonIgnore]
        //public virtual ICollection<User>? UserAssigned { get; set; }

        //[JsonIgnore]
        //public virtual Vendor? VendorDetails { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Cart>? Customer { get; set; }
    }
}
