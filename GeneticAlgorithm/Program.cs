using AlgorithmCore;
using System;

namespace GeneticAlgorithmStart
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm();
            int populationSize = int.Parse(args[0]);
            int boardSize = int.Parse(args[1]);
            geneticAlgorithm.RunAlgorithm(populationSize, boardSize);
        }
    }
}
