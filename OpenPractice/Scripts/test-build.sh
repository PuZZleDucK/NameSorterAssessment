#!/bin/bash
set -o errexit
set -o pipefail

echo ":: UNIT TESTS"
dotnet test OpenPractice.Tests/Libs/NameSort/Unit/
echo ":: INTEGRATION TESTS"
dotnet test OpenPractice.Tests/Libs/NameSort/Integration/
echo ":: STRESS TESTS"
dotnet test OpenPractice.Tests/Libs/NameSort/Stress/
