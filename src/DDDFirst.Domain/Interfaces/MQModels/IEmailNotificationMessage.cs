namespace DDDFirst.Domain.Interfaces.MQModels
{
    public interface IEmailNotificationMessage
    {
        /// <summary>
        /// 收件人
        /// </summary>
        string Email { get; }

        /// <summary>
        /// 副本
        /// </summary>
        string CarbonCopies { get; }

        /// <summary>
        /// 主旨
        /// </summary>
        string Subject { get; }

        /// <summary>
        /// 內容
        /// </summary>
        string Body { get; }
    }
}
