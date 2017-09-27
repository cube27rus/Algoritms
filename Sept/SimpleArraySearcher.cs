/*
В первой строке даны целое число 1≤n≤10^5 и массив A[1…n] из n различных натуральных чисел, не превышающих 10^9, 
в порядке возрастания, во второй — целое число 1≤k≤10^5 и k натуральных чисел b1,…,bk, не превышающих 10^9. 
Для каждого i от 1 до k необходимо вывести индекс 1≤j≤n, для которого A[j]=bi, или −1, если такого j нет.
*/

using System;
using System.Collections.Generic;
using System.Linq;
public class MainClass
{
    public static void Main(String[] args)
        {
            List<int> result = new List<int>();
            List<string> splitedArray = Console.ReadLine().Split(' ').ToList();
            List<string> splitedValues = Console.ReadLine().Split(' ').ToList();
            int splitArrayValue = Int32.Parse(splitedArray[0]);
            splitedArray.RemoveAt(0);
            for(int i = 0; i < splitArrayValue; i++)
            {
                result.Add(Int32.Parse(splitedArray[i]));
            }
            int splitValue = Int32.Parse(splitedValues[0]);
            splitedValues.RemoveAt(0);
            
            foreach (String num in splitedValues)
            {
                Console.Write(getResult(result,Int32.Parse(num))+" ");
            }
            Console.ReadKey();
            
        }
        public static int getResult(List<int> z,int index)
        {
            int l = 0;
            int r = z.Count()-1;
            
            while (l <= r)
            {
                int m = (l + r) / 2;
                if (z[m] == index)
                {
                    return m+1;
                    
                }
                if (z[m] > index)
                {
                    r = m - 1;
                    continue;
                }
                else
                {
                    l = m + 1;
                    continue;
                }

            }
            return -1;
            
        }
}
