using System;
using System.Collections.Generic;

class Program
{
    static int N, M;
    static int[,] map;
    static int[,,] visited;
    static int[] dx = { 1, -1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };

    class Node
    {
        public int x, y, broken;
        public Node(int x, int y, int broken)
        {
            this.x = x;
            this.y = y;
            this.broken = broken;
        }
    }

    static void Main()
    {
        var parts = Console.ReadLine().Split();
        N = int.Parse(parts[0]);
        M = int.Parse(parts[1]);

        map = new int[N, M];
        visited = new int[N, M, 2];

        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            for (int j = 0; j < M; j++)
                map[i, j] = line[j] - '0';
        }

        Console.WriteLine(Bfs());
    }

    static int Bfs()
    {
        var q = new Queue<Node>();
        q.Enqueue(new Node(0, 0, 0));
        visited[0, 0, 0] = 1;

        while (q.Count > 0)
        {
            var cur = q.Dequeue();
            int x = cur.x, y = cur.y, broken = cur.broken;

            if (x == N - 1 && y == M - 1)
                return visited[x, y, broken];

            for (int i = 0; i < 4; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx < 0 || ny < 0 || nx >= N || ny >= M)
                    continue;

                if (map[nx, ny] == 0 && visited[nx, ny, broken] == 0)
                {
                    visited[nx, ny, broken] = visited[x, y, broken] + 1;
                    q.Enqueue(new Node(nx, ny, broken));
                }

                else if (map[nx, ny] == 1 && broken == 0 && visited[nx, ny, 1] == 0)
                {
                    visited[nx, ny, 1] = visited[x, y, broken] + 1;
                    q.Enqueue(new Node(nx, ny, 1));
                }
            }
        }

        return -1;
    }
}
