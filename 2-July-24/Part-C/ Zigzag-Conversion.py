class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if numRows==1: return s
        
        m = [""]*numRows
        row,direction = 1, 1
        for c in s[1:]:
            m[row] += c
            if row == numRows-1 or row == 0:
                direction=-direction
            row+=direction
        return s[0] +"".join(m)