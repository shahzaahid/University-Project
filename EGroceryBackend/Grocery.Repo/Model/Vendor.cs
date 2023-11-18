using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Grocery.Repo.Model
{
    [Index(nameof(MobileNo), IsUnique = true, Name = "MobileLogger"), Index(nameof(EmailId), Name = "EmailLogger", IsUnique = true)]
    public class Vendor
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Company Name is Required")]
        public string? CompanyName { get; set; }

        [Required,MaxLength(14, ErrorMessage = "FSSAI number should be 14 characters long")]
        public string? FSSAI { get; set; }

        [Required, MaxLength(15, ErrorMessage = "GST number should be 15 characters long")]
        public string? GST { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Mobile No is Required")]
        [MinLength(10, ErrorMessage = "Enter 10 Digits Mobile Number")]
        public string? MobileNo { get; set; }

        [Required, MaxLength(60, ErrorMessage = "Email Id is Required")]
        [MinLength(10, ErrorMessage = "Email Id cannot be shorter than 10 characters")]
        public string? EmailId { get; set; }

        [Required, MaxLength(40, ErrorMessage = "Password field is required")]
        public string? Password { get; set; }

     
        //Navigation Properties
      
    }
}
