using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    public class GeneticAlgorithm
    {
        private int populationSize;
        private double crossoverRate;
        private double mutationRate;
        private int eliteSize;
        private int generationCount;
        private Random random;
        private Chromosome bestSolution;
        private List<double> bestFitnessHistory;

        public GeneticAlgorithm(int populationSize, double crossoverRate, double mutationRate, int eliteSize, int generationCount)
        {
            this.populationSize = populationSize;
            this.crossoverRate = crossoverRate;
            this.mutationRate = mutationRate;
            this.eliteSize = eliteSize;
            this.generationCount = generationCount;
            this.random = new Random();
            this.bestFitnessHistory = new List<double>();
        }

        public void Solve()
        {
            List<Chromosome> population = InitializePopulation();
            bestSolution = null;

            for (int i = 0; i < generationCount; i++)
            {
                foreach (var chromosome in population)
                {
                    chromosome.Fitness = CalculateFitness(chromosome.X, chromosome.Y);
                }

                population.Sort((x, y) => x.Fitness.CompareTo(y.Fitness));

                if (bestSolution == null || population[0].Fitness < bestSolution.Fitness)
                {
                    bestSolution = new Chromosome(population[0].X, population[0].Y);
                    bestSolution.Fitness = population[0].Fitness;
                }

                bestFitnessHistory.Add(bestSolution.Fitness);

                List<Chromosome> elites = new List<Chromosome>();
                for (int j = 0; j < eliteSize && j < population.Count; j++)
                {
                    elites.Add(new Chromosome(population[j].X, population[j].Y));
                    elites[j].Fitness = population[j].Fitness;
                }

                List<Chromosome> newPopulation = new List<Chromosome>();
                while (newPopulation.Count < populationSize - eliteSize)
                {
                    Chromosome parent1 = SelectParent(population);
                    Chromosome parent2 = SelectParent(population);
                    Chromosome child = Crossover(parent1, parent2);
                    Mutate(child);
                    newPopulation.Add(child);
                }

                newPopulation.AddRange(elites);
                population = newPopulation;

            }


            Console.WriteLine("En iyi çözüm:");
            Console.WriteLine($"X = {bestSolution.X}, Y = {bestSolution.Y}");
            Console.WriteLine($"Amaç Fonksiyon Değeri: {bestSolution.Fitness}");
        }

        private List<Chromosome> InitializePopulation()
        {
            List<Chromosome> population = new List<Chromosome>();
            for (int i = 0; i < populationSize; i++)
            {
                double x = random.NextDouble() * 20 - 10;
                double y = random.NextDouble() * 20 - 10;
                population.Add(new Chromosome(x, y));
            }
            return population;
        }

        private void Mutate(Chromosome chromosome)
        {
            if (random.NextDouble() < mutationRate)
            {
                chromosome.X += (random.NextDouble() * 2 - 1) * 2;
                chromosome.X = Math.Max(-10, Math.Min(10, chromosome.X));
            }
            if (random.NextDouble() < mutationRate)
            {
                chromosome.Y += (random.NextDouble() * 2 - 1) * 2;
                chromosome.Y = Math.Max(-10, Math.Min(10, chromosome.Y));
            }
        }

        public Chromosome GetBestSolution
        {
            get { return bestSolution; }
        }
        private Chromosome SelectParent(List<Chromosome> population)
        {
            int tournamentSize = 3;

            List<Chromosome> tournamentParticipants = new List<Chromosome>();
            for (int i = 0; i < tournamentSize; i++)
            {
                int index = random.Next(population.Count);
                tournamentParticipants.Add(population[index]);
            }
          
            return tournamentParticipants.OrderBy(chromosome => chromosome.Fitness).First();
        }

        private Chromosome Crossover(Chromosome parent1, Chromosome parent2)
        {
            if (random.NextDouble() < crossoverRate)
            {
                double alpha = random.NextDouble();
                double x = alpha * parent1.X + (1 - alpha) * parent2.X;
                double y = alpha * parent1.Y + (1 - alpha) * parent2.Y;
                return new Chromosome(x, y);
            }
            else
            {
                return random.NextDouble() < 0.5 ?
                    new Chromosome(parent1.X, parent1.Y) :
                    new Chromosome(parent2.X, parent2.Y);
            }
        }

        public List<double> GetBestFitnessHistory()
        {
            return bestFitnessHistory;
        }

        private double CalculateFitness(double x, double y)
        {

            x = Math.Max(-10, Math.Min(10, x));
            y = Math.Max(-10, Math.Min(10, y));

            return (1 + Math.Pow((x + y + 1), 2) * (19 - 14 * x + 3 * Math.Pow(x, 2) - 14 * y + 6 * x * y + 3 * Math.Pow(y, 2))) *
                  (30 + Math.Pow((2 * x - 3 * y), 2) * (18 - 32 * x + 12 * Math.Pow(x, 2) + 48 * y - 36 * x * y + 27 * Math.Pow(y, 2)));
        }
    }
}
