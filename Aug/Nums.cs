/*
По данному числу 1≤n≤10^99 найдите максимальное число kk, для которого nn можно представить как сумму k различных натуральных слагаемых. 
Выведите в первой строке число k, во второй — k слагаемых.
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
            string itemsAndCapacity = Console.ReadLine();
            
            int number = Convert.ToInt32(itemsAndCapacity);   
           
            if(number!=1&&number!=2){
                 
                Program.run(number);
                
            }else{
                 Console.WriteLine(1);
                Console.WriteLine(number);
            }
            
        }
        
        public static int[] run(int num){
           // ArrayList al = new ArrayList();
            List<int> al = new List<int>();
            int curNum=1;
            al.Add(curNum);
            for(int i = 2;curNum<num;i++){
                
                al.Add(i);                
                curNum+=al[i-1];
               
            }
             
            if(curNum>num){ 
                int lastNum = al[al.Count-1];
                int prevLastNum =  al[al.Count-2];
                int difference=curNum-num;
                lastNum-=difference;
                al.RemoveAt(al.Count-1);                
                //Console.WriteLine(lastNum); 
                al[al.Count-1]=lastNum+prevLastNum;
            }
            Console.WriteLine(al.Count);
           
            foreach(int k in al){
                Console.Write(k+" ");
            }
            
            return (int[])al.ToArray(  );
        }
    }
}
