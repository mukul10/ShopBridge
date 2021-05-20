using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ShopBridge.Models;
using ShopBridge.Models.Context;

namespace ShopBridge.Controllers
{
    public class ProductsController : ApiController
    {
        
        private Dal dal = new Dal();
        
        [Route("Products/GetProducts")]
        public IQueryable<Product> GetProducts()
        {
            return dal.GetAllProduct();

        }

        
        
        [Route("Products/GetProduct/{id}")]

        public async Task<IHttpActionResult> GetProduct(int id)
        {
           
            Product product = await dal.findProduct(id);
            if (product == null)
            {
                return Ok("Resource Not Found");
            }

            return Ok(product);
        }

        
        
        [Route("Product/UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IHttpActionResult> PutProduct(int id, [FromBody] Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result =await dal.UpdateProduct(id, product);

            return Ok(result);
        }

        
        
        [Route("Products/AddProduct")]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await dal.addProduct(product);

            return Ok(result);
        }

        [HttpGet]
        [Route("Products/DeleteProduct/{id}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {   var result =await dal.deleteProduct(id);

            return Ok(result);
        }

        
    }
}