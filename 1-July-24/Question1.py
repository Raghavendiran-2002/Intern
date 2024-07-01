import re
from datetime import datetime
import pandas as pd
from fpdf import FPDF

class Employee:
    def __init__(self, name, dob, phone, email):
        self.name = name
        self.dob = dob
        self.age = self.calculate_age()
        self.phone = phone
        self.email = email

    def calculate_age(self):
        today = datetime.today()
        dob = datetime.strptime(self.dob, "%Y-%m-%d")
        return today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))

    def validate_dob(dob):
        try:
            datetime.strptime(dob, "%Y-%m-%d")
            return True
        except ValueError:
            return False
    
    def validate_name(name):
        return bool(re.match(r"^[A-Za-z ]+$", name))
    
    def validate_phone(phone):
        return bool(re.match(r"^\d{10}$", phone))
    
    def validate_email(email):
        return bool(re.match(r"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", email))

def get_employee_details():
    name = input("Enter name: ")
    while not Employee.validate_name(name):
        print("Invalid name. Please enter a valid name.")
        name = input("Enter name: ")

    dob = input("Enter date of birth (YYYY-MM-DD): ")
    while not Employee.validate_dob(dob):
        print("Invalid date. Please enter a valid date in the format YYYY-MM-DD.")
        dob = input("Enter date of birth (YYYY-MM-DD): ")

    phone = input("Enter phone number: ")
    while not Employee.validate_phone(phone):
        print("Invalid phone number. Please enter a valid 10 digit phone number.")
        phone = input("Enter phone number: ")

    email = input("Enter email: ")
    while not Employee.validate_email(email):
        print("Invalid email. Please enter a valid email.")
        email = input("Enter email: ")

    return Employee(name, dob, phone, email)

def save_to_text(employee):
    with open("employees.txt", "a") as file:
        file.write(f"Name : {employee.name}")
        file.write(f"\nDate of Birth : {employee.dob}")
        file.write(f"\nAge : {employee.age}")
        file.write(f"\nPhone Number : {employee.phone}")
        file.write(f"\nEmail : {employee.email}\n")

def save_to_excel(employee):
    df = pd.DataFrame([{
        "Name" : employee.name,
        "Date of Birth" : employee.dob,
        "Age" : employee.age,
        "Phone Number" : employee.phone, 
        "Email" : employee.email
        }])
    df.to_excel(f"{employee.name}_details.xlsx", index=False)

def save_to_pdf(employee):
    pdf = FPDF()
    pdf.add_page()
    pdf.set_font("Arial", size=12)
    pdf.cell(200, 10, f"Name: {employee.name}", align="L")
    pdf.ln(10)
    pdf.cell(200, 10, f"Date of Birth: {employee.dob}", align="L")
    pdf.cell(200, 10, f"Age: {employee.age}", align="L")
    pdf.cell(200, 10, f"Phone Number: {employee.phone}", align="L")
    pdf.cell(200, 10, f"Email: {employee.email}", align="L")
    pdf.output(f"{employee.name}_details.pdf")

def save_employee_details(employee):
    print("Select the format to save the employee details:")
    print("1. Text File")
    print("2. Excel File")
    print("3. PDF File")
    choice = input("Enter your choice (1/2/3): ")
    if choice == "1":
        save_to_text(employee)
    elif choice == "2":
        save_to_excel(employee)
    elif choice == "3":
        save_to_pdf(employee)
    else:
        print("Invalid choice. Please select a valid option.")

if __name__ == "__main__":
    employee = get_employee_details()
    print(f"Employee Details:\nName: {employee.name}\nDate of Birth: {employee.dob}\nAge: {employee.age}\nPhone Number: {employee.phone}\nEmail: {employee.email}")
    save_employee_details(employee)
    