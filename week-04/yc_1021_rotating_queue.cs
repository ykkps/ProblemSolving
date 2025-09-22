using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        var dq = new LinkedList<int>();
        for (int i = 1; i <= n; i++)
        {
            dq.AddLast(i);
        }

        var targets = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

        int result = 0;

        foreach (var target in targets)
        {
            int index = 0;
            var node = dq.First;
            while (node.Value != target)
            {
                node = node.Next;
                index++;
            }

            int leftDistance = index;
            int rightDistance = dq.Count - index;

            if (leftDistance > rightDistance)
            {
                for (int i = 0; i < rightDistance; i++)
                {
                    dq.AddFirst(dq.Last.Value);
                    dq.RemoveLast();
                    result++;
                }
            }
            else
            {
                for (int i = 0; i < leftDistance; i++)
                {
                    dq.AddLast(dq.First.Value);
                    dq.RemoveFirst();
                    result++;
                }
            }
            dq.RemoveFirst();
        }

        Console.WriteLine(result);
    }
}
