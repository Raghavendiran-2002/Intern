class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        
        pair = "()"
        arr = []
        arr.append(pair)

        for _ in range(2,n+1):
            temp = set()

            while arr:
                val = arr.pop()
                for i in range(len(val)):
                    s = val[:i] + pair + val[i:]
                    temp.add(s)

            for t in temp:
                arr.append(t)

        return arr





        
