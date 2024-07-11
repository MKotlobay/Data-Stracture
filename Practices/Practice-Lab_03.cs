using System;
using Data_Stracture.MainClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Stracture
{
    public class Practice_Lab_03
    {
        #region Task 1
        public bool CountHighLow(Node<int> node)
        {
            int counterOver = 0;
            int counterLower = 0;

            while (node != null)
            {
                if (node.GetValue() > 0)
                    counterOver++;
                else
                    counterLower++;

                node = node.GetNext();
            }
            if (counterOver > counterLower)
                return true;
            return false;
        }
        #endregion End task 1
    }
}
