#  Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.

def longest_substring(string):
    size = len(string)
    head = 0
    tail = 0
    charSet = set()
    s= 0
    e= 0
    max_len = 1
    for tail in range(size): 
        while string[tail] in charSet:
            charSet.remove(string[head])
            head += 1
        charSet.add(string[tail])
        if max_len < (tail - head + 1):
            s = head
            e = tail 
            max_len = e - s + 1
    result = string[s:e+1]
    return result

longest_string_result = longest_substring("xzzxyxyz")
print(longest_string_result)