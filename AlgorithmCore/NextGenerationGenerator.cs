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
            //randomly flip all the chars
            char[] pathAsArray = newChromosome.PathString.ToCharArray();
            for (int i=0;i<pathAsArray.Length;i++)
            {
                int numberFromZeroToThree = _random.Next(0, 4);
                char newDirection = Enum.GetName(typeof(Movements), numberFromZeroToThree).ToCharArray()[0];
                pathAsArray[i] = newDirection;
            }
            newChromosome.PathString = new string(pathAsArray);
            return newChromosome;
        }

        //crossover
        private Chromosome Crossover(Chromosome parentOne, Chromosome parentTwo,int crossoverIndex)
        {
            Chromosome newChromosome = new Chromosome();
            string parentOnePathString = parentOne.PathString;
            string parentTwoPathString = parentTwo.PathString;
          
            string beginningOfParentOne = parentOnePathString.Remove(crossoverIndex);
            string beginningOfParentTwo = parentTwoPathString.Remove(crossoverIndex);
            string endOfParentOne = parentOnePathString.Substring(crossoverIndex);
            string endOfParentTwo = parentTwoPathString.Substring(crossoverIndex);

            string newPathStringOne = beginningOfParentOne + endOfParentTwo;
            string newPathStringTwo = beginningOfParentTwo + endOfParentOne;

            if (_random.NextDouble() > CROSSOVER_PROBABILITY)
            {
                newChromosome.PathString = newPathStringOne;
            }
            else
            {
                newChromosome.PathString = newPathStringTwo;
            }

            return newChromosome;
        }
    }
}
