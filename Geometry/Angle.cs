namespace Geometry
{
    public class Angle
    {
        public Angle(double value) : this(value, AngularUnit.Degree)
        {
        }

        public Angle(double value, AngularUnit angularUnit)
        {
            if(angularUnit == AngularUnit.Rad)
            {
                Value = Convert(value, AngularUnit.Degree);
                Unit = AngularUnit.Degree;
            }
            else
            {
                Value = value;
                Unit = angularUnit;
            }
        }

        public double Value { get; private set; }

        public AngularUnit Unit { get; private set; }

        public Angle Convert(AngularUnit unit)
        {
            if (Unit == unit) return this;

            var newValue = Convert(Value, unit);
            return new Angle(newValue, unit);
        }

        public static double Convert(double value, AngularUnit unit)
        {
            if (unit == AngularUnit.Degree)
            {
                return value * (180 / Math.PI);
            }
            else
            {
                return value * (Math.PI / 180);
            }
        }
    }
}
