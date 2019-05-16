#!/bin/sh

#clean old junk, includes custom target in Directory.Build.targets - cleans old bin and obj files
dotnet clean

# build release dll
dotnet build --configuration release 

# add .nuget files.
dotnet pack --configuration release  

# oy2pfyusmhpvpg3c7ypa6mjrq5kqxjluxgktfl5xdguo3q
#publish all the package files
nuget push -ApiKey oy2pfyusmhpvpg3c7ypa6mjrq5kqxjluxgktfl5xdguo3q -Source https://api.nuget.org/v3/index.json ee.itcollege.javalg**Release/ee.itcollege.javalg*.nupkg 
