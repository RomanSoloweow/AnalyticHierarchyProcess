using NamespaceMatrixTable;
using VectorDouble = MathNet.Numerics.LinearAlgebra.Vector<double>;
using ListString = System.Collections.Generic.List<string>;
using DIctionaryStringMatrixTable = System.Collections.Generic.Dictionary<string, NamespaceMatrixTable.MatrixTable>;
namespace NamespaceModel
{
    class Model
    {
        public MatrixTable task = null;
        public VectorDouble NormResult = null;
        public VectorDouble IdealResult = null;
        public DIctionaryStringMatrixTable matrixsCompare = new DIctionaryStringMatrixTable();
        public ListString options = new ListString();
    }
}
