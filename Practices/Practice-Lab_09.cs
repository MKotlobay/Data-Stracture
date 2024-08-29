using System;
using Build_Base.MainClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.Practices
{
    public class Practice_Lab_09
    {
        #region Builders
        public Stack<int> BuildStack() // Builds stack from 1 to 10
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 1; i <= 10; i++)
                stack.Push(i);
            return stack;
        }
        public Stack<int> BuilsStackRandom() // Builds stack from 1 to 1000
        {
            Stack<int> stack = new Stack<int>();
            Random rnd = new Random();

            for (int i = 1; i <= 10; i++)
                stack.Push(rnd.Next(1, 1000));
            return stack;
        }
        public Stack<char> BuildCharStack()
        {
            Stack<char> stack = new Stack<char>();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(chars[rnd.Next(chars.Length)]);
            }
            return stack;
        }
        #endregion End Builders

        #region Section B
        public void task1() // Amount of stacks have
        {
            Stack<int> stack = BuildStack();
            Console.WriteLine(CountStack(stack));
        }
        public int CountStack(Stack<int> stack) // For this exmaple used int, for using any type have to make class
        {
            int count = 0;
            Stack<int> temp = new Stack<int>();

            while (!stack.IsEmpty())
            {
                count++;
                temp.Push(stack.Pop());
            }
            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
            return count;
        }

        public void task2() // Returns order in reversed
        {
            Stack<int> stack = BuildStack();
            Console.WriteLine("Original Stacking");
            Console.WriteLine(stack.ToString());

            stack = ReverseStack(stack); // Gets new order - in revrsed
            Console.WriteLine("Reversed Stacking");
            Console.WriteLine(stack.ToString());
        }
        public Stack<int> ReverseStack(Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();

            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
            }
            return temp;
        }

        public void task3() // Summing value
        {
            Stack<int> stack = BuildStack();
            Console.WriteLine($"Summary of stack is:{SumStack(stack)}");
        }
        public int SumStack(Stack<int> stack)
        {
            int sum = 0;
            Stack<int> temp = new Stack<int>();

            while (!stack.IsEmpty())
            {
                sum += stack.Top();
                temp.Push(stack.Pop());
            }
            while(!temp.IsEmpty())
                stack.Push(temp.Pop());
            return sum;
        }

        public void task4()
        {
            Stack<int> stack = BuilsStackRandom();
            Console.WriteLine("Whole List: ");
            Console.WriteLine(stack.ToString());
            Console.WriteLine($"Max value in stack is:{MaxStack(stack)}");
        }
        public int MaxStack(Stack<int> stack) // Returns highest value in stack
        {
            int highestValue = 0;

            while (!stack.IsEmpty())
            {
                if (stack.Top() > highestValue)
                    highestValue = stack.Top();
                stack.Pop(); // Must inorder to get next value even if not entered to "if"
            }
            return highestValue;
        }

        public void task5() // Returns sum of stack values that above average
        {
            Stack<int> stack = BuilsStackRandom();
            Console.WriteLine("Whole list: ");
            Console.WriteLine(stack.ToString());
            Console.WriteLine("Sum of values that above avg");
            Console.WriteLine(GreaterAvg(stack));
        }
        public int GreaterAvg(Stack<int> stack)
        {
            int avg = SumStack(stack) / CountStack(stack);
            int aboveAvg = 0;

            while (!stack.IsEmpty())
            {
                if (stack.Top() > avg)
                {
                    aboveAvg += stack.Top();
                }
                stack.Pop();
            }
            return aboveAvg;
        }

        public void task6() // Find located char in stack
        {
            Stack<char> stack = new Stack<char>();
            stack.Push('a');
            stack.Push('b');
            stack.Push('c');
            stack.Push('d');
            stack.Push('e');

            Console.WriteLine($"Letter C is located in place num: " + CharStackLocation(stack, 'c'));
        }
        public int CharStackLocation(Stack<char> stack, char ch)
        {
            int location = 0;

            while (!stack.IsEmpty())
            {
                if (stack.Top() == ch)
                {
                    return location;
                }
                location++;
                stack.Pop();
            }
            return -1;
        }

        public void task7()
        {
            Stack<char> stack = BuildCharStack();
            Console.WriteLine("Base build");
            Console.WriteLine(stack.ToString());

            Console.WriteLine("Enter char for entering at last stack postion");
            char ch = char.Parse(Console.ReadLine());

            stack = InsertEndChar(stack,ch);
            Console.WriteLine("Added char to stack");
            Console.WriteLine(stack.ToString());
        }
        public Stack<char> InsertEndChar(Stack<char> stack, char ch)
        {
            Stack<char> temp = new Stack<char>();

            while (!stack.IsEmpty())
            {
                temp.Push(stack.Pop());
            }
            temp.Push(ch);
            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
            return stack;
        }

        public void task8() // Delting all chars from stack by letting user choose the char
        {
            Stack<char> stack = BuildCharStack();
            Console.WriteLine("Base build");
            Console.WriteLine(stack.ToString());

            Console.WriteLine("Enter char to be deleted in stack build");
            char ch = char.Parse(Console.ReadLine());

            stack = DeleteChar(stack,ch);
            Console.WriteLine("Removed char from stack");
            Console.WriteLine(stack.ToString());
        }
        public Stack<char> DeleteChar(Stack<char> stack, char ch)
        {
            Stack<char> temp = new Stack<char>();

            while (!stack.IsEmpty())
            {
                if (stack.Top() == ch)
                    stack.Pop();
                else
                    temp.Push(stack.Pop());
            }
            while (!temp.IsEmpty())
                stack.Push(temp.Pop());
            return stack;
        }

        public void task9() // Merging Stacks
        {
            Stack<int> stack1 = BuildStack();
            Stack<int> stack2 = BuildStack();

            Console.WriteLine($"First stack: {stack1.ToString()}");
            for (int i = 0;i<3;i++) // Only to make stack2 a bit different - cause BuildStack() by default is 10 nums
                stack2.Pop();
            Console.WriteLine($"Second stack: {stack2.ToString()}");

            Console.WriteLine("Merged stacks");
            Stack<int> stack3 = MergeStacks(stack1,stack2);
            Console.WriteLine(stack3.ToString());

        }
        public Stack<int> MergeStacks(Stack<int> stack1, Stack<int> stack2)
        {
            Stack<int> temp = new Stack<int>();

            while (!stack1.IsEmpty() || !stack2.IsEmpty())
            {
                if (!stack1.IsEmpty())
                    temp.Push(stack1.Pop());
                if (!stack2.IsEmpty())
                    temp.Push(stack2.Pop());
            }
            return ReverseStack(temp); // To get it back as it recived
        }
        #endregion End section B
    }
}
