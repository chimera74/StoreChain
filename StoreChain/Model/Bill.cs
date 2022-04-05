using System;
using System.Collections.Generic;

namespace StoreChain.Model
{
    public class Bill
    {
        public readonly int id;
        public readonly DateTime date;
        public readonly Customer customer;
        public readonly List<ProductBillInfo> productList;

        public Bill(int id, DateTime date, Customer customer, List<ProductBillInfo> productList)
        {
            this.id = id;
            this.date = date;
            this.customer = customer;
            this.productList = productList;
        }

        public float GetTotal()
        {
            float total = 0; 
            foreach (var prInfo in productList)
            {
                total += prInfo.amount * prInfo.price;
            }

            return total;
        }
    }
}