#!/bin/bash

OUTPUT="$(dotnet test)" 
echo "${OUTPUT}"
echo "${OUTPUT}" | tr "\n" " "  | grep -e "Failed: 0.*Failed: 0*Failed: 0"  && true || false