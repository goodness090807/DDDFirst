namespace DDDFirst.Application.Services.UserService
{
    public static class UserServiceErrors
    {
        /// <summary>
        /// 使用者不存在
        /// </summary>
        public static readonly string UserNotFound = "User.UserNotFound";
        /// <summary>
        /// 使用者重複
        /// </summary>
        public static readonly string UserAlreadyExists = "User.UserAlreadyExists";
    }
}
