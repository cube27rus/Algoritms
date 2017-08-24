/*
По данным nn отрезкам необходимо найти множество точек минимального размера, для которого каждый из отрезков содержит хотя бы одну из точек.
В первой строке дано число 1≤n≤100 отрезков. Каждая из последующих nn строк содержит по два числа 0≤l≤r≤10^9, 
задающих начало и конец отрезка. 
Выведите оптимальное число m точек и сами m точек. Если таких множеств точек несколько, выведите любое из них.
*/

//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections;
namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int countLines = Convert.ToInt16(Console.ReadLine());
            
            SortedDictionary<int, int> sd = new SortedDictionary<int, int>();
            ArrayList segments = new ArrayList();
            
            //sd.Add(7,4);sd.Add(3,1);sd.Add(5,2);sd.Add(6,5);
            for (int i = 0; i < countLines; i++)
            {
                string[] splited = Console.ReadLine().Split();
                    int startPoint = Convert.ToInt32(splited[0]);
                    int endPoint = Convert.ToInt32(splited[1]);
                Segment segment = new Segment(startPoint,endPoint);
                segments.Add(segment);
                
            }
            segments.Sort();
            //Your code goes here
            ArrayList al = new ArrayList();
            int resultOtrezki = 0;
            int currentEndOtrezka = -1;
            foreach(Segment seg in segments){
                
                if (currentEndOtrezka == -1)
                {
                    currentEndOtrezka = seg.finish;
                    al.Add(currentEndOtrezka);
                    resultOtrezki++;
                    continue;
                }
                if (seg.start > currentEndOtrezka)
                {
                    currentEndOtrezka = seg.finish;
                    al.Add(currentEndOtrezka);
                    resultOtrezki++;
                }
                
            }
            /*foreach (KeyValuePair<int, int> sds in sd)
            {
                

                if (currentEndOtrezka == -1)
                {
                    currentEndOtrezka = sds.Key;
                    al.Add(currentEndOtrezka);
                    resultOtrezki++;
                    continue;
                }
                if (sds.Value > currentEndOtrezka)
                {
                    currentEndOtrezka = sds.Key;
                    al.Add(currentEndOtrezka);
                    resultOtrezki++;
                }
            }

            */
            Console.WriteLine(resultOtrezki);

            foreach (var item in al)
            {
                Console.Write(item + " ");
            }
            
            Console.ReadLine();
        }

    }
    
    public class Segment : IComparable{
        public int start{get;set;}
        public int finish{get;set;}
        public Segment(int start,int finish){
            this.start=start;
            this.finish = finish;
        }
        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Segment sermentCompare = obj as Segment;
            if(sermentCompare.finish<this.finish){
                return 1;
            }else if(sermentCompare.finish>this.finish){
                return -1;
            }else{
                return 0;
            }
        }
    }
   
}
