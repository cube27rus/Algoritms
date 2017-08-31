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
            // мапа с чарами и повторениями
            Dictionary<char, int> chars = new Dictionary<char, int>();
            char[] targetToCharArray = target.ToCharArray();
            for(int i = 0;i<targetToCharArray.Count();i++){
                if(!chars.ContainsKey(targetToCharArray[i])){
                    chars.Add(targetToCharArray[i],0);
                }else{
                    chars[targetToCharArray[i]]++;
                }                
            }
           
            Queue<string> myQ = new Queue<string>();
            //ноды в подярдке возрастания частоты
            List<Node> nodeList = new List<Node>();
            
            
            List<KeyValuePair<char, int>> myList = chars.ToList();

            myList.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));
          
            Dictionary<char, string> targetDict = new Dictionary<char, string>();
            String curWay = "0";
            foreach(KeyValuePair<char, int> entry in myList){
                myQ.Enqueue(entry.Key.ToString());
                targetDict.Add(entry.Key, curWay);
                curWay="1"+curWay;
                nodeList.Add(new Node(entry.Value,entry.Key));
            }
            
            foreach(Node entry in nodeList){
                Console.WriteLine(entry);
            }
            for(int i=1;i<nodeList.Count;i++){
                 //Node newNode = new Node(nodeList[i-1]);   
                }
            /* 
            
            алгоритм: вытаскивать первые два элемента из nodelisi, удалять их, образовать из них новую ноду с value = 
            сумме предыдущих, добавить новую ноду в лист.
            лист должен сортироваться по value node.
            */
            
           
        }
    }
    public class Node{
        public Node leftNode=null;
        public Node rightNode=null;
        public int valueNode;
        public char charNode;
        
        public Node(Node leftNode,Node rightNode,int valueNode,char charNode){
            this.leftNode=leftNode;
            this.rightNode=rightNode;
            this.valueNode=valueNode;
            this.charNode = charNode;
        }
        
        public Node(int valueNode,char charNode){            
            this.valueNode=valueNode;
            this.charNode = charNode;
        }
        
         public Node(char charNode){            
            this.charNode=charNode;
            
        }
        
        public override string ToString(){
            return String.Format("Left node: {0}, Right node: {1}, Value: {2}, Char: {3};",this.leftNode,this.rightNode,this.valueNode,this.charNode);
        }
        
    }
}
