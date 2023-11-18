using Grocery.Repo.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories.Interface
{
    public interface IVendorRepository
    {
        public IEnumerable<Vendor> AllVendors();
        int AddVendor(Vendor vendor);
        Vendor? GetVendorById(int id);
        int UpdateVendor(int id, Vendor updatedVendor);
        Vendor Authenticate(Login vednor);
        public int DeleteVendor(int id);
    }
}
