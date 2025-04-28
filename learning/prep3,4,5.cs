// Loops

/* Only difference from Python is the curly braces */
string response = "yes";

while (response == "yes")
{
    Console.Write("Do you want to continue? ");
    response = Console.ReadLine();
}

// Do-While Loops

/* body of the loop runs once first, before the check is made for the first time */

string response;

do
{
    Console.Write("Do you want to continue? ");
    response = Console.ReadLine();
} while (response == "yes");

// For
/* The first initializes the value, the second is the condition to check,
 and the third is an increment step that is run at the end of each loop
the ++ increments the value in the variable by one */

//   starting value; check condition; increment step
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

/* could put other values or statements in these spots, such as counting from 2 to 20 by two's */
for (int i = 2; i <= 20; i = i + 2)
{
    Console.WriteLine(i);
}

// Foreach

foreach (string color in colors)
{
    Console.WriteLine(color);
}

// Random Numbers

Random randomGenerator = new Random();
int number = randomGenerator.Next(1, 11);

// Lists

List<int> numbers; // List of integers
List<string> words; // List of strings

// The code above declares a variable to hold the list, but before you can use one, you need to create 
// a new one to use with the new keyword

List<int> numbers = new List<int>();
List<string> words = new List<string>();

// Any file that uses Lists (or any other standard collection), must refer to that library at the top of the file

using System.Collections.Generic;

// List is a class or custom data type and we are creating a new object or instance of that class

// To add items to the list, you use the .Add() method

using System.Collections.Generic;

...

List<string> words = new List<string>();

words.Add("phone");
words.Add("keyboard");
words.Add("mouse");

// You can get the size of the list with the Count property

Console.WriteLine(words.Count);

// The easiest (and safest) way to iterate through a list in C# is to use the foreach loop

foreach (string word in words)
{
    Console.WriteLine(word);
}

// You can also access the items by their index


for (int i = 0; i < words.Count; i++)
{
    Console.WriteLine(words[i]);
}

// method (functions)

string name = "Bob";
int age = 42;

singHappyBirthday(name, age); // call the method in Main with the arguments

static void singHappyBirthday(string name, int age) // argument is passed in
{
    Console.WriteLine("Happy birthday to you!");
    Console.WriteLine("Happy birthday to you!");
    Console.WriteLine($"Happy birthday dear {name}!");
    Console.WriteLine($"You are now {age} years old!");
    Console.WriteLine("Happy birthday to you!");
    Console.WriteLine();
}

// The general structure of a function definition in C# is:

returnType FunctionName(dataType parameter1, dataType parameter2)
{
    // function_body
}

// One key difference in C# is that in the same way that each variable must define a type, 
// each function must define its return type, for example, whether it will return an int, a string, 
// or nothing (the return type for nothing is void)

void DisplayMessage()
{
    Console.WriteLine("Hello world!");
}

// add two numbers together and return the result
int AddNumbers(int first, int second)
{
    int sum = first + second;
    return sum;
}


// If you want to define "regular" standalone function, you need to use the static keyword. 
// This tells C# that you want your functions to be able to be called without any other context.
static void DisplayMessage()
{
    Console.WriteLine("Hello world!");
}

static void DisplayPersonalMessage(string userName)
{
    Console.WriteLine($"Hello {userName}");
}

static int AddNumbers(int first, int second)
{
    int sum = first + second;
    return sum;
}

// Use static for all of your functions until we start writing classes.

// Variable Scope

// Just like in Python, variables declared and used in the body of a function can only be accessed within 
// that function (they cannot be accessed in main or any other function).

