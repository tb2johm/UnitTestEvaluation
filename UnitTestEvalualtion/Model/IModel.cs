using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestEvalualtion.Model
{
    public interface IModel
    {
        string Add(string a, string b);
        string Sub(string a, string b);
        bool Validate(string a, string b);
    }
}
