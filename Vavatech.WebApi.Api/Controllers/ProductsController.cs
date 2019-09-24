using System.Web.Http;
using Vavatech.WebApi.IRepositories;

namespace Vavatech.WebApi.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //public ProductsController()
        //    : this(new FakeProductRepository(new ProductFaker()))
        //{

        //}

        public IHttpActionResult Get()
        {
            var products= productRepository.Get();

            return Ok(products);
        }
    }
}
