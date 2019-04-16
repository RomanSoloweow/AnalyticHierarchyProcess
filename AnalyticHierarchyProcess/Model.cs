using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet;
using NamespaceMatrixTable;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
namespace NamespaceModel
{
    class Model
    {
        public Dictionary<int, string> scalesInt = new Dictionary<int, string>()
        {
            {-1,"Обратное симметричному"},
            {1, "Одинаковая значимость"},
            {2, "Почти слабая значимость"},
            {3, "Cлабая значимость"},
            {4, "Почти существенная значимость"},
            {5, "Существенная значимость"},
            {6, "Почти очевидная значимость"},
            {7, "Очевидная значимость"},
            {8, "Почти абсолютная значимость"},
            {9, "Абсолютная значимость"}
        };
        public Dictionary<string, int> scalesString = new Dictionary<string, int>()
        {
            {"Обратное симметричному",-1},
            {"Одинаковая значимость",1},
            {"Почти слабая значимость",2},
            {"Cлабая значимость",3},
            {"Почти существенная значимость",4},
            {"Существенная значимость",5},
            {"Почти очевидная значимость",6},
            {"Очевидная значимость",7},
            {"Почти абсолютная значимость",8},
            {"Абсолютная значимость",9}
        };
        public MatrixTable task = null;
        public Vector<double> NormResult = null;
        public Vector<double> IdealResult = null;
        public Dictionary<string, MatrixTable> matrixsCompare = new Dictionary<string, MatrixTable>();
        public List<string> options = new List<string>();
    }
}
