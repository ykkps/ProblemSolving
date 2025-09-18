using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Queue<int> q = new Queue<int>();

        for (int i = 1; i <= n; i++)
        {
            q.Enqueue(i);
        }
        while (q.Count > 1)
        {
            q.Dequeue();
            q.Enqueue(q.Dequeue());
        }
        Console.WriteLine(q.Peek());
    }
}
