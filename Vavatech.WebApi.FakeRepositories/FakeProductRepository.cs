using System.Collections.Generic;
using System.Linq;
using Bogus;
using Vavatech.WebApi.Fakers;
using Vavatech.WebApi.IRepositories;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.FakeRepositories
{
    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(ProductFaker faker) : base(faker)
        {
        }

        public ICollection<Product> GetByColor(string color)
        {
            return entities.Where(e => e.Color == color).ToList();
        }


        public override void Remove(int id)
        {
            Product product = Get(id);
            product.Id = 0;
        }
    }
}
