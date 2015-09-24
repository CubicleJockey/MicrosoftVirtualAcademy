namespace WhatsNewInCSharp6.DataTransferObjectSupport
{
    public class Point
    {
        //Readonly support. Don't need to do {get; private set;}
        #region Properties
        
        
        //These have to be set by a constructor or intializer
        //anywhere else will throw a compiler error
        public double X { get; }
        public double Y { get; }

        #endregion Properties

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        //This will get a compiler error
        //public void SetX(double x)
        //{
        //    X = x;
        //}
    }
}
