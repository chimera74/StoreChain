namespace StoreChain.Model
{
    public class Pharmacy: Shop
    {
        public override void SetStock(Product product, float price, int amount)
        {
            if (product.Type != ProductType.Cigarettes)
                base.SetStock(product, price, amount);
        }
    }
}