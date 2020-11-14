using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment1.Products.Transformers
{
    public interface IProductsTransformer
    {
        Task<IEnumerable<Product>> TransformAsync(IEnumerable<Product> products);
    }
}
