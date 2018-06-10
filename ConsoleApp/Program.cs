using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static Product GetInputValues()
        {
            Console.Write("Product Name: ");
            var name = Console.ReadLine();

            Console.Write("Product Price: ");
            var inputPrice = Console.ReadLine();
            decimal price;
            decimal.TryParse(inputPrice, out price);

            Console.Write("Product Category: ");
            var category = Console.ReadLine();

            return new Product
            {
                Name = name,
                Price = price,
                Category = category
            };
        }
        static int GetInputId()
        {
            Console.Write("Product Id: ");
            var inputId = Console.ReadLine();

            int id;
            int.TryParse(inputId, out id);

            return id;
        }
        static void Test()
        {
            Console.Write("Action Type: ");

            var action = Console.ReadLine().ToUpper();

            switch (action)
            {
                case "GETBYID":
                    var id = GetInputId();

                    var productTask = RESTClient.GetById(id);

                    Console.WriteLine(productTask.Result);
                    break;

                case "GETALL":
                    var productsTask = RESTClient.GetAll();

                    foreach (var result in productsTask.Result)
                    {
                        Console.WriteLine(result);
                    }
                    break;

                case "POST":
                    var product = GetInputValues();

                    Task post = RESTClient.Post(product);
                    break;

                case "PUT":
                    id = GetInputId();
                    product = GetInputValues();

                    Task put = RESTClient.Put(id, product);
                    break;

                case "DELETE":
                    id = GetInputId();

                    Task delete = RESTClient.Delete(id);
                    break;

                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Test();
                Console.ReadLine();
            }
        }
    }
}
