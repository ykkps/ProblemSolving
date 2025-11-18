using System;
using System.Collections.Generic;

class Program
{
    const int MAX = 100000;
    static int[] time = new int[MAX + 1];
    static bool[] visited = new bool[MAX + 1];

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int k = int.Parse(inputs[1]);

        BFS(n, k);
    }

    static void BFS(int start, int target)
    {
        LinkedList<int> deque = new LinkedList<int>();
        deque.AddLast(start);

        for (int i = 0; i <= MAX; i++)
        {
            time[i] = -1;
        }

        time[start] = 0;

        while (deque.Count > 0)
        {
            int current = deque.First.Value;
            deque.RemoveFirst();

            if (current == target)
            {
                Console.WriteLine(time[current]);
                return;
            }

            int nextTeleport = current * 2;
            if (nextTeleport <= MAX && time[nextTeleport] == -1)
            {
                time[nextTeleport] = time[current];
                deque.AddFirst(nextTeleport);
            }

            int nextBack = current - 1;
            if (nextBack >= 0 && time[nextBack] == -1)
            {
                time[nextBack] = time[current] + 1;
                deque.AddLast(nextBack);
            }

            int nextForward = current + 1;
            if (nextForward <= MAX && time[nextForward] == -1)
            {
                time[nextForward] = time[current] + 1;
                deque.AddLast(nextForward);
            }
        }
    }
}
