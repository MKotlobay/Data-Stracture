using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CustomClasses
{
    public class Expr
    {
        private double num1;
        private double num2;
        private char op;

        public Expr(double num1, double num2, char op)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.op = op;
        }

        public double GetNum1() { return num1; }
        public double GetNum2() { return num2; }
        public char GetOp() { return op; }
        public void ToString()
        {
            Console.WriteLine("Expr of " + this.num1 + " and this " + this.num2 + " with that op " + this.op + " will result " + Calculate());
        }

        public double Calculate()
        {
            switch (this.op)
            {
                case '+':
                    return this.num1+this.num2;
                case '-':
                    return this.num1-this.num2;
                case '*':
                    return this.num1*this.num2;
                case '/':
                    return this.num1/this.num2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
}
