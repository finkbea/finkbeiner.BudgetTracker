using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetTracker.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase {
        private readonly IExpenditureService _expenditureService;
        public ExpenditureController(IExpenditureService expenditureService) {
            _expenditureService = expenditureService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index() {
            var expenditure = await _expenditureService.getExpenditures();
            return Ok(expenditure);
        }
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Add(ExpenditureRequestModel model) {
            var expenditure = await _expenditureService.AddExpenditure(model);
            return Ok(expenditure);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task Delete(int id) {
            await _expenditureService.DeleteExpenditure(id);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateExpenditureRequestModel model) {
            var expenditure = await _expenditureService.UpdateExpenditure(model);
            return Ok(expenditure);
        }
    }
}
