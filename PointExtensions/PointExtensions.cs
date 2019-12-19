using Crosscutting;
using System;
using System.Drawing;

namespace PointExtensions
{
    public static class PointExtensions
    {
        //gets point and returns point moved by direction
        public static Point Move(this Point p,string direction)
        {
            if(direction.Equals(Movements.U.ToString()))
            {
                p.Y--;
            }
            if (direction.Equals(Movements.R.ToString()))
            {
                p.X++;
            }
            if (direction.Equals(Movements.D.ToString()))
            {
                p.Y++;
            }
            if (direction.Equals(Movements.L.ToString()))
            {
                p.X--;
            }
            return p;
        }
    }
}
