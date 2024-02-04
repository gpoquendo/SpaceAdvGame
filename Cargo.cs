using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceAdvGame
{
    public class Cargo
    {
        public string Name { get; }
        public int Weight { get; }

        public Cargo(string name, int weight)
        {
            Name = name;
            Weight = weight;
        }
    }
}
