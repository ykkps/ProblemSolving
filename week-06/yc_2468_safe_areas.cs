using System;
using System.Collections.Generic;

class Program {
    static int N;
    static int[,] map;
    static bool[,] visited;
    static int[] dx = { 1, -1, 0, 0 };
    static int[] dy = { 0, 0, 1, -1 };

    static void Main() {
        N = int.Parse(Console.ReadLine());
        map = new int[N, N];
        int maxHeight = 0;

        for (int i = 0; i < N; i++) {
            var line = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int j = 0; j < N; j++) {
                map[i, j] = line[j];
                if (map[i, j] > maxHeight)
                    maxHeight = map[i, j];
            }
        }

        int maxSafe = 0;
        for (int h = 0; h <= maxHeight; h++) {
            visited = new bool[N, N];
            int count = 0;

            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    if (!visited[i, j] && map[i, j] > h) {
                        BFS(i, j, h);
                        count++;
                    }
                }
            }

            if (count > maxSafe)
                maxSafe = count;
        }

        Console.WriteLine(maxSafe);
    }

    static void BFS(int startX, int startY, int h) {
        Queue<(int, int)> q = new Queue<(int, int)>();
        q.Enqueue((startX, startY));
        visited[startX, startY] = true;

        while (q.Count > 0) {
            var (x, y) = q.Dequeue();

            for (int dir = 0; dir < 4; dir++) {
                int nx = x + dx[dir];
                int ny = y + dy[dir];

                if (nx >= 0 && ny >= 0 && nx < N && ny < N) {
                    if (!visited[nx, ny] && map[nx, ny] > h) {
                        visited[nx, ny] = true;
                        q.Enqueue((nx, ny));
                    }
                }
            }
        }
    }
}
