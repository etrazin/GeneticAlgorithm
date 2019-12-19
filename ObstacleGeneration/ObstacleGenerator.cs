using System;
using System.Collections.Generic;

namespace ObstacleGeneration
{
    public class ObstacleGenerator
    {
        //returns a list of pairs of ints that represent the coordinates of the obstacles on the game board
        public List<Tuple<int, int>> Generate()
        {
            List<Tuple<int, int>> obstaclesCoordinates = new List<Tuple<int, int>>();
            Tuple<int, int> obstacleOne = new Tuple<int, int>(0, 9);
            Tuple<int, int> obstacleTwo = new Tuple<int, int>(1, 3);
            Tuple<int, int> obstacleThree = new Tuple<int, int>(2, 5);
            Tuple<int, int> obstacleFour = new Tuple<int, int>(3, 7);
            Tuple<int, int> obstacleFive = new Tuple<int, int>(4, 2);
            Tuple<int, int> obstacleSix = new Tuple<int, int>(5, 2);
            Tuple<int, int> obstacleSeven = new Tuple<int, int>(6, 3);
            Tuple<int, int> obstacleEight = new Tuple<int, int>(7, 5);
            Tuple<int, int> obstacleNine = new Tuple<int, int>(8, 3);
            Tuple<int, int> obstacleTen = new Tuple<int, int>(9, 8);
            obstaclesCoordinates.Add(obstacleOne);
            obstaclesCoordinates.Add(obstacleTwo);
            obstaclesCoordinates.Add(obstacleThree);
            obstaclesCoordinates.Add(obstacleFour);
            obstaclesCoordinates.Add(obstacleFive);
            obstaclesCoordinates.Add(obstacleSix);
            obstaclesCoordinates.Add(obstacleSeven);
            obstaclesCoordinates.Add(obstacleEight);
            obstaclesCoordinates.Add(obstacleNine);
            obstaclesCoordinates.Add(obstacleTen);
            return obstaclesCoordinates;
        }
    }
}
