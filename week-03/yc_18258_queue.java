import java.io.*;
import java.util.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();

        int n = Integer.parseInt(br.readLine());
        int[] q = new int[n];
        int front = 0;
        int back = 0;

        for (int i = 0; i < n; i++) {
            String[] cmd = br.readLine().split(" ");
            switch (cmd[0]) {
                case "push":
                    q[back++] = Integer.parseInt(cmd[1]);
                    break;
                case "pop":
                    sb.append(front == back ? -1 : q[front++]).append("\n");
                    break;
                case "size":
                    sb.append(back - front).append("\n");
                    break;
                case "empty":
                    sb.append(front == back ? 1 : 0).append("\n");
                    break;
                case "front":
                    sb.append(front == back ? -1 : q[front]).append("\n");
                    break;
                case "back":
                    sb.append(front == back ? -1 : q[back - 1]).append("\n");
                    break;
            }
        }
        System.out.println(sb);
    }
}