using Grocery.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Business.Services.Interface
{
    public interface IUserService
    {
        int AddUser(User user);
        int UpdateRole(int id, Role role);
        IEnumerable<User> GetAllUsers();
        int AddUserAddress(UserAddress userAddress);
        IEnumerable<UserAddress> GetUserAddressById(int id);
        int DeleteUser(int id);
        int UpdateUser(int id, User user);
        User Authenticate(Login user);
        string GetRoleById(int roleId);
        IEnumerable<User> GetUserById(int id);
    }

}
