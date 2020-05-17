using System;
using System.Collections.Generic;

namespace InheritanceMP
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<InventoryItemModel> inv = new List<InventoryItemModel>();
            //inv.Add(new VehicleModel { DealerFee = 25, ProductName = "Car1" });
            //inv.Add(new BookModel { ProductName = "Book1", NumOfPgs = 100 });

            List<IRentable> rent = new List<IRentable>();
            List<IPurchasable> pur = new List<IPurchasable>();

            var ve = new VehicleModel { DealerFee = 25, ProductName = "Car1" };
            var bo = new BookModel { ProductName = "Book1", NumOfPgs = 100 };
            var ex = new ExcavatorModel { ProductName = "Ex1", QuantityInStock = 10 };

            rent.Add(ve);
            rent.Add(ex);
            pur.Add(bo);
            pur.Add(ve);

            Console.Write("Rent(R) or Purchase(P)");
            string userInput = Console.ReadLine();

            if (userInput.ToUpper() == "R")
            {
                foreach (var i in rent)
                {
                    Console.WriteLine($"Item: {i.ProductName}");
                    Console.WriteLine("Do you want to rent this item: Yes(Y), No(N)");
                    string userA = Console.ReadLine();

                    if (userA.ToUpper() == "Y")
                    {
                        i.Rent();
                    }

                    Console.WriteLine("Do you want to return this item: Yes(Y), No(N)");
                    string userA2 = Console.ReadLine();

                    if (userA.ToUpper() == "Y")
                    {
                        i.ReturnRental();
                    }
                }
            }
            else
            {
                foreach (var i in pur)
                {
                    Console.WriteLine($"Item: {i.ProductName}");
                    Console.WriteLine("Do you want to purchase this item: Yes(Y), No(N)");
                    string userA = Console.ReadLine();

                    if (userA.ToUpper() == "Y")
                    {
                        i.Purchase();
                    }
                }
            }

            Console.WriteLine("Done.");
            Console.ReadLine();
        }
    }
}
