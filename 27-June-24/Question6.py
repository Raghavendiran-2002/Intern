def is_prime(n):
    if n <= 1:
        return False
    for i in range(2, (n//2) + 1):
        if n % i == 0:
            return False
    return True

def check_prime(number):
    if is_prime(number):
        print(f"{number} is a prime number")
    else:
        print(f"{number} is not a prime number")

number = 11
check_prime(number)