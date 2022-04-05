namespace StoreChain.Model
{
    public class CornerShop : Shop
    {
        public override void SetStock(Product product, float price, int amount)
        {
            if (product.Type != ProductType.Medicine)
                base.SetStock(product, price, amount);
        }
    }
}