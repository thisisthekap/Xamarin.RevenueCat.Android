# Xamarin.RevenueCat.Android

Xamarin.Android Bindings for RevenueCat ([Website](https://www.revenuecat.com/), [MVN](https://mvnrepository.com/artifact/com.revenuecat.purchases/purchases)).

## NuGet Feed

[https://www.nuget.org/packages/Xamarin.RevenueCat.Android/](https://www.nuget.org/packages/Xamarin.RevenueCat.Android/)

## Versioning Scheme

The versioning scheme of `Xamarin.RevenueCat.Android` is derived from the versioning of `com.revenuecat.purchases:purchases`.

### Example:

| com.revenuecat.purchases:purchases | Xamarin.RevenueCat.Android | Note |
|:--|:--|:--|
| 3.4.1 | 3.4.1.1 | First version of bindings for 3.4.1 |
| 3.4.1 | 3.4.1.17 | Bindings for 3.4.1 containing fixes |

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
* Karamunting.Kotlin.Android.Extensions.Runtime
	* Version >= 1.3.72

## Xamarin.RevenueCat.Android.UsageChecker.UITests

Use this project to briefly check if the bindings are working. Execute the Project in Visual Studio to execute the UI tests.

## License

The license for this repository is specified in 
[LICENSE.txt](LICENSE.txt)
