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
           
          
            //ноды в подярдке возрастания частоты
            List<Node> nodeList = new List<Node>();
            
            
            List<KeyValuePair<char, int>> myList = chars.ToList();

            myList.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));
          
            Dictionary<char, string> targetDict = new Dictionary<char, string>();
            String curWay = "0";
            foreach(KeyValuePair<char, int> entry in myList){
             
                nodeList.Add(new Node(entry.Value+1,entry.Key));
            }
            
            nodeList.OrderBy(o=>o.valueNode).ToList();
            
            
            while(nodeList.Count>1){
                /*foreach(Node entry in nodeList){
                    Console.WriteLine(entry);
                }
                Console.WriteLine("----------------------------------");*/
                Node newNode = new Node(nodeList[0],nodeList[1],(nodeList[0].valueNode+nodeList[1].valueNode),'-');
                nodeList.RemoveAt(1);
                nodeList.RemoveAt(0);                
                nodeList.Insert(0,newNode);
                
                nodeList = nodeList.OrderBy(o=>o.valueNode).ToList();                
            }
            Console.WriteLine(nodeList.Count);
             Node finishNode = nodeList[0];
            /*foreach(Node entry in nodeList){
                Console.WriteLine(entry);
            }*/
            
            Console.WriteLine(finishNode.Search('o'),"");
            
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
        
        public Node(Node leftNode,Node rightNode,int valueNode){
            this.leftNode=leftNode;
            this.rightNode=rightNode;
            this.valueNode=valueNode;           
        }
        
        
        public Node(int valueNode,char charNode){            
            this.valueNode=valueNode;
            this.charNode = charNode;
        }
        
         public Node(char charNode){            
            this.charNode=charNode;
            
        }
        
        public bool tryGetValue(char findThat){
            bool result = this.charNode==findThat;
            if(!result)
                result = this.leftNode.charNode==findThat;
            if(!result)
                result = this.rightNode.charNode==findThat;
            return result;
        }
        
        public String Search(char charFind,String inner="" ){
            
            String result = inner;
            
            if(charFind==charNode){
                return result;
            }
            
            if(this.rightNode!=null){
                String newRes = result+"1";
                String res = rightNode.Search(charFind,newRes);
                if(res!=""){ return res;}
            }
            
            if(this.leftNode!=null){
                String newRes = result+"0";
                String res = leftNode.Search(charFind,newRes);
                if(res!=""){ return res;}
            }
            
            return "";
            /*
             if(this.rightNode!=null){
                Console.WriteLine("Правая: "+rightNode);
                String newRes = result+="1";
                String rightResult =  this.rightNode.Search(charFind,newRes);
                if(rightResult!=""){return rightResult;}
            }
            
            if(this.leftNode!=null){ 
                Console.WriteLine("Левая: "+leftNode);
                String newResL = result+="0";
                String leftResult =  this.leftNode.Search(charFind,newResL);
                if(leftResult!=""){return leftResult;}
            }
           
           
           
            return "";
                */
            
        }
        
        public override string ToString(){
            String fs = String.Format("\r\n || start --> My value : {0}, My char : {1} <-- end || \r\n",this.valueNode,this.charNode);
            return fs;
        }
        
    }
}
