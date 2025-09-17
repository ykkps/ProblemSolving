using System;
using System.Collections.Generic;

record Person(int Height, long Count);

class Program
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Stack<Person> stack = new Stack<Person>();
        long result = 0;

        for (int i = 0; i < n; i++)
        {
            int h = int.Parse(Console.ReadLine());
            long count = 1;

            while (stack.Count && stack.Peek().Height < h)
            {
                result += stack.Peek().Count;
                stack.Pop();
            }

            if (stack.Count > 0 && stack.Peek().Height == h)
            {
                var top = stack.Pop();
                result += top.Count;
                count = top.Count + 1;

                if (stack.Count > 0)
                {
                    result += 1;
                }
            }
            else
            {
                if (stack.Count > 0)
                {
                    result += 1;
                }
            }
            stack.Push(new Person(h, count));
        }
        Console.WriteLine(result);
    }
}