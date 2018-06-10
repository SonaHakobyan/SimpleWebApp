namespace BussinessLayer
{
    /// <summary>
    /// Represent bussiness layer product
    /// </summary>
    public class Product
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
