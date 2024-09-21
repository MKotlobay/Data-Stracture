using System;
using Build_Base.MainClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CampusPractices
{
    public class PracticeStacks
    {
        #region Chapter 4 Task 3
        public static void Chapter4Task3()
        {
            Stack<int> stk = StackRandomInt(); // Used builder for random stack of ints
            Console.WriteLine(stk.ToString());

            stk = BlockStack(stk);
            Console.WriteLine(stk.ToString());
        }

        public static Stack<int> BlockStack(Stack<int> stk)
        {
            Stack<int> temp = new Stack<int>();

            int tempNum = 0;

            while (!stk.IsEmpty())
            {
                tempNum = stk.Pop();
                while (!stk.IsEmpty() && tempNum == stk.Top()) // Must include in while - check IsEmpty to avoid nulls
                {
                    stk.Pop();
                }
                temp.Push(tempNum);
            }
            return temp;
        }
        #endregion End Chapter 4 Task 3

        #region Chapter 4 Task 5
        public static void Chapter4Task5()
        {
            Stack<int> stk = StackRandomInt(); // Random stack numbers (1 to 999)

            Console.WriteLine(IsExist(stk, 8)); // Task 5.1

            Stack<int> clonedStk = Clone(stk); // Task 5.2

            Console.WriteLine(AllExist(stk)); // Task 5.3
        }

        #region Task 5.1
        public static bool IsExist(Stack<int> stk, int num)
        {
            Stack<int> tempStk = new Stack<int>();

            while (!stk.IsEmpty())
            {
                tempStk.Push(stk.Top()); // Saves original

                while (stk.Top() > 0)
                {
                    if (stk.Top() % 10 == num)
                        return true;
                    else
                    {
                        int tempNum = stk.Pop();
                        tempNum /= 10;
                        stk.Push(tempNum);
                    }
                }
                stk.Pop();
            }
            return false;
        }
        #endregion End task 5.1

        #region Task 5.2
        public static Stack<int> Clone(Stack<int> stk)
        {
            Stack<int> tempStk = new Stack<int>();
            Stack<int> cloneStk = new Stack<int>();

            while (!stk.IsEmpty())
                tempStk.Push(stk.Pop()); // Holds
            while (!tempStk.IsEmpty())
            {
                cloneStk.Push(tempStk.Top());
                stk.Push(tempStk.Pop()); // Returns to original
            }

            return cloneStk;
        }
        #endregion End task 5.2

        #region Task 5.3
        public static bool AllExist(Stack<int> stk)
        {
            Stack<int> clonedStk = Clone(stk); // Clones Stack to working on - on same sequence

            while (!clonedStk.IsEmpty()) // Checks cloned
            {
                int tempNum = clonedStk.Top(); // For getting first num will copy Top stack to grab first num

                while (tempNum / 10 != 0) // Repair it here - must to get only first num
                {
                    tempNum /= 10; // Get first num
                }
                if (IsExist(clonedStk, tempNum) == false) // Checks whole stack with using first num
                    return false;
                clonedStk.Pop(); // Get next
            }
            return true;
        }
        #endregion End task 5.3

        #endregion End Chapter 4 Task 5

        #region Chapter 4 Task 6
        public static void Chapter4Task6()
        {
            Console.WriteLine(Secret()); // Works - check to Improve it
        }

        public static Stack<int> StackRandomInt()
        {
            Stack<int> stack = new Stack<int>();

            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(rnd.Next(1, 1000));
            }
            return stack;
        }

        #region Task 6.1
        public static string Secret()
        {
            Stack<char> stk = new Stack<char>();
            Stack<char> tempStk = new Stack<char>();

            string stkText = "";

            Console.WriteLine("Enter only chars - stops at f");
            char tempChar = char.Parse(Console.ReadLine());

            while (tempChar != 'f')
            {
                stk.Push(tempChar);
                tempChar = char.Parse(Console.ReadLine());
            }

            while (!stk.IsEmpty())
            {
                if (stk.Top() == '@')
                {
                    stk.Pop();
                    while (!stk.IsEmpty() && stk.Top() != '@')
                    {
                        tempStk.Push(stk.Pop());
                    }
                    while (!tempStk.IsEmpty())
                        stkText += (tempStk.Pop());
                }
                else
                {
                    stkText += stk.Pop();
                }
            }

            return stkText;
        }
        #endregion End task 6.1

        #endregion End Chapter 4 Task 6

        #region Chapter 4 Task 8
        public static void Chapter4Task8()
        {

        }
        public static int MaxCuple(Stack<int> st1, Stack<int> st2)
        {
            int sum2 = 0; // Sum of highest stack of 2 in st2

            st2.Pop();
            while (!st2.IsEmpty())
            {
                int temp2 = st2.Top() + st2.Pop();
                if (temp2 > sum2)
                {
                    sum2 = temp2; // Changes value of sum2 to temp2 if it been greater
                }
                st2.Pop();
            }

            st1.Pop();
            while (!st1.IsEmpty())
            {
                int temp1 = st1.Top() + st1.Pop();
                if (temp1 > sum2)
                {
                    return temp1;
                }
                st1.Pop();
            }
            return 0;
        }
        #endregion End Chapter 4 Task 8

        #region Chapter 4 Task 9
        public static void Chapter4Task9()
        {
            Stack<int> stk = new Stack<int>();

            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            stk.Push(2);
            stk.Push(1);
            stk.Push(2);

            Console.WriteLine(stk.ToString());
            ChangeDirectionNum(stk);
            Console.WriteLine(stk.ToString());

            stk = new Stack<int>();
            stk.Push(3);
            stk.Push(7);
            stk.Push(3);
            stk.Push(7);
            stk.Push(3);

            Console.WriteLine(stk.ToString());
            ChangeDirectionNum(stk);
            Console.WriteLine(stk.ToString());
        }
        public static void ChangeDirectionNum(Stack<int> s) // Not good enough
        {
            Stack<int> tempStack = new Stack<int>();

            int head = s.Pop();
            int current = s.Pop();

            tempStack.Push(head);
            tempStack.Push(current);

            while (!s.IsEmpty())
            {
                if (head == s.Top())
                {
                    tempStack.Push(current);
                    tempStack.Push(s.Pop());
                }
                else if (!s.IsEmpty())
                {
                    head = tempStack.Top();
                    current = s.Pop();
                    tempStack.Push(current);
                }
            }

            while (!tempStack.IsEmpty())
                s.Push(tempStack.Pop());
        }

        public static void RightChangeDirectionNum(Stack<int> s) // Right way to do it
        {
            int temp, prev, top;
            Stack<int> st = new Stack<int>();

            while (!s.IsEmpty())
                st.Push(s.Pop());

            prev = st.Pop();
            s.Push(prev);
            s.Push(st.Pop());

            while (!st.IsEmpty())
            {
                temp = st.Pop();
                top = s.Top();
                if ((top > prev && temp < top) || (top < prev && temp > top))
                    s.Push(top);
                prev = top;
                s.Push(temp);
            }
        }
        #endregion End Chapter 4 Task 9
    }
}
