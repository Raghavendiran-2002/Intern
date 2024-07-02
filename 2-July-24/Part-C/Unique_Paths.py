class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        dp=[1]*n
        pre=0
            
        for i in range(1,m):
            for j in range(n):
                if j==0:
                    pre=1
                else:
                    dp[j]=dp[j]+pre
                    pre=dp[j]
        return dp[n-1]