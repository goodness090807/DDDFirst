using DDDFirst.Domain.Interfaces.Utils;
using DDDFirst.Domain.SeedWork;
using System.Text.RegularExpressions;

namespace DDDFirst.Domain.ValueObjects.User
{
    public class Password : ValueObject
    {
        private const int MINIMUM_PASSWORD_LENGTH = 8;

        public string Value { get; }

        private Password(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("密碼不能為空");
            }

            Value = value;
        }

        public static Password CreateHashedPassword(string password, IPasswordHasher passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("密碼不能為空");
            }

            // 密碼合規性驗證
            if (password.Length < MINIMUM_PASSWORD_LENGTH)
            {
                throw new ArgumentException("密碼長度不能少於8個字符");
            }

            if (!Regex.IsMatch(password, @"[0-9]"))
            {
                throw new ArgumentException("密碼必須包含至少一個數字");
            }

            if (!Regex.IsMatch(password, "[!@#$%^&*(),.?\":{ }|<>]"))
            {
                throw new ArgumentException("密碼必須包含至少一個特殊字符");
            }

            return new Password(passwordHasher.HashPassword(password));
        }

        public bool Verify(string providedPassword, IPasswordHasher passwordHasher)
        {
            return passwordHasher.VerifyPassword(Value, providedPassword);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
