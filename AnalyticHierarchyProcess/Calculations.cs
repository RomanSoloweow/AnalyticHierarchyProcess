using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;

namespace AnalyticHierarchyProcess
{
    public class Calculations
    {
        public Calculations(Task.Task task) {
            task.GetIndexAgreed();

        }

        public int CalcCR() {
            return 0;
        }

        public int[] Sole(int[] matrix) {
            SparseMatrix matrix1 = new SparseMatrix(n);
            //matrix1.Solve
            int[] a = new int[5];
            return new int[7];
        }
    }
}
