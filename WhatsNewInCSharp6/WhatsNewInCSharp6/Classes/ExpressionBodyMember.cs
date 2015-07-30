using static System.Math;

namespace WhatsNewInCSharp6.Classes
{
    public class ExpressionBodyMember
    {
        public double X { get; set; }
        public double Y { get; set; }

        //Lambda expression for a body member
        //The static using makes it so you don't have to use Math.Sqrt you can just call Sqrt
        //all static methods of a class become global to this class
        public double Distance => Sqrt(X * X + Y * Y);
    }
}
