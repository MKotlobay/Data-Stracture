using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CustomClasses
{
    public class Item
    {
        private int from;
        private int to;

        public Item(int from, int to) // Recives day numbers that will be rainy days
        {
            this.from = from;
            this.to = to;
        }

        public int GetFrom() { return this.from; }
        public int GetTo() { return this.to; }
    }
}
