/*
Первая строка содержит количество предметов 1≤n≤10^3 и вместимость рюкзака 0≤W≤2⋅10^6
Каждая из следующих nn строк задаёт стоимость 0≤ci≤2⋅10^6 и объём 0≤wi≤2⋅10^6 предмета (n, W, ci, wi — целые числа).
Выведите максимальную стоимость частей предметов (от каждого предмета можно отделить любую часть, 
стоимость и объём при этом пропорционально уменьшатся), помещающихся в данный рюкзак, с точностью не менее трёх знаков после запятой.
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
            string[] itemsAndCapacity = Console.ReadLine().Split();
            int items = Convert.ToInt32(itemsAndCapacity[0]);
            int capacity = Convert.ToInt32(itemsAndCapacity[1]);
            
            SortedDictionary<int, int> sd = new SortedDictionary<int, int>();
            ArrayList itemsArray = new ArrayList();
            
            //sd.Add(7,4);sd.Add(3,1);sd.Add(5,2);sd.Add(6,5);
            for (int i = 0; i < items; i++)
            {
                string[] splited = Console.ReadLine().Split();
                    int price = Convert.ToInt32(splited[0]);
                    int weight = Convert.ToInt32(splited[1]);
                Item item = new Item(price,weight);
                itemsArray.Add(item);
                
            }
            itemsArray.Sort();

            foreach (Item item in itemsArray)
            {
                //Console.WriteLine(item.price + " " + item.weight);
            }
            
            double curCapacity = capacity;
            double resultValue = 0;
            
            for(int i =0;i<itemsArray.Count;i++){
                Item loopItem = itemsArray[i] as Item;
                double weightTo = loopItem.weight;
                double priceTo = loopItem.price;  
                
                if(curCapacity<weightTo){
                    double propor = weightTo/curCapacity;
                    weightTo = weightTo/propor;
                    priceTo = priceTo/propor;
                }                
                resultValue+=priceTo;
                curCapacity-=weightTo;
                if(curCapacity<=0){
                    break;
                } 
                
            }
            
            //Console.WriteLine(curCapacity);
            Console.WriteLine(Math.Round(resultValue,3));
            
            
            Console.ReadLine();
        }

    }
    
    public class Item : IComparable{
        public double price{get;set;}
        public double weight{get;set;}
        public Item(double price,double weight){
            this.price=price;
            this.weight = weight;
        }
        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Item compareItem = obj as Item;
            double curentValue = this.price/this.weight;
            double compareValue = compareItem.price/compareItem.weight;
            //Console.WriteLine(curentValue + " " + compareValue);
            if(compareValue>curentValue){
                return 1;
            }else if(compareValue<curentValue){
                return -1;
            }else{
                return 0;
            }
        }
    }
   
}
