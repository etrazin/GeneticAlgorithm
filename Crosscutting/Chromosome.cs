using System.Drawing;

namespace Crosscutting
{
    public class Chromosome
    {
        #region private
        private const int ZERO = 0;
        #endregion

        public string PathString { get; set; }
        //further distance from end point means higher score
        public double Score { get; set; }
        //fitness value in relation to other chromosomes
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
