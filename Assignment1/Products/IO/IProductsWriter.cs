using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment1.Products.IO
{
    public interface IProductsWriter
    {
        Task WriteProductsAsync(IEnumerable<Product> products);
    }
}