using System;
using Build_Base.MainClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.Practices
{
    public class Practice_Lab_12
    {
        #region Builders
        public Queue<int> BuildRandomQ()
        {
            Queue<int> q = new Queue<int>();
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                q.Insert(rnd.Next(1, 11));
            }
            return q;
        }
        #endregion End Builders
        #region Task 1
        public void task1()
        {
            Queue<int> q = BuildRandomQ();
            Console.WriteLine(q.ToString());

            Console.WriteLine($"Amount of number 5 been used in Queue is: {CountAmount(q, 5)}"); // Task 1A
            Console.WriteLine("");

            Queue<int> q1 = new Queue<int>();
            q1.Insert(3);
            q1.Insert(1);
            q1.Insert(2);
            q1.Insert(1);
            q1.Insert(0);
            q1.Insert(7);
            q1.Insert(8);
            q1.Insert(8);
            q1.Insert(9);
            q1.Insert(5);
            q1.Insert(9);

            Queue<int> q2 = new Queue<int>();
            q2.Insert(4);
            q2.Insert(3);
            q2.Insert(4);
            q2.Insert(5);
            q2.Insert(3);
            q2.Insert(8);

            Console.WriteLine("Original Queue's");
            Console.WriteLine(q1.ToString());
            Console.WriteLine(q2.ToString());

            Console.WriteLine(SameNumsInQ(q1, q2).ToString());
            //Console.WriteLine($"After reduction: {SameNumsInQ(q1, q2).ToString()}");
        }
        #region Task 1A
        public int CountAmount(Queue<int> q, int num)
        {
            Queue<int> tempQ = new Queue<int>();
            int counter = 1;

            while (!q.IsEmpty())
            {
                if (q.Head() == num)
                {
                    counter++;
                }
                tempQ.Insert(q.Remove());
            }
            while (!tempQ.IsEmpty())
                q.Insert(tempQ.Remove());
            return counter;
        }
        #endregion End Task 1A
        #region Task 1B
        public Queue<int> SameNumsInQ(Queue<int> q1, Queue<int> q2)
        {
            Queue<int> newQ = new Queue<int>();

            while (!q1.IsEmpty())
            {
                int countX = CountAmount(q1, q1.Head());
                int countY = CountAmount(q2, q1.Head());

                if (countX > 1 && countY > 1 && countX != countY)
                {
                    newQ.Insert(q1.Head());
                }
                q1.Remove();
            }
            return newQ;
        }
        #endregion End Task 1B
        #endregion End Task 1
        #region Task 2
        public void task2()
        {
        }
        public bool IsQLogicalBool(Queue<char> q)
        {
            if (q.Head() == 'T' || q.Head() == 'F')
            {
                q.Remove();
                while (!q.IsEmpty())
                {
                    if (q.Head() != 'O' || q.Head() != 'A')
                        return false;
                    else
                        q.Remove();
                    if (q.Head() != 'T' || q.Head() != 'F')
                        return false;
                    else
                        q.Remove();
                }
                return true;
            }
            return false;
        }

        #endregion End Task 2
        #region Task 3
        public void task3()
        {
        }
        public Queue<int> HigherOnlyQ(Queue<int> q)
        {
            Queue<int> newQ = new Queue<int>();
            int higher = 0;

            while (!q.IsEmpty())
            {
                if (q.Head() != -1)
                {
                    if (q.Head() > higher)
                        higher = q.Head();
                    q.Remove();
                }
                else
                {
                    newQ.Insert(higher);
                    newQ.Insert(q.Remove());
                    higher = 0;
                }
            }
            return newQ;
        }
        #endregion End Task 3
        #region Task 4
        public void task4()
        {
        }
        public Queue<int> OrderByQNum(Queue<int> q)
        {
            Queue<int> newQ = new Queue<int>();

            int amount = 0;
            int num = 0;

            while (!q.IsEmpty())
            {
                amount = q.Head();
                num = q.Remove();
                while (amount > 0)
                {
                    newQ.Insert(num);
                    amount -= 1;
                }
            }
            return newQ;
        }
        #endregion End Task 4
    }
}
