using System.Collections.Generic;

namespace DataAccessLayer
{
    /// <summary>
    /// Provide CRUD operations
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Create a new product with specified values
        /// </summary>
        /// <param name="paramValues">Product's parameters: name, price, category values</param>
        /// <returns>Product identifier</returns>
        public static List<Dictionary<string, object>> CreateProduct(Dictionary<string, object> paramValues)
        {
            var procName = "sp_CreateProduct";
            return StorageManager.CallProcedure(procName, paramValues);
        }

        /// <summary>
        /// Get all products from Products table 
        /// </summary>
        /// <returns>List of products. Product is represented by key value pairs</returns>
        public static List<Dictionary<string, object>> GetAllProducts()
        {
            var procName = "sp_GetAllProducts";
            return StorageManager.CallProcedure(procName);
        }

        /// <summary>
        /// Get the specified product
        /// </summary>
        /// <param name="paramValues">Product identifier</param>
        /// <returns>The product</returns>
        public static List<Dictionary<string, object>> GetProductById(Dictionary<string, object> paramValues)
        {
            var procName = "sp_GetProductById";
            return StorageManager.CallProcedure(procName, paramValues);
        }

        /// <summary>
        /// Update product with specified values
        /// </summary>
        /// <param name="paramValues">Product's identifier and new parameters: name, price, category values</param>
        public static void UpdateProduct(Dictionary<string, object> paramValues)
        {
            var procName = "sp_UpdateProduct";
            StorageManager.CallProcedure(procName, paramValues);
        }

        /// <summary>
        /// Delete product by specified id
        /// </summary>
        /// <param name="paramValues">Product identifier</param>
        public static void DeleteProduct(Dictionary<string, object> paramValues)
        {
            var procName = "sp_DeleteProduct";
            StorageManager.CallProcedure(procName, paramValues);
        }
    }
}