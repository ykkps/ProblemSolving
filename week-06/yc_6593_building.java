import java.util.*;

public class Main {
    static class Node {
        int l, r, c, time;

        Node(int l, int r, int c, int time) {
            this.l = l;
            this.r = r;
            this.c = c;
            this.time = time;
        }
    }

    static int[] dl = {1, -1, 0, 0, 0, 0};
    static int[] dr = {0, 0, 1, -1, 0, 0};
    static int[] dc = {0, 0, 0, 0, 1, -1};

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        while (true) {
            int L = sc.nextInt();
            int R = sc.nextInt();
            int C = sc.nextInt();
            if (L == 0 && R == 0 && C == 0) break;

            char[][][] map = new char[L][R][C];
            Node start = null;

            for (int l = 0; l < L; l++) {
                for (int r = 0; r < R; r++) {
                    String line = sc.next();
                    for (int c = 0; c < C; c++) {
                        map[l][r][c] = line.charAt(c);
                        if (map[l][r][c] == 'S') {
                            start = new Node(l, r, c, 0);
                        }
                    }
                }
            }

            int result = bfs(map, start, L, R, C);
            if (result == -1)
                System.out.println("Trapped!");
            else
                System.out.printf("Escaped in %d minute(s).%n", result);
        }

        sc.close();
    }

    static int bfs(char[][][] map, Node start, int L, int R, int C) {
        boolean[][][] visited = new boolean[L][R][C];
        Queue<Node> q = new LinkedList<>();
        q.add(start);
        visited[start.l][start.r][start.c] = true;

        while (!q.isEmpty()) {
            Node cur = q.poll();

            if (map[cur.l][cur.r][cur.c] == 'E') {
                return cur.time;
            }

            for (int i = 0; i < 6; i++) {
                int nl = cur.l + dl[i];
                int nr = cur.r + dr[i];
                int nc = cur.c + dc[i];

                if (nl < 0 || nr < 0 || nc < 0 || nl >= L || nr >= R || nc >= C) continue;
                if (visited[nl][nr][nc] || map[nl][nr][nc] == '#') continue;

                visited[nl][nr][nc] = true;
                q.add(new Node(nl, nr, nc, cur.time + 1));
            }
        }

        return -1;
    }
}
