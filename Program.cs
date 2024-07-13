using Build_Base.Practices;
using Data_Stracture.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            //Node<char> a = new Node<char>('A');
            //a = new Node<char>('T', a);


            //// Task 3 - A
            //Node<int> n1 = new Node<int>(8);
            //Node<int> n2 = new Node<int>(8);
            //Node<int> n3 = new Node<int>(5);
            //Node<int> n4 = new Node<int>(8);
            //Node<int> n5 = new Node<int>(2);
            //Node<int> n6 = new Node<int>(8);
            //Node<int> n7 = new Node<int>(4);
            //Node<int> n8 = new Node<int>(3);
            //Node<int> n9 = new Node<int>(8);

            //n1.SetNext(n2);
            //n2.SetNext(n3);
            //n3.SetNext(n4);
            //n4.SetNext(n5);
            //n5.SetNext(n6);
            //n6.SetNext(n7);
            //n7.SetNext(n8);
            //n9.SetNext(n9);

            //n1 = Practice_Lab_02.RemoveByNumber(n1, 8);
            //while (n1 != null)
            //{
            //    Console.Write(n1.GetValue() + "-->");
            //    n1 = n1.GetNext();
            //}

            //Practice_Lab_04 practiceLab4 = new Practice_Lab_04();
            //practiceLab.test();


            //Practice_Lab_05 practiceLab5 = new Practice_Lab_05();
            //practiceLab5.task1();
            //practiceLab5.task2();
            //practiceLab5.task3();

            Practice_Lab_06 practiceLab6 = new Practice_Lab_06();
            //practiceLab6.task1();
            //practiceLab6.task2();
            practiceLab6.task3();
        }
    }
}
