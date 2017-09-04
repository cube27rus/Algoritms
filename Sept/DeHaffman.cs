/*
Восстановите строку по её коду и беспрефиксному коду символов. 

В первой строке входного файла заданы два целых числа k и l через пробел — количество различных букв, 
встречающихся в строке, и размер получившейся закодированной строки, соответственно. 
В следующих k строках записаны коды букв в формате "letter: code". 
Ни один код не является префиксом другого. Буквы могут быть перечислены в любом порядке. 
В качестве букв могут встречаться лишь строчные буквы латинского алфавита; каждая из этих букв встречается в строке хотя бы один раз. 
Наконец, в последней строке записана закодированная строка. Исходная строка и коды всех букв непусты. 
Заданный код таков, что закодированная строка имеет минимальный возможный размер.

В первой строке выходного файла выведите строку s. 
Она должна состоять из строчных букв латинского алфавита. 
Гарантируется, что длина правильного ответа не превосходит 10^4 символов.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class MainClass
{
   public static void Main()
        {
            string[] target = Console.ReadLine().Split();
            int numWords = Convert.ToInt32( target[0]);
            int stringLenght = Convert.ToInt32( target[1]);
            
            Dictionary<String,String> dict = new Dictionary<String,String>();
            for(int i = 0;i<numWords;i++){
                string[] letterCode = Console.ReadLine().Split(':');
                string letter = letterCode[0].Trim();
                string code = letterCode[1].Trim();   
                dict.Add(code,letter);
            }
            
            string cipher = Console.ReadLine();
           /* Console.WriteLine(cipher);
            foreach(KeyValuePair<string,string> entry in dict){
                Console.WriteLine("-{0}:{1}-", entry.Key,entry.Value);
            }*/
           char[] cipherArray = cipher.ToCharArray();
            string result ="";
            string deCipher ="";
            
           foreach(char entry in cipherArray){
               
                deCipher += entry;
               
               if(dict.ContainsKey(deCipher)){
                   
                   result+=dict[deCipher];
                   deCipher="";
               }
              
            }
            Console.WriteLine(result);
           
        }
}
