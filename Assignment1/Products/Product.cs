using CsvHelper.Configuration.Attributes;

namespace Assignment1.Products
{
    public record Product
    {
        [Name("productId")]
        public int Id { get; init; }

        [Name("name")]
        public string Name { get; init; }

        [Name("description")]
        public string Description { get; init; }

        [Name("price")]
        public decimal Price { get; init; }

        [Name("category")]
        public string Category { get; init; }

        [Ignore]
        public Currency Currency { get; private set; } = Currency.USD;

        public Product ConvertToCurrency(Currency currency)
        {
            return this with
            {
                Price = Price / Currency.Rate * currency.Rate,
                Category = Category
            } ;
        }
    }
}
