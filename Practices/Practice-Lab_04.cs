using System;
using Data_Stracture.MainClasses;
using Data_Stracture.CustomClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture
{
    public class Practice_Lab_04
    {
        public void test()
        {
            #region Task 1
            Node<int> list1 = ListBuild(); // Build list of numbers by user
            Node<int> list2 = ListBuild(); // Build list of numbers by user

            Polynom poli = new Polynom(list1, list2); // Merging one list using 2 lists into one

            poli.ToString(); // Prints merged list
            poli.PolyNumSum(); // Summering values from merged list
            #endregion End task 1

            #region Task 2
            Node<int> list3 = ListBuild();
            int? num = NextZero(list3, 2);
            Console.WriteLine(num);

            num = PrevZero(list3, 4);
            Console.WriteLine(num);

            num = CountZero(list3);
            Console.WriteLine(num);
            #endregion End task 2
        }

        public Node<int> ListBuild() // Building list of numbers by user
        {
            Node<int> head = null; // Main head
            Node<int> current = head; // Moving and adding values

            for (int i = 0; i < 4; i++)
            {
                Node<int> node = new Node<int>(int.Parse(Console.ReadLine()));
                if (head == null)
                {
                    head = node;
                    current = head;
                }
                else
                {
                    current.SetNext(node);
                    current = node;
                }
            }
            return head;
        }

        #region Task 2.1
        public int? NextZero(Node<int> lst, int p) // int? represent either an int value or null.
        {
            Node<int> current = lst; // Head

            int counter = 1;

            while (current != null && counter < p) // Moving to p = location
            {
                current = current.GetNext();
                counter++;
            }
            while (current != null && current.GetValue() != 0) // Moving from p = location to find 0
            {
                current = current.GetNext();
                counter++;
            }
            if (current.GetValue() == 0)
                return counter;
            return null;
        }
        #endregion End task 2.1

        #region Task 2.2
        public int? PrevZero(Node<int> lst, int p)
        {
            Node<int> current = lst; // Head

            int counter = 1;

            while (current != null && counter < p) // Checks if counter that counts steps that it will be lower then p location
            {
                if (current.GetValue() == 0) // If value equals to 0 then it returns coutner that represents location of the next 0
                    return counter;
                else
                {
                    counter++;
                    current = current.GetNext();
                }
            }
            return null; // if non found then returns null
        }
        #endregion End task 2.2

        #region Task 2.3
        public int CountZero(Node<int> lst)
        {
            Node<int> current = lst; // head

            int counter = 0; // counter for number 0 amount

            while (current != null)
            {
                if (current.GetValue() == 0)
                    counter++;
                current = current.GetNext();
            }
            return counter;
        }
        #endregion End task 2.3

        #region Task 4
        public Node<int> PowList(Node<int> list1, Node<int> list2)
        {
            Node<int> current1 = list1;
            Node<int> current2 = list2;

            Node<int> head = null;
            Node<int> current = head;

            while (current1 != null)
            {
                while (current2 != null)
                {
                    if (head == null && (int)Math.Pow(current1.GetValue(), 2) == current2.GetValue())
                    {
                        head = current1;
                        current = head;
                    }
                    else if ((int)Math.Pow(current1.GetValue(), 2) == current2.GetValue())
                    {
                        current.SetNext(current1);
                        current = current1;
                    }
                    current2 = current2.GetNext();
                }
                current2 = list2;
                current1 = current1.GetNext();
            }
            return head;
        }
        #endregion End task 4
    }
}
