using System.Threading;
using CMS.API.Controllers.Users.Requests;
using DDDFirst.Application.Services.UserService;
using DDDFirst.Domain.Interfaces.MQModels;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using NotificationReceiver.Consumers;

namespace CMS.API.Controllers.Users
{
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IPublishEndpoint _publishEndpoint;

        public UsersController(IUserService userService, IPublishEndpoint publishEndpoint)
        {
            _userService = userService;
            _publishEndpoint = publishEndpoint;
        }

        /// <summary>
        /// 使用者註冊
        /// </summary>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserRequest req, CancellationToken cancellationToken)
        {
            var result = await _userService.RegisterAsync(req.Name, req.Email, req.Password);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            await _publishEndpoint.Publish<IEmailNotificationMessage>(new EmailNotificationMessage(
                req.Email,
                "",
                "Welecome",
                "to my website"), cancellationToken);

            return Ok();
        }

        /// <summary>
        /// TODO：這個是範例
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> LoginAsync(CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IEmailNotificationMessage>(new EmailNotificationMessage(
                "aaa",
                "",
                "Welecome",
                "to my website"),
                (context) =>
                {
                    context.Headers.Set("x-rabbitmq-routing-key", "email-notification");
                },
                cancellationToken);
            return Ok();
        }
    }
}
