

# Global X - Open Practice - Name Sorter Library

I have presented the project as a mock library called ```NameSorter``` in the ```Libs``` directory of the ```OpenPractice``` framework with a demo cli interface.

I have developed the project on Ubuntu 17.10 and tested it in CI on Ubuntu 14.04. It would be ideal to include alternative platforms.

I have chosen to use Semaphore for my CI service primarily as it is what I'm most familiar with. An added bonus was that it is not a "supported by default" platform on Semaphore so I got to learn how to set it up from scratch. Alternative providers would also be a bonus.


## Getting the "Open Practice" project

```sh
git clone https://github.com/PuZZleDucK/NameSorterAssessment
cd NameSorterAssessment
```

# Behind the Scenes

The following sections consist of my personal notes for the project. They are included here to allow you to  easily follow my thinking and progress through the project and would not normally be included in the repository or documentation.

## Assumptions and Issues

- We want the program to give a best-effort if the list contains invalid names (name not in output, warning printed to console (as it occurs and summary at end), possible err-out.txt list?)
- Including the library in a mock "OpenPractice" project means that the the main readme.md and other files referring to the library are in the wrong place and should be in the Libs directory and will have to be reffered to in the new OpenPractice readme.md
- The way the fail count is detected in CI is not ideal. If an error were to emmit the string "Failed: 0" as part of the error message this could fool the CI into thinking all is ok :(
- Could a name not have a last-name and only have a first-name? My assumption was a yes
- This last-name-could-be-null assumption causes an issue with where to sort a name with a single first-name and no last-name like "Teller" in a list where other entries have a last-name like "Raymond Joseph Teller". I have deided it makes most sense to list them in order at the top as the string "" seems to precede any other string
- The problem description describes invoking the program like so: ```name-sorter ./unsorted-names-list.txt```. However dotnet core seems to (by design) not produce standalone executables in the interests of platform independence. I have created a short build script that converts the .dll file produced by dotnet into an executable usable on linux systems but have not tested if this works on windows or mac.
- Performance limit on total file size (name count or length) in relation to machine memory. Difficult to overcome without overengineering (sort input into subcategories first, file buffering, etc)


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
- [ ] add alternative CI platforms/providers
- [ ] better erroring on invalid names
- [ ] code metrics
- [x] add release candidate
- [ ] review submission (style, documentation, presentation, CI/CD?)


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
- [ ] newbe/hackathon/low-hanging-fruit planning (multiple file arguments, output file specification, large files, ...)
- [x] unit test project
- [x] integration test project
- [x] stress tests project

- [ ] mostly long and descriptive naming
- [ ] self documenting... comments usually explain "why" or "why not the usual/expected way"
- [x] model / view separation - demo
- [ ] validation and verbose error reporting
- [ ] functional (foreach) style at times
- [x] nice .gitattributes
- [ ] Fody NullGuard - investigate if time allows
- [ ] honest about defects

Other observations not strictly relevant in no particular order:

- strict js :D
- material gui
- some old issues... mostly new
- some terse abbreviations in naming - only one code base
- ```if (object) { one liner }``` used often - only one code base

## The Challenge - GlobalX Coding Assessment

Below is a collection of notes and check points I intend to cover that has been condensed from the origional assessment challenge.

### Notes

- problem domain is deliberately simple
- our goal is not to see you implement a trivial sorting algroithm
- [ ] how your code communicates it's purpose clearly and with empathy to your potential team members.
- [ ] Caring about how easy your code is to understand and navigate for the next engineer who touches it.
- [ ] Understand your ability to compose quality code that adheres to SOLID principles
  - [ ] Single Responsibility Principle
  - [ ] Open/Close Principle
  - [ ] Liskov Substitution Principle
  - [ ] Interface Segregation Principle
  - [ ] Dependency Inversion Principle
- [ ] to see how you write tests.
- [ ] best effort
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
- [ ] When you are done let us know the url of the repo.

![](https://pbs.twimg.com/media/CyjIC1aUAAAjfCy?format=jpg&name=small)

By the way that's me with Uncle Bob! :D
