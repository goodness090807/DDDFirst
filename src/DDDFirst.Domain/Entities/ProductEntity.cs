using DDDFirst.ValueObjects.Product;

namespace DDDFirst.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; init; }
        public string Name { get; private set; }
        public string Description { get; private set; } = string.Empty;

        /// <summary>
        /// 商品編號
        /// </summary>
        public string ProductNo { get; set; } = string.Empty;

        public List<Price> Prices { get; private set; }

        public ProductEntity(string name, List<Price> prices)
        {
            Name = name;
            Prices = prices;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void AddPrice(Price price)
        {
            Prices.Add(price);
        }

        public override string ToString()
        {
            return $"{Name} - {string.Join(", ", Prices)}";
        }
    }
}
