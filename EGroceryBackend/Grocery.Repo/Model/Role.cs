using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Linq;
namespace Grocery.Repo.Model
{
    public class Role
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30, ErrorMessage = "Role Name is required")]
        public string? RoleName { get; set; }

        [Required, MaxLength(200, ErrorMessage = "Role Description is required")]
        public string? RoleDescription { get; set; }

        //Navigation properties
        //[JsonIgnore]
        //public virtual ICollection<User>? Roles{ get; set; }
    }
}
