using ApplicationCore.Models;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces {
    public interface IIncomeService {
        Task<List<IncomeResponseModel>> getIncomes();
        Task<IncomeResponseModel> AddIncome(IncomeRequestModel model);
        Task DeleteIncome(int id);
        Task<IncomeResponseModel> UpdateIncome(UpdateIncomeRequestModel model);
    }
}
