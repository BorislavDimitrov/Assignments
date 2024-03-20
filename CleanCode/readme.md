Some signs of bad code(code smells):
-Bad indentation, using too many spaces or using different number of spaces for a code that is on the same block level
-Leaving too many empty lines between the code
-Unnecessary nested ifs
-Unnecessary if
-Custom exception not being in separate files
-Enums not being in separate file
-Unmeaningful comments left
-Unnecessary comments left(code should be self-explaining)
-Lack of validation
-Unclear if clauses
-Hardcoded values
-Magic numbers 
-Caught exceptions but not handle it
-Badly named variables
-Code Duplication
-Used flag elements
-Used negative conditions

Some problems of the Speaker class:
-Most of the above mentioned problems lead to badly formatted, inconsistent and unreadable code.
-The class attempts to handle too many responsibilities. Best would be breaking these responsibilities into appropiate classes.
-If we decide to keep the responsibilities best will be to separate the big Register method into smaller ones.
-Could be applied validation for all data members and could be used more access modifiers else than only public to achieve better protection.
-There is some info that might be better to come from outside like the domains, employers and technologies.
-Since the class relies on hardcoded values, it is harder to extend or modify it.
-When we check if sessions is approved, we also chane its property value. Which in the context of our Register method is some kind of side effect.

It violates the following coding principles:
-Single Responsibility
-Open/Closed
-DRY (Dont repeat yourself)
-Encapsulation

For refactoring i did:
-Extract Methods
-Rename variables
-Extract exception classes and enums
-Replace magic numbers with named constants
-Merge duplicate code
-Remove dead code
-Proper formatting
-Data members validation
