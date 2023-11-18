using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grocery.Repo.Model
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        //[Required]
        //public DateTime CreatedOn { get; set; }

        //[Required]
        //public DateTime UpdatedOn { get; set; }

        //public BaseEntity()
        //{
        //    CreatedOn = DateTime.UtcNow;
        //    UpdatedOn = DateTime.UtcNow;
        //}
    }
}