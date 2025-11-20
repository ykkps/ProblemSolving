import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.Queue;
import java.util.StringTokenizer;

public class Main {

    static int K, W, H;
    static int[][] board;
    static int[][][] visited;

    static int[] dr_monkey = {0, 0, 1, -1};
    static int[] dc_monkey = {1, -1, 0, 0};

    static int[] dr_horse = {-2, -2, -1, -1, 1, 1, 2, 2};
    static int[] dc_horse = {-1, 1, -2, 2, -2, 2, -1, 1};

    static class Point {
        int r, c, k, dist;

        public Point(int r, int c, int k, int dist) {
            this.r = r;
            this.c = c;
            this.k = k;
            this.dist = dist;
        }
    }

    public static void main(String[] args) throws Exception {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

        K = Integer.parseInt(br.readLine());

        StringTokenizer st = new StringTokenizer(br.readLine());
        W = Integer.parseInt(st.nextToken());
        H = Integer.parseInt(st.nextToken());

        board = new int[H][W];
        for (int i = 0; i < H; i++) {
            st = new StringTokenizer(br.readLine());
            for (int j = 0; j < W; j++) {
                board[i][j] = Integer.parseInt(st.nextToken());
            }
        }

        System.out.println(bfs());
    }

    public static int bfs() {
        if (H == 1 && W == 1) {
            return 0;
        }

        visited = new int[H][W][K + 1];
        for (int i = 0; i < H; i++) {
            for (int j = 0; j < W; j++) {
                for (int l = 0; l <= K; l++) {
                    visited[i][j][l] = -1;
                }
            }
        }

        Queue<Point> queue = new LinkedList<>();

        queue.add(new Point(0, 0, 0, 0));
        visited[0][0][0] = 0;

        while (!queue.isEmpty()) {
            Point current = queue.poll();

            if (current.k < K) {
                for (int i = 0; i < 8; i++) {
                    int nr = current.r + dr_horse[i];
                    int nc = current.c + dc_horse[i];
                    int nk = current.k + 1;

                    if (nr < 0 || nr >= H || nc < 0 || nc >= W) continue;

                    if (board[nr][nc] == 1) continue;

                    if (visited[nr][nc][nk] != -1) continue;

                    if (nr == H - 1 && nc == W - 1) {
                        return current.dist + 1;
                    }

                    visited[nr][nc][nk] = current.dist + 1;
                    queue.add(new Point(nr, nc, nk, current.dist + 1));
                }
            }

            for (int i = 0; i < 4; i++) {
                int nr = current.r + dr_monkey[i];
                int nc = current.c + dc_monkey[i];
                int nk = current.k;

                if (nr < 0 || nr >= H || nc < 0 || nc >= W) continue;

                if (board[nr][nc] == 1) continue;

                if (visited[nr][nc][nk] != -1) continue;

                if (nr == H - 1 && nc == W - 1) {
                    return current.dist + 1;
                }

                visited[nr][nc][nk] = current.dist + 1;
                queue.add(new Point(nr, nc, nk, current.dist + 1));
            }
        }
        return -1;
    }
}