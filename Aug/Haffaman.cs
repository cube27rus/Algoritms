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
             string target = Console.ReadLine();
            Console.WriteLine(target);
            Dictionary<char, string> words = new Dictionary<char, string>();
            String curWay = "0";
           for (char c = 'a'; c <= 'z'; c++)
            {
               
               char chares = c;
               words.Add(chares,curWay);
                   curWay="1"+curWay;               
            } 
            /*foreach(KeyValuePair<string, string> entry in words){
                Console.WriteLine("key : {0} + value : {1}", entry.Key,entry.Value);
            }*/
            char[] targetToCharArray = target.ToCharArray();
            
            String result = "";
            for(int i = 0;i<targetToCharArray.Count();i++){
                Console.WriteLine("{0} : {1}", targetToCharArray[i],words[targetToCharArray[i]]);
                 result +=words[targetToCharArray[i]];
            }
            Console.WriteLine(result.Length);
            Console.WriteLine(result);
        }
    }
}
