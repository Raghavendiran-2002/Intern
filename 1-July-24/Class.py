# Scopes and Namespaces 

z = "Global z"
def scope_outer():
    z = "outer"
    def scope_inner():
        z = "inner"
        print("Inner scope : ", z)
    scope_inner()
    print("Outer scope : " ,z)

scope_outer()
print("Global scope : " , z)

# Class Creation

class Bike:
    # Attribute
    year=1999

    # Constructor
    def __init__(self, year, model):
        self.year = year
        self.model = model
    
    # Method
    def start_engine(self):
        print(f"Engine Started {self.year} {self.model}")

bike1 = Bike(2013, "DX")

print("Instance Variable : ", bike1.year)
print("Class Variable : ", Bike.year)
bike1.start_engine()