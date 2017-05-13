using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static Dictionary<long, Dictionary<int, long>> numWays = new Dictionary<long, Dictionary<int, long>>();

    private static long getWays2(long n, long[] c, int coinIndex) {
        if (coinIndex < 0 || n < 0) {
            return 0;
        }

        if (!numWays.ContainsKey(n)) {
            numWays[n] = new Dictionary<int, long>();
        }
        if (numWays[n].ContainsKey(coinIndex)) {
            return numWays[n][coinIndex];
        }
        if (coinIndex == 0) {
            if (n % c[0] == 0) {
                numWays[n][0] = 1;
            } else {
                numWays[n][0] = 0;
            }
            return numWays[n][0];
        }

        long result = getWays2(n, c, coinIndex - 1) + getWays2(n - c[coinIndex], c, coinIndex);
        numWays[n][coinIndex] = result;
        return result;
    }

    // private static long getWays(long n, long[] c) {
    //     if (n == 0) {
    //         Console.WriteLine("nums ways for 0 is 1");
    //         return 1;
    //     }
    //     if (numWays.ContainsKey(n)) {
    //         Console.WriteLine("nums ways for {0} is {1}", n, numWays[n]);
    //         return numWays[n];
    //     }

    //     long ways = 0;
    //     foreach (long coin in c.Where(cn => cn <= n)) {
    //         Console.WriteLine("breaking {0} down to {1}+{2}", n, coin, n - coin);
    //         long temp = getWays(n - coin, c);
    //         ways += temp;
    //     }
    //     Console.WriteLine("nums ways for {0} is {1}", n, ways);
    //     numWays[n] = ways;
    //     return ways;
    // }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        long[] c = Array.ConvertAll(c_temp,Int64.Parse);
        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'
        long ways = getWays2(n, c, c.Length - 1);
        Console.WriteLine(ways);
    }
}
