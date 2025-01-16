using CSharpFunctionalExtensions;
using DDDFirst.Domain.Errors;

namespace DDDFirst.Domain.ValueObjects
{
    /// <summary>
    /// Email Value Object
    /// </summary>
    public class Email
    {
        public string Value { get; }

        private Email(string value)
        {
            Value = value;
        }

        public static Result<Email> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<Email>(CommonErrors.ValueIsNullOrEmpty);
            }
            if (!IsValidEmail(value))
            {
                return Result.Failure<Email>(CommonErrors.EmailError);
            }
            return Result.Success(new Email(value));
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
