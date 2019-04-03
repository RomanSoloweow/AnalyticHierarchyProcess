using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
namespace Option
{
    class Option
    {
        public string name;
        double globalPriority = -1;
        Vector<double> Priority
        Option(string _name, List<string> _criterions):base(_criterions)
        {
            name = _name;
        }
    }
}
