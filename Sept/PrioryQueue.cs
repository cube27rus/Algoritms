//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            List<int> intList = new List<int>();
            intList.Add(200);
            intList.Add(50);
            foreach(int k in intList){
                Console.WriteLine(k);
            }
        }
    }
    
    public class PrioryQueue{
        List<int> intList = new List<int>();
        
        public void add(int k){
            intList.Add(k);
        }
        
        public boolean swap(int i,int j){
            if(i<intList.Count()&&j<intList.Count()){
                int temp = intList[j];
                intList[j]= intList[i];
                intList[i]=temp;
                return true;
            }
            return false;
            
        }
    
    }
    
}
