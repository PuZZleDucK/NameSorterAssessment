#!/bin/bash

dotnet publish -c release -r ubuntu.14.04-x64
#binary always fails if moved :(
#cp OpenPractice/Demos/name-sorter/bin/Release/netcoreapp2.0/ubuntu.14.04-x64/publish/name-sorter OpenPractice/Demos/name-sorter/
