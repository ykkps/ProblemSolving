using System;
using System.Collections.Generic;
using System.Linq;

public class Boj1600
{
    public class Point
    {
        public int R { get; set; }
        public int C { get; set; }
        public int K { get; set; }
        public int Dist { get; set; }

        public Point(int r, int c, int k, int dist)
        {
            R = r;
            C = c;
            K = k;
            Dist = dist;
        }
    }

    static int K, W, H;
    static int[][] Board;
    static int[,,] Visited;

    static int[] dr_monkey = {0, 0, 1, -1};
    static int[] dc_monkey = {1, -1, 0, 0};

    static int[] dr_horse = {-2, -2, -1, -1, 1, 1, 2, 2};
    static int[] dc_horse = {-1, 1, -2, 2, -2, 2, -1, 1};

    public static void Main(string[] args)
    {
        K = int.Parse(Console.ReadLine());

        string[] wh = Console.ReadLine().Split(' ');
        W = int.Parse(wh[0]);
        H = int.Parse(wh[1]);

        Board = new int[H][];
        for (int i = 0; i < H; i++)
        {
            Board[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        }

        Console.WriteLine(Bfs());
    }

    public static int Bfs()
    {
        if (H == 1 && W == 1)
        {
            return 0;
        }

        Visited = new int[H, W, K + 1];
        for (int i = 0; i < H; i++)
        {
            for (int j = 0; j < W; j++)
            {
                for (int l = 0; l <= K; l++)
                {
                    Visited[i, j, l] = -1;
                }
            }
        }

        Queue<Point> queue = new Queue<Point>();

        queue.Enqueue(new Point(0, 0, 0, 0));
        Visited[0, 0, 0] = 0;

        while (queue.Any())
        {
            Point current = queue.Dequeue();

            if (current.K < K)
            {
                for (int i = 0; i < 8; i++)
                {
                    int nr = current.R + dr_horse[i];
                    int nc = current.C + dc_horse[i];
                    int nk = current.K + 1;

                    if (nr < 0 || nr >= H || nc < 0 || nc >= W) continue;

                    if (Board[nr][nc] == 1) continue;

                    if (Visited[nr, nc, nk] != -1) continue;

                    if (nr == H - 1 && nc == W - 1)
                    {
                        return current.Dist + 1;
                    }

                    Visited[nr, nc, nk] = current.Dist + 1;
                    queue.Enqueue(new Point(nr, nc, nk, current.Dist + 1));
                }
            }

            for (int i = 0; i < 4; i++)
            {
                int nr = current.R + dr_monkey[i];
                int nc = current.C + dc_monkey[i];
                int nk = current.K;

                if (nr < 0 || nr >= H || nc < 0 || nc >= W) continue;

                if (Board[nr][nc] == 1) continue;

                if (Visited[nr, nc, nk] != -1) continue;

                if (nr == H - 1 && nc == W - 1)
                {
                    return current.Dist + 1;
                }

                Visited[nr, nc, nk] = current.Dist + 1;
                queue.Enqueue(new Point(nr, nc, nk, current.Dist + 1));
            }
        }
        return -1;
    }
}