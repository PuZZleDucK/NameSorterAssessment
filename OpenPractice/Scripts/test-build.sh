#!/bin/bash

dotnet test | tr "\n" " "  | grep -e "Failed: 0.*Failed: 0*Failed: 0"  && true || false
