import java.io.*;
import java.util.*;

public class Main {
    static int w, h;
    static char[][] map;
    static int[] dx = {1, -1, 0, 0};
    static int[] dy = {0, 0, 1, -1};

    static class Point {
        int x, y;

        Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int T = Integer.parseInt(br.readLine());

        while (T-- > 0) {
            StringTokenizer st = new StringTokenizer(br.readLine());
            w = Integer.parseInt(st.nextToken());
            h = Integer.parseInt(st.nextToken());
            map = new char[h][w];

            Queue<Point> fireQ = new LinkedList<>();
            Queue<Point> personQ = new LinkedList<>();

            for (int i = 0; i < h; i++) {
                String line = br.readLine();
                for (int j = 0; j < w; j++) {
                    map[i][j] = line.charAt(j);
                    if (map[i][j] == '*') fireQ.add(new Point(i, j));
                    if (map[i][j] == '@') personQ.add(new Point(i, j));
                }
            }

            int time = 0;
            boolean escaped = false;

            while (!personQ.isEmpty()) {
                time++;

                int fireSize = fireQ.size();
                for (int f = 0; f < fireSize; f++) {
                    Point fire = fireQ.poll();
                    for (int d = 0; d < 4; d++) {
                        int nx = fire.x + dx[d];
                        int ny = fire.y + dy[d];
                        if (nx >= 0 && nx < h && ny >= 0 && ny < w && map[nx][ny] == '.') {
                            map[nx][ny] = '*';
                            fireQ.add(new Point(nx, ny));
                        }
                    }
                }

                int personSize = personQ.size();
                for (int p = 0; p < personSize; p++) {
                    Point cur = personQ.poll();

                    for (int d = 0; d < 4; d++) {
                        int nx = cur.x + dx[d];
                        int ny = cur.y + dy[d];

                        if (nx < 0 || nx >= h || ny < 0 || ny >= w) {
                            System.out.println(time);
                            escaped = true;
                            break;
                        }

                        if (map[nx][ny] == '.') {
                            map[nx][ny] = '@';
                            personQ.add(new Point(nx, ny));
                        }
                    }
                    if (escaped) break;
                }
                if (escaped) break;
            }
            if (!escaped) System.out.println("IMPOSSIBLE");
        }
    }
}