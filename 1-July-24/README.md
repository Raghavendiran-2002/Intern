# Python Concepts: Scopes, Namespaces, Class Creation, Inheritance, Exception Handling, Polymorphism, Modules, and File Handling

## Scopes and Namespaces

In Python, a **scope** refers to the region of the code where a particular variable is accessible. There are four types of scopes:

1. **Local Scope**: Variables defined within a function.
2. **Enclosing Scope**: Variables in the local scope of enclosing functions.
3. **Global Scope**: Variables defined at the top level of a script or module.
4. **Built-in Scope**: Names preassigned in Python.

A **namespace** is a container where names are mapped to objects. Different namespaces are isolated from each other.

### Example

```python
z = "Global z"

def scope_outer():
    z = "outer"
    def scope_inner():
        z = "inner"
        print("Inner scope : ", z)
    scope_inner()
    print("Outer scope : ", z)

scope_outer()
print("Global scope : ", z)
```

- `z` in `scope_inner` shadows `z` in `scope_outer`, which in turn shadows the global `z`.
- The `print` statements demonstrate the value of `z` in different scopes.

## Class Creation

A **class** in Python is a blueprint for creating objects. It encapsulates data (attributes) and functions (methods) that operate on the data.

### Example

```python
class Bike:
    # Class Attribute
    year = 1999

    # Constructor
    def __init__(self, year, model):
        self.year = year  # Instance Attribute
        self.model = model

    # Method
    def start_engine(self):
        print(f"Engine Started {self.year} {self.model}")

bike1 = Bike(2013, "DX")

print("Instance Variable : ", bike1.year)
print("Class Variable : ", Bike.year)
bike1.start_engine()
```

- **Class Attribute**: Shared across all instances of the class (`year=1999`).
- **Instance Attributes**: Unique to each instance, defined in the `__init__` constructor.
- **Method**: A function defined within a class that operates on instances of the class (`start_engine`).

### Key Points

- **Instance Variable**: Accessed via `self`, unique to each instance.
- **Class Variable**: Shared among all instances, accessed via the class name.
- **Method**: Functions that belong to the class and typically operate on instance data.

## Inheritance

**Inheritance** is a fundamental concept in object-oriented programming that allows a class to inherit attributes and methods from another class. The class that inherits is called the **child class**, and the class being inherited from is called the **parent class**.

### Example

```python
# Parent class
class Parent:
    def __init__(self, name, age):
        self.name = name
        self.age = age
    def introduce(self):
        print(f"Hi, I am {self.name} and I am {self.age} years old.")

# Child class
class Child(Parent):
    def __init__(self, name, age, favorite_color):
        super().__init__(name, age)
        self.favorite_color = favorite_color
    def introduce(self):
        print(f"Hi, I am {self.name} and I am {self.age} years old. My favorite color is {self.favorite_color}")

# Create objects
parent = Parent("Vikram", 30)
child = Child("Pranav", 25, "blue")

# Call introduce methods
parent.introduce()
child.introduce()
```

- **Parent Class**: The class whose attributes and methods are inherited (`Parent`).
- **Child Class**: The class that inherits from the parent class (`Child`).
- **super()**: A function used to call the parent class's methods and constructors from the child class.

### Key Points

- **Inheritance** allows for code reuse and the creation of a hierarchical relationship between classes.
- The child class can override methods from the parent class to provide specific functionality.
- The `super()` function is used to call the parent class's methods and constructors, ensuring that the parent class is properly initialized.

## Exception Handling

**Exception Handling** is a mechanism in Python that allows you to handle runtime errors so that the normal flow of the program can be maintained. It involves using try-except blocks to catch and handle exceptions.

### Example

```python
try:
    # Code that might raise an exception
    x = 5 / 0
except ZeroDivisionError:
    # Handle the exception
    print("You cannot divide by zero!")
```

- The `try` block contains the code that might raise an exception.
- The `except` block catches the exception and handles it by printing an error message.

### Key Points

- **try-except** blocks are used to handle exceptions.
- The `try` block contains the code that might raise an exception.
- The `except` block catches the exception and handles it.
- You can have multiple `except` blocks to handle different types of exceptions.

## Polymorphism

**Polymorphism** is the ability of an object to take on multiple forms. In Python, polymorphism is achieved through method overriding or method overloading.

### Example

```python
class Animal:
    def sound(self):
        print("The animal makes a sound.")

class Dog(Animal):
    def sound(self):
        print("The dog barks.")

class Cat(Animal):
    def sound(self):
        print("The cat meows.")

# Create objects
dog = Dog()
cat = Cat()

# Call the sound method
dog.sound()
cat.sound()
```

- The `Animal` class has a `sound` method that prints a generic message.
- The `Dog` and `Cat` classes inherit from `Animal` and override the `sound` method to provide specific implementations.
- When we call the `sound` method on instances of `Dog` and `Cat`, the overridden methods are called.

### Key Points

- **Polymorphism** allows objects of different classes to be treated as objects of a common superclass.
- **Method Overriding**: A subclass provides a specific implementation of a method already defined in its superclass.
- **Method Overloading**: A class provides multiple definitions for a method with the same name but different parameters.

## Modules

**Modules** are pre-written code libraries that can be imported into your Python program to provide additional functionality.

### Example

```python
import math

# Use the math module
result = math.sqrt(16)
print(result)
```

- The `math` module is imported using the `import` statement.
- The `sqrt` function from the `math` module is used to calculate the square root of 16.
- The result is printed to the console.

### Key Points

- **Modules** are pre-written code libraries that can be imported into your Python program.
- **Importing** a module allows you to use its functions, classes, and variables.
- You can create your own modules by writing Python code in a separate file and importing it into your main program.

## File Handling

**File Handling** in Python allows you to read and write files. You can open a file in different modes, such as read-only, write-only, or read-write.

### Example

```python
# Open a file in read mode
with open("example.txt", "r") as file:
    content = file.read()
    print(content)

# Open a file in write mode
with open("example.txt", "w") as file:
    file.write("This is an example file.")
```

- The `open` function is used to open a file in read mode (`"r"`).
- The `with` statement ensures that the file is properly closed after it is no longer needed.
- The `read` method reads the content of the file and prints it to the console.
- The `open` function is used to open a file in write mode (`"w"`).
- The `write` method writes a string to the file.

### Key Points

- **File Handling** allows you to read and write files in Python.
- **Modes**: Files can be opened in different modes, such as read-only (`"r"`), write-only (`"w"`), or read-write (`"r+"`).
- The `with` statement ensures that the file is properly closed after it is no longer needed.
