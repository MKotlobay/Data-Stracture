using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.MainClasses
{
    public class BinNode<T>
    {
        private T value;
        private BinNode<T> left;
        private BinNode<T> right;
        public BinNode(T value)
        {
            this.value = value;
            this.left = null;
            this.right = null;
        }
        public BinNode(BinNode<T> left, T value, BinNode<T> right) 
        {
            this.left = left;
            this.value = value;
            this.right = right;
        }
        public BinNode<T> GetLeft()
        {
            return this.left;
        }
        public void SetLeft(BinNode<T> left)
        {
            this.left = left;
        }
        public T GetValue()
        {
            return this.value;
        }
        public void SetValue(T value)
        {
            this.value = value;
        }
        public BinNode<T> GetRight()
        {
            return this.right;
        }
        public void SetRight(BinNode<T> right)
        {
            this.right = right;
        }
        public bool HasLeft()
        {
            return this.left != null;
        }
        public bool HasRight()
        {
            return this.right != null;
        }
        public override string ToString()
        {
            return " " + this.value;
        }
    }
}
