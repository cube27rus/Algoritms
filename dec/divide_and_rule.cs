/*
Cортировка слиянием

Первая строка содержит число 1≤n≤10^5 1≤n≤10^5, вторая — массив A[1…n]A[1…n], содержащий натуральные числа, не превосходящие 109109. 
Необходимо посчитать число пар индексов 1≤i<j≤n 1≤i<j≤n, для которых A[i]>A[j]A[i]>A[j]. 
(Такая пара элементов называется инверсией массива. Количество инверсий в массиве является в некотором смысле его мерой неупорядоченности:
например, в упорядоченном по неубыванию массиве инверсий нет вообще, а в массиве, упорядоченном по убыванию, 
инверсию образуют каждые два элемента.)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
    public static class Program
    {

        static int revert = 0;

        static void Main(string[] args)
        {
            int arsize= Int32.Parse(Console.ReadLine());
            Int32[] intar = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            int[] result = Program.mergeSort(intar);

            /*for (int i = 0; i < result.Count(); i++)
            {
                Console.WriteLine(result[i]);
            }*/
            Console.WriteLine(revert);
            Console.ReadKey();

        }

        public static int[] mergeSort(int[] arint)
        {            
           

            int size = arint.Count();

            if (size > 1)
            {
                int half = size / 2;
                return merge(mergeSort(SubArray(arint, 0, half)), mergeSort(SubArray(arint, half, size-half)));
            }
            else 
            {
                return arint;
            }

            
        }

        public static int[] merge(int[] arint1, int[] arint2)
        {
            List<int> result = new List<int>();

            Queue<int> queue1 = new Queue<int>(arint1);
            Queue<int> queue2 = new Queue<int>(arint2);

            while(queue1.Count!=0 || queue2.Count!=0){
                if (queue1.Count != 0 && queue2.Count != 0)
                {
                    int peekFirst1 = queue1.Peek();
                    int peekFirst2 = queue2.Peek();
                    if (peekFirst1 <= peekFirst2)
                    {
                        result.Add(queue1.Dequeue());
                    }
                    else
                    {
                        
                         Program.revert += queue1.Count();
                        
                        
                        result.Add(queue2.Dequeue());
                    }
                }
                else
                {
                    if (queue1.Count == 0)
                    {
                        for(int i = 0;i< queue2.Count();i++)
                        {
                            result.Add(queue2.Dequeue());
                        }
                    }
                    else
                    {
                        for (int i = 0; i < queue1.Count(); i++)
                        {
                            result.Add(queue1.Dequeue());
                        }
                    }
                }
            }

            return result.ToArray();
            
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
