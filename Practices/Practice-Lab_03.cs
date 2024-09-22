using System;
using Build_Base.MainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Build_Base.CustomClasses;

namespace Build_Base
{
    public class Practice_Lab_03
    {
        #region Task 1
        public void test1()
        {
            Node<Item> head = new Node<Item>(new Item(1, 5));
            Node<Item> n1 = new Node<Item>(new Item(7, 12));
            Node<Item> n2 = new Node<Item>(new Item(13, 20));
            Node<Item> n3 = new Node<Item>(new Item(25, 28));

            head.SetNext(n1);
            n1.SetNext(n2);
            n2.SetNext(n3);

            bool[] arr = new bool[31];
            Random rnd = new Random();
            for (int i = 1; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(2) == 0;
            }
            NotEqual(head, arr);
        }
        public void NotEqual(Node<Item> list, bool[] arr)
        {
            for (int i = 1; i <= 30; i++)
            {
                if (list != null && i < list.GetValue().GetFrom())
                {
                    if (arr[i] == true)
                    {
                        Console.WriteLine("Wrong Day " + i);
                    }
                }
                else if (list != null && i >= list.GetValue().GetFrom() && i <= list.GetValue().GetTo())
                {
                    if (arr[i] == false)
                    {
                        Console.WriteLine("Wrong Day " + i);
                    }
                }
                else if (list != null && i > list.GetValue().GetFrom() && list != null)
                {
                    list = list.GetNext();
                }
                else if (list == null && arr[i] == true)
                {
                    Console.WriteLine("Wrong Day " + i);
                }
            }
        }
        #endregion End task 1
    }
}
