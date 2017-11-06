#!/bin/bash

echo ":: FETCHING MS GPG KEY"
curl https://packages.microsoft.com/keys/microsoft.asc | gpg --dearmor > microsoft.gpg
echo ":: MOVING KEY"
sudo mv microsoft.gpg /etc/apt/trusted.gpg.d/microsoft.gpg
echo ":: ADD DOTNET REPO"
sudo sh -c 'echo "deb [arch=amd64] https://packages.microsoft.com/repos/microsoft-ubuntu-trusty-prod trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
echo ":: UPDATE REPOS"
sudo apt-get update
echo ":: INSTALL DOTNET"
sudo apt-get install -qy dotnet-sdk-2.0.2
echo ":: INSTALL libcurl3"
sudo apt-get install -qy libcurl3

