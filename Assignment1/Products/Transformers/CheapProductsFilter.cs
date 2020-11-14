using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Products.Transformers
{
    public class CheapProductsFilter : IProductsTransformer
    {
        private readonly decimal _minimumPrice;

        public CheapProductsFilter(decimal minimumPrice)
        {
            _minimumPrice = minimumPrice;
        }

        public Task<IEnumerable<Product>> TransformAsync(IEnumerable<Product> products)
        {
            var result = products
                .Where(x => x.Price > _minimumPrice)
                .ToArray()
                .AsEnumerable();

            return Task.FromResult(result);
        }
    }
}
