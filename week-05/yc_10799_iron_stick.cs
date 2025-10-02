using System;

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        int result = 0;
        int stack = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                stack++;
            }
            else
            {
                stack--;
                if (input[i - 1] == '(')
                {
                    result += stack;
                }
                else
                {
                    result += 1;
                }
            }
        }
        Console.WriteLine(result);
    }
}