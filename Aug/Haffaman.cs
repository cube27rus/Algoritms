/*
По данной непустой строке s длины не более 10^4, состоящей из строчных букв латинского алфавита, 
постройте оптимальный беспрефиксный код. В первой строке выведите количество различных букв k, 
встречающихся в строке, и размер получившейся закодированной строки. 
В следующих k строках запишите коды букв в формате "letter: code". 
В последней строке выведите закодированную строку.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

             Node finishNode = nodeList[0];

           Console.Write(chars.Count+" ");
            
            Dictionary<char, String> charPath = new Dictionary<char, String>();
            foreach(KeyValuePair<char, int> entry in chars){
                if(chars.Count==1){
                    charPath.Add(entry.Key,finishNode.Search((entry.Key),"1"));
                }else
                charPath.Add(entry.Key,finishNode.Search((entry.Key),""));
            }
            
            
            
            String result = "";
            foreach(char entry in targetToCharArray){
                result +=charPath[entry];
            }
            Console.WriteLine(result.Length);
             foreach(KeyValuePair<char, String> entry in charPath){
                Console.WriteLine("{0}: {1}", entry.Key,entry.Value);
            }
            Console.WriteLine(result);

           
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

            
        }
        
        public override string ToString(){
            String fs = String.Format("\r\n || start --> My value : {0}, My char : {1} <-- end || \r\n",this.valueNode,this.charNode);
            return fs;
        }
        
    }
