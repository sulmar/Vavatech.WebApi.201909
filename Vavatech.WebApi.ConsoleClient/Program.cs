using Newtonsoft.Json;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.WebApi.Fakers;
using Vavatech.WebApi.Models;

namespace Vavatech.WebApi.ConsoleClient
{
    class Program
    {
        static int ManagedThreadId => Thread.CurrentThread.ManagedThreadId;

        static async Task Main(string[] args)
        {
            // await AsyncAwaitTest();
           // await AddCustomerTest();
            await GetCustomerByIdTest(10);
            await GetCustomersTest2();
            await GetProductsTest();

            await GetCustomersTest();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static async Task AddCustomers()
        {
            var customerFaker = new CustomerFaker();
            List<Customer> customers = customerFaker.Generate(10);

            foreach (var customer in customers)
            {
                await AddCustomer(customer);
            }

        }
          

        private static async Task AddCustomer(Customer customer)
        {
           
            string request = "api/customers";

            string json = JsonConvert.SerializeObject(customer);

            string url = "https://localhost:44375";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpContent content = new StringContent(json);

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            content.Headers.Add("Authorization", "marcin:12345");

            HttpResponseMessage response = await client.PostAsync(request, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync();
                Console.WriteLine(response.Headers.Location);


            }

        }

        private static async Task GetCustomersTest()
        {
            string request = "api/customers";

            string url = "https://localhost:44375";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                IEnumerable<Customer> customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(json);
            }
              

        }

        private static async Task GetCustomerByIdTest(int customerId)
        {
            string request = $"api/customers/{customerId}";

            var customer = await GetEntitiesTest<Customer>(request);
        }

        private static async Task GetCustomersTest2()
        {
            string request = "api/customers";

            var customers = await GetEntitiesTest<IEnumerable<Customer>>(request);
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

        private static async Task GetProductsTest()
        {
            string request = "api/products";

            var products = await GetEntitiesTest<Product>(request);
        }

        private static async Task<TResult> GetEntitiesTest<TResult>(string request)
        {
            string url = "https://localhost:44375";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                TResult result = JsonConvert.DeserializeObject<TResult>(json);

                return result;
            }

            throw new NotSupportedException();


        }

        private static void Display(Customer customer)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(customer.FirstName);
            stringBuilder.AppendLine(customer.LastName);

            if (customer.IsRemoved)
            {
                stringBuilder.AppendLine("UWAGA: usuniety");
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private static async Task AsyncAwaitTest()
        {
            Console.WriteLine($"#{ManagedThreadId} Started.");

            // synchronicznie
            // Send("Hello World!");

            // asynchronicznie

            //Task task = Task.Run(() => Send("Hello World!"));
            //task.ContinueWith(t => Console.WriteLine("Done."));

            //Task.Run(() => Send("Hello World!"))
            //    .ContinueWith(t => Console.WriteLine("Done."));

            // synchronicznie
            //decimal result = Calculate(10, 5);
            //Console.WriteLine($"Result: {result}");

            // asynchronicznie
            //Task.Run(() => Calculate(10, 5))
            //    .ContinueWith(t => Console.WriteLine($"Result: {t.Result}"));

            decimal result2 = await CalculateAsync(10, 5);
            Console.WriteLine($"Result: {result2}");
        }

        static Task<decimal> CalculateAsync(decimal unitPrice, int quantity)
        {
            return Task.Run(() => Calculate(unitPrice, quantity));
        }

        static decimal Calculate(decimal unitPrice, int quantity)
        {
            Console.WriteLine($"{ManagedThreadId} Calculating...");

            decimal result = unitPrice * quantity;

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"{ManagedThreadId} Calculated");

            return result;
        }

        static void Send(string message)
        {
            Console.WriteLine($"#{ManagedThreadId} Sending...{message}");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine($"#{ManagedThreadId} Sent. {message}");
        }
    }
}
