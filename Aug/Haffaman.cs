using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class MainClass
{
    public static void Main()
    {
          string target = Console.ReadLine();
            //Console.WriteLine(target);
            Dictionary<char, string> words = new Dictionary<char, string>();
            String curWay = "0";
           for (char c = 'a'; c <= 'z'; c++)
            {
               
               char chares = c;
               words.Add(chares,curWay);
                   curWay="1"+curWay;               
            } 
            //мапа с уникальными занчениями
            SortedDictionary<char, string> targetDict = new SortedDictionary<char, string>();
            
            char[] targetToCharArray = target.ToCharArray();
            //формируем уникальную мапу
            for(int i = 0;i<targetToCharArray.Count();i++){
                if(!targetDict.ContainsKey(targetToCharArray[i])){
                    targetDict.Add(targetToCharArray[i],words[targetToCharArray[i]]);
                }                
            }
             if(targetDict.Count>1){
            var last = targetDict.Values.Last();
            var lastKey = targetDict.Keys.Last();
            targetDict.Remove(targetDict.Keys.Last());
            targetDict.Add(lastKey, last.Remove(last.Length - 1));
            }
            
            /*foreach(KeyValuePair<char, string> entry in targetDict){
                Console.WriteLine("key : {0} + value : {1}", entry.Key,entry.Value);
            }*/
            
            Console.Write(targetDict.Count()+" ");
            String result = "";
            for(int i = 0;i<targetToCharArray.Count();i++){
                //Console.WriteLine("{0} : {1}", targetToCharArray[i],targetDict[targetToCharArray[i]]);
                 result +=targetDict[targetToCharArray[i]];
            }
            Console.WriteLine(result.Length);
            foreach(KeyValuePair<char, string> entry in targetDict){
                Console.WriteLine("{0}: {1}", entry.Key,entry.Value);
            }
           
            Console.WriteLine(result);
    }
}
