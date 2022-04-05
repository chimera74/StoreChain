namespace StoreChain.Model
{
    public class Supermarket : Shop
    {
        public override void SetStock(Product product, float price, int amount)
        {
            if (product.Type != ProductType.Medicine 
                || product.Type != ProductType.Cigarettes)
                base.SetStock(product, price, amount);
        }
    }
}