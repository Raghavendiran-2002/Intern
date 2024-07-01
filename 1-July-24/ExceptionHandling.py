def divide_number(a, b):
    try:
        result = a / b
    except ZeroDivisionError:
        return "Error: Division by zero is not allowed."
    else:
        return result
    finally:
        print("Execution finished")

print(divide_number(10, 2))
print(divide_number(10, 0))