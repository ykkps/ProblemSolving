using System;
using System.Collections.Generic;

class Program
{
    const int MAX = 100000;
    static int[] dist = new int[MAX + 1];
    static int[] prev = new int[MAX + 1];

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int K = int.Parse(input[1]);

        Array.Fill(dist, -1);
        Array.Fill(prev, -1);

        BFS(N, K);

        List<int> path = new List<int>();
        for (int cur = K; cur != -1; cur = prev[cur])
            path.Add(cur);

        path.Reverse();

        Console.WriteLine(dist[K]);
        Console.WriteLine(string.Join(" ", path));
    }

    static void BFS(int N, int K)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(N);
        dist[N] = 0;

        while (q.Count > 0)
        {
            int x = q.Dequeue();

            if (x == K) return;

            int[] nexts = { x - 1, x + 1, x * 2 };

            foreach (int nx in nexts)
            {
                if (nx >= 0 && nx <= MAX && dist[nx] == -1)
                {
                    dist[nx] = dist[x] + 1;
                    prev[nx] = x;
                    q.Enqueue(nx);
                }
            }
        }
    }
}
