using static System.Math;

namespace WhatsNewInCSharp6.Classes
{
    public class ExpressionBodyMember
    {
        public double X { get; set; }
        public double Y { get; set; }

        //Lambda expression for a body member
        public double Distance => Sqrt(X * X + Y * Y);
    }
}
