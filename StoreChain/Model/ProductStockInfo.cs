using System.Drawing;

namespace StoreChain.Model
{
    public class ProductStockInfo
    {
        public float price;
        public int amount;

        public ProductStockInfo(float price, int amount)
        {
            this.price = price;
            this.amount = amount;
        }
    }
}