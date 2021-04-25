using ApplicationCore.Models.Request;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces {
    public interface IUserService {
        Task<List<UserResponseModel>> getUsers();
        Task<UserDetailsResponseModel> getUserById(int id);
        Task<UserResponseModel> AddUser(UserRequestModel model);
        Task DeleteUser(int id);
        Task<UserResponseModel> UpdateUser(UpdateUserRequestModel model);
    }
}
