using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] nums = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        int[] freq = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
        List<int> inputList = new List<int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < freq[i]; j++)
            {
                inputList.Add(nums[i]);
            }

        }
        int[] input = inputList.ToArray();
        Array.Sort(input);

        Day_1_Quartiles(n, input);

    }

    public static void Day_1_Quartiles(int n, int[] input)
    {
        Solution p = new Solution();
        decimal median = p.Median(input);

        List<int> lowerHalf = new List<int>();
        List<int> upperHalf = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (n % 2 == 0)
            {
                if (input[i] < median)
                {
                    lowerHalf.Add(input[i]);
                }
                else if (input[i] >= median)
                {
                    upperHalf.Add(input[i]);
                }
                else
                {
                    continue;
                }
            }
            else
            {
                if (input[i] <= median)
                {
                    lowerHalf.Add(input[i]);
                }
                else if (input[i] > median)
                {
                    upperHalf.Add(input[i]);
                }
                else
                {
                    continue;
                }
            }

        }
        int Q1 = Convert.ToInt32(p.Median(lowerHalf.ToArray()));
        decimal Q3 = p.Median(upperHalf.ToArray());

        Console.WriteLine(string.Format("{0:F1}", Q3 - Q1));
        Console.ReadLine();
    }

    public decimal Median(int[] input)
    {
        decimal medLower = 0;
        decimal medHigher = 0;

        if (input.Length % 2 == 0)
        {
            medLower = input[(input.Length - 1) / 2];
            medHigher = input[(input.Length - 1) / 2 + 1];
        }
        else
        {
            medLower = input[(input.Length - 1) / 2];
            medHigher = input[(int)Math.Round((input.Length - 1) / 2.0, 0, MidpointRounding.AwayFromZero)];
        }
        return (medLower + medHigher) / 2;
    }
}


