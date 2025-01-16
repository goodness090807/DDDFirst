using CMS.API.Controllers.Users.Requests;
using DDDFirst.Application.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers.Users
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 使用者註冊
        /// </summary>
        [HttpPost("Register")]
        public async Task RegisterAsync(RegisterUserRequest req)
        {
            await _userService.RegisterAsync(req.Name, req.Email, req.Password);
        }
    }
}
