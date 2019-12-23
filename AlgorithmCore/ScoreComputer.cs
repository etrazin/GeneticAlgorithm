using Crosscutting;
using System;
using System.Collections.Generic;
using System.Drawing;
namespace AlgorithmCore
{
    public class ScoreComputer
    {
        #region private const
        private const int TWO = 2;
        #endregion

        //n is the board size (n for nxn board)
        //distance is the distance between the chromosome's end coordinates and the end point 
        //score is 2*n-distance
        public List<Chromosome> ComputeScores(List<Chromosome> population,int boardSize)
        {
            Point endPoint = new Point(boardSize, boardSize);
            foreach (Chromosome chromosome in population)
            {
                Point lastPoint = chromosome.PathStringToEndCoordinates();
                int distance = lastPoint.ManhattanDistance(endPoint);
                chromosome.Score = 2 * boardSize - distance;
            }
            return population;
        }
    }
}
