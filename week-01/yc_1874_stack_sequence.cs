using System.Text;

namespace ProblemSolving.week01;

public class Yc1874
{
    static void Main(string args[])
    {
        int stackSize = int.Parse(Console.ReadLine());
        StringBuilder answer = new StringBuilder();
        bool resultAvailable = true;
        int valueToPush = 1;
        Stack<int> stack = new Stack<int>();

        for (int i = 0; i < stackSize; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            while (valueToPush <= currentNumber)
            {
                stack.Push(valueToPush++);
                answer.Append("+").Append("\n");
            }

            if (stack.Count > 0 && stack.Peek() == currentNumber)
            {
                stack.Pop();
                answer.Append("-").Append("\n");
            }
            else
            {
                resultAvailable = false;
            }
        }

        if (resultAvailable)
        {
            Console.WriteLine(answer);
        }
        else
        {
            Console.WriteLine("NO");
        }
    }
}