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
    public class IncomeController : ControllerBase {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService) {
            _incomeService = incomeService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index() {
            var income = await _incomeService.getIncomes();
            return Ok(income);
        }
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Add(IncomeRequestModel model) {
            var income = await _incomeService.AddIncome(model);
            return Ok(income);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task Delete(int id) {
            await _incomeService.DeleteIncome(id);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateIncomeRequestModel model) {
            var income = await _incomeService.UpdateIncome(model);
            return Ok(income);
        }
    }
}
