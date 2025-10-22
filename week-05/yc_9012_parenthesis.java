import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.Stack;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        StringBuilder sb = new StringBuilder();

        int n = Integer.parseInt(br.readLine());

        for (int i = 0; i < n; i++) {
            String ps = br.readLine();
            Stack<Character> stack = new Stack<>();
            boolean isValid = true;

            for (int j = 0; j < ps.length(); j++) {
                char c = ps.charAt(j);

                if (c == '(') {
                    stack.push(c);
                } else if (c == ')') {
                    if (stack.empty()) {
                        isValid = false;
                        break;
                    } else {
                        stack.pop();
                    }
                }
            }
            if (isValid && stack.empty()) {
                sb.append("YES").append("\n");
            } else {
                sb.append("NO").append("\n");
            }
        }
        System.out.println(sb.toString());
    }
}