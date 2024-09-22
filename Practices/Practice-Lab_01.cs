using System;
using Build_Base.MainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base
{
    public class Practice_Lab_01
    {
        public Practice_Lab_01()
        {
            #region Section A
            IntNode n1 = new IntNode(14);
            IntNode n2 = new IntNode(24);
            IntNode n3 = new IntNode(34);
            IntNode n4 = new IntNode(44);
            IntNode n5 = new IntNode(54);
            IntNode n6 = new IntNode(64);

            n1.SetNext(n2);
            n2.SetNext(n3);
            n3.SetNext(n4);
            n4.SetNext(n5);
            n5.SetNext(n6);

            // Task 1 - Done in class
            print(n1); // Task 2

            IntNode n7 = new IntNode(19); // Task 3

            n6.SetNext(n7); // Task 4
            print(n1);

            IntNode n8 = new IntNode(23); // Task 5

            n1.SetNext(n8);// Task 6
            n8.SetNext(n2);
            print(n1);

            IntNode n9 = new IntNode(63); // Task 7

            n9.SetNext(n1); // Task 8
            print(n9);

            n2.SetNext(n4); // Task 9
            n3.SetNext(null);
            print(n9);

            n9.SetValue(11); // Task 10
            print(n9);
        }

        public static void print(IntNode lst)
        {
            IntNode pos = lst;
            while (pos != null)
            {
                // הדפס את האיבר
                Console.Write(pos.GetValue() + "-->");
                // עבור לאיבר הבא
                pos = pos.GetNext();
            }
            Console.WriteLine();
        }
        #endregion Section A

        #region Section B
        public static int Sum(IntNode lst) // Task 1
        {
            IntNode pos = lst;
            int sum = 0;
            while (pos != null)
            {
                // Sum Value
                sum += pos.GetValue();
                // Moving to next node
                pos = pos.GetNext();
            }
            return sum;
        }

        public static bool IsExsist(IntNode lst, int num) // Task 2
        {
            IntNode pos = lst;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                    return true;
            }
            return false;
        }

        public static void EnterLast(IntNode lst, IntNode num) // Task 3
        {
            IntNode pos = lst;
            while (pos.HasNext() != true)
            {
                pos = pos.GetNext();
            }
            pos.SetNext(num);
        }

        public static void EnterSecond(IntNode lst, IntNode num) // Task 4
        {
            IntNode pos = lst;
            pos = pos.GetNext();
            pos.SetNext(num);
        }

        public static int Size(IntNode lst) // Task 5
        {
            IntNode pos = lst;
            int counter = 0;
            while (pos != null)
            {
                counter++;
            }
            return counter;
        }

        public static int HowMany(IntNode lst, int num) // Task 6
        {
            IntNode pos = lst;
            int counterNum = 0;
            while (pos != null)
            {
                if (pos.GetValue() == num)
                {
                    counterNum++;
                }
            }
            return counterNum;
        }

        public static bool InOrder(IntNode lst) // Task 7
        {
            IntNode pos = lst;
            int temp = pos.GetValue();
            pos.GetNext();
            while (pos != null)
            {
                if (pos.GetValue() <= temp)
                    return false;
                temp = pos.GetValue();
            }
            return true;
        }

        public static int SumOdd(IntNode lst) // Task 8
        {
            IntNode pos = lst;
            int sumOdd = 0;
            while (pos != null)
            {
                if (pos.GetValue() % 2 == 1)
                    sumOdd += pos.GetValue();
            }
            return sumOdd;
        }

        public static void EnterInOrder(IntNode lst, int num) // Task 9
        {
            IntNode pos = lst;
            IntNode temp = new IntNode(num);
            while (pos != null && pos.GetNext().GetValue() < num)
            {
                pos = pos.GetNext();
            }
            temp.SetNext(pos.GetNext());
            pos.SetNext(temp);
        }

        public static bool IsSerial(IntNode lst) // Task 10
        {
            IntNode pos = lst;

            int numSedra = Math.Abs(pos.GetValue() - pos.GetNext().GetValue()); // Equivalent to a mathematical series

            while (pos != null || pos.GetNext() != null)
            {
                if (Math.Abs(pos.GetValue() - pos.GetNext().GetValue()) != numSedra)
                    return false;
            }
            return true;
        }

        public static IntNode RemovePos(IntNode lst, int num) // Task 11
        {
            IntNode pos = lst;

            int index = 1;

            while (pos != null && index + 1 < num)
            {
                index++;
                pos = pos.GetNext();
            }
            pos.SetNext(pos.GetNext().GetNext());
            return pos;
        }

        public static IntNode ReturnAtPos(IntNode lst, int step) // Task 12
        {
            IntNode pos = lst;

            while (pos != null && step != 0)
            {
                step = step - 1; // Acting as counter
                pos = pos.GetNext();
            }
            return pos;
        }

        public static IntNode ReturnNum(IntNode lst, int num) // Task 13
        {
            IntNode pos = lst;

            while (pos != null)
            {
                if (pos.GetValue() == num)
                    return pos;
                pos = pos.GetNext();
            }
            return pos;
        }

        public static int Max(IntNode lst) // Task 14
        {
            IntNode pos = lst;
            int maxValue = pos.GetValue();

            while (pos != null)
            {
                if (pos.GetValue() > maxValue)
                    maxValue = pos.GetValue();
                pos = pos.GetNext();
            }
            return maxValue;
        }

        public static IntNode Prev(IntNode lst, IntNode num) // Task 15
        {
            IntNode pos = lst;

            while (pos != null && pos.GetNext() != num)
            {
                pos = pos.GetNext();
            }
            return pos;
        }
        #endregion Section B
    }
}
