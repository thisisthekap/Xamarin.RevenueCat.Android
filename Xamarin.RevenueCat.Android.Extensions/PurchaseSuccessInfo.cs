using Com.Revenuecat.Purchases;
using Com.Revenuecat.Purchases.Models;

namespace Xamarin.RevenueCat.Android.Extensions
{
    public class PurchaseSuccessInfo
    {
        public StoreTransaction StoreTransaction { get; }
        public CustomerInfo CustomerInfo { get; }

        public PurchaseSuccessInfo(StoreTransaction storeTransaction, CustomerInfo customerInfo)
        {
            StoreTransaction = storeTransaction;
            CustomerInfo = customerInfo;
        }
    }
}
