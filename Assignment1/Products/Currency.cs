namespace Assignment1.Products
{
    public class Currency
    {
        public static readonly Currency USD = new Currency(1);
        public static readonly Currency EUR = new Currency(0.85m);

        public decimal Rate { get; }

        private Currency(decimal rate)
        {
            Rate = rate;
        }

    }
}