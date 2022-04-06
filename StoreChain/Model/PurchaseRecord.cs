using System;
using System.Text;

namespace StoreChain.Model
{
    public class PurchaseRecord
    {
        public string shopType;
        public string productType;
        public float price;
        public int amountBefore;
        public int amountAfter;
        public DateTime creationTime;
        
        private const string REPORT_FORMAT = "{0,12}|{1,13}|{2,8}|{3,6}|{4,6}|{5,20}\n";

        public static string GenerateReportHeader()
        {
            return string.Format(REPORT_FORMAT, "Shop type", "Product type", "Price", "Before", "After", "Date&Time");
        }

        public void GenerateReportString(StringBuilder sb)
        {
            sb.AppendFormat(REPORT_FORMAT, shopType, productType, price, amountBefore, amountAfter, creationTime);
        }
    }
}