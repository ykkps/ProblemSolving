using System;
using System.Collections.Generic;

class Program
{
    class Node
    {
        public int x, y, broken;
        public Node(int x, int y, int broken) { this.x = x; this.y = y; this.broken = broken; }
    }

    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int N = int.Parse(input[0]);
        int M = int.Parse(input[1]);
        int K = int.Parse(input[2]);

        int[,] map = new int[N, M];
        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < M; j++)
                map[i, j] = line[j] - '0';
        }

        int[,,] dist = new int[N, M, K + 1];
        for (int i = 0; i < N; i++)
            for (int j = 0; j < M; j++)
                for (int k = 0; k <= K; k++)
                    dist[i, j, k] = -1;

        Queue<Node> q = new Queue<Node>();
        q.Enqueue(new Node(0, 0, 0));
        dist[0, 0, 0] = 1;

        int[] dx = { 1, -1, 0, 0 };
        int[] dy = { 0, 0, 1, -1 };

        while (q.Count > 0)
        {
            Node cur = q.Dequeue();

            if (cur.x == N - 1 && cur.y == M - 1)
            {
                Console.WriteLine(dist[cur.x, cur.y, cur.broken]);
                return;
            }

            for (int d = 0; d < 4; d++)
            {
                int nx = cur.x + dx[d];
                int ny = cur.y + dy[d];

                if (nx < 0 || ny < 0 || nx >= N || ny >= M)
                    continue;

                if (map[nx, ny] == 0 && dist[nx, ny, cur.broken] == -1)
                {
                    dist[nx, ny, cur.broken] = dist[cur.x, cur.y, cur.broken] + 1;
                    q.Enqueue(new Node(nx, ny, cur.broken));
                }

                if (map[nx, ny] == 1 && cur.broken < K && dist[nx, ny, cur.broken + 1] == -1)
                {
                    dist[nx, ny, cur.broken + 1] = dist[cur.x, cur.y, cur.broken] + 1;
                    q.Enqueue(new Node(nx, ny, cur.broken + 1));
                }
            }
        }

        Console.WriteLine(-1);
    }
}
