using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Products.Transformers
{
    public class PriceToEurConverter : IProductsTransformer
    {
        public Task<IEnumerable<Product>> TransformAsync(IEnumerable<Product> products)
        {
            var result = products
                .Select(x => x.ConvertToCurrency(Currency.EUR))
                .ToArray()
                .AsEnumerable();

            return Task.FromResult(result);
        }
    }
}