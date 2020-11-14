using System.Threading.Tasks;
using Assignment1.Products.IO;
using Assignment1.Products.Transformers;

namespace Assignment1
{
    public static class Program
    {
        public static async Task Main()
        {
            var productReader = new CsvFileIoHandler(@"C:\src\Assignment1\data\001-inputs.csv");

            var productTransformers = new IProductsTransformer[]
            {
                new CheapProductsFilter(10),
                new PriceToEurConverter()
            };

            var productWriter = new CsvFileIoHandler(@"C:\src\Assignment1\data\001-outputs.csv");

            var productManager = new ProductManager(productReader, productTransformers, productWriter);
            await productManager.RunAsync();
        }
    }
}
