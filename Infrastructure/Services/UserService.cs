using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Models.Request;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services {
    public class UserService : IUserService {
        private readonly IAsyncRepository<Users> _userRepository;
        public UserService(IAsyncRepository<Users> userRepository) {
            _userRepository = userRepository;
        }
        public async Task<List<UserResponseModel>> getUsers() {
            var users = await _userRepository.GetAllAsync();
            var result = new List<UserResponseModel>();
            foreach (var user in users) {
                result.Add(
                    new UserResponseModel
                    {
                        Id = user.Id,
                        Fullname = user.Fullname
                    });
            }
            return result;
        }
        public async Task<UserDetailsResponseModel> getUserById(int id) {
            var user = await _userRepository.GetByIdAsync(id);
            var incomes = new List<SubIncomeResponseModel>();
            foreach (var income in user.Incomes) {
                incomes.Add(new SubIncomeResponseModel
                {
                    Id=income.Id,
                    Amount=income.Amount,
                    Description=income.Description,
                    IncomeDate=income.IncomeDate,
                    Remarks=income.Remarks
                });
            }
            var expenditures = new List<SubExpenditureResponseModel>();
            foreach (var expenditure in user.Expenditures) {
                expenditures.Add(new SubExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }
            var result = new UserDetailsResponseModel
            {
                Id = user.Id,
                Email=user.Email,
                Fullname=user.Fullname,
                JoinedOn=user.JoinedOn,
                Expenditures=expenditures,
                Incomes=incomes
            };
            return result;
        }
        public async Task<UserResponseModel> AddUser(UserRequestModel model) {
            var user = new Users
            {
                Email = model.Email,
                Fullname = model.Fullname,
                Password = model.Password,
                JoinedOn = model.JoinedOn
            };
            var addUser = await _userRepository.AddAsync(user);
            var userResponseModel = new UserResponseModel
            {
                Id=addUser.Id,
                Fullname=addUser.Fullname
            };
            return userResponseModel;
        }
        public async Task DeleteUser(int id) {
            var user = await _userRepository.GetByIdAsync(id);
            await _userRepository.DeleteAsync(user);
        }
        public async Task<UserResponseModel> UpdateUser(UpdateUserRequestModel model) {
            var updatedUser = new Users
            {
                Id=model.Id,
                Email = model.Email,
                Fullname = model.Fullname,
                Password = model.Password,
                JoinedOn = model.JoinedOn
            };
            await _userRepository.UpdateAsync(updatedUser);
            var userResponseModel = new UserResponseModel { 
                Id=updatedUser.Id,
                Fullname =updatedUser.Fullname
            };
            return userResponseModel;
        }
    }
}
