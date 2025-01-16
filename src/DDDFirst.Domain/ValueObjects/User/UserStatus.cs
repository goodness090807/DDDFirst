namespace DDDFirst.Domain.ValueObjects.User
{
    public class UserStatus
    {
        public int Id { get; }
        public string Value { get; }

        /// <summary>
        /// 等待驗證
        /// </summary>
        public static readonly UserStatus PendingVerification = new(0, "PendingVerification");
        /// <summary>
        /// 啟用
        /// </summary>
        public static readonly UserStatus Active = new(1, "Active");
        /// <summary>
        /// 停用
        /// </summary>
        public static readonly UserStatus Inactive = new (2, "Inactive");
        /// <summary>
        /// 封鎖
        /// </summary>
        public static readonly UserStatus Blocked = new (3, "Blocked");
        /// <summary>
        /// 刪除
        /// </summary>
        public static readonly UserStatus Deleted = new (-1, "Deleted");

        private UserStatus(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
