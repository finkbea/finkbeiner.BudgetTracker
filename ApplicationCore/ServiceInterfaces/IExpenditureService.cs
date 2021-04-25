using ApplicationCore.Models;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces {
    public interface IExpenditureService {
        Task<List<ExpenditureResponseModel>> getExpenditures();
        Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel model);
        Task DeleteExpenditure(int id);
        Task<ExpenditureResponseModel> UpdateExpenditure(UpdateExpenditureRequestModel model);
    }
}
