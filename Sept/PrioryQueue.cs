/*
Первая строка входа содержит число операций 1≤n≤10^5. Каждая из последующих n
строк задают операцию одного из следующих двух типов:
    - Insert x, где 0≤x≤10^9 — целое число;
    - ExtractMax.
Первая операция добавляет число x в очередь с приоритетами, вторая — извлекает максимальное число и выводит его.
*/
using System;
using System.Collections;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class MainClass
{
    public static void Main()
    {
        PrioryQueue pq = new PrioryQueue();
        
        List<string> commands = new List<string>();
        int opernum = Int32.Parse(Console.ReadLine());
        for (int i = 0; i < opernum; i++)
        {
            commands.Add(Console.ReadLine());

        }
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i].Contains("Insert"))
            {
                string[] values = commands[i].Split(' ');
                int toadd = Int32.Parse(values[1]);
                pq.Insert(toadd);
            }
            if (commands[i].Equals("ExtractMax"))
            {
                Console.WriteLine(pq.ExactMax());

            }
            //pq.ShowQueue();
        }
        Console.ReadLine();

    }

}
public class PrioryQueue
{
    public List<int> PQ = new List<int>();

    public PrioryQueue()
    {
        PQ.Add(0);
    }
    private void Add(int toAdd)
    {
        PQ.Add(toAdd);
    }    

    public void Swap(int one, int two)
    {
        int temp = PQ[one];
        PQ[one] = PQ[two];
        PQ[two] = temp;
    }

    public void SiftUp2(int k)
    {
        if (k / 2 >= 1)
            if (PQ[k] > PQ[k / 2])
            {
                Swap(k, k / 2);
                SiftUp2(k / 2);
            }
    }

    public void SiftDown2(int k)
    {

        int a = PQ[k];
        int biggest = k;

        if (2 * k <= PQ.Count - 1 && PQ[biggest] < PQ[2 * k])
        {
            biggest = 2 * k;
        }
        if (2 * k + 1 <= PQ.Count - 1 && PQ[biggest] < PQ[2 * k + 1])
        {
            biggest = 2 * k + 1;
        }
        if (biggest != k)
        {
            Swap(k, biggest);
            SiftDown2(biggest);
        }
        
    }
    

    public int ExactMax()
    {
        int max = PQ[1];
        int lenght = PQ.Count - 1;
        PQ[1] = PQ[lenght];
        PQ.RemoveAt(lenght);
        if(lenght!=1)
        SiftDown2(1);
        return max;
    }
   
    public void Insert(int i)
    {
        PQ.Add(i);
        if (PQ.Count > 1)
            SiftUp2(PQ.Count - 1);
       
    }
    
    public void ShowQueue()
    {
        int i = 0;
        foreach (int integer in PQ)
        {
            Console.WriteLine("In index {0} is {1}", i, integer);
            i++;

        }
        Console.WriteLine("----------------------");
        Console.ReadKey();
    }



}






/*
 11
Insert 2
Insert 3
Insert 18
Insert 15
Insert 18
Insert 12
Insert 12
Insert 2
ExtractMax
ExtractMax
ExtractMax

8
Insert 2
Insert 3
Insert 15
Insert 18
Insert 12
ExtractMax
ExtractMax
ExtractMax

    8
Insert 200
Insert 10
Insert 5
Insert 500
ExtractMax
ExtractMax
ExtractMax
ExtractMax
     */
