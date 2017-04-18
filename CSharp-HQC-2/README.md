# Defensive Programming

- always expect incorrect input
- create correct exception messages
- user must never see exception messages

### Assertions

- must be used only for very heavy failure situations
- not used often
- cannot be try/catched
- gives a message with stack trace

```c#
public class StudentGradesCalculator
{
    private readonly IList<int> studentGrades;
    public StudentGradesCalculator(IList<int> studentGrades)
    {
        this.studentGrades = studentGrades;
    }

    public double GetAverageStudentGrade()
    {
        Debug.Assert(studentGrades != null && studentGrades.Count > 0,
        "Student grades are not initialised"); // better make validation in constructor

        return studentGrades.Average();
    }
}

public class AssertionDemo
{
    static void Main()
    {   // this will not work in release
        Debug.Assert(PerformAction(), "Could not perform action"); // if statement is true program is working

        StudentGradesCalculator calc = new StudentGradesCalculator(new Int[] {5, 6, 4, 3, 4, 5, 6});
        Console.WriteLine(calc.GetAverageStudentGrade());

        calc = new StudentGradesCalculator(new Int[] {}); // this will interrupt the execution
        Console.WriteLine(calc.GetAverageStudentGrade());
    }

    private static bool PerformAction()
    {
        Console.WriteLine("Action performed.");
        return true;
    }
}
```

### Exceptions

- use only in exceptional situations
- can be very slow (do not use for simple errors as user names)
- crate custom exception Class when needed
- messages need to be very descriptive

#### Defense Clauses
```c#
if (input == null) 
{
    throw new ArgumentException("Input cannot be null");
}
```
#### Try - Catch blocks
```c#
try
{
    readInput(input);
}
catch (ArgumentException e)
{
    Console.WriteLine("Invalid Argument");
}
finally
{
    Console.WriteLine("Hello from Finally!"); // used for closing IDisposable for example
}
```

#### [Bytes2you.Validation](https://github.com/veskokolev/Bytes2you.Validation) library
- include from NuGet and use like this

```c#
Guard.WhenArgument(number, "Action number")
    .IsGreaterThan(15)
    .IsLessThan(10)
    .Throw();
```

#### Robustness vs. Correctness
- **Robustness** - always try to return something (video decoding or game)
- **Correctness** - never return wrong result (bank or medical software)

#### Error Barricades
- public methods / functions
- private methods / functions


### Release and Debug modes in Visual Studio

#### Release mode
- **unsafe mode** - allows to use `unsafe {}` block
- **optimise** 
    - removes debugger/breakpoints - allows program to start faster
    - removes dead code (after return)
    - changes cycles
    - Debug class is removed - all code in `Debug.Assert()` will not work
    

 