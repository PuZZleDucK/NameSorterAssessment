
# Helping out

So you want to help develop **Open Practice**. The simplest way to get started is in one of the many useful libraries in the ```Libs``` directory such as **NameSort**.


## Project Structure

In the main directory we find many miscellaneous files for git and continuous integration. We also have some documentation files in markdown format and a .sln file which links all the OpenPractice projects, libraries and tests together for the dotnet core tools.

The two directories that hold the bulk of the project are **OpenPractice** and **OpenPractice.Tests**. Looking into ```OpenPractice.Tests``` we see a project folder for test helper classes and another containing tests for libraries. In general each library will have it's own set of test requirements, but if we look into the ```NameSort``` directory for example we can see projects dedicated to unit, integration and stress testing.

Moving over now to the main ```OpenPractice``` folder we see folders for **helpers**, **scripts**, **libraries** and **demos**. The ```Helpers``` and ```Scripts``` directories hold code generally usefull in many parts of the software or useful in building the project. The ```Libs``` directory contains all the plugins and modules used by OpenPractice such as the NameSort class library. The ```Demos``` directory contains programs written to demonstrate the capabilities of OpenPractice and its libraries like NameSort (which has a ```name-sorter``` demonstration program).


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

An easy place to start might be to add an option to the NameSort library to sort by first name.

### Add a Failing Test - Red

In order to do this we'll first need to introduce an error in our tests in order to resolve the issue. Open the ```OpenPractice.Tests/Libs/NameSort/Unit/UnitTests.cs``` file and add a new test by adding a test based on this template:

```csharp
[Fact]
public void DescriptiveTestName()
{
    string[] simple_name = { "Bono" };
    Assert.Equal("Bono", String.Join(" ", _nameSorter.SortNames(simple_name, true)));
}
```

and we can verify our test now fails with:

```sh
dotnet test OpenPractice.Tests/Libs/NameSort/Unit/
```

### Fix Failing Test - Green

Now we will edit the ```OpenPractice/Libs/NameSort``` library to fix the failing test we introduced. Open up the file ```NameSort.cs``` and take a look at the ```SortNames(string[] unsorted_names)``` function, this is where we will need to work. Add an optional parameter to the function:

```csharp
public string[] SortNames(string[] unsorted_names, bool sort_on_first_name = false)
```

Then in the OrderBy clause we can conditionally switch between our sorting methods:

```csharp
if(sort_on_first_name)
{
    return other_names + " " + last_name;
} else {
    return last_name + " " + other_names;
}
```

and we can see our tests are green again:

```sh
dotnet test OpenPractice.Tests/Libs/NameSort/Unit/
```

Of course this is not the most ideal (or well tested) code but it serves to introduce us to the structure of the project.

### Add a Demonstration

Now that we've got an exciting new feature in our library we'll need to create a new demonstration program for our first-name-sorting feature. We will need to make a new project in the ```OpenPractice/Demos``` directory with the following commands:

```sh
cd OpenPractice/Demos
mkdir first-name-sorter
cd first-name-sorter
dotnet new console
dotnet add reference ../../../OpenPractice/Libs/NameSort/NameSort.csproj
dotnet add reference ../../../OpenPractice/Helpers/Helpers.csproj
cd ../../..
dotnet sln add ./OpenPractice/Demos/first-name-sorter/first-name-sorter.csproj
dotnet build
```

You will see our new application being compiled along with all the other libraries and tests. Then we will edit the generated file ```Program.cs``` and base the file on ```OpenPractice/Demos/name-sorter``` with the only significant change being on line 21 where we set our new boolean flag to true:

```csharp
string[] sorted_names = name_sorter.SortNames(System.IO.File.ReadAllLines(args[0]), true);
```

### Running Your New Demonstration - Congratulations!

Now we can build and run our new demonstration program with:

```sh
dotnet build
dotnet run --project OpenPractice/Demos/first-name-sorter/
```

## Where to Next?

Other interesting but simple projects could be to add a reverse sorting, handle multiple file names on the command line, allowing the user to specify an alternative output file, or if you're realy ambitious you could tackle the problem of sorting really large files.

You can always keep in touch or contribute ideas on [our wiki](https://github.com/PuZZleDucK/NameSorterAssessment/wiki) or on [GitHub issues.](https://github.com/PuZZleDucK/NameSorterAssessment/issues)
