# Xamarin.RevenueCat.Android

Xamarin.Android Bindings for RevenueCat ([Website](https://www.revenuecat.com/), [MVN](https://mvnrepository.com/artifact/com.revenuecat.purchases/purchases)).

## NuGet Feed

### Xamarin.RevenueCat.Android

This nuget package consists of the actual Xamarin.Android bindings.

[https://www.nuget.org/packages/Xamarin.RevenueCat.Android/](https://www.nuget.org/packages/Xamarin.RevenueCat.Android/)

### Xamarin.RevenueCat.Android.Extensions

This nuget package contains convenience methods to be able to use things like async/await when working with Xamarin.RevenueCat.Android.

[https://www.nuget.org/packages/Xamarin.RevenueCat.Android.Extensions/](https://www.nuget.org/packages/Xamarin.RevenueCat.Android.Extensions/)

## Versioning Scheme

The versioning scheme of `Xamarin.RevenueCat.Android` (and `Xamarin.RevenueCat.Android.Extensions`) is derived from the versioning of `com.revenuecat.purchases:purchases`.

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

## List runtime dependencies of `com.revenuecat.purchases:purchases`

When creating the bindings for a new version, you might need to know the runtime classpath dependencies of `com.revenuecat.purchases:purchases`.

Within the checked out RevenueCat repository, this command may be used to accomplish this task:

`‌gradle dependencies --configuration releaseRuntimeClasspath`

Optionally add the `--scan` option to the command to view a "web-based, searchable dependency report".

## License

The license for this repository is specified in 
[LICENSE.txt](LICENSE.txt)
