using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Products.IO;
using Assignment1.Products.Transformers;

namespace Assignment1
{
    public class ProductManager
    {
        private readonly IProductsReader _productsReader;
        private readonly IEnumerable<IProductsTransformer> _productTransformers;
        private readonly IProductsWriter _productsWriter;

        public ProductManager(IProductsReader productsReader, IEnumerable<IProductsTransformer> productTransformers, IProductsWriter productsWriter)
        {
            _productsReader = productsReader;
            _productTransformers = productTransformers;
            _productsWriter = productsWriter;
        }

        public async Task RunAsync()
        {
            var products = await _productsReader.ReadProductsAsync();

            foreach (var transformer in _productTransformers)
            {
                products = await transformer.TransformAsync(products);
            }

            await _productsWriter.WriteProductsAsync(products);
        }
    }
}