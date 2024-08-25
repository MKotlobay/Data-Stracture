using Build_Base.CustomClasses;
using Build_Base.MainClasses;
using Data_Stracture.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.Practices
{
    public class Practice_Lab_07
    {
        #region Task 1
        public void task1()
        {
            Console.WriteLine("Enter size of BinNode");
            int size = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter from value");
            int from = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter to value");
            int to = int.Parse(Console.ReadLine());

            Console.WriteLine("");

            BinNode<int> binNodeList = GetBiList(size, from, to);
            Console.WriteLine("The List:");
            while (binNodeList != null)
            {
                Console.WriteLine(binNodeList);
                binNodeList = binNodeList.GetRight();
            }
        }
        public BinNode<int> GetBiList(int size, int from, int to) // Builder for lists
        {
            if (from < to)
            {
                Random rnd = new Random();

                BinNode<int> head = new BinNode<int>(rnd.Next(from, to + 1));
                BinNode<int> current = head;

                for (int i = 1; i < size; i++)
                {
                    int tempNum = rnd.Next(from, to + 1);
                    current.SetRight(new BinNode<int>(current, tempNum, null));
                    current = current.GetRight();
                }
                return head;
            }
            return null;
        }
        #endregion End task 1

        #region Task 2
        public void task2()
        {
            BinNode<int> list = GetBiList(10, 1, 100);
            ToPrintLeftRight(list);
        }

        public static void ToPrintLeftRight(BinNode<int> list)
        {
            while (list != null)
            {
                Console.WriteLine(list);
                list = list.GetRight();
            }
        }
        #endregion End task 2

        #region Task 3
        public void task3()
        {
            BinNode<int> list = GetBiList(10, 1, 100);
            ToPrintRightLeft(list);
        }

        public void ToPrintRightLeft(BinNode<int> list)
        {
            // Option A
            while (list.GetRight() != null)
                list = list.GetRight();
            while (list != null)
            {
                Console.WriteLine(list);
                list = list.GetLeft();
            }

            // Option B
            /*BinNode<int> head = list;
            BinNode<int> current = head;

            while (current.HasRight()) // Checks if true then will enter
            {
                current = current.GetRight();
            }
            while (current != null) // Will be stopped at max left side
            {
                Console.WriteLine(current);
                current = current.GetLeft();
            }*/
        }
        #endregion End task 3

        #region Task 4
        public void task4()
        {
            BinNode<int> list = GetBiList(10, 1, 100); // Builded new list
            list = AddLeftThenFarRight(list);
        }
        public BinNode<int> AddLeftThenFarRight(BinNode<int> list)
        {
            BinNode<int> head = list;
            BinNode<int> current = head;
            int counter = 1;

            Console.WriteLine("Before");
            ToPrintLeftRight(list);

            Random rnd = new Random();

            BinNode<int> newNode = new BinNode<int>(rnd.Next(1, 100));
            #region Left adding value section
            current.SetLeft(newNode);

            Console.WriteLine("---");
            Console.WriteLine("After");
            Console.WriteLine(current.GetLeft());
            #endregion End adding left value section
            #region Far right adding value section
            // Check it - have problem in getting last right side - Solution is getting to null by HasRight then break it
            while (list != null)
            {
                Console.WriteLine(current); // Requested to show every node in list
                counter++;
                if (current.HasRight() == false)
                {
                    break;
                }
                current = current.GetRight();
            }
            newNode.SetValue(rnd.Next(1, 100)); // Updates value of newNode
            current.SetRight(newNode); // Add to last node
            current = current.GetRight();
            Console.WriteLine(current);
            counter++;
            #endregion End far right adding value section
            #region Random middle adding value section - baced on amount
            counter = rnd.Next(1, counter); // Updates value of newNode
            newNode.SetValue(rnd.Next(1, 100));
            current = head;
            for (int i = 0; i < counter; i++)
            {
                current = current.GetRight();
            }
            current.SetLeft(newNode);
            #endregion End random middle adding value section - baced on amount
            return head;
        }
        #endregion End task 4

        #region Task 5
        public void task5()
        {
            BinNode<int> list = GetBiList(10, 1, 100); // Builded new list
            list = RemoveByNumber(list, 50);
            ToPrintLeftRight(list);
        }
        public BinNode<int> RemoveByNumber(BinNode<int> list, int num)
        {
            BinNode<int> head = list;
            BinNode<int> current = head;

            while (current.HasRight())
            {
                if (current.GetValue() > num)
                {
                    current = current.GetRight();
                    current.SetLeft(null);
                }
                if (current.GetRight().GetValue() > num)
                {
                    if (current.GetRight().HasRight() == false)
                        current.SetRight(null);
                    else
                        current.SetRight(current.GetRight().GetRight());
                }
                else
                    current = current.GetRight();
            }
            return head;
            #endregion End task 5
        }
    }
}
