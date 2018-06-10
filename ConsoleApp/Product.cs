namespace ConsoleApp
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

        /// <summary>
        /// Override ToString for Product
        /// </summary>
        /// <returns>Products's string representation</returns>
        public override string ToString() => $"{Id}  {Name}  {Price}  {Category}";
    }
}
