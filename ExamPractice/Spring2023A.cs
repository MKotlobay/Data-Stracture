using System;
using Build_Base.MainClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.ExamPractice
{
    public class Spring2023A
    {
        #region Task 1
        public static void task1()
        {
            Queue<int> marks = new Queue<int>();
            marks.Insert(80);
            marks.Insert(90);
            marks.Insert(100);
            marks.Insert(75);
            marks.Insert(96);
            marks.Insert(100);
            marks.Insert(100);
            marks.Insert(97);
            marks.Insert(96);
            marks.Insert(88);
            marks.Insert(94);

            Queue<int> tests = new Queue<int>();
            tests.Insert(3);
            tests.Insert(2);
            tests.Insert(4);
            tests.Insert(2);

            Queue<double> avgQu = AverageQueue(marks, tests);
            Console.WriteLine(avgQu.ToString());
        }
        public static Queue<double> AverageQueue(Queue<int> marks, Queue<int> tests)
        {
            Queue<double> avgQu = new Queue<double>();

            while (!tests.IsEmpty())
            {
                double sum = 0;
                int max = tests.Remove();
                for (int i = 0; i < max; i++)
                {
                    sum += marks.Remove();
                }
                avgQu.Insert(sum/max);
            }
            return avgQu;
        }
        #endregion End Task 1

        #region Task 2
        public static void task2()
        {
            #region Task A
            Node<int> n = new Node<int>(2);
            Node<int> nTemp = n;

            nTemp.SetNext(new Node<int>(3));
            nTemp = nTemp.GetNext();
            nTemp.SetNext(new Node<int>(2));
            nTemp = nTemp.GetNext();
            nTemp.SetNext(new Node<int>(1));
            nTemp = nTemp.GetNext();
            nTemp.SetNext(new Node<int>(4));
            nTemp = nTemp.GetNext();
            nTemp.SetNext(new Node<int>(1));
            nTemp = nTemp.GetNext();
            nTemp.SetNext(new Node<int>(8));

            Console.WriteLine(NumDigits(n));
            #endregion End Task A

            #region Task B
            Random rnd = new Random();
            Node<int> n1 = new Node<int>(rnd.Next(1,10));
            Node<int> n1Current = n1;
            for (int i = 0; i < 10; i++)
            {
                n1Current.SetNext(new Node<int>(rnd.Next(1, 10)));
                n1Current = n1Current.GetNext();
            }

            Node<int> n2 = new Node<int>(rnd.Next(1, 10));
            Node<int> n2Current = n2;
            for (int i = 0; i < 10; i++)
            {
                n2Current.SetNext(new Node<int>(rnd.Next(1, 10)));
                n2Current = n2Current.GetNext();
            }
            Console.WriteLine(Compare(n1,n2));
            #endregion End Task B
        }

        #region Task A
        public static int NumDigits(Node<int> n)
        {
            int counter = 0;

            while (n != null)
            {
                counter++;
                n = n.GetNext();
            }
            return counter;
        }
        #endregion End Task A
        #region Task B
        public static int Compare(Node<int> n1, Node<int> n2)
        {
            int lengthN1 = NumDigits(n1);
            int lengthN2 = NumDigits(n2);

            if (lengthN1 > lengthN2)
                return 1;

            else if (lengthN2 > lengthN1)
                return 2;

            else
            {
                for (int i = 0; i < lengthN1; i++)
                {
                    if (n1.GetValue() > n2.GetValue())
                        return 1;
                    else if (n2.GetValue() > n1.GetValue())
                        return 2;
                    else
                    {
                        n1 = n1.GetNext();
                        n2 = n2.GetNext();
                    }
                }
            }
            return 0;
        }
        #endregion End Task B
        #endregion End Task 2
    }
}
