using System.Collections.Generic;

namespace BussinessLayer
{
    public class ProductMapper
    {
        /// <summary>
        /// Create product with given values
        /// </summary>
        /// <param name="productValues">Product values</param>
        /// <returns></returns>
        public static Product Map(Dictionary<string, object> productValues)
        {
            var product = new Product();
            product.Id = (int)productValues["Id"];
            product.Name = (string)productValues[("Name")];
            product.Price = (decimal)productValues["Price"];
            product.Category = (string)productValues["Category"];

            return product;
        }
    }
}
