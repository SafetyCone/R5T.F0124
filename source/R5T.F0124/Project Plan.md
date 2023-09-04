# R5T.F0124
The .NET Standard 2.1 base functionality library.


## Base Functionality Library

Base functionality libraries can reference:

* Type definition libraries (T####).
* Base functionality libraries for prior versions of .NET.

But nothing else. It should depend solely on the functionality of the C# language and the .NET Standard 2.1 library, and base functionality libraries for prior versions of .NET.

Base functionality libraries can contain:

* Strong Types
* Functions
* Values
* Extensions

But nothing else.


## Versus Platform Libraries

Platform libraries cannot reference anything

The R5T.F0000 library is a platform library. This is because the R5T.F0000 library predates the concept of a base functionality library.
