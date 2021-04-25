using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Infrastructure.Services {
    public class IncomeService : IIncomeService {
        private readonly IAsyncRepository<Incomes> _incomeRepository;
        public IncomeService(IAsyncRepository<Incomes> incomeRepository) {
            _incomeRepository = incomeRepository;
        }
        public async Task<List<IncomeResponseModel>> getIncomes() {
            var incomes = await _incomeRepository.GetAllAsync();
            var result = new List<IncomeResponseModel>();
            foreach (var inc in incomes) {
                result.Add(
                    new IncomeResponseModel
                    {
                        Id = inc.Id,
                        UserId=inc.UserId,
                        Amount=inc.Amount,
                        Description=inc.Description,
                        IncomeDate=inc.IncomeDate,
                        Remarks=inc.Remarks
                    });
            }
            return result;
        }
        public async Task<IncomeResponseModel> AddIncome(IncomeRequestModel model) {
            var income = new Incomes
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                IncomeDate = model.IncomeDate,
                Remarks = model.Remarks
            };
            var addIncome = await _incomeRepository.AddAsync(income);
            var incomeResponseModel = new IncomeResponseModel
            {
                Id = addIncome.Id,
                UserId = addIncome.UserId,
                Amount = addIncome.Amount,
                Description = addIncome.Description,
                IncomeDate = addIncome.IncomeDate,
                Remarks = addIncome.Remarks
            };
            return incomeResponseModel;
        }
        public async Task DeleteIncome(int id) {
            var income = await _incomeRepository.GetByIdAsync(id);
            await _incomeRepository.DeleteAsync(income);
        }
        public async Task<IncomeResponseModel> UpdateIncome(UpdateIncomeRequestModel model) {
            var updatedIncome = new Incomes
            {
                Id = model.Id,
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                IncomeDate = model.IncomeDate,
                Remarks = model.Remarks
            };
            await _incomeRepository.UpdateAsync(updatedIncome);
            var incomeResponseModel = new IncomeResponseModel
            {
                Id = updatedIncome.Id,
                UserId = updatedIncome.UserId,
                Amount = updatedIncome.Amount,
                Description = updatedIncome.Description,
                IncomeDate = updatedIncome.IncomeDate,
                Remarks = updatedIncome.Remarks
            };
            return incomeResponseModel;
        }
    }
}
