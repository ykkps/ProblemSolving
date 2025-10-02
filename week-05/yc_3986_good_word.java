import java.util.*;
import java.io.*;

public class Main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
        int n = Integer.parseInt(br.readLine().trim());
        int good = 0;

        for(int i = 0; i < n; i++) {
            char[] word = br.readLine().trim().toCharArray();
            char[] stack = new char[word.length];
            int top = -1;

            for(char c : word) {
                if (top >= 0 && stack[top] == c) {
                    top--;
                }
                else {
                    stack[++top] = c;
                }
            }
            if(top == -1) good++;
        }
        System.out.println(good);
    }
}