namespace Geometry
{
    public class Shape : IGeometricShape
    {
        public Shape(Point[] points)
        {
            if (points.Length < 3)
            {
                throw new ArgumentException("Shape cannot consist of less than 3 points.");
            }

            Points = points;
            Array.Sort(Points, new ClockwiseComparer());
        }

        public Point[] Points { get; }

        public double GetPerimeter()
        {
            var result = 0d;

            for (int i = 0; i < Points.Length; i++)
            {
                if (i < Points.Length - 1)
                {
                    result += GetLength(Points[i], Points[i + 1]);
                }
                else
                {
                    result += GetLength(Points[i], Points[0]);
                }
            }

            return result;
        }

        public double GetSquare()
        {
            double sum1 = 0;
            double sum2 = 0;

            for (int i = 0; i < Points.Length; i++)
            {
                if (i < Points.Length - 1)
                {
                    sum1 += Points[i].X * Points[i + 1].Y;
                    sum2 += Points[i].Y * Points[i + 1].X;
                }
                else
                {
                    sum1 += Points[i].X * Points[0].Y;
                    sum2 += Points[i].Y * Points[0].X;
                }
            }

            var result = (sum2 - sum1) / 2;

            if (result < 0)
            {
                result *= -1;
            }

            return result;
        }

        private double GetLength(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
        }
    }
}
