using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.DTOs
{
    public class Item
    {
        public string? Name { get; set; }

        public string? Brand { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Unit { get; set; } //EG. pounds, kilograms, pieces, etc.

        public string? PackSize { get; set; } //e.g., 500g, 1 liter, etc.

        public int VendorId { get; set; }

        public int AddedBy { get; set; }
        public object TotalAmount { get; internal set; }
    }
}
