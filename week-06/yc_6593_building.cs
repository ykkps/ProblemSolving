using System;
using System.Collections.Generic;

class Program
{
    class Node
    {
        public int L, R, C, Time;
        public Node(int l, int r, int c, int time)
        {
            L = l; R = r; C = c; Time = time;
        }
    }

    static int[] dl = { 1, -1, 0, 0, 0, 0 };
    static int[] dr = { 0, 0, 1, -1, 0, 0 };
    static int[] dc = { 0, 0, 0, 0, 1, -1 };

    static void Main()
    {
        while (true)
        {
            var parts = Console.ReadLine().Split();
            int L = int.Parse(parts[0]);
            int R = int.Parse(parts[1]);
            int C = int.Parse(parts[2]);
            if (L == 0 && R == 0 && C == 0) break;

            char[,,] map = new char[L, R, C];
            Node start = null;

            for (int l = 0; l < L; l++)
            {
                for (int r = 0; r < R; r++)
                {
                    string line = Console.ReadLine();
                    for (int c = 0; c < C; c++)
                    {
                        map[l, r, c] = line[c];
                        if (map[l, r, c] == 'S')
                            start = new Node(l, r, c, 0);
                    }
                }
                Console.ReadLine();
            }

            int result = BFS(map, start, L, R, C);
            if (result == -1)
                Console.WriteLine("Trapped!");
            else
                Console.WriteLine($"Escaped in {result} minute(s).");
        }
    }

    static int BFS(char[,,] map, Node start, int L, int R, int C)
    {
        bool[,,] visited = new bool[L, R, C];
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(start);
        visited[start.L, start.R, start.C] = true;

        while (q.Count > 0)
        {
            Node cur = q.Dequeue();

            if (map[cur.L, cur.R, cur.C] == 'E')
                return cur.Time;

            for (int i = 0; i < 6; i++)
            {
                int nl = cur.L + dl[i];
                int nr = cur.R + dr[i];
                int nc = cur.C + dc[i];

                if (nl < 0 || nr < 0 || nc < 0 || nl >= L || nr >= R || nc >= C)
                    continue;
                if (visited[nl, nr, nc] || map[nl, nr, nc] == '#')
                    continue;

                visited[nl, nr, nc] = true;
                q.Enqueue(new Node(nl, nr, nc, cur.Time + 1));
            }
        }

        return -1;
    }
}
