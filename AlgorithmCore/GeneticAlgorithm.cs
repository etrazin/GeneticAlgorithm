using Crosscutting;
using PopulationGeneration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace AlgorithmCore
{
    public class GeneticAlgorithm
    {
        public void RunAlgorithm(int populationSize,int boardSize)
        {
            Chromosome correctPath = null;
            List<Chromosome> population = new List<Chromosome>();

            //generate initial population
            PopulationGenerator populationGenerator = new PopulationGenerator();
            population = populationGenerator.Generate(populationSize, boardSize);

            NextGenerationGenerator nextGenerationGenerator = new NextGenerationGenerator();
            
            int generationNumber = 0;
            while (generationNumber<10000)
            {
                //compute scores for each member of population
                ScoreComputer scoreComputer = new ScoreComputer();
                population = scoreComputer.ComputeScores(population, boardSize);

                //if correct path is found then print it
                correctPath = population.FirstOrDefault(chrom => chrom.Score == boardSize * 2);
                if (correctPath!=null)
                {
                    Console.WriteLine("correct path:" + correctPath.PathString);
                }
                
                //calculate fitness of each chromosome
                FitnessValueCalculator fitnessValueCalculator = new FitnessValueCalculator();
                population = fitnessValueCalculator.Calculate(population);

                population = nextGenerationGenerator.GenerateNextGeneration(population, populationSize, boardSize);
                //foreach (var item in population)
                //{
                //    Console.WriteLine(item.PathString);
                //}
                //Console.WriteLine(population.Select(chrom => chrom.Score).Max());
                //Console.WriteLine("generation number" + generationNumber);
                generationNumber++;
            }
            if(generationNumber==9999)
            {
                Console.WriteLine("correct path not found");
            }
        }
    }
}
