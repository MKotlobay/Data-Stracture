using Build_Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CustomClasses
{
    public class Point
    {
        private double x;
        private double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetX() { return this.x; }

        public double GetY() { return this.y; }

        public void SetX(double x) { this.x = x; }

        public void SetY(double y) { this.y = y; }

        public override string ToString()
        {
            return this.x + " , " + this.y;
        }
    }
}
