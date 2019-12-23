using Crosscutting;
using PopulationGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmCore
{
    
    public class GeneticAlgorithm
    {
        //flow of genetic algorithm
        public List<Chromosome> GenerateNextGeneration(int populationSize,int boardSize)
        {
            //generate population
            List<Chromosome> nextGenerationPopulation = new List<Chromosome>();
            List<Chromosome> population = new List<Chromosome>();

            PopulationGenerator populationGenerator = new PopulationGenerator();
            population = populationGenerator.Generate(populationSize, boardSize);

            //compute scores for each member of population
            ScoreComputer scoreComputer = new ScoreComputer();
            population = scoreComputer.ComputeScores(population, boardSize);

            for (int i = 0; i < populationSize; i++)
            {
                //select
                //crossover
                //mutation
                //add to next generation
            }
            return nextGenerationPopulation;
        }
    }
}
