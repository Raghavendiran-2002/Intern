name = input("Enter your name: ")
gender = input("Enter your gender (M/F): ")
def provide_salutation(gender):
    if gender.upper() == "M":
        return "Mr."
    elif gender.upper() == "F":
        return "Ms."
    else:
        return ""

print("Hello", provide_salutation(gender), name)