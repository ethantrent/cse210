// WHAT IS ABSTRACTION?

/* Abstraction is the process of turning complex ideas into simple ones. It is removing characteristics
from something so that only the essential ones remain.

The print function in Python is an abstraction. It is the simplification of something that is actually quite complex. 
In order to use it, all we need to know is the function name itself, or "print", and the required arguments, 
some literal text or a variable that can be transformed into literal text.*/

// OBJECTS AND CLASSES

/* Programming with classes is another way of creating abstractions in software.
An object is a conceptual model for a category of things, real or imagined, that has a specific 
responsibility within our program. 

For example, we might think of an object that holds and provides identifying information about a person.
Objects have state and behavior that allow them to fulfill their responsibility. The person object may have state 
like "given name" and "family name". It may also have related behaviors like "show western name" and "show eastern name".

With an object in mind we are ready to translate it to a code template called a class. The object's state is translated 
to variables called attributes. The object's behaviors are translated to functions called methods.

the standard in C# is to use TitleCase for class and method names, and to use _underscoreCamelCase for our member variable names.
The underscore at the beginning helps you recognize that the variables are members of the class and are different from regular, 
local variables.*/

 // A code template for the category of things known as Person. The
    // responsibility of a Person is to hold and display personal information.
    public class Person
    {
        // The C# convention is to start member variables with an underscore _
        public string _givenName = "";
        public string _familyName = "";

        // A special method, called a constructor that is invoked using the  
        // new keyword followed by the class name and parentheses.
        public Person()
        {
        }

        // A method that displays the person's full name as used in eastern 
        // countries or <family name, given name>.
        public void ShowEasternName()
        {
            Console.WriteLine($"{_familyName}, {_givenName}");
        }

        // A method that displays the person's full name as used in western 
        // countries or <given name family name>.
        public void ShowWesternName()
        {
            Console.WriteLine($"{_givenName} {_familyName}");
        }
    }

// CLASSES AND INSTANCES

/*By itself, a class is just a template for something. It only becomes useful when an instance is created and assigned to a 
variable in your program. An instance is the realization of attributes and methods in the computer's memory.*/

 Person person = new Person();
    person._givenName = "Joseph";
    person._familyName = "Smith";
    person.ShowWesternName();
    person.ShowEasternName();

/*  Output:
    Joseph Smith
    Smith, Joseph */

/* In this example, an instance of the Person class is created and assigned to the variable called "person". 
It is created by invoking a special method, called the constructor, which is the name of the class followed by parentheses.
Some programming languages, like Java, C# and others, require the "new" keyword when calling a constructor.

One of the most important aspects of programming with classes is that multiple instances can be created and used in the 
same program. The following example shows the creation of two Person instances. Notice how the "given name" attributes
are assigned different values, varying the behavior of the "show western name" method from one instance to the other.*/

  person1 = new Person();
    person1._givenName = "Emma";
    person1._familyName = "Smith";
    person1.ShowWesternName();

    person2 = new Person();
    person2._givenName = "Joseph";
    person2._familyName = "Smith";
    person2.ShowWesternName();

/* Output:
   Emma Smith
   Joseph Smith */

// CUSTOM DATA TYPES

/* When you create classes, you are really creating a new custom data type. For example, in C# there are built-in data types 
for integers and strings. When you declare a variable of these types, it is like making a box that can hold that type of data, 
and putting a label on the outside of the box with the variable name.*/

int height;
string color;

height = 17; // when you assign the value, it puts it in the box.
height = 24; // when you assign a new value, it replaces the old value in the box.


public class Blind
{
  public double _width;
  public double _height;
  public string _color;
}

/* With this new custom data type, you can now create a new variable whose type is Blind. We can think about this as creating 
a new box for it. The difference is that this box has a little separator inside it making three smaller compartments, 
one for each of the three member variables.

Every time you create a new Blind variable, it creates another large box that has these three components. 
The class is what defines the structure of the large box, and each of these large boxes that you create is an object 
or instance of that class.*/

Blind kitchen = new Blind(); // This creates a new variable called kitchen, which is a box that can hold a Blind object.

/* whenever you use the variable kitchen it refers to a large box, and if you want to refer to anything 
inside the box, you use the "dot" operator.*/

kitchen._width = 60; // This sets the width of the kitchen blind to 60.
kitchen._height = 48; // This sets the height of the kitchen blind to 48.
kitchen._color = "white"; // This sets the color of the kitchen blind to white.

Console.WriteLine(kitchen._width); // This prints the width of the kitchen blind.

/* Storing all of these values together in one larger box can greatly simplify your code, because, 
for example, you can now pass that whole large box to a function as a parameter, or return it.*/

// ADDING BEHAVIORS

/* In addition to storing values together that belong together, you can also put the member functions, 
or methods, that use that data right in the box with them*/
public class Blind
{
    public double _width;
    public double _height;
    public string _color;
    
    public double GetArea()
    {
        return _width * _height;
    }
}

/* The GetArea() function now belongs inside the box as well. And because it is inside the box, 
you use the "dot" notation to call it*/

double materialAmount = kitchen.GetArea(); // This calls the GetArea() method on the kitchen blind object, which returns the area of the blind.

Blind kitchen = new Blind();

kitchen._width = 60;
kitchen._height = 48;
kitchen._color = "White";

double materialAmount = kitchen.GetArea(); // you must supply the name of the object first, followed by a dot

// OBJECTS WITHIN OBJECTS

/* In the previous example, all of the member variables had simple types (double or string). But member variables 
can also have custom types. This is similar to putting another box inside the larger one.*/

public class House
{
    public string _owner;
    public Blind _kitchen;
    public Blind _livingRoom;
}

/* Remember, that you must initialize these blinds to new values. You can do this after you create a new House object*/

public class House
{
    public string _owner = "";
    public Blind _kitchen = new Blind();
    public Blind _livingRoom = new Blind();
}

/* Once you have created a new House object, you can access its member variables using the "dot" operator*/

House johnsonHome = new House();
johnsonHome._owner = "Johnson Family";

/* When you want to access the internal values of one of these complex-type, member variables, you can 
just chain together multiple "dot" operations*/

johnsonHome._kitchen._width = 60; // This sets the width of the kitchen blind in the Johnson home to 60.

// LIST OF CUSTOM TYPES

/* In the same way that you can create a list of strings or a list of doubles, you can also create a list of a new custom type. 
For example, instead of the House class containing variables for the kitchen and the living room blinds, it might have a 
list of blinds*/

public class House
{
    public string _owner;
    public List<Blind> _blinds = new List<Blind>();
}

/* With this new version of the House class, you could write code like:*/

foreach (Blind b in johnsonHome._blinds)
{
    double amount = b.GetArea();
}

// TERMS

/* Class - A new custom data type that defines attributes (member variables) and methods. This is like a blueprint to create instances or objects of that class. Example: A Person has given name and family name.

Instance - A variable whose data type is the class. We often use the term Object interchangeably. Example: We can have two instances of the Person class: one for John, and one for Mary.

Instantiate - A verb that means "to create an instance of." Example: We can instantiate the Person class to create a new object.

Method - A member function. Methods are called using "dot notation" with an instance of the class before the dot.*/