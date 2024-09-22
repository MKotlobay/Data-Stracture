using System;
using Build_Base.MainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CustomClasses
{
    public class Poly
    {
        public Node<int> head;

        public Poly(Node<int> list1, Node<int> list2)
        {
            Node<int> ls1 = list1;
            Node<int> ls2 = list2;

            // Builds combained lists as one polynom
            Node<int> polyHead = null;
            Node<int> polyCurrent = polyHead;

            while(ls1 != null || ls2 != null)
            {
                if (polyHead == null)
                {
                    if (ls1.GetNext().GetValue() == ls2.GetNext().GetValue())
                    {
                        polyHead = new Node<int>(ls1.GetNext().GetValue() + ls2.GetNext().GetValue());
                        ls1 = ls1.GetNext();
                        polyHead.SetNext(polyCurrent = ls1);
                        ls1 = ls1.GetNext();
                        ls2 = ls2.GetNext().GetNext();
                    }
                    else
                    {
                        polyHead = ls1;
                        polyCurrent = ls1;

                        ls1 = ls1.GetNext();
                        polyCurrent.SetNext(ls1);
                        ls1 = ls1.GetNext();

                        polyCurrent.SetNext(ls2);
                        polyCurrent = ls2;
                        ls2 = ls2.GetNext();

                        polyCurrent.SetNext(ls2);
                        polyCurrent = ls2;
                        ls2 = ls2.GetNext();
                    }
                }
                else
                {
                    if (ls1.GetNext().GetValue() == ls2.GetNext().GetValue())
                    {
                        Node<int> tempNode = new Node<int>(ls1.GetNext().GetValue()+ls2.GetNext().GetValue());
                        polyCurrent.SetNext(tempNode);
                        polyCurrent = tempNode;
                        ls1 = ls1.GetNext();

                        polyCurrent.SetNext(ls1);
                        polyCurrent = ls1;
                        ls1 = ls1.GetNext();

                        ls2 = ls2.GetNext().GetNext();
                    }
                    else
                    {
                        polyCurrent.SetNext(ls1);
                        polyCurrent = ls1;
                        ls1 = ls1.GetNext();

                        polyCurrent.SetNext(ls1);
                        polyCurrent = ls1;
                        ls1 = ls1.GetNext();

                        polyCurrent.SetNext(ls2);
                        polyCurrent = ls2;
                        ls2 = ls2.GetNext();

                        polyCurrent.SetNext(ls2);
                        polyCurrent = ls2;
                        ls2 = ls2.GetNext();
                    }
                }





            }
            this.head = polyHead;

            /*while (current1 != null || current2 != null)
            {
                if (polyHead == null)
                {
                    if (current1.GetNext().GetValue() == current2.GetNext().GetValue())
                    {
                        Node<int> newNode = new Node<int>(current1.GetValue() + current2.GetValue());
                        polyHead = newNode;
                        polyCurrent = newNode;
                        current1 = current1.GetNext().GetNext();
                        current2 = current2.GetNext().GetNext();
                    }
                    else
                    {
                        polyHead = current1;
                        polyCurrent = current1.GetNext();
                        current1 = current1.GetNext().GetNext();

                        polyCurrent.SetNext(current2);
                        current2 = current2.GetNext();
                        polyCurrent.SetNext(current2);
                        current2 = current2.GetNext();
                    }
                }
                else
                {
                    if (current1.GetNext().GetValue() == current2.GetNext().GetValue())
                    {
                        polyCurrent = polyCurrent.GetNext();
                        Node<int> newNode = new Node<int>(current1.GetValue() + current2.GetValue());
                        polyCurrent = newNode;
                        polyCurrent.SetNext(current1.GetNext());

                        current1 = current1.GetNext().GetNext();
                        current2 = current2.GetNext().GetNext();
                    }
                    else
                    {
                        // Inserts from list 1
                        polyCurrent = current1;
                        polyCurrent = polyCurrent.GetNext();
                        polyCurrent = current1.GetNext();

                        // Inserts from list 2
                        polyCurrent = polyCurrent.GetNext();
                        polyCurrent = current2;
                        polyCurrent = polyCurrent.GetNext();
                        polyCurrent = current2.GetNext();

                        current1 = current1.GetNext().GetNext();
                        current2 = current2.GetNext().GetNext();
                    }
                }
            }
            this.head = polyHead;
            */
        }

        public void ToString()
        {
            Node<int> current = this.head;

            while (current != null && current.GetNext() != null)
            {
                Console.Write("(" + current.GetValue() + "," + current.GetNext().GetValue() + ")");
                current = current.GetNext().GetNext();
            }
            Console.WriteLine("");
        }
    }
}
