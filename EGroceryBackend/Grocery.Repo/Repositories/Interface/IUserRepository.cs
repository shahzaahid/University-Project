using Grocery.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Repo.Repositories.Interface
{
    public interface IUserRepository
    {
        int AddUser(User user);
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetUserById(int id);
        IEnumerable<UserAddress> GetUserAddressById(int id);
        int UpdateRole(int id, Role role);
        int AddUserAddress(UserAddress userAddress);
        int DeleteUser(int id);
        int  UpdateUser(int id, User user);
        User Authenticate(Login user);
        string GetRoleById(int roleId);
    }
}
