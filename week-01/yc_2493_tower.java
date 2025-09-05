import java.io.*;
import java.util.*;

public class Yc2493 {
    record Tower(int index, int height) {}

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();

        int n = Integer.parseInt(br.readLine());
        int[] towers = new int[n];
        StringTokenizer st = new StringTokenizer(br.readLine());

        for (int i = 0; i < n; i++) {
            towers[i] = Integer.parseInt(st.nextToken());
        }

        Stack<Tower> stack = new Stack<>();

        for (int i = 0; i < n; i++) {
            int height = towers[i];

            while (!stack.isEmpty() && stack.peek().height() < height) {
                stack.pop();
            }

            if (!stack.isEmpty()) {
                sb.append(stack.peek().index()).append(" ");
            } else {
                sb.append("0 ");
            }

            stack.push(new Tower(i + 1, height));
        }

        System.out.println(sb.toString().trim());
    }
}
