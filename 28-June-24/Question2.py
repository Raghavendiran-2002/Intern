# Print the list of prime numbers up to a given number

def is_prime(n):
    if n <= 1:
        return False
    for i in range(2, (n//2) + 1):
        if n % i == 0:
            return False
    return True
n = int(input("enter number : "))
list = [];
for i in range(n):
    if is_prime(i):
       list.append(i)
print(list)