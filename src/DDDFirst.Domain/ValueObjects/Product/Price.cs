namespace DDDFirst.ValueObjects.Product
{
    public class Price
    {
        public decimal Value { get; private set; }
        public Currency Currency { get; private set; }
        public Price(decimal value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentException("金額不能小於0");
            }
            Value = value;
            Currency = currency;
        }

        /// <summary>
        /// 轉換幣別
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public Price ConvertTo(Currency currency)
        {
            if (Currency.Code == currency.Code)
            {
                return this;
            }
            return new Price(Value * currency.Rate, currency);
        }

        public override string ToString()
        {
            return $"{Value} {Currency.Code}";
        }
    }
}
