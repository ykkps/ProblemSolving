using System;
using System.Collections.Generic;

public class Program
{
    static int w, h;
    static char[,] map = new char[1,1];
    static readonly int[] dx = {1, -1, 0, 0};
    static readonly int[] dy = {0, 0, 1, -1};

    class Point
    {
        public int X, Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    static void Main(string[] args)
    {
        int T = int.Parse(Console.ReadLine()!);

        while (T-- > 0)
        {
            var tokens = Console.ReadLine()!.Split();
            w = int.Parse(tokens[0]);
            h = int.Parse(tokens[1]);
            map = new char[h, w];

            Queue<Point> fireQ = new Queue<Point>();
            Queue<Point> personQ = new Queue<Point>();

            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine()!;
                for (int j = 0; j < w; j++)
                {
                    map[i, j] = line[j];
                    if (map[i, j] == '*') fireQ.Enqueue(new Point(i, j));
                    if (map[i, j] == '@') personQ.Enqueue(new Point(i, j));
                }
            }
            int time = 0;
            bool escaped = false;

            while (personQ.Count > 0)
            {
                time++;

                int fireSize = fireQ.Count;
                for (int f = 0; f < fireSize; f++)
                {
                    Point fire = fireQ.Dequeue();
                    for (int d = 0; d < 4; d++)
                    {
                        int nx = fire.X + dx[d];
                        int ny = fire.Y + dy[d];

                        if (nx >= 0 && nx < h && ny >= 0 && ny < w && map[nx, ny] == '.')
                        {
                            map[nx, ny] = '*';
                            fireQ.Enqueue(new Point(nx, ny));
                        }
                    }
                }

                int personSize = personQ.Count;
                for (int p = 0; p < personSize; p++)
                {
                    Point cur = personQ.Dequeue();

                    for (int d = 0; d < 4; d++)
                    {
                        int nx = cur.X + dx[d];
                        int ny = cur.Y + dy[d];

                        if (nx < 0 || nx >= h || ny < 0 || ny >= w)
                        {
                            Console.WriteLine(time);
                            escaped = true;
                            break;
                        }

                        if (map[nx, ny] == '.')
                        {
                            map[nx, ny] = '@';
                            personQ.Enqueue(new Point(nx, ny));
                        }
                    }
                    if (escaped) break;
                }
                if (escaped) break;
            }
            if (!escaped) Console.WriteLine("IMPOSSIBLE");
        }
    }
}