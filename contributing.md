
# Helping out

So you want to help develop Open Practice. The simplest way to get started helping Open Practice is in one of the many useful libraries in the ```Libs``` directory.

## Project Structure

In the main directory we find many miscelanious files for git and continuious integration. We also have some documentation files in markdown format and a .sln file which links all the projects, libraries and tests together for the dotnet core tools.

The two directories that hold the bulk of the project are *OpenPractice* and *OpenPractice.Tests*. Looking into OpenPractice.Tests we see a project folder for test helper classes and another containing tests for libraries. In general each library will have it's own set of test requirements, but if we look into the ```NameSort``` directory for example we can see projects dedicated to unit, integration and stress testing.

Moving over now to the main OpenPractice folder we see folders for *helpers*, *scripts*, *libraries* and *demos*. The ```Helpers``` and ```Scripts``` directories hold code generally usefull in many parts of the software or usefull in building the project. The ```Libs``` directory contains all the plugins and modules used by OpenPractice such as the NameSort class library. The ```Demos``` directory contains programs written to demonstrate the capabilities of OpenPractice and its libraries like NameSort (which has a name-sorter demonstration program)



## running the tests

To run all tests use:

```sh
dotnet test
```

or

```sh
./OpenPractice/Scripts/test-build.sh
```

To run only the a specific suite of tests run one of the following:

```sh
dotnet test OpenPractice.Tests/Libs/NameSort/Unit/
dotnet test OpenPractice.Tests/Libs/NameSort/Integration/
dotnet test OpenPractice.Tests/Libs/NameSort/Stress/
```

## Your first contribution

An easy place to start might be to add an option to the NameSorter library to sort by first name.

In order to do this we'll first need to introduce an error in our tests in order to resolve the issue. Open the ```OpenPractice.Tests/Libs/NameSort/Unit/UnitTests.cs``` file and add a new test by...

Now we will edit the ```OpenPractice/Libs/NameSort``` library to fix the failing test we introduced. Open up the file ```NameSort.cs``` and take a look at the ```SortNames(string[] unsorted_names)``` function, this is where we will need to work...

In order to create a new demonstration program for our first name sorting we will need to make a new project in the ```OpenPractice/Demos``` directory...

```
cd OpenPractice/Demos
...
cd ../..



Other interesting but simple projects could be to add a reverse sorting, handle multiple file names on the command line, allowing the user to specify an alternative output file, or if you're realy ambitious you could tackle the problem of sorting realy large files.
