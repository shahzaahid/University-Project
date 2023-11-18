using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories
{
    public class VendorRepository: IVendorRepository
    {
        private readonly GroceryDBContext _context;
        public VendorRepository(GroceryDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Vendor> AllVendors()
        {
            return _context.Vendor.ToList();
        }
        public Vendor? GetVendorById(int id)
        {
            var vendor = _context.Vendor.FirstOrDefault(v => v.Id == id);
            if(vendor != null)
            {
                return vendor;
            }
            return null;
        }
        public int UpdateVendor(int id, Vendor updatedVendor)
        {
            var vendor = _context.Vendor.FirstOrDefault(v => v.Id == id);
            if(vendor != null)
            {
                _context.Entry(vendor).CurrentValues.SetValues(updatedVendor);
                _context.SaveChanges();
                return vendor.Id;
            }
            return 0;
        }

        public int AddVendor(Vendor vendor)
        {
            int vendorId = _context.Vendor.Add(vendor).Entity.Id;
            _context.SaveChanges();
            return(vendorId);
        }

        public Vendor Authenticate(Login vendor)
        {
            var validVendor = _context.Vendor.FirstOrDefault(u => u.EmailId == vendor.Email && u.Password == vendor.Password);

            if (validVendor != null)
            {
                return validVendor;
                
            }
            return null;
        }
        public int DeleteVendor(int id)
        {
            if (id > 0)
            {
                    var vendorToDelete = _context.Vendor.Find(id);
                    if (vendorToDelete != null)
                    {
                        _context.Vendor.Remove(vendorToDelete);
                        _context.SaveChanges();
                    return id;
                    }
                    else
                    {
                        // Vendor with the given id was not found
                        return 0;
                    }
               
            }
            else
            {
                // Invalid id, return an error code or throw an exception
                return -1; // Or any other appropriate error code
            }
        }

    }
}
