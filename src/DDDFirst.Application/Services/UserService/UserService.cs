using CSharpFunctionalExtensions;
using DDDFirst.Domain.Entities;
using DDDFirst.Domain.Interfaces.Utils;
using DDDFirst.Domain.ValueObjects;
using DDDFirst.Domain.ValueObjects.User;
using DDDFirst.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDDFirst.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly ApplicationDbContext _context;

        public UserService(IPasswordHasher passwordHasher, ApplicationDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<Result> RegisterAsync(string name, string email, string password)
        {
            var emailValue = Email.Create(email);

            if (emailValue.IsFailure)
            {
                return Result.Failure(emailValue.Error);
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == emailValue.Value);
            if (user != null)
            {
                return Result.Failure(UserServiceErrors.UserAlreadyExists);
            }

            var hashedPassword = Password.CreateHashedPassword(password, _passwordHasher);
            var newUser = new UserEntity(name, emailValue.Value, hashedPassword, UserStatus.PendingVerification);
            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
