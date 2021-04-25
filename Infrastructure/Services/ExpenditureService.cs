using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services {
    public class ExpenditureService : IExpenditureService {
        private readonly IAsyncRepository<Expenditures> _expenditureRepository;
        public ExpenditureService(IAsyncRepository<Expenditures> expenditureRepository) {
            _expenditureRepository = expenditureRepository;
        }
        public async Task<List<ExpenditureResponseModel>> getExpenditures() {
            var expenditures = await _expenditureRepository.GetAllAsync();
            var result = new List<ExpenditureResponseModel>();
            foreach (var exp in expenditures) {
                result.Add(
                    new ExpenditureResponseModel
                    {
                        Id = exp.Id,
                        UserId = exp.UserId,
                        Amount = exp.Amount,
                        Description = exp.Description,
                        ExpDate = exp.ExpDate,
                        Remarks = exp.Remarks
                    });
            }
            return result;
        }
        public async Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel model) {
            var expenditure = new Expenditures
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            var addExpenditure = await _expenditureRepository.AddAsync(expenditure);
            var expenditureResponseModel = new ExpenditureResponseModel
            {
                Id = addExpenditure.Id,
                UserId = addExpenditure.UserId,
                Amount = addExpenditure.Amount,
                Description = addExpenditure.Description,
                ExpDate = addExpenditure.ExpDate,
                Remarks = addExpenditure.Remarks
            };
            return expenditureResponseModel;
        }
        public async Task DeleteExpenditure(int id) {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);
            await _expenditureRepository.DeleteAsync(expenditure);
        }
        public async Task<ExpenditureResponseModel> UpdateExpenditure(UpdateExpenditureRequestModel model) {
            var updatedExpenditure = new Expenditures
            {
                Id = model.Id,
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            await _expenditureRepository.UpdateAsync(updatedExpenditure);
            var expenditureResponseModel = new ExpenditureResponseModel
            {
                Id = updatedExpenditure.Id,
                UserId = updatedExpenditure.UserId,
                Amount = updatedExpenditure.Amount,
                Description = updatedExpenditure.Description,
                ExpDate = updatedExpenditure.ExpDate,
                Remarks = updatedExpenditure.Remarks
            };
            return expenditureResponseModel;
        }
    }
}
