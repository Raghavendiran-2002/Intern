def merge_the_tools(string, k):
    for i in range(0, len(string), k):
      kstring = ''
      for j in range(k):
         if string[i+j] not in kstring:
            kstring = kstring + string[i+j]
      print(kstring)


if __name__ == '__main__':
    string, k = input(), int(input())
    merge_the_tools(string, k)