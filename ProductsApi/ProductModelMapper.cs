using BussinessLayer;
using ProductsApi.Models;

namespace ProductsApi
{
    public class ProductModelMapper
    {
        /// <summary>
        /// Create product model with given values
        /// </summary>
        /// <param name="product">The product</param>
        /// <returns></returns>
        public static ProductModel Map(Product product)
        {
            var model = new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category
            };

            return model;
        }

        /// <summary>
        /// Create product with given values
        /// </summary>
        /// <param name="model">The product model</param>
        /// <returns></returns>
        public static Product Map(ProductModel model)
        {
            var product = new Product
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Category = model.Category
            };

            return product;
        }
    }
}