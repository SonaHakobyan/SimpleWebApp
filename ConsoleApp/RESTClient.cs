using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Text;

namespace ConsoleApp
{
    public class RESTClient
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<Product>> GetAll()
        {
            var result = new List<Product>();

            using (var client = new HttpClient())
            {
                var uri = ConfigurationSettings.AppSettings["uri"];

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/product/getall");

                var jsonResult = await response.Content.ReadAsStringAsync();

                result = new JavaScriptSerializer().Deserialize<IEnumerable<Product>>(jsonResult).ToList();
            }

            return result;
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns></returns>
        public static async Task<Product> GetById(int id)
        {
            Product result = null;
            using (var client = new HttpClient())
            {
                var uri = ConfigurationSettings.AppSettings["uri"];

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var fullUri = uri + $"api/product/getbyid/{id}";

                var response = await client.GetAsync(fullUri);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    result = new JavaScriptSerializer().Deserialize<Product>(jsonResult);
                }
            }

            return result;
        }

        /// <summary>
        /// Post a new product
        /// </summary>
        /// <param name="product">New product's values</param>
        /// <returns></returns>
        public static async Task Post(Product product)
        {
            using (var client = new HttpClient())
            {
                string uri = ConfigurationSettings.AppSettings["uri"];

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = new JavaScriptSerializer().Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PostAsync("api/product/post", content);
            }
        }

        /// <summary>
        /// Put new values uo given product
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <param name="product">Product's new values</param>
        /// <returns></returns>
        public static async Task Put(int id, Product product)
        {
            using (var client = new HttpClient())
            {
                var uri = ConfigurationSettings.AppSettings["uri"];

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = new JavaScriptSerializer().Serialize(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await client.PutAsync($"api/product/put/{id}", content);

            }
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="id">Product identifier</param>
        /// <returns></returns>
        public static async Task Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var uri = ConfigurationSettings.AppSettings["uri"];

                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage responseMessage = await client.DeleteAsync($"api/product/delete/{id}");
            }
        }
    }
}
