using System;
using Data_Stracture.MainClasses;
using Data_Stracture.CustomClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture
{
    public class Practice_Lab_02
    {
        #region Task 1
        public static Node<int> ReturnEvenA(Node<int> nodes) // Answear A - regular
        {
            Node<int> nod = null; // start point
            Node<int> pos = nod;

            while (nodes != null)
            {
                if (nodes.GetValue() % 2 == 0)
                {
                    Node<int> n = new Node<int>(nodes.GetValue());
                    if (nod == null)
                    {
                        nod = n;
                        pos = nod;
                    }
                    else
                    {
                        pos.SetNext(n);
                        pos = pos.GetNext();
                    }
                }
                nodes = nodes.GetNext();
            }
            return nod;
        }

        public static Node<int> ReturnEvenB(Node<int> nodes) // Answear B - reverse
        {
            Node<int> reversed = null;
            Node<int> current = nodes;

            while (current != null)
            {
                if (current.GetValue() % 2 == 0)
                {
                    Node<int> node = new Node<int>(current.GetValue());
                    node.SetNext(reversed);
                    reversed = node; // It updates the head of the nodes - used in reversed
                }
                current = current.GetNext();
            }
            return reversed;
        }
        #endregion End task 1

        #region Task 2
        public static bool DNACheck(Node<char> dna1, Node<char> dna2) // Answear A
        {
            while (dna1 != null && dna2 != null)
            {
                if (dna1.GetValue() == 'A' && dna2.GetValue() == 'T' || dna1.GetValue() == 'T' && dna2.GetValue() == 'A' || dna1.GetValue() == 'G' && dna2.GetValue() == 'C' || dna1.GetValue() == 'C' && dna2.GetValue() == 'G')
                {
                    dna1 = dna1.GetNext();
                    dna2 = dna2.GetNext();
                }
                return false;
            }
            return true;
        }

        public static Node<char> oppoDNA(Node<char> dna) // Answear B
        {
            Node<char> oppositeDNA = null;
            Node<char> currentDNA = oppositeDNA;

            while (dna != null)
            {
                if (oppositeDNA == null)
                {
                    oppositeDNA = SettingValueDNA(dna);
                    currentDNA = oppositeDNA;
                }
                else
                {
                    currentDNA.SetNext(SettingValueDNA(dna));
                    currentDNA = currentDNA.GetNext();
                    dna.GetNext();
                }
                dna.GetNext();
            }
            return oppositeDNA;
        }

        public static Node<char> SettingValueDNA(Node<char> dna) // Answear B - helper
        {
            Node<char> node = new Node<char>('X');
            if (dna.GetValue() == 'A')
            {
                node.SetValue('T');
                return node;
            }
            else if (dna.GetValue() == 'T')
            {
                node.SetValue('A');
                return node;
            }
            else if (dna.GetValue() == 'G')
            {
                node.SetValue('C');
                return node;
            }
            else
            {
                node.SetValue('G');
                return node;
            }
        }
        #endregion End task 2

        #region Task 3
        public static Node<int> RemoveByNumber(Node<int> node, int num)
        {
            Node<int> head = null; // Start point
            Node<int> current = head; // Current point
            Node<int> nextNode = node; // Leading Node

            while (node != null)
            {
                nextNode = nextNode.GetNext();
                if (node.GetValue() != num && head == null) // Section A
                {
                    head = node;
                    current = head;
                }
                else if(node.GetValue() == num && current != null) // Section B
                {
                    current.SetNext(node.GetNext());
                    current = current.GetNext();
                    node.SetNext(null);
                    node = nextNode;
                }
                node = node.GetNext();
            }
            return head;
        }
        #endregion End task 3

        #region Task 4
        public static int PCircles(Node<Circle> c, Point p)
        {
            int counter = 0;

            while (c != null)
            {
                if (c.GetValue().GetPoint().GetX() == p.GetX() && c.GetValue().GetPoint().GetY() == p.GetY())
                    counter++;
                c = c.GetNext();
            }
            return counter;
        }
        #endregion End task 4

        #region Task 5
        public static double SumExpressions(Node<Expr> expr)
        {
            double sum = 0;

            while (expr != null)
            {
                sum += expr.GetValue().Calculate();
                expr = expr.GetNext();
            }
            return sum;
        }
        #endregion End task 5
    }
}
