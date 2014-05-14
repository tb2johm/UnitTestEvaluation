using System;
using System.Globalization;

namespace UnitTestEvalualtion.Model
{
    public class Model : IModel
    {
        public string Add(string a, string b)
        {
            double da = double.Parse(a);
            double db = double.Parse(b);

            double dr = da + db;

            return dr.ToString(CultureInfo.InvariantCulture);
        }

        public string Sub(string a, string b)
        {
            double da = double.Parse(a);
            double db = double.Parse(b);

            double dr = da - db;

            return dr.ToString(CultureInfo.InvariantCulture);
        }

        public bool Validate(string a, string b)
        {
            try
            {
                double.Parse(a);
                double.Parse(b);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
