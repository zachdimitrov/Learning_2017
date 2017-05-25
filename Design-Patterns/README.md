# Design Patterns with C#
- Telerik Academy Programming Course 05.2017
- [Current Issue](https://telerikacademy.com/Courses/Courses/Details/431)
- [Past Issue 2016](https://telerikacademy.com/Courses/Courses/Details/389)

## Principles in OOP Design - SOLID

#### Single Responsibility 
every object should have single responsibility and there should be only one reason to change

#### Open Closed
A Class should be open for extension and closed for modification
Three approaches:
- Parameters - pass delegates / callbacks
- Inheritance / Template Method pattern - Chold override base class behavior
- Composition / Strategy pattern - abstraction

#### Liskov Substitution Principle
A class should easily substitute its base class
- Tell, Don't ask - don't ask for types, tell the object what to do and it should do it
- Refactoring to base class - extract common functionality to base or 3-rd class

#### Interface Segregation Principle
- Interfases must be small and do only one thing
- All public methosts and properties of a class are also interface
- divide fat interface into smaller pieces
- adapter pattern - create adapter class that connects your interface with the fat one

#### Dependency Inversion Principle
- High level modules should not depend on modules on low level
- use higher level of abstraction - abstract class, base class, interface
- database, file system, static methods and types, new is glue are bad

*How to do it roght*  
- classes should declare what they need
- constructors should require dependencies
- don't call us we'll call you, dependency injection

*types of dependency injection*  
- constructor injection - add dependency in constructor
- property injection - add public property
- method parameter - only this method can use it
- poor man's ioc, IoC, starting point - new in it

#### DRY - repetition is bad
- Analyze solution for code clones (tool)

#### YAGNI - do not do more than needed
- More code - more time for many things

#### KISS - keep it simple stupid
#### Other Principles
- Golden Hammer - learn something cool and use it everywhere without need to
- Feature Creep - too many useless things
- Duct Tape Coder - not tested 
- Iseberg Class - do magic below
- Spagetty Core - no principles
- Calendar Coder - need to thing when copy code
- Reinventing the Wheel - opposite
- Boyscout Rule, NY Police - Car with broken window
