

# Global X - Open Practice and Name Sorter Library

[![Build Status](https://semaphoreci.com/api/v1/puzzleduck/namesorterassessment/branches/master/badge.svg)](https://semaphoreci.com/puzzleduck/namesorterassessment) [![Build Status](https://travis-ci.org/PuZZleDucK/NameSorterAssessment.svg?branch=master)](https://travis-ci.org/PuZZleDucK/NameSorterAssessment) [![Build status](https://ci.appveyor.com/api/projects/status/qsgtgxd20eloc8i0?svg=true)](https://ci.appveyor.com/project/PuZZleDucK/namesorterassessment)

## Preamble

I have presented my submission as a class library called ```NameSorter``` in the ```Libs``` directory of a mock ```OpenPractice``` framework. The NameSorter library has a demonstration command line interface for user exploration and extensive unit, integration and stress testing.

I have developed and tested the project on Ubuntu 17.10. It has also been tested Ubuntu 14.04 and Windows Visual Studio 2017 by Continuous Integration servers on [Semaphore](https://semaphoreci.com/puzzleduck/namesorterassessment), [Travis](https://travis-ci.org/PuZZleDucK/NameSorterAssessment/) and [AppVeyor](https://ci.appveyor.com/project/PuZZleDucK/namesorterassessment).

The project was developed using test driven development which can be easily observed by viewing the [Semaphore CI history](https://semaphoreci.com/puzzleduck/namesorterassessment) where I pushed every failing test before proceeding to develop the solution.


## Getting the "Open Practice" project

To build your own version of **OpenPractice** and all the associated libraries such as **NameSort** you will need to download the source code with the following commands:

```sh
git clone https://github.com/PuZZleDucK/NameSorterAssessment
cd NameSorterAssessment
```

You can build OpenPractice and all its associated libraries in one step with:

```sh
dotnet build
```


## Running the Library Demonstrations

You can run any of the library demonstration programs such as ```name-sorter``` by invoking the dotnet run command like so:

```sh
dotnet run --project OpenPractice/Demos/name-sorter/
```

## Developing with OpenPractice

If you're interested in getting to know more about OpenPractice or the NameSort library there are plenty of ways to get involved. You can check out [our wiki.](https://github.com/PuZZleDucK/NameSorterAssessment/wiki)

If your interested in developing a library, testing the code or contribuiting then checkout our excelent [contributing.md developer guide](https://github.com/PuZZleDucK/NameSorterAssessment/blob/master/contributing.md) for more information.



# Behind the Scenes

The following sections consist of my personal notes for the project. They are included here to allow you to  easily follow my thinking and progress through the project and would not normally be included in the repository or documentation.

## Assumptions and Issues

- Could a name not have a last-name and only have a first-name? My assumption was a yes
- This last-name-could-be-null assumption causes an issue with where to sort a name with a single first-name and no last-name like "Teller" in a list where other entries have a last-name like "Raymond Joseph Teller". I have decided it makes most sense to list them in order at the top as the string "" seems to precede any other string (bonus: it was easy)
- The problem description describes invoking the program like so: ```name-sorter ./unsorted-names-list.txt```. However dotnet core seems to (by design) not produce standalone executables in the interests of platform independence. I have included instructions on how to run the program as best I can.
- Main performance limit is dependant on total file size (a combination of name-count and name-length) in relation to machine memory. Difficult to overcome without over engineering (sort input into subcategories first, file buffering, etc)
- NuGet going down can cause build and tests to fail :(
- The final three integration tests reveal some issues with the windows build. "Madona\r\n" not equal to "Madona\r\n"... not sure how to debug that :/ ... the output is character for character an exact match and string lengths can be used to confirm no data is lost.


## The Plan

- [x] init repo
- [x] review GlobalX github repos for style/practices/project layout/etc
- [x] review challenge
- [x] initialise project
- [x] setup CI
- [x] initialise documentation & wiki
- [x] test program with no input - usage information
- [x] add simple sample data
- [x] test program with simple inputs
- [x] test advanced inputs
- [x] test mixed simple/advanced inputs
- [x] integration tests for file input/output
- [x] add cli interface
- [x] add advanced sample data
- [x] test examples on cli in integration
- [x] stress testing
- [x] add alternative CI platforms/providers
- [x] add helper methods
- [x] naming review
- [x] SOLID review
- [x] comment review
- [x] readability review
- [x] better erroring on invalid names
- [x] error if file does not exist
- [x] add release candidate
- [x] review c# conventions
- [x] update docs and references (check commands in docs work)
- [x] review submission (documentation, presentation, CI/CD?)


## GlobalX source code review observations

Observations from reviewing GlobalX public repositories on GitHub. They are presented in approximate order I expect to emulate the good examples:

- [x] top level Project & Project.Tests convention
- [x] include guides (user/dev) - readme.md/contributing.md
- [x] setup wiki
- [x] mit licence
- [x] CONTRIBUTING.md
- [x] include examples /
- [x] include demo
- [x] include samples
- [x] newbe/hackathon/low-hanging-fruit planning (multiple file arguments, output file specification, large files, ...)
- [x] unit test project
- [x] integration test project
- [x] stress tests project

- [x] mostly long and descriptive naming
- [x] self documenting... comments usually explain "why" or "why not the usual/expected way"
- [x] model / view separation - demo
- [x] validation and verbose error reporting
- [x] nice .gitattributes
- [x] honest about defects


## Notes form Assignment

- [x] our goal is not to see you implement a trivial sorting algroithm
- [x] how your code communicates it's purpose clearly and with empathy to others
- [x] how easy your code is to understand and navigate for the next person
- [x] Understand your ability to compose quality code that adheres to SOLID principles
  - [x] Single Responsibility Principle
  - [x] Open/Close Principle
  - [x] Liskov Substitution Principle
  - [x] Interface Segregation Principle
  - [x] Dependency Inversion Principle
- [x] to see how you write tests.
- [x] best effort
- [x] a solution that you are proud of

### Problem Specification

- [x] The Goal: Name Sorter
- [x] Given a set of names
- [x] order that set first by last name
- [x] then by any given names the person may have
- [x] A name must have at least 1 given name
- [x] A name may have up to 3 given names (what should I do for lists with invalid names?)
- [x] and create a file in the working directory called ```sorted-names-list.txt``` containing the sorted names.

### Assessment Criteria

- [x] We will execute your submission against a list with a thousand names - minimal stress test
- [x] The solution should be available for review on github.
- [x] The names should be sorted correctly.
- [x] It should print the sorted list of names to screen.
- [x] It should write/overwrite the sorted list of names to a file called sorted-names-list.txt.
- [x] Unit tests should exist.
- [x] Minimal, practical documentation should exist.
- [x] Create a build pipeline like Travis or AppVeyor that execute build and test steps.
- [x] When you are done let us know the url of the repo.

## Addendum

![](https://pbs.twimg.com/media/CyjIC1aUAAAjfCy?format=jpg&name=small)

By the way that's me with Uncle Bob! :D
