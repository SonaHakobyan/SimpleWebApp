using DataAccessLayer;
using System.Collections.Generic;

namespace BussinessLayer
{
    public class ProductRepository
    {
        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="product">The product</param>
        public static void AddProduct(Product product)
        {
            var paramValues = new Dictionary<string, object>();
            paramValues["Name"] = product.Name;
            paramValues["Price"] = product.Price;
            paramValues["Category"] = product.Category;

            DataManager.CreateProduct(paramValues);
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Products collection</returns>
        public static IEnumerable<Product> GetAllProducts()
        {
            // The result
            var result = new List<Product>();

            // Get all product values from database
            var dalResult = DataManager.GetAllProducts();

            foreach (Dictionary<string, object> dalProduct in dalResult)
            {
                // Get product from product values
                var product = ProductMapper.Map(dalProduct);

                // Add the product to the result
                result.Add(product);
            }

            return result;
        }

        /// <summary>
        /// Get product by given id
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns>The product</returns>
        public static Product GetProductById(int id)
        {
            var paramValues = new Dictionary<string, object>();
            paramValues["Id"] = id;

            Product product = null;

            var dalResult = DataManager.GetProductById(paramValues);

            foreach (Dictionary<string, object> dalProduct in dalResult)
            {
                product = ProductMapper.Map(dalProduct);
            }

            return product;
        }

        /// <summary>
        /// Delete product with specified id
        /// </summary>
        /// <param name="id">Identifier of the product</param>
        public static void DeleteProduct(int id)
        {
            var paramValues = new Dictionary<string, object>();
            paramValues["Id"] = id;

            DataManager.DeleteProduct(paramValues);
        }

        /// <summary>
        /// Update product with specified id
        /// </summary>
        /// /// <param name="id">Product identifier</param>
        /// <param name="product">Product's new values</param>
        public static void UpdateProduct(int id, Product product)
        {
            var paramValues = new Dictionary<string, object>();
            paramValues["Id"] = id;
            paramValues["Name"] = product.Name;
            paramValues["Price"] = product.Price;
            paramValues["Category"] = product.Category;

            DataManager.UpdateProduct(paramValues);
        }
    }
}
