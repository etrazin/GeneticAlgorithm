using System.Drawing;

namespace Crosscutting
{
    public class Chromosome
    {
        #region private
        private const int ZERO = 0;
        #endregion

        public string PathString { get; set; }
        
        //let board size = n (meaning the board has n*n squares)
        //score = 2*n minus chromosome's (Manhattan) distance from end point
        //for example if chromosome ends 3 squares from end point and n=10
        //then score = 2*10-3=17
        public int Score { get; set; }

        //fitness value=score/sum of scores
        //higher score causes higher fitness value
        public double FitnessValue { get; set; }
        public Point PathStringToEndCoordinates()
        {           
            Point currentLocation = new Point(0, 0);
            foreach (char direction in PathString.ToCharArray())
            {
                string directionAsAString = direction.ToString();
                if ((currentLocation.X == ZERO && directionAsAString.Equals(Movements.L.ToString()))||
                        (currentLocation.Y==ZERO&&directionAsAString.Equals(Movements.U.ToString())))
                {
                    //if trying to move left in leftmost column or up in uppermost row
                    continue;
                }
                else
                {
                    currentLocation = currentLocation.Move(direction.ToString());
                }
            }
            return currentLocation;
        }
    }
}
