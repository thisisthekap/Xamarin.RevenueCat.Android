#!/bin/bash
projects=" \
	Xamarin.RevenueCat.Android.Core.Strings \
	Xamarin.RevenueCat.Android.Core.Utils \
	Xamarin.RevenueCat.Android.Core.Public \
	Xamarin.RevenueCat.Android.Core.Common \
	Xamarin.RevenueCat.Android.Core.Feature.Subscriber.Attributes \
	Xamarin.RevenueCat.Android.Core.Feature.Identity \
	Xamarin.RevenueCat.Android.Store.Google \
	Xamarin.RevenueCat.Android \
	Xamarin.RevenueCat.Android.Store.Amazon \
	Xamarin.RevenueCat.Android.Extensions"

mkdir -p nugetoutput
rm nugetoutput/*.nupkg

for project in $projects; do
	cd $project
	rm nugetoutput/*.nupkg
	msbuild /p:Configuration=Release /t:Clean
	msbuild /p:Configuration=Release /t:Restore
	msbuild /p:Configuration=Release /t:Build
	msbuild /p:Configuration=Release /t:Pack
	cp nugetoutput/*.nupkg ../nugetoutput/
	cd ..
done
