using System;
using System.Collections.Generic;

namespace StoreChain.Model
{
    public class Product
    {
        public string Name;
        public ProductType Type;

        public virtual List<ProductBillInfo> GenerateBillInfo(float price, int amount)
        {
            return new List<ProductBillInfo>()
            {
                new ProductBillInfo() { product = this, price = price, amount = amount }
            };
        }

        protected bool Equals(Product other)
        {
            return Name == other.Name && Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Type);
        }
    }

    public enum ProductType
    {
        Food, Drink, Medicine, Cigarettes, Toy, ParkingTicket
    }
}

