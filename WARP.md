# WARP.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Development Commands

### Build and Run
```bash
# Build the solution
dotnet build AdventOfCode/AdventOfCode.sln

# Run the main console application
dotnet run --project AdventOfCode/AdventOfCode/AdventOfCode.csproj

# Build in release mode
dotnet build AdventOfCode/AdventOfCode.sln --configuration Release
```

### Testing
```bash
# Run all tests
dotnet test AdventOfCode/AdventOfCode.sln

# Run tests with verbose output
dotnet test AdventOfCode/AdventOfCode.sln --verbosity normal

# Run tests for a specific project
dotnet test AdventOfCode/AdventOfCode.Tests/AdventOfCode.Tests.csproj

# Run tests matching a pattern
dotnet test --filter "DayOne"
```

### Development Workflow
```bash
# Clean build artifacts
dotnet clean AdventOfCode/AdventOfCode.sln

# Restore NuGet packages
dotnet restore AdventOfCode/AdventOfCode.sln

# Watch for changes and rebuild
dotnet watch run --project AdventOfCode/AdventOfCode/AdventOfCode.csproj
```

## Architecture Overview

This is an **Advent of Code** solutions repository written in C# targeting .NET Core 3.1. The codebase follows a year-based organizational structure for solving programming challenges.

### Project Structure
- **AdventOfCode/AdventOfCode**: Main console application containing solution implementations
- **AdventOfCode/AdventOfCode.Tests**: XUnit test project with unit tests for solutions
- **Year-based namespaces**: Solutions organized by year (e.g., `_2017` namespace)

### Key Components

#### Solver Pattern
Each year has a `Solver` class that implements solution methods for that year's challenges:
- Methods typically follow naming convention like `SumOfRepeatedNumbersNextDigit()` for part 1
- Extended versions for part 2 challenges (e.g., `SumOfRepeatedNumbersExtended()`)
- Solutions return `double` type to handle various numeric result types

#### Input Handling
- `PuzzleInputs.cs`: Static class containing puzzle input data as string constants
- Input data stored as `const string` fields (e.g., `DayOne`, `DayTwo`)
- `MyExtensions.cs`: Utility methods for parsing input formats:
  - `ConvertToLongArray()`: Converts string sequences to long arrays
  - `ConvertToList()`: Parses spreadsheet data into lists of long arrays
  - `Tokenize()`: String tokenization with escape character support

#### Testing Architecture
- XUnit framework with theory-based testing using `[InlineData]`
- Test classes organized by day/challenge (e.g., `DayOneTests`, `InverseCaptchaTests`)
- Both part 1 and part 2 solutions tested with example inputs from problem statements

### Development Patterns

#### Adding New Solutions
1. Create solver methods in the appropriate year's `Solver` class
2. Add input data to `PuzzleInputs.cs` as const string
3. Update `Program.cs` to call new solver methods
4. Create corresponding test class with example test cases

#### File Organization
- Year-based folders under both main project and test project
- Solver classes contain all solutions for a given year
- Test classes mirror the structure with descriptive names for different challenges

#### Extension Methods
The codebase relies heavily on extension methods in `MyExtensions.cs` for input parsing, enabling fluent syntax like `spreadsheet.ConvertToList()` for transforming puzzle inputs into workable data structures.