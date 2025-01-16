namespace DDDFirst.ValueObjects.Product
{
    public class Currency
    {
        /// <summary>
        /// 代碼
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 匯率
        /// </summary>
        public decimal Rate { get; private set; } = 1;

        public Currency(string code, decimal rate)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("代碼不能為空");
            }

            if (rate <= 0)
            {
                throw new ArgumentException("匯率必須大於0");
            }

            Code = code;
            Rate = rate;
        }
    }
}
