class Shape:
    def area(self):
        raise NotImplemented("Abstract method")
    
class Rectangle(Shape):
    def __init__(self, length, breadth):
        self.length = length
        self.breadth = breadth
    def area(self):
        return self.length * self.breadth
    
class Circle(Shape):
    def __init__(self, radius):
        self.radius = radius
    def area(self):
        return 3.14 * self.radius * self.radius

def print_area(shape):
    print("Area : ", shape.area())

rectangle = Rectangle(3,4)
circle = Circle(5)

print_area(rectangle)
print_area(circle)