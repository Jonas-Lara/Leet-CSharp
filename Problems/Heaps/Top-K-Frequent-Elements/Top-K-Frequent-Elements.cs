﻿public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        if (nums.Length == k) return nums;
        var cnt = new Dictionary<int, int>();

        foreach (int n in nums)
        {
            if (cnt.ContainsKey(n)) cnt[n]++;
            else cnt.Add(n, 1);
        }
      
        List<int> ans = new List<int>();
      
      	if (cnt.Count == k)
        {
            foreach (var item in cnt) ans.Add(item.Key);
            return ans.ToArray();
        }

        var cmp = Comparer<int>.Create((a, b) => cnt[a] != cnt[b] ? cnt[a].CompareTo(cnt[b]) : a.CompareTo(b));
        var ss = new SortedSet<int>(cmp);

        foreach (var item in cnt)
        {
            ss.Add(item.Key);
            if (ss.Count > k) ss.Remove(ss.Min);
        }
        while (ss.Count > 0)
        {
            ans.Add(ss.Min);
            ss.Remove(ss.Min);
        }
      
        return ans.ToArray();
    }
}