import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.StringTokenizer;
import java.util.Queue;
import java.util.LinkedList;

public class Main {

    static int N, M;
    static int[][] grid;
    static int[] dr = {-1, 1, 0, 0};
    static int[] dc = {0, 0, -1, 1};

    static class Point {
        int r, c;

        Point(int r, int c) {
            this.r = r;
            this.c = c;
        }
    }

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        N = Integer.parseInt(st.nextToken());
        M = Integer.parseInt(st.nextToken());
        grid = new int[N][M];

        for (int i = 0; i < N; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 0; j < M; j++) {
                grid[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        int year = 0;
        while (true) {
            int componentCount = countComponents();

            if (componentCount >= 2) {
                System.out.println(year);
                break;
            }
            if (componentCount == 0) {
                System.out.println(0);
                break;
            }

            melt();

            year++;
        }
    }

    static int countComponents() {
        boolean[][] visited = new boolean[N][M];
        int count = 0;

        for (int i = 0; i < N; i++) {
            for (int j = 0; j < M; j++) {
                if (grid[i][j] > 0 && !visited[i][j]) {
                    count++;
                    bfs(i, j, visited);
                }
            }
        }
        return count;
    }

    static void bfs(int startR, int startC, boolean[][] visited) {
        Queue<Point> queue = new LinkedList<>();
        queue.add(new Point(startR, startC));
        visited[startR][startC] = true;

        while (!queue.isEmpty()) {
            Point current = queue.poll();
            int r = current.r;
            int c = current.c;

            for (int i = 0; i < 4; i++) {
                int nr = r + dr[i];
                int nc = c + dc[i];

                if (isInBounds(nr, nc) && !visited[nr][nc] && grid[nr][nc] > 0) {
                    visited[nr][nc] = true;
                    queue.add(new Point(nr, nc));
                }
            }
        }
    }

    static void melt() {
        int[][] meltAmount = new int[N][M];

        for (int r = 0; r < N; r++) {
            for (int c = 0; c < M; c++) {
                if (grid[r][c] > 0) {
                    int waterNeighbors = 0;
                    for (int i = 0; i < 4; i++) {
                        int nr = r + dr[i];
                        int nc = c + dc[i];

                        if (isInBounds(nr, nc) && grid[nr][nc] == 0) {
                            waterNeighbors++;
                        }
                    }
                    meltAmount[r][c] = waterNeighbors;
                }
            }
        }

        for (int r = 0; r < N; r++) {
            for (int c = 0; c < M; c++) {
                grid[r][c] = Math.max(0, grid[r][c] - meltAmount[r][c]);
            }
        }
    }

    static boolean isInBounds(int r, int c) {
        return r >= 0 && r < N && c >= 0 && c < M;
    }
}
