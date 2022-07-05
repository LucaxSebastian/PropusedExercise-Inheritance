using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;

namespace Course
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            var nProducts = int.Parse(Console.ReadLine());
            
            for(int i = 1; i <= nProducts; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Product #{i} data:");

                Console.Write("Commom, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine().ToLower()); // ToLoweer > Converte letra maiúscula em minúscula

                Console.Write("Name: ");
                var name = Console.ReadLine();

                Console.Write("Price: ");
                var price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(type == 'c')
                {
                    products.Add(new Product(name, price));
                }
                else if(type == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    var manufactureDate = DateTime.Parse(Console.ReadLine());
                    products.Add(new UsedProduct(name, price, manufactureDate));
                }
                else
                {
                    Console.Write("Customs fee: ");
                    var customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    products.Add(new ImportedProduct(name, price, customFee));  
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS");

            foreach(var product in products)
            {
                Console.WriteLine(product.PriceTag());
            }

            Console.ReadKey();
        }
    }
}
