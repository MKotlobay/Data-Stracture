using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.MainClasses
{
    public class IntNode
    {
        private int value;
        private IntNode next;

        public IntNode(int x)
        {
            this.value = x;
            this.next = null;
        }

        public IntNode(int x, IntNode next)
        {
            this.value = x;
            this.next = next;
        }

        public int GetValue()
        {
            return this.value;
        }

        public void SetValue(int x)
        {
            this.value = x;
        }

        public IntNode GetNext()
        {
            return this.next;
        }

        public void SetNext(IntNode x)
        {
            this.next = x;
        }

        public bool HasNext()
        {
            return next != null;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
