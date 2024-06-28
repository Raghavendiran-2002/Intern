# Credit card validation - Luhn check algorithm
def double_digit(number):
    result = []
    for char in number:
        digit = int(char)
        doubled = digit * 2     
        if doubled > 9:
            doubled = doubled // 10 + doubled % 10    
        result.append(str(doubled))
    return ''.join(result)

account_number_string ="4325236146"

account_number_sliced_1 = account_number_string[1::2]
account_number_sliced_2 = account_number_string[::2]

account_number_doubled_digits = double_digit(account_number_sliced_1)
sum1 = sum(map(int,account_number_sliced_2))
sum2 = sum(map(int,account_number_doubled_digits))
if((sum1 + sum2)%10 ==0): 
    print("valid Account Number")
else:
    print("invalid Account Number")