using DDDFirst.Domain.Entities.Common;
using DDDFirst.Domain.ValueObjects;
using DDDFirst.Domain.ValueObjects.User;

namespace DDDFirst.Domain.Entities
{
    public class UserEntity : BaseAuditableEntity<int>
    {
        public string Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public UserStatus UserStatus { get; private set; }

        public UserEntity(string name, Email email, Password password, UserStatus userStatus)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            Email = email;
            Password = password;
            UserStatus = userStatus;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void ChangeEmail(Email email)
        {
            Email = email;
        }
    }
}
