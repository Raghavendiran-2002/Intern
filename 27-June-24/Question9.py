def find_permutations(string):
    if len(string) == 0:
        return []

    if len(string) == 1:
        return [string]

    permutations = []
    for i in range(len(string)):
        char = string[i]
        remaining_chars = string[:i] + string[i+1:]
        for permutation in find_permutations(remaining_chars):
            permutations.append(char + permutation)

    return permutations

input = input("Enter string : ")
permutations = find_permutations(input)
print(permutations)