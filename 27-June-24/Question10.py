def print_pyramid(rows):
    for i in range(rows):
        print(" " * (rows - i - 1) + "*" * (2 * i + 1))


num_rows = 3
print_pyramid(num_rows)