using Grocery.Business.Services.Interface;
using Grocery.Repo.Model;
using Grocery.Repo.Repositories.Interface;
using System;


namespace Grocery.Business.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

       
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public IEnumerable<UserAddress> GetUserAddressById(int id)
        {
            return _userRepository.GetUserAddressById(id);  
        }
        public IEnumerable<User> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public int UpdateRole(int id, Role role)
        {
            return _userRepository.UpdateRole(id, role);
        }
        public int  UpdateUser(int id, User user)
        {
            return _userRepository.UpdateUser(id, user);
        }
        public int DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
        public int AddUserAddress(UserAddress userAddress)
        {
            return _userRepository.AddUserAddress(userAddress);
        }

        public User Authenticate(Login user)
        {
            return _userRepository.Authenticate(user);
        }

        public string GetRoleById(int roleId)
        {
            return _userRepository.GetRoleById(roleId);
        }
    }
}
