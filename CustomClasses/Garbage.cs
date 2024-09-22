using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CustomClasses
{
    public class Garbage
    {
        private string num;
        private double capacity;
        private double quantity;
        private string neighbor;

        public Garbage(string num, double capacity, double quantity, string neighbor)
        {
            this.num = num;
            this.capacity = capacity;
            this.quantity = quantity;
            this.neighbor = neighbor;
        }

        #region Get
        public string GetNum() { return num; }
        public double GetCapacity() { return capacity; }
        public double GetQuantity() { return quantity; }
        public string GetNeighbor() { return neighbor; }
        #endregion End get

        #region Set
        public void SetNum(string num) { this.num = num; }
        public void SetCapacity(double capacity) { this.capacity = capacity; }
        public void SetQuantity(double quantity) { this.quantity = quantity; }
        public void SetNeighbor(string neighbor) { this.neighbor = neighbor; }
        #endregion End set

        public void ToString()
        {
            Console.WriteLine("Trash Can num: " + this.num + "Capacity is: " + this.capacity + "Quantity is: " + this.quantity + "Located in neighbor: " + this.neighbor);
        }

        public bool RequireClean() // Checks if quantity above capacity in precentage about 80%
        {
            if (((this.capacity / this.quantity) * 100) >= 80)
            {
                return true;
            }
            return false;
        }
    }
}
