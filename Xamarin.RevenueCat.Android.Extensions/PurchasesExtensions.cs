using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Com.Revenuecat.Purchases;
using Com.Revenuecat.Purchases.Interfaces;
using Com.Revenuecat.Purchases.Models;
using Xamarin.RevenueCat.Android.Extensions.Exceptions;
using Xamarin.RevenueCat.Android.Extensions.Util;

namespace Xamarin.RevenueCat.Android.Extensions
{
    public static class PurchasesExtensions
    {
        public static Task<CustomerInfo> GetCustomerInfoAsync(this Purchases purchases,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceiveCustomerInfoCallback(cancellationToken);
            purchases.GetCustomerInfo(listener);
            return listener.Task;
        }

        public static Task<CustomerInfo> LogInAsync(this Purchases purchases, string newAppUserId,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingLogInCallback(cancellationToken);
            purchases.LogIn(newAppUserId, listener);
            return listener.Task;
        }

        public static Task<CustomerInfo> LogOutAsync(this Purchases purchases,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceiveCustomerInfoCallback(cancellationToken);
            purchases.LogOut(listener);
            return listener.Task;
        }

        public static Task<Offerings> GetOfferingsAsync(this Purchases purchases,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceiveOfferingsCallback(cancellationToken);
            purchases.GetOfferings(listener);
            return listener.Task;
        }

        [Obsolete("Use PurchaseAsync() instead")]
        public static Task<PurchaseSuccessInfo> PurchasePackageAsync(this Purchases purchases, Activity activity,
            Package packageToPurchase, CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingMakePurchaseListener(cancellationToken);
            purchases.PurchasePackage(activity, packageToPurchase, listener);
            return listener.Task;
        }

        public static Task<PurchaseSuccessInfo> PurchaseAsync(this Purchases purchases, Activity activity,
            Package packageToPurchase, CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingMakePurchaseListener(cancellationToken);
            var purchaseParams = new PurchaseParams(new PurchaseParams.Builder(activity, packageToPurchase));
            purchases.Purchase(purchaseParams, listener);
            return listener.Task;
        }

        public static Task<CustomerInfo> RestorePurchasesAsync(this Purchases purchases,
            CancellationToken cancellationToken = default)
        {
            var listener = new DelegatingReceiveCustomerInfoCallback(cancellationToken);
            purchases.RestorePurchases(listener);
            return listener.Task;
        }

        private class DelegatingReceiveCustomerInfoCallback : DelegatingListenerBase<CustomerInfo>,
            IReceiveCustomerInfoCallback
        {
            public DelegatingReceiveCustomerInfoCallback(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public void OnError(PurchasesError error)
            {
                ReportException(new PurchasesErrorException(error, false));
            }

            public void OnReceived(CustomerInfo customerInfo)
            {
                ReportSuccess(customerInfo);
            }
        }

        private class DelegatingLogInCallback : DelegatingListenerBase<CustomerInfo>, ILogInCallback
        {
            public DelegatingLogInCallback(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public void OnError(PurchasesError error)
            {
                ReportException(new PurchasesErrorException(error, false));
            }

            public void OnReceived(CustomerInfo customerInfo, bool created)
            {
                ReportSuccess(customerInfo);
            }
        }

        private class DelegatingMakePurchaseListener : DelegatingListenerBase<PurchaseSuccessInfo>, IPurchaseCallback
        {
            public DelegatingMakePurchaseListener(CancellationToken cancellationToken) : base(cancellationToken)
            {
            }

            public void OnCompleted(StoreTransaction storeTransaction, CustomerInfo customerInfo)
            {
                ReportSuccess(new PurchaseSuccessInfo(storeTransaction, customerInfo));
            }

            public void OnError(PurchasesError purchasesError, bool userCancelled)
            {
                ReportException(new PurchasesErrorException(purchasesError, userCancelled));
            }
        }

        private class DelegatingReceiveOfferingsCallback : DelegatingListenerBase<Offerings>, IReceiveOfferingsCallback
        {
            public DelegatingReceiveOfferingsCallback(CancellationToken cancellationToken) : base(cancellationToken)
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