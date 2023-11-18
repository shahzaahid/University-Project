using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories;
using Grocery.Repo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Business.Services
{
    public class VendorService: IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        public VendorService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;   
        }
        public IEnumerable<Vendor> AllVendors()
        {
            return _vendorRepository.AllVendors();
        }
        public int AddVendor(Vendor vendor)
        {
            return _vendorRepository.AddVendor(vendor); 
        }

       
        public Vendor? GetVendorById(int id)
        {
            return _vendorRepository.GetVendorById(id);
        }
        public int UpdateVendor(int id, Vendor updatedVendor)
        {
            return _vendorRepository.UpdateVendor(id, updatedVendor);
        }

        public Vendor Authenticate(Login vendor)
        {
            return _vendorRepository.Authenticate(vendor);
        }

        public int DeleteVendor(int id)
        {
            return _vendorRepository.DeleteVendor(id);
        }
    }

}
