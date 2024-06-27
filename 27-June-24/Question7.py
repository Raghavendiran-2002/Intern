def is_prime(num):
    if num < 2:
        return False
    for i in range(2, (num // 2) + 1):
        if num % i == 0:
            return False
    return True

numbers = []
for i in range(10):
    number = int(input("Enter a number: "))
    numbers.append(number)

prime_numbers = [num for num in numbers if is_prime(num)]
print(prime_numbers)
average = sum(prime_numbers) / len(prime_numbers)

print("Average of prime numbers:", average)