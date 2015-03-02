using System;
using System.Web.Http;
using SpaUserControl.Domain.Interfaces.Services;

namespace SpaUserControl.WebApi.Controllers
{
    [RoutePrefix("api/v1")]    
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("products")]
        // GET: api/Product
        public IHttpActionResult Get()
        {
            try
            {
                _productService.Create("Sabonete", "Sabonete liquido", new decimal(02.50));
                return Ok(_productService.Get(0));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
