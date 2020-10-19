using Android.BillingClient.Api;
using Com.Revenuecat.Purchases;

namespace Xamarin.RevenueCat.Android.Extensions
{
    public class PurchaseSuccessInfo
    {
        public Purchase Purchase { get; }
        public PurchaserInfo PurchaserInfo { get; }

        public PurchaseSuccessInfo(Purchase purchase, PurchaserInfo purchaserInfo)
        {
            Purchase = purchase;
            PurchaserInfo = purchaserInfo;
        }
    }
}
