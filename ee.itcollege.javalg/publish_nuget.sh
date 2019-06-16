#!/bin/sh

#clean old junk, includes custom target in Directory.Build.targets - cleans old bin and obj files
dotnet clean

# build release dll
dotnet build --configuration release 

# add .nuget files.
dotnet pack --configuration release  

#publish all the package files
nuget push -ApiKey [enter api key here] -Source [nuget url]
