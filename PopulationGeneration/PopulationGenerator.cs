using Crosscutting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PopulationGeneration
{
    public class PopulationGenerator
    {
        private readonly Random _random = new Random();

        public List<string> Generate(int populationSize, int boardSize)
        {
            List<string> population = new List<string>();
            for (int i = 0; i < populationSize; i++)
            {
                StringBuilder chromosome = new StringBuilder();
                //generate strings of length boardSize*2 so that they'll  be equal to the shortest possible path from start to end
                for (int j = 0; j < boardSize * 2; j++)
                {
                    //append U R D or L to the string/chromosome
                    chromosome.Append(Enum.GetName(typeof(Movements), _random.Next(0, 4)));
                }
                population.Add(chromosome.ToString());
            }
            return population;
        }
    }
}