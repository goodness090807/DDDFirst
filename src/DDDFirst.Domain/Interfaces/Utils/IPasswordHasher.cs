namespace DDDFirst.Domain.Interfaces.Utils
{
    public interface IPasswordHasher
    {
        /// <summary>
        /// 將密碼Hash
        /// </summary>
        string HashPassword(string password);

        /// <summary>
        /// 驗證密碼
        /// </summary>
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
