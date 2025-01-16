using DDDFirst.Domain.SeedWork;

namespace DDDFirst.Domain.Errors
{
    public static class CommonErrors
    {
        /// <summary>
        /// 值為空或Null
        /// </summary>
        public static readonly string ValueIsNullOrEmpty = "Common.ValueIsNullOrEmpty";

        /// <summary>
        /// Email格式錯誤
        /// </summary>
        public static readonly string EmailError = "Common.EmailError";
    }
}
