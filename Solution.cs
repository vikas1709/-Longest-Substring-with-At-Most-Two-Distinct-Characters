public class Solution {
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        Dictionary<char, int> window = new Dictionary<char, int>();
        int desiredCount = 0;
        int maxLength = -1;
        int l = 0, r = 0;
        while(r < s.Length)
        {
            char c = s[r];
            if(!window.ContainsKey(c))
            {
                window.Add(c, 1);
                desiredCount++;
            }
            else
                window[c]++;
            
            if(desiredCount <= 2)
            {
                if(maxLength == -1 || maxLength < r - l + 1)
                {
                   maxLength = r - l + 1;
                }
                 r++;
                continue;
            }
            
            if(desiredCount == 3)
            {
                while(desiredCount > 2 && l <= r)
                {
                    c = s[l];
                    if(window[c] > 1)
                    {
                        window[c]--;
                    }
                    else
                    {   
                        window.Remove(c);
                        desiredCount--;
                    }
                    l++; 
                } 
            }
            r++;
        }
        
        return maxLength;
    }
}
