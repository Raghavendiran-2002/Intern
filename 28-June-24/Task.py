# String Manipulating

#  Concatenating strings
string1 = "Hello"
string2 = "World"
result = string1 + " " + string2
print(result)  

#  Count characters
length = len(string1)
print(length)

#  String Split
string1 = "Hello world, how are you today?"
words = string1.split()
print(words)

#  Accessing individual characters
string = "Python Programming"
print(string[0]) 
print(string[2]) 

#  Slicing strings
print(string[0:6])  
print(string[7:])   

#  Changing case
print(string.upper())  
print(string.lower())  

#  Finding substrings
print(string.find("Python")) 
print(string.find("Programming")) 

# -------------------------------------------------------------------------- #

# Functions 

# Defining a function
def greet(name):
    print("Hello, " + name + "!")

# Calling the function
greet("Vikram")
greet("Pranav")

# -------------------------------------------------------------------------- #

# Tuples
tuple = (1, 2, 3, 4, 5)
print(tuple)

# Accessing tuple elements
print(tuple[0])
print(tuple[2])

# Tuple slicing
print(tuple[1:4])

# Tuple length
print(len(tuple))

# Tuple concatenation
tuple1 = (4, 5, 6)
concatenated_tuple = tuple + tuple1
print(concatenated_tuple)

# Tuple repetition
repeated_tuple = tuple1 * 3
print(repeated_tuple)

# Tuple unpacking
a, b, c = tuple1
print(a)
print(b)
print(c)

# -------------------------------------------------------------------------- #

# Dictionary
dictionary = {"name": "Pranav", "age": 22, "city": "Chennai", "country": "India"}

# Accessing dictionary elements
print(dictionary["name"])
print(dictionary["age"])

# Modifying dictionary elements
dictionary["age"] = 26
print(dictionary)

# Adding new key-value pairs
dictionary["occupation"] = "Designer"
print(dictionary)

# Removing key-value pairs
del dictionary["city"]
print(dictionary)

# Checking if a key exists in the dictionary
if "name" in dictionary:
    print("Name exists in the dictionary")

# Getting all keys and values in the dictionary
keys = dictionary.keys()
values = dictionary.values()
print(keys)
print(values)

# Looping through dictionary
for key, value in dictionary.items():
    print(key, value)

# Sets

# Creating a set
set = {1, 2, 3, "hi", 4.2}
print(set)

# Length of the set
print(len(set))

# Accessing Set items
for item in set:
    print(item)

# Check if an item exists in the set
if "hi" in item:
    print("Yes, 'hi' is in the set")

# Add item to Set
set.add("Hello")
print(set)

# Remove item from Set
set.remove("Hello")