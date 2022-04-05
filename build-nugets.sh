#!/bin/bash
projects=$(cat ./projects.txt)

for project in ${projects}; do
	cd ${project}
	rm nugetoutput/*.nupkg
	msbuild /p:Configuration=Release /t:Clean
	msbuild /p:Configuration=Release /t:Restore
	msbuild /p:Configuration=Release /t:Build
	msbuild /p:Configuration=Release /t:Pack
	cd ..
done
./copy-nugets.sh
