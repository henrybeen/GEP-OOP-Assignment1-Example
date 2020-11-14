using System.Linq;
using System.Threading.Tasks;
using Assignment1.Products;
using Assignment1.Products.Transformers;
using NUnit.Framework;

namespace Assignment1.Test.Products.Transformers
{
    [TestFixture]
    public class CheapProductsFilterTest
    {
        private CheapProductsFilter _subject;
        public const decimal Threshold = 25;

        [SetUp]
        public void SetUp()
        {
            _subject = new CheapProductsFilter(Threshold);
        }

        [TestCase(4)]
        [TestCase(25)]
        public async Task WhenProductIsBelowThreshold_ThenItIsNotReturned(decimal price)
        {
            var inputs = BuildProduct(price);

            var outputs = await _subject.TransformAsync(inputs);

            Assert.IsEmpty(outputs);
        }

        [TestCase(25.0000000001)]
        [TestCase(26)]
        [TestCase(45)]
        public async Task WhenProductIsAboveThreshold_ThenItIsReturned(decimal price)
        {
            var inputs = BuildProduct(price);

            var outputs = await _subject.TransformAsync(inputs);

            Assert.AreEqual(1, outputs.Count());
        }

        private Product[] BuildProduct(decimal price)
        {
            var inputs = new[]
            {
                new Product()
                {
                    Price = price
                }
            };
            return inputs;
        }
    }
}
