using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsApi.Models
{
    /// <summary>
    /// Represent MVC product model
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// Product id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Produt price
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Producct category
        /// </summary>
        public string Category { get; set; }
    }
}