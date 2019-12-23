using Crosscutting;
using System;
using System.Collections.Generic;

namespace AlgorithmCore
{
    
    public class NextGenerationGenerator
    {
        #region private
        private const double CROSSOVER_PROBABILITY = 0.5;
        private const double MUTATION_PROBABILITY = 0.5;
        private readonly Random _random = new Random();
        #endregion
        
        public List<Chromosome> GenerateNextGeneration(List<Chromosome> population, int populationSize,int boardSize)
        {
            int crossoverIndex = CalculateCrossoverIndex(boardSize);

            List<Chromosome> nextGenerationPopulation = new List<Chromosome>();

            for (int i = 0; i < populationSize; i++)
            {
                //select
                FitnessSelector fitnessSelector = new FitnessSelector();
                Chromosome parentOne = fitnessSelector.Select(population);
                Chromosome parentTwo = fitnessSelector.Select(population);
                
                Chromosome newChromosome = parentOne;

                //crossover 
                if (_random.NextDouble() > CROSSOVER_PROBABILITY)
                {
                    newChromosome = Crossover(parentOne, parentTwo, crossoverIndex);
                }

                //mutation
                if (_random.NextDouble() > MUTATION_PROBABILITY)
                {
                    newChromosome = ApplyMutation(newChromosome);
                }

                //add to next generation
                nextGenerationPopulation.Add(newChromosome);
            }
            return nextGenerationPopulation;
        }

        private static int CalculateCrossoverIndex(int boardSize)
        {
            double crossoverIndexWoutFloor = 0.75 * (boardSize * 2);
            int crossoverIndex = (int)Math.Floor(crossoverIndexWoutFloor);
            return crossoverIndex;
        }

        //mutation is converting the last char in the path string to 'R'
        private Chromosome ApplyMutation(Chromosome newChromosome)
        {
            newChromosome.PathString = newChromosome.PathString.Remove(newChromosome.PathString.Length - 1) + "R";
            return newChromosome;
        }

        //crossover and insert new string into parent one
        private Chromosome Crossover(Chromosome parentOne, Chromosome parentTwo,int crossoverIndex)
        {
            string parentOnePathString = parentOne.PathString;
            string parentTwoPathString = parentTwo.PathString;

            parentOnePathString = parentOnePathString.Remove(crossoverIndex);
            parentOnePathString = parentOnePathString + parentTwoPathString.Substring(crossoverIndex);
            
            parentOne.PathString = parentOnePathString;
            return parentOne;
        }
    }
}
