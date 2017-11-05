
# Helping out

So you want to sort names, you've come to the right place.

## running the tests

To run all tests use:

```sh
dotnet test
```

To run only the Name Sorter tests run:
```sh
dotnet test OpenPractice.Tests/Libs/NameSort/Unit/
dotnet test OpenPractice.Tests/Libs/NameSort/Integration/
dotnet test OpenPractice.Tests/Libs/NameSort/Stress/
```

## Continuous Integration

NameSort has a CI pipeline setup at Semaphore: https://semaphoreci.com/puzzleduck/namesorterassessment/

[![Build Status](https://semaphoreci.com/api/v1/puzzleduck/namesorterassessment/branches/master/badge.svg)](https://semaphoreci.com/puzzleduck/namesorterassessment)


## Your first contribution

An easy place to start might be to add a reverse sorting option.

In order to do this we'll ...
