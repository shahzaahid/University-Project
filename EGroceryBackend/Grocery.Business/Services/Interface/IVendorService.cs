using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Business.Services.Interface
{
    public interface IVendorService
    {
        public IEnumerable<Vendor> AllVendors();
        int AddVendor(Vendor vendor);
        Vendor? GetVendorById(int id); 
        int UpdateVendor(int id, Vendor updatedVendor);
        Vendor Authenticate(Login vendor);
        public int DeleteVendor(int id);
    }
}