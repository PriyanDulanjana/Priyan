using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Demand_Management_Sys
{
    class Stack
    {
        private PowerPlant[] stackArray;
        private int top;

        public Stack(int size)
        {
            stackArray = new PowerPlant[size];
            top = -1;
        }

        public void Push(PowerPlant plant)
        {
            if (top < stackArray.Length - 1)
            {
                stackArray[++top] = plant;
            }
        }

        public PowerPlant Pop()
        {
            return (top >= 0) ? stackArray[top--] : null;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
    }


}
