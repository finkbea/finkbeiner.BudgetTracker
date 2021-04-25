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
    public class UserController : ControllerBase {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index() {
            var users = await _userService.getUsers();
            return Ok(users);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id) {
            var user = await _userService.getUserById(id);
            return Ok(user);
        }
        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> Add(UserRequestModel model) {
            var user = await _userService.AddUser(model);
            return Ok(user);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task Delete(int id) {
            await _userService.DeleteUser(id);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(UpdateUserRequestModel model) {
            var user = await _userService.UpdateUser(model);
            return Ok(user);
        }
    }
}
