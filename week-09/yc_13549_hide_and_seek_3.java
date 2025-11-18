import java.io.*;
import java.util.*;

public class Main {
    static int MAX = 100000;
    static int[] time = new int[MAX + 1];
    static boolean[] visited = new boolean[MAX + 1];

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringTokenizer st = new StringTokenizer(br.readLine());

        int n = Integer.parseInt(st.nextToken());
        int k = Integer.parseInt(st.nextToken());

        bfs(n, k);
    }

    public static void bfs(int start, int target) {
        Deque<Integer> deque = new ArrayDeque<>();
        deque.offer(start);

        Arrays.fill(time, -1);
        time[start] = 0;

        while (!deque.isEmpty()) {
            int current = deque.poll();

            if (current == target) {
                System.out.println(time[current]);
                return;
            }

            int nextTeleport = current * 2;
            if (nextTeleport <= MAX && time[nextTeleport] == -1) {
                time[nextTeleport] = time[current];
                deque.addFirst(nextTeleport);
            }

            int nextBack = current - 1;
            if (nextBack >= 0 && time[nextBack] == -1) {
                time[nextBack] = time[current] + 1;
                deque.addLast(nextBack);
            }

            int nextForward = current + 1;
            if (nextForward <= MAX && time[nextForward] == -1) {
                time[nextForward] = time[current] + 1;
                deque.addLast(nextForward);
            }
        }
    }
}
