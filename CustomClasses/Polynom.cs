using System;
using Data_Stracture.MainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture.CustomClasses
{
    public class Polynom
    {
        private Node<int> polynom;

        public Polynom(Node<int> list1, Node<int> list2)
        {
            this.polynom = null; // Head
            Node<int> current = polynom;

            Node<int> ls1 = list1;
            Node<int> ls2 = list2;

            while (ls1 != null)
            {
                if (this.polynom == null)
                {
                    this.polynom = ls1;
                    current = polynom;
                }
                else
                {
                    current.SetNext(ls1);
                    current = ls1;
                }
                ls1 = ls1.GetNext();
            }

            while (ls2 != null)
            {
                current.SetNext(ls2);
                current = ls2;
                ls2 = ls2.GetNext();
            }
        }

        public void ToString()
        {
            Node<int> current = this.polynom;

            while (current != null && current.GetNext() != null)
            {
                Console.Write("(" + current.GetValue() + "," + current.GetNext().GetValue() + ")");
                current = current.GetNext().GetNext();
            }
            Console.WriteLine("");
        }

        public void PolyNumSum()
        {
            int sum = 0;
            Node<int> current = this.polynom;

            while(current != null && current.GetNext() != null)
            {
                int num1 = current.GetValue();
                int num2 = current.GetNext().GetValue();

                int value = (int)Math.Pow(num1,num2);

                sum+= value;
                current = current.GetNext().GetNext();
            }
            Console.WriteLine(sum);
        }
    }
}
