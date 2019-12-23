using System;
using Crosscutting;
using System.Collections.Generic;
using System.Linq;
namespace AlgorithmCore
{
    public class FitnessSelector
    {
        //selects a pair of chromosomes from population to be parents
        //selection is done randomly with each chromosome having probability by fitness using roulette wheel selection
        public Chromosome Select(List<Chromosome> population)
        {
            Chromosome selectedChromosome = null;
            double fitnessValuesSum = 0;
            //generate random value between 0 and 1
            Random random = new Random();
            double randomValue = random.NextDouble();

            //sort population by fitness value
            population = population.OrderBy(chrom => chrom.FitnessValue).ToList();
            
            //sum the fitness values and select the first that is larger than probability value
            foreach (Chromosome chromosome in population)
            {
                fitnessValuesSum = fitnessValuesSum + chromosome.FitnessValue;
                if(randomValue<fitnessValuesSum)
                {
                    selectedChromosome = chromosome;
                    break;
                }
            }
            return selectedChromosome;
        }
    }
}
