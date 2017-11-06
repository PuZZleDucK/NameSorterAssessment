#!/bin/bash
set -o errexit
set -o pipefail

dotnet test OpenPractice.Tests/Libs/NameSort/Unit/
dotnet test OpenPractice.Tests/Libs/NameSort/Integration/
dotnet test OpenPractice.Tests/Libs/NameSort/Stress/
