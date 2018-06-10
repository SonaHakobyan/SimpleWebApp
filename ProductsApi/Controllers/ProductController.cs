using ProductsApi.Models;
using System.Collections.Generic;
using System.Web.Http;
using BussinessLayer;

namespace ProductsApi.Controllers
{
    public class ProductController : ApiController
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Collection of products</returns>
        public IEnumerable<ProductModel> GetAll()
        {
            // The result
            var result = new List<ProductModel>();

            // Get all products from BL
            var products = ProductRepository.GetAllProducts();

            foreach (var product in products)
            {
                // Get product model from product
                var model = ProductModelMapper.Map(product);

                // Add the product model to the result
                result.Add(model);
            }

            return result;
        }

        /// <summary>
        /// Get product by Id
        /// </summary>
        /// <param name="id">The product Id</param>
        /// <returns></returns>
        public IHttpActionResult GetById(int id)
        {
            var product = ProductRepository.GetProductById(id);
            
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Post a new product
        /// </summary>
        /// <param name="model">The product</param>
        [HttpPost]
        public void Post([FromBody]ProductModel model)
        {
            var product = ProductModelMapper.Map(model);
            ProductRepository.AddProduct(product);
        }

        /// <summary>
        /// Put new values on given product
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <param name="model">Product's new values</param>
        [HttpPut]
        public void Put(int id, [FromBody] ProductModel model)
        {
            var product = ProductModelMapper.Map(model);
            ProductRepository.UpdateProduct(id, product);
        }

        /// <summary>
        /// Delete product 
        /// </summary>
        /// <param name="id">The product identifier</param>
        [HttpDelete]
        public void Delete(int id)
        {
            ProductRepository.DeleteProduct(id);
        }
    }
}
