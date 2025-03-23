using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class Chromosome
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Fitness { get; set; }

        public Chromosome(double x, double y)
        {
            X = x;
            Y = y;
            Fitness = double.MaxValue;
        }
    }
}
