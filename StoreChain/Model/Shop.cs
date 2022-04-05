using System;
using System.Collections.Generic;

namespace StoreChain.Model
{
    public class Shop
    {
        public string Name { get; set; }

        private Dictionary<Product, ProductStockInfo> _products;
        private List<Bill> _bills;
        private int billNumber; 

        public Shop()
        {
            _products = new Dictionary<Product, ProductStockInfo>();
            _bills = new List<Bill>();
            billNumber = 0;
        }

        public virtual void SetStock(Product product, float price, int amount)
        {
            if (_products.ContainsKey(product))
                _products[product] = new ProductStockInfo(price, amount);
            else
                _products.Add(product, new ProductStockInfo(price, amount));
        }

        public Bill Purchase(Dictionary<Product, int> productList, Customer customer)
        {
            // check if enough stock
            foreach (var prVal in productList)
            {
                if (!_products.ContainsKey(prVal.Key) || _products[prVal.Key].amount - prVal.Value < 0)
                {
                    Console.WriteLine("Unable to carry on the purchase. " + prVal.Key.Name + "required:" + prVal.Value +
                                      ", in stock: " + _products[prVal.Key] + ".");
                    return null;
                }
            }

            // subtract products and form a bill
            var billList = new List<ProductBillInfo>();
            foreach (var prVal in productList)
            {
                _products[prVal.Key].amount -= prVal.Value;
                var billInfo = prVal.Key.GenerateBillInfo(_products[prVal.Key].price, prVal.Value);
                billList.AddRange(billInfo);
            }
            var bill = new Bill(generateBillId(), DateTime.Now, customer, billList);
            
            _bills.Add(bill);
            return bill;
        }

        private int generateBillId()
        {
            billNumber++;
            return billNumber;
        }
    }
}