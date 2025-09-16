using System;
using System.Collections.Generic;

record Element(int Index, int Value);

class Program
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
		int[] answer = new int[n];

		Stack<Element> stack = new Stack<Element>();

		for(int i = 0; i < n; i++)
		{
			int value = arr[i];

			while(stack.Count > 0 && stack.Peek().Value < value)
			{
				var e = stack.Pop();
				ans[e.Index] = value;
			}

			stack.Push(new Element(i, value));
		}

		while(stack.Count > 0)
		{
			answer[stack.Pop().Index] = -1;
		}
		Console.WriteLine(string.Join(" ", answer);
	}
}
