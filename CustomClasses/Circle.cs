using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture.CustomClasses
{
    public class Circle
    {
        private Point p;
        private double radius;

        public Circle(Point p, double radius)
        {
            this.p = p;
            this.radius = radius;
        }

        public Point GetPoint()
        {
            return this.p;
        }

        public double GetRadius()
        {
            return this.radius;
        }

        public void SetPoint(Point p)
        {
            this.p = p;
        }

        public void SetRadius(double radius)
        {
            this.radius = radius;
        }
    }
}
