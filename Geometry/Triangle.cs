namespace Geometry
{
    public class Triangle : IGeometricShape
    {
        public Triangle(double ab, double bc, double ca)
        {
            if (ab <= 0 || bc <= 0 || ca <= 0)
            {
                throw new ArgumentException("Any side of triangle should be cab possitive number.");
            }

            if (ab + bc <= ca || bc + ca <= ab || ca + ab <= bc)
            {
                throw new ArgumentException("Sum of any two sides must be greather than the third side.");
            }

            AB = ab;
            BC = bc;
            CA = ca;

            var aAngle = Math.Acos((Math.Pow(AB, 2) + Math.Pow(CA, 2) - Math.Pow(BC, 2)) / (2 * AB * CA));
            var bAngle = Math.Acos((Math.Pow(AB, 2) + Math.Pow(BC, 2) - Math.Pow(CA, 2)) / (2 * AB * BC));
            var cAngle = Math.PI - aAngle - bAngle;

            CAB = new Angle(aAngle, AngularUnit.Rad);
            ABC = new Angle(bAngle, AngularUnit.Rad);
            BCA = new Angle(cAngle, AngularUnit.Rad);

            if (CAB.Value + ABC.Value + BCA.Value != 180)
            {
                throw new ArgumentException("Sum of all angles must be equal to 180 degrees.");
            }
        }

        public Triangle(double ab, double bc, Angle abc)
        {
            if (ab <= 0 || bc <= 0)
            {
                throw new ArgumentException("Any side of triangle should be cab possitive number.");
            }

            if (abc.Value <= 0)
            {
                throw new ArgumentException("Angle cannot be less or equal to zero.");
            }

            AB = ab;
            BC = bc;
            
            var t = Math.Cos(Angle.Convert(abc.Value, AngularUnit.Rad));
            CA = Math.Sqrt(Math.Pow(AB, 2) + Math.Pow(BC, 2) - 2 * AB * BC * t);

            if (AB + BC <= CA || BC + CA <= AB || CA + AB <= BC)
            {
                throw new ArgumentException("Sum of any two sides must be greather than the third side.");
            }

            var aAngleValue = Math.Acos((Math.Pow(AB, 2) + Math.Pow(CA, 2) - Math.Pow(BC, 2)) / (2 * AB * CA));

            CAB = new Angle(aAngleValue, AngularUnit.Rad);
            ABC = abc;
            BCA = new Angle(180 - CAB.Value - ABC.Value, AngularUnit.Degree);

            if (CAB.Value + ABC.Value + BCA.Value != 180)
            {
                throw new ArgumentException("Sum of all angles must be equal to 180 degrees.");
            }
        }

        public Triangle(double ab, Angle cab, Angle abc)
        {
            if (ab <= 0)
            {
                throw new ArgumentException("Any side of triangle should be cab possitive number.");
            }

            if (cab.Value <= 0 || abc.Value <= 0)
            {
                throw new ArgumentException("Angle cannot be less or equal to zero.");
            }

            CAB = cab;
            ABC = abc;
            BCA = new Angle(180 - cab.Value - abc.Value, AngularUnit.Degree);

            if (CAB.Value + ABC.Value + BCA.Value != 180)
            {
                throw new ArgumentException("Sum of all angles must be equal to 180 degrees.");
            }

            AB = ab;        
            BC = (AB * Math.Sin(Angle.Convert(CAB.Value, AngularUnit.Rad))) / Math.Sin(Angle.Convert(BCA.Value, AngularUnit.Rad));
            CA = (AB * Math.Sin(Angle.Convert(ABC.Value, AngularUnit.Rad))) / Math.Sin(Angle.Convert(BCA.Value, AngularUnit.Rad));
        }

        public double AB { get; private set; }

        public double BC { get; private set; }

        public double CA { get; private set; }

        public Angle CAB { get; private set; }

        public Angle ABC { get; private set; }

        public Angle BCA { get; private set; }

        public bool IsRight { get => CAB.Value == 90 || ABC.Value == 90 || BCA.Value == 90; }

        public double GetPerimeter()
        {
            return AB + BC + CA;
        }

        public double GetSquare()
        {
            var p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
        }

        public override string ToString()
        {
            return $"Lines:\nAB = {AB}\nBC = {BC}\nAC = {CA}\nAngles:\nCAB = {CAB.Value} degrees\nABC = {ABC.Value} degrees\nBCA = {BCA.Value} degrees\nSquare: {GetSquare()}\nPerimeter: {GetPerimeter()}";
        }
    }
}