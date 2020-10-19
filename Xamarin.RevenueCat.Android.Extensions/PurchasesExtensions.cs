using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.BillingClient.Api;
using Com.Revenuecat.Purchases;
using Com.Revenuecat.Purchases.Interfaces;
using Xamarin.RevenueCat.Android.Extensions.Exceptions;
using Xamarin.RevenueCat.Android.Extensions.Util;
using Package = Com.Revenuecat.Purchases.Package;

namespace Xamarin.RevenueCat.Android.Extensions
{
    public static class PurchasesExtensions
    {
        public static Task<PurchaserInfo> IdentifyAsync(this Purchases purchases, string newAppUserId,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceivePurchaserInfoListener(cancellationToken);
            purchases.Identify(newAppUserId, listener);
            return listener.Task;
        }

        public static Task<Offerings> GetOfferingsAsync(this Purchases purchases,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceiveOfferingsListener(cancellationToken);
            purchases.GetOfferings(listener);
            return listener.Task;
        }

        public static Task<PurchaseSuccessInfo> PurchasePackageAsync(this Purchases purchases, Activity activity,
            Package packageToPurchase, CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingMakePurchaseListener(cancellationToken);
            purchases.PurchasePackage(activity, packageToPurchase, listener);
            return listener.Task;
        }

        public static Task<PurchaserInfo> RestorePurchasesAsync(this Purchases purchases,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceivePurchaserInfoListener(cancellationToken);
            purchases.RestorePurchases(listener);
            return listener.Task;
        }

        private class DelegatingReceivePurchaserInfoListener : DelegatingListenerBase<PurchaserInfo>,
            IReceivePurchaserInfoListener
        {
            public DelegatingReceivePurchaserInfoListener(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public void OnError(PurchasesError purchasesError)
            {
                ReportException(new PurchasesErrorException(purchasesError, false));
            }

            public void OnReceived(PurchaserInfo purchaserInfo)
            {
                ReportSuccess(purchaserInfo);
            }
        }

        private class DelegatingMakePurchaseListener : DelegatingListenerBase<PurchaseSuccessInfo>,
            IMakePurchaseListener
        {
            public DelegatingMakePurchaseListener(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public void OnCompleted(Purchase purchase, PurchaserInfo purchaserInfo)
            {
                ReportSuccess(new PurchaseSuccessInfo(purchase, purchaserInfo));
            }

            public void OnError(PurchasesError purchasesError, bool userCancelled)
            {
                ReportException(new PurchasesErrorException(purchasesError, userCancelled));
            }
        }

        private class DelegatingReceiveOfferingsListener : DelegatingListenerBase<Offerings>, IReceiveOfferingsListener
        {
            public DelegatingReceiveOfferingsListener(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public void OnError(PurchasesError purchasesError)
            {
                ReportException(new PurchasesErrorException(purchasesError, false));
            }

            public void OnReceived(Offerings offerings)
            {
                ReportSuccess(offerings);
            }
        }
    }
}