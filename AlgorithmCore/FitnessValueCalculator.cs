using Crosscutting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AlgorithmCore
{
    //calculates fitness values for population
    //fitness value=score/sum of scores
    public class FitnessValueCalculator
    {
        public List<Chromosome> Calculate(List<Chromosome> population)
        {
            double populationScoresSum = population.Select(chrom => chrom.Score).Sum();
            foreach (Chromosome chromosome in population)
            {
                double fitnessValue = chromosome.Score / populationScoresSum;
                chromosome.FitnessValue = fitnessValue;
            }
            return population;
        }
    }
}
