namespace Geometry
{
    public class ClockwiseComparer : IComparer<Point>
    {
        public int Compare(Point point, Point point_2)
        {
            double angle1 = Math.Atan2(point.Y, point.X) * (180 / Math.PI);
            double angle2 = Math.Atan2(point_2.Y, point_2.X) * (180 / Math.PI);

            if (angle1 < 0)
            {
                angle1 += 2 * Math.PI;
            }

            if (angle2 < 0)
            {
                angle2 += 2 * Math.PI;
            }

            return angle1.CompareTo(angle2);
        }
    }
}
