using CsvHelper.Configuration.Attributes;

namespace Assignment1.Products
{
    public class Product
    {
        [Name("productId")]
        public int Id { get; set; }

        [Name("name")]
        public string Name { get; set; }

        [Name("description")]
        public string Description { get; set; }

        [Name("price")]
        public decimal Price { get; set; }

        [Name("category")]
        public string Category { get; set; }

        [Ignore]
        public Currency Currency { get; private set; } = Currency.USD;

        public Product ConvertToCurrency(Currency currency)
        {
            return new Product
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price / Currency.Rate * currency.Rate,
                Category = Category,
                Currency = currency
            };
        }

    }
}
