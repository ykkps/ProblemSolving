using System;
using System.Text;
using System.Collections.Generic;

public class Program
{
    public void Main(string[] args)
    {
        if (!int.TryParse(Console.ReadLine(), out int n))
        {
            return ;
        }

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string ps = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char c in ps)
            {
                if ( c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
            if (isValid && stack.Count == 0)
            {
                sb.AppendLine("YES");
            }
            else
            {
                sb.AppendLine("NO");
            }
        }
        Console.Write(sb.ToString());
    }
}