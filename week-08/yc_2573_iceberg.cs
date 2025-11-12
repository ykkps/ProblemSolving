using System;
using System.Collections.Generic;
using System.Linq;

public class Program {

    static int N, M;
    static int[,] grid;
    static int[] dr = { -1, 1, 0, 0 };
    static int[] dc = { 0, 0, -1, 1 };

    public static void Main(string[] args) {
        string[] "line" = Console.ReadLine().Split(' ');
        N = int.Parse(line[0]);
        M = int.Parse(line[1]);
        grid = new int[N, M];

        for (int i = 0; i < N; i++) {
            line = Console.ReadLine().Split(' ');
            for (int j = 0; j < M; j++) {
                grid[i, j] = int.Parse(line[j]);
            }
        }

        int year = 0;
        while (true) {
            int componentCount = CountComponents();

            if (componentCount >= 2) {
                Console.WriteLine(year);
                break;
            }
            if (componentCount == 0) {
                Console.WriteLine(0);
                break;
            }

            Melt();

            year++;
        }
    }

    static int CountComponents() {
        bool[,] visited = new bool[N, M];
        int count = 0;

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) {
                if (grid[i, j] > 0 && !visited[i, j]) {
                    count++;
                    Bfs(i, j, visited);
                }
            }
        }
        return count;
    }

    static void Bfs(int startR, int startC, bool[,] visited) {
        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        queue.Enqueue((startR, startC));
        visited[startR, startC] = true;

        while (queue.Count > 0) {
            (int r, int c) = queue.Dequeue();

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];

                if (IsInBounds(nr, nc) && !visited[nr, nc] && grid[nr, nc] > 0) {
                    visited[nr, nc] = true;
                    queue.Enqueue((nr, nc));
                }
            }
        }
    }

    static void Melt() {
        int[,] meltAmount = new int[N, M];

        for (int r = 0; r < N; r++) {
            for (int c = 0; c < M; c++) {
                if (grid[r, c] > 0) {
                    int waterNeighbors = 0;
                    for (int i = 0; i < 4; i++) {
                        int nr = r + dr[i];
                        int nc = c + dc[i];

                        if (IsInBounds(nr, nc) && grid[nr, nc] == 0) {
                            waterNeighbors++;
                        }
                    }
                    meltAmount[r, c] = waterNeighbors;
                }
            }
        }

        for (int r = 0; r < N; r++) {
            for (int c = 0; c < M; c++) {
                grid[r, c] = Math.Max(0, grid[r, c] - meltAmount[r, c]);
            }
        }
    }

    static bool IsInBounds(int r, int c) {
        return r >= 0 && r < N && c >= 0 && c < M;
    }
}