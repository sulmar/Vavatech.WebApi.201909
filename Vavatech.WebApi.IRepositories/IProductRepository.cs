using System.Collections;
using System.Collections.Generic;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.IRepositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        ICollection<Product> GetByColor(string color);
    }


}
