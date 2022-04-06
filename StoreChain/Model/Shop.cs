using System;
using System.Collections.Generic;
using System.Text;

namespace StoreChain.Model
{
    public class Shop
    {
        public string Name { get; set; }

        private Dictionary<Product, ProductRecord> _products;
        private List<Bill> _bills;
        private int _billNumber;
        private List<PurchaseRecord> _purchaseRecords;

        public Shop()
        {
            _products = new Dictionary<Product, ProductRecord>();
            _bills = new List<Bill>();
            _billNumber = 0;
            _purchaseRecords = new List<PurchaseRecord>();
        }

        public virtual void SetStock(Product product, float price, int amount)
        {
            if (_products.ContainsKey(product))
                _products[product] = new ProductRecord(price, amount);
            else
                _products.Add(product, new ProductRecord(price, amount));
        }

        public Bill Purchase(Dictionary<Product, int> productList, Customer customer)
        {
            // check if enough stock
            foreach (var prVal in productList)
            {
                if (!_products.ContainsKey(prVal.Key) || _products[prVal.Key].amount - prVal.Value < 0)
                {
                    Console.WriteLine("Unable to carry on the purchase. \"" + prVal.Key.Name + "\" required: " + prVal.Value +
                                      ", in stock: " + _products[prVal.Key].amount + ".");
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
                var pr = new PurchaseRecord()
                {
                    shopType = this.GetType().Name,
                    productType = prVal.Key.Type.ToString(),
                    price = _products[prVal.Key].price,
                    amountAfter = _products[prVal.Key].amount,
                    amountBefore = _products[prVal.Key].amount + prVal.Value,
                    creationTime = DateTime.Now
                };
                _purchaseRecords.Add(pr);
            }
            var bill = new Bill(generateBillId(), DateTime.Now, customer, billList);
            
            
            _bills.Add(bill);
            return bill;
        }

        private int generateBillId()
        {
            _billNumber++;
            return _billNumber;
        }

        public void GenerateReport(DateTime startDate, DateTime endDate)
        {
            StringBuilder sbReport = new StringBuilder();
            foreach (var record in _purchaseRecords)
            {
                record.GenerateReportString(sbReport);
            }

            Console.WriteLine(sbReport);
        }
    }
}