// Types

int x = 5;
string y = "Hello";
bool z = true;
double a = 3.14;
char b = 'A';

// Input and Output

Console.WriteLine("Hi there!"); // will print, or write, a full line, including the new line
Console.Write("Hi there!"); // will print, or write, without the new line

Console.Write("Enter your name: ");
string name = Console.ReadLine(); // will read a line from the console, including the new line using the function
Console.WriteLine($"Hello, {name}"); // will print a formatted string, including the new line

// Blocks

/* Curly braces are used to define a block of code. 
   A block of code is a group of statements that are executed together. 
   Curly braces are used to define the scope of a block of code. */

if (x > y)
{
  Console.WriteLine("greater");
}

// Semicolon

/*  A semicolon is used to terminate a statement.
    semicolon is used to separate statements in a block of code.
    do not put a semicolon between the condition of an if statement and its body, or the name of a function and its body */

// String Interpolation

string school = "BYU-I";
Console.WriteLine($"I go to {school}"); // will print a formatted string, including the new line

// If Statements

/* Slightly different than Python, C# requires a condition to be in parentheses. 
   The body of the if statement is in curly braces. 
   The else statement is not required to have a condition. */

if (x > y)
{
    Console.WriteLine("x is greater than y");   
}

// Else and Else If Statements

if (x > y)
{
    Console.WriteLine("x is greater than y");   
}
else if (x < y)
{
    Console.WriteLine("x is less than y");   
}
else
{
    Console.WriteLine("x is equal to y");   
}

// Operators

if (name == "John") // == is the equality operator, checks if two values are equal
{
    Console.WriteLine("The name is John");
}

if (color != favoriteColor) // != is the inequality operator, checks if two values are not equal
{
    Console.WriteLine("The color is not my favorite");
}

if (name == "Peter" || name == "James" || name == "John") // || is the logical OR operator, checks if at least one of the conditions is true
{
    Console.WriteLine("This is a biblical name.");
}

if (firstName == "Brigham" && lastName == "Young") // && is the logical AND operator, checks if both conditions are true
{
    Console.WriteLine("Welcome Brother Brigham!");
}

if (!(name == "Peter" || name == "James" || name == "John")) // ! is the logical NOT operator, negates the condition
{
    Console.WriteLine("This is a not one of those three");
}

// Variables and Types

/* Camel case is used for variable names. 
   Pascal case is used for class names. 
   Snake case is used for file names. 
   Upper case is used for constants. */

bool isStudent = true; // boolean
string fullName = $"{firstName} {lastName}"; // string interpolation

/* You can, however convert a the value of a variable to a different type using the int.Parse() function */

string valueInText = "42";
int number = int.Parse(valueInText);

/* This is especially important if the value comes from the user via a Console.ReadLine() statement, which always returns a string */
Console.Write("What is your favorite number? ");
string userInput = Console.ReadLine();
int number = int.Parse(userInput);

/* Similarly, an integer can be converted to a string using the .ToString() function of the variable */

int number = 42;
string textVersion = number.ToString();