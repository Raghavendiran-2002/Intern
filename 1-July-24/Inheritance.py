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