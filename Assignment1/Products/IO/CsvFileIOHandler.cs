using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace Assignment1.Products.IO
{
    public class CsvFileIoHandler : IProductsReader, IProductsWriter
    {
        private readonly string _csvFileNamev;

        public CsvFileIoHandler(string csvFileNamev)
        {
            _csvFileNamev = csvFileNamev;
        }

        public async Task<IEnumerable<Product>> ReadProductsAsync()
        {
            using var streamReader = new StreamReader(_csvFileNamev);
            using var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture);

            csvReader.Configuration.TrimOptions = TrimOptions.Trim;

            return await csvReader.GetRecordsAsync<Product>().ToArrayAsync();
        }

        public async Task WriteProductsAsync(IEnumerable<Product> products)
        {
            await using var streamWriter = new StreamWriter(_csvFileNamev);
            await using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            await csvWriter.WriteRecordsAsync(products);
        }
    }
}
