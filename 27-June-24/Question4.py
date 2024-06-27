from datetime import datetime

def detail(name,  date_of_birth):
    print(f"Hello, {name}! You are {calculate_age(date_of_birth)} years old. You were born on {date_of_birth}.")

def calculate_age(date_of_birth):
    today = datetime.today()
    dob = datetime.strptime(date_of_birth, "%d-%m-%y")
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age

detail(input('Please enter your name: '), input('Please enter your date of birth (dd-mm-yy): '))
