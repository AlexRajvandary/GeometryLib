namespace Geometry
{
    public class Circle : IGeometricShape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}