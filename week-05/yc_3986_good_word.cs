using System;
using System.IO;

class Program
{
	static void Main(string[] args)
	{
		StreamReader sr = new StreamReader(Console.OpenStandardInput());
		string line = sr.ReadLine();
		int n = int.Parse(line!.Trim());
		int good = 0;

		for(int i = 0; i < n; i++)
		{
			var word = sr.ReadLine()!.Trim().AsSpan();
			char[] stack = new char[word.Length];
			int top = -1;

			for(int j = 0; j < word.Length; j++)
			{
				char c = word[j];
				if(top >= 0 && stack[top] == c)
				{
					top--;
				}
				else
				{
					stack[++top] = c;
				}
			}
			if(top == -1) good++;
		}
		Console.WriteLine(good);
	}
}
