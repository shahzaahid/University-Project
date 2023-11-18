using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GroceryDBContext _context;
        public UserRepository(GroceryDBContext context)
        {
            _context = context;
        }
        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public int AddUserAddress(UserAddress userAddress)
        {
            _context.UsersAddress.Add(userAddress);
            _context.SaveChanges();
            return userAddress.Id;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<UserAddress> GetUserAddressById(int id)
        {
            return _context.UsersAddress.Where(user => user.UserId == id).ToList();  
        }
        public IEnumerable<User> GetUserById(int id)
        {
            var user = _context.Users.Where(user => user.Id == id).ToList();
            if(user != null)
            {
                return user;
            }
            return null;
        }

        public int UpdateRole(int id, Role role)
        {
            var updatedId = _context.Roles.Update(role).Entity.Id;
            _context.SaveChanges();
            return updatedId;
        }
        public int UpdateUser(int id, User user)
        {
            var updatedUser = _context.Users.Update(user).Entity.Id;
            _context.SaveChanges();
            return updatedUser;
        }
        public int DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user.Id;
            }
            return 0;
        }

        public User Authenticate(Login user)
        {
            var validUser = _context.Users.FirstOrDefault(u => u.EmailId == user.Email && u.Password == user.Password);

            if (validUser != null)
            {
                return validUser;
            }
            return null;
        }

        public string GetRoleById(int roleId)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == roleId);
            return role.RoleName;
        }
    }
}
