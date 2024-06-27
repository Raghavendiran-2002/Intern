import re
from datetime import datetime

def validate_name(name):
    if not re.match(r'^[A-Za-z\s]+$', name):
        return False
    return True

def calculate_age(date_of_birth):
    today = datetime.today()
    dob = datetime.strptime(date_of_birth, "%d-%m-%y")
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age

def validate_date_of_birth(date_of_birth):
    if not re.match(r'^\d{2}-\d{2}-\d{4}$', date_of_birth):
        return False
    return True

def validate_phone(phone):
    if not re.match(r'^\d{10}$', phone):
        return False
    return True

def print_details(name, age, date_of_birth, phone):
    print(f"Name: {name}")
    print(f"Age: {age}")
    print(f"Date of Birth: {date_of_birth}")
    print(f"Phone: {phone}")

name = input("Enter your name: ")
age = input("Enter your age: ")
date_of_birth = input("Enter your date of birth (DD-MM-YYYY): ")
phone = input("Enter your phone number: ")

if not validate_name(name):
    print("Invalid name!")
elif not validate_date_of_birth(date_of_birth):
    print("Invalid date of birth!")
elif not validate_phone(phone):
    print("Invalid phone number!")
else:
    print_details(name, age, date_of_birth, phone)