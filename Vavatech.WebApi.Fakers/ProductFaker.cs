using Bogus;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker + 1);
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.SerialNumber, f => f.Commerce.Ean13());
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.UnitPrice, f => decimal.Round(f.Random.Decimal(1, 100), 2));

        }
    }
}
