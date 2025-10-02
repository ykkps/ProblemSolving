import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        int result = 0;
        int stack = 0;

        for (int i = 0; i < input.length(); i++) {
            if (input.charAt(i) == '(') {
                stack++;
            } else {
                stack--;
                if (input.charAt(i - 1) == '(') {
                    result += stack;
                } else {
                    result += 1;
                }
            }
        }

        System.out.println(result);
    }
}