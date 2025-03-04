using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electricity_Demand_Management_Sys
{
    class PowerPlant
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
        public double UnitCost { get; set; }
        public bool IsBaseload { get; set; }
        public PowerPlant? Next { get; set; }
        public PowerPlant? Prev { get; set; }

        public PowerPlant(string name, double capacity, double unitCost, bool isBaseload)
        {
            Name = name;
            Capacity = capacity;
            UnitCost = unitCost;
            IsBaseload = isBaseload;
            Next = null;
            Prev = null;
        }
    }
}
