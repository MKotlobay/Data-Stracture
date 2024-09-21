using System;
using Build_Base.MainClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.Practices
{
    public class Practice_Lab_11
    {
        #region Builders
        public Queue<int> BuildQueue(Queue<int> q)
        {
            for (int i = 1; i <= 10; i++)
                q.Insert(i);
            return q;
        }
        public Queue<int> BuildRandomQueue(Queue<int> q)
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
                q.Insert(rnd.Next(1, 100));
            return q;
        }
        #endregion End builders

        #region Task 1
        public void task1()
        {
            Queue<int> q = BuildQueue(new Queue<int>());
            Console.WriteLine($"Amount in queue: {QueueCounter(q)}");
        }

        public int QueueCounter(Queue<int> q) // Counts length of queue
        {
            Queue<int> temp = new Queue<int>();

            int counter = 0;

            while (!q.IsEmpty()) // used remove inorder to count it
            {
                temp.Insert(q.Remove());
                counter++;
            }
            while (!temp.IsEmpty()) // Must return all queues to save original queue
                q.Insert(temp.Remove());

            return counter;
        }
        #endregion End task 1

        #region Task 2
        public void task2()
        {
            Queue<int> q1 = BuildQueue(new Queue<int>());
            Queue<int> q2 = CloneQueue(q1);

            Console.WriteLine("Original");
            Console.WriteLine(q1.ToString());
            Console.WriteLine("Cloned");
            Console.WriteLine(q2.ToString());
        }
        public Queue<int> CloneQueue(Queue<int> q) // Clones
        {
            Queue<int> clonedQ = new Queue<int>();
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                clonedQ.Insert(q.Head()); // takes first in line of 'q' and inserts copy of it
                temp.Insert(q.Remove()); // to make queue to move have to remove it
            }
            while (!temp.IsEmpty()) // Returns que to original queue
                q.Insert(temp.Remove());

            return clonedQ;
        }
        #endregion End task 2

        #region Task 3
        public void task3()
        {
            Queue<int> q = BuildQueue(new Queue<int>());
            Console.WriteLine(IsLocatedInQueue(q,5));
        }

        public bool IsLocatedInQueue(Queue<int> q, int num) // Check if num located in queue
        {
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                if (q.Head() == num)
                    return true;

                temp.Insert(q.Remove());
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return false;
        }
        #endregion End task 3

        #region Task 4
        public void task4()
        {
            Queue<int> q1 = BuildRandomQueue(new Queue<int>());
            Console.WriteLine(IsSorted(q1)); // Check for q1 - build base of random

            Queue<int> q2 = BuildQueue(new Queue<int>());
            Console.WriteLine(IsSorted(q2)); // Check for q2 - build base of sorts
        }

        public bool IsSorted(Queue<int> q) // Check is sorted queue by low to high numbers
        {
            Queue<int> temp = new Queue<int>();
            int tempValue = 0;

            while (!q.IsEmpty())
            {
                if (q.Head() > tempValue)
                {
                    tempValue = q.Head();
                    temp.Insert(q.Remove());
                }
                else
                    return false;
            }
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return true;
        }
        #endregion End task 4

        #region Task 5
        public void task5()
        {
            Queue<int> q1 = BuildQueue(new Queue<int>());
            Queue<int> q2 = BuildQueue(new Queue<int>());

            Console.WriteLine(IsSame(q1,q2));
        }

        public bool IsSame(Queue<int> q1, Queue<int> q2) // Checks if queues received is have same vlues
        {
            Queue<int> temp1 = new Queue<int>();
            Queue<int> temp2 = new Queue<int>();

            while (!q1.IsEmpty() && !q2.IsEmpty())
            {
                if (q1.Head() == q2.Head())
                {
                    temp1.Insert(q1.Remove());
                    temp2.Insert(q2.Remove());
                }
                else
                    return false;
            }
            while (!temp1.IsEmpty())
            {
                q1.Insert(temp1.Remove());
                q2.Insert(temp2.Remove());
            }

            return true;
        }
        #endregion End task 5

        #region Task 6
        public void task6()
        {
            Queue<int> q = BuildQueue(new Queue<int>());
            Console.WriteLine("Before changes");
            Console.WriteLine(q.ToString());

            UpdateHeadLocation(q, 5);
            Console.WriteLine("After changes");
            Console.WriteLine(q.ToString());
        }

        public Queue<int> UpdateHeadLocation(Queue<int> q, int num) // If num located then moves to head queue
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> tempHead = new Queue<int>();

            while (!q.IsEmpty())
            {
                if (q.Head() == num)
                {
                    tempHead.Insert(q.Remove());
                }
                temp.Insert(q.Remove());
            }
            q.Insert(tempHead.Remove());
            while(!temp.IsEmpty())
                q.Insert(temp.Remove());

            return q;
        }
        #endregion End task 6
    }
}
