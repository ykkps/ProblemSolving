using System;
using System.Collections.Generic;
using System.Linq;

public class Program {

    static int N;
    static int[,] grid;
    static bool[,] visited;
    static int[,] dist;
    static int[] dr = { -1, 1, 0, 0 };
    static int[] dc = { 0, 0, -1, 1 };

    public static void Main(string[] args) {
        N = int.Parse(Console.ReadLine());

        grid = new int[N, N];
        visited = new bool[N, N];
        dist = new int[N, N];

        for (int i = 0; i < N; i++) {
            string[] "line" = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++) {
                grid[i, j] = int.Parse(line[j]);
                dist[i, j] = -1;
            }
        }

        int islandId = 2;
        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (grid[i, j] == 1 && !visited[i, j]) {
                    LabelIsland(i, j, islandId);
                    islandId++;
                }
            }
        }

        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < N; j++) {
                if (grid[i, j] > 0) {
                    queue.Enqueue((i, j));
                    dist[i, j] = 0;
                }
            }
        }

        int minBridgeLength = int.MaxValue;

        while (queue.Count > 0) {
            (int r, int c) = queue.Dequeue();
            int currentIslandId = grid[r, c];

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];

                if (!IsInBounds(nr, nc)) continue;

                if (grid[nr, nc] == 0) {
                    grid[nr, nc] = currentIslandId;
                    dist[nr, nc] = dist[r, c] + 1;
                    queue.Enqueue((nr, nc));
                }
                else if (grid[nr, nc] > 0 && grid[nr, nc] != currentIslandId) {
                    int bridgeLength = dist[r, c] + dist[nr, nc];
                    minBridgeLength = Math.Min(minBridgeLength, bridgeLength);
                }
            }
        }

        Console.WriteLine(minBridgeLength);
    }

    static void LabelIsland(int startR, int startC, int id) {
        Queue<(int r, int c)> q = new Queue<(int r, int c)>();
        q.Enqueue((startR, startC));
        visited[startR, startC] = true;
        grid[startR, startC] = id;

        while (q.Count > 0) {
            (int r, int c) = q.Dequeue();

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];

                if (IsInBounds(nr, nc) && !visited[nr, nc] && grid[nr, nc] == 1) {
                    visited[nr, nc] = true;
                    grid[nr, nc] = id;
                    q.Enqueue((nr, nc));
                }
            }
        }
    }

    static bool IsInBounds(int r, int c) {
        return r >= 0 && r < N && c >= 0 && c < N;
    }
}
