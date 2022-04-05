using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace StoreChain.Model
{
    public class ProductWithSerial : Product
    {
        public Guid SerialNumber { get; private set; }

        private Guid GenerateSerialNumber()
        {
            SerialNumber = Guid.NewGuid();
            return SerialNumber;
        }
        
        public override List<ProductBillInfo> GenerateBillInfo(float price, int amount)
        {
            var billInfo = new List<ProductBillInfo>();
            for (int i = 0; i < amount; i++)
            {
                ProductWithSerial singleProduct = this.MemberwiseClone() as ProductWithSerial;
                singleProduct.GenerateSerialNumber();
                billInfo.Add(new ProductBillInfo() { product = singleProduct, price = price, amount = amount });
            };
            return billInfo;
        }
    }
}