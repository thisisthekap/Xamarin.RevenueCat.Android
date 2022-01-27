using System;
using Com.Revenuecat.Purchases;

namespace Xamarin.RevenueCat.Android.Extensions.Exceptions
{
    public class PurchasesErrorException : Exception
    {
        public PurchasesError PurchasesError { get; }
        public bool UserCancelled { get; }

        public PurchasesErrorException(PurchasesError purchasesError, bool userCancelled)
            : base($"{purchasesError?.Message} ({purchasesError?.UnderlyingErrorMessage}) code: {purchasesError?.Code} userCancelled: {userCancelled}")
        {
            PurchasesError = purchasesError;
            UserCancelled = userCancelled;
        }
    }
}
