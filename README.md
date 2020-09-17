# Xamarin.RevenueCat.Android

Xamarin.Android Bindings for RevenueCat ([Website](https://www.revenuecat.com/), [MVN](https://mvnrepository.com/artifact/com.revenuecat.purchases/purchases)).

## Production Build Status

[![Build Status](https://funmusic.visualstudio.com/Xamarin%20RevenueCat%20Bindings/_apis/build/status/Production-Xamarin.RevenueCat.Android?branchName=refs%2Fpull%2F7%2Fmerge)](https://funmusic.visualstudio.com/Xamarin%20RevenueCat%20Bindings/_build/latest?definitionId=148&branchName=refs%2Fpull%2F7%2Fmerge)

## Versioning Scheme

The versioning scheme of `Xamarin.RevenueCat.Android` is derived from the versioning of `com.revenuecat.purchases:purchases`.

### Example:

| com.revenuecat.purchases:purchases | Xamarin.RevenueCat.Android | Note |
|:--|:--|:--|
| 3.4.1 | 3.4.1.1 | First version of bindings for 3.4.1 |
| 3.4.1 | 3.4.1.17 | Bindings for 3.4.1 containing fixes |

The initial version of `Xamarin.RevenueCat.Android` mapping `com.revenuecat.purchases:purchases` `3.4.1` is 

## Trouble Shooting

If you encounter errors like `Java.Lang.NoClassDefFoundError: Failed resolution of: Lkotlin/jvm/internal/Intrinsics`, consider to explicitly reference the transitive dependencies of `Xamarin.RevenueCat.Android`:

* Xamarin.Kotlin.StdLib.Jdk7
	* Version >= 1.3.72
* Xamarin.AndroidX.Lifecycle.Runtime
	* Version >= 2.1.0
* Xamarin.AndroidX.Lifecycle.Extensions
	* Version >= 2.1.0
* Xamarin.AndroidX.Annotation
	* Version >= 1.1.0
* Xamarin.Android.Google.BillingClient
	* Version >= 3.0.0

## License

The license for this repository is specified in 
[LICENSE.md](Xamarin.RevenueCat.Android/Xamarin.Android/LICENSE.md)