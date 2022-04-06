using System.Drawing;

namespace StoreChain.Model
{
    public class ProductRecord
    {
        public float price;
        public int amount;

        public ProductRecord(float price, int amount)
        {
            this.price = price;
            this.amount = amount;
        }
    }
}