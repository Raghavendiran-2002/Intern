# Basics
print("Hello")

# Understanding Execution
x=2
y=3
z=y-x
print(x)  # Execution - > Top to Bottom / Line after Line

# Input - > use input()

x=int(input("Enter a number : "))
print(x)

#  Output - > use print()
print (x - 1)
print(f"Hello, {x}!") 

# Datatypes
string = "Hello"
print(type(string)) 
int = 10  
print(type(int))
float = 10.5 
print(type(float))
bool = True  
print(type(bool))
list = [1, 2, 3, 4, 5] 
print(type(list ))
tuple = (1, 2, 3) 
print(type(tuple))
dict = {"name": "John", "age": 30} 
print(type(dict ))

# Operators

x = 5
y = 3
print(x + y) # Addition
print(x - y) # Subtraction
print(x * y) # Multiplication
print(x / y) # Divide
print(x % y) # Modulus
print(x ** 2) # Divide
print(x // 2) # Floor Division

print(x == y) # Equal
print(x != y) # Not Equal
print(x > y) # Greater than
print(x < y) # Lesser than
print(x >= y) # Greater than or equal
print(x <= y) # Less than or equal

print(x > 1 and y > 1) # AND
print(x > 1 or y < 1) # OR
print(not (y > 2)) # NOT

# Conditional Statements

if(x >= 3):
    print("x is greater than or equal to 3")
else:
    print("x is less than 3")

if(y >= 6):
    print("y is greater than or equal to 6")
elif(y <= 5):
    print("y is less than or equal to 5")
else:
    print("y is neither greater than or equal to 6 nor less than or equal to 5")

# Iterations 

# For Loop
print("For Loop : ")
for x in range(1, 3):
    print(x)

# While Loop
print("While Loop : ")
c = 1
while c < 3:
    print(c)
    c += 1

# Methods 

def Methods(name):
    print(f"Hello, {name}!")

Methods("Raghav")

# Parameter

def add(p, q):
    return p + q

res = add(1,2)
print("Add : ",res)

# Return 
def square(x):
    return x * x

res = square(2)
print("Square : ",res)

# List and Indexing

#create List 
list = [1,2,3,4,5]
print(list[0]) #  Access 1st element
print(list[1]) #  Access 2nd element
print(list[-1]) # Access last element
print(list[1:3]) # Access 2nd element , 3rd element
print(list[:3]) # Access 1st element - 3rd element
print(list[::-1]) # Reverse List