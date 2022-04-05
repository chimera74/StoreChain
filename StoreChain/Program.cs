using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using StoreChain.Model;

namespace StoreChain
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // products
            var ticket = new ProductWithSerial()
            {
                Name = "Parking Ticket", Type = ProductType.ParkingTicket
            };
            var medicine = new ProductWithSerial()
            {
                Name = "Cough Syrup", Type = ProductType.Medicine
            };
            var food = new Product()
            {
                Name = "Hamburger", Type = ProductType.Food
            };
            var drink = new Product()
            {
                Name = "Soda", Type = ProductType.Drink
            };
            var toy = new Product()
            {
                Name = "Toy car", Type = ProductType.Toy
            };
            var cigarettes = new Product()
            {
                Name = "Marlboro", Type = ProductType.Cigarettes
            };
            
            // create shops
            var shops = new List<Shop>();
            
            var cshop1 = new CornerShop()
                { Name = "Corner Shop 1" };
            cshop1.SetStock(cigarettes, 2.00f, 50);
            cshop1.SetStock(food, 1.99f, 50);
            cshop1.SetStock(ticket, 2.50f, 1000);
            cshop1.SetStock(toy, 49.99f, 1);
            shops.Add(cshop1);
            
            var pharmacy1 = new Pharmacy()
                { Name = "Corner Shop 1" };
            pharmacy1.SetStock(medicine, 9.99f, 50);
            pharmacy1.SetStock(drink, 1.99f, 50);
            pharmacy1.SetStock(ticket, 2.50f, 1000);
            shops.Add(pharmacy1);
            
            var supermarket1 = new Supermarket()
                { Name = "Corner Shop 1" };
            supermarket1.SetStock(drink, 1.99f, 50);
            supermarket1.SetStock(food, 1.99f, 50);
            supermarket1.SetStock(ticket, 2.50f, 1000);
            supermarket1.SetStock(toy, 49.99f, 50);
            shops.Add(supermarket1);

            
            var customer = new Customer()
            {
                FirstName = "Jhon",
                LastName = "Doe",
                PhoneNumber = "1234567890"
            };

            // bills
            var shopList1 = new Dictionary<Product, int>()
            {
                {cigarettes, 2},
                {ticket, 1}
            };
            PrintPurchaseResult(cshop1.Purchase(shopList1, customer));
            
            var shopList2 = new Dictionary<Product, int>()
            {   
                {cigarettes, 5},
                {ticket, 5}
            };
            PrintPurchaseResult(cshop1.Purchase(shopList2, customer));
            
            var shopList3 = new Dictionary<Product, int>()
            {
                {medicine, 1},
                {ticket, 1}
            };
            PrintPurchaseResult(pharmacy1.Purchase(shopList3, customer));
            
            var shopList4 = new Dictionary<Product, int>()
            {   
                {medicine, 1},
                {drink, 5}
            };
            PrintPurchaseResult(pharmacy1.Purchase(shopList4, customer));
            
            var shopList5 = new Dictionary<Product, int>()
            {   
                {drink, 1},
                {food, 1},
                {toy, 1},
                {ticket, 1}
            };
            PrintPurchaseResult(supermarket1.Purchase(shopList5, customer));
            
            var shopList6 = new Dictionary<Product, int>()
            {   
                {drink, 5},
                {food, 5},
            };
            PrintPurchaseResult(supermarket1.Purchase(shopList6, customer));
            
            // invalid purchase
            var shopList7 = new Dictionary<Product, int>()
            {   
                {toy, 2}
            };
            PrintPurchaseResult(cshop1.Purchase(shopList7, customer));

        }

        public static void PrintPurchaseResult(Bill bill)
        {
            if (bill is null)
            {
                Console.WriteLine("Purchase did not go through");
                return;
            }

            Console.WriteLine("Bill ID:" + bill.id);
            foreach (var product in bill.productList)
            {
                Console.WriteLine(product.product.Name +
                                  (product.product is ProductWithSerial serial ? (": " + serial.SerialNumber) : "")
                                  + " | " + product.price + " | " + product.amount);
            }
            Console.WriteLine("Total: " + bill.GetTotal());
            Console.WriteLine();
        } 
    }
}