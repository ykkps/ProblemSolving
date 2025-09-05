import java.io.BufferedReader;
import java.io.IOException;
import java.util.Stack;

public class yc_6198_garden {
    record Building(int index, int height) {}

    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new java.io.InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine());
        long answer = 0;
        Stack<Building> stack = new Stack<>();

        for (int i = 0; i < n; i++) {
            int height = Integer.parseInt(br.readLine());

            while (!stack.isEmpty() && stack.peek().height() <= height) {
                stack.pop();
            }

            answer += stack.size();

            stack.push(new Building(i, height));
        }
        System.out.println( answer );
    }
}