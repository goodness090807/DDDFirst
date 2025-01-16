using CSharpFunctionalExtensions;

namespace DDDFirst.Application.Services.UserService
{
    public interface IUserService
    {
        Task<Result> RegisterAsync(string name, string email, string password);
    }
}
