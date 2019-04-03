using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixTable;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra;

namespace AnalyticHierarchyProcess
{
    public static class Calculations
    {
        public static Vector<double> Sole(Matrix<double> matrix)
        {
            // максимальное собственное значение
            double MaxEigenVal = MaxEigenValue(matrix);

            //из главной диагонали матрицы вычитаем это собственное значение
            matrix.SetDiagonal((matrix.Diagonal() - MaxEigenVal));

            int n = matrix.RowCount;
            //создаем вектор, необходимый для решения слау (первый столбец умножанный на -1, без 1 элемента
            Vector<double> _vector = Vector<double>.Build.DenseOfVector((matrix.Column(0) * (-1)).SubVector(0, n - 1));

            //преобразуем матрицу для слау
            matrix = matrix.RemoveColumn(0);
            matrix = matrix.RemoveRow(n-1);

            //вычисляем решение 
            Vector<double> result = Vector<double>.Build.Dense(n, 1);
            matrix.Solve(_vector).CopySubVectorTo(result, 0, 1, _vector.Count);

            return result;
        }
        public static Vector<double> GetVectorPriority(Matrix<double> matrix)
        {
            int n = matrix.ColumnCount;
            Vector<double> vectorPriority = Vector<double>.Build.Dense(n, 1);

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    vectorPriority[i] *= matrix[i, j];

            for (int i = 0; i < n; i++)
                vectorPriority[i] = Math.Pow(vectorPriority[i], (1.0 / (n - 1)));

            double sum = vectorPriority.Sum();

            for (int i = 0; i < n; i++)
                vectorPriority[i] /= sum;
            return vectorPriority;
        }
        public static double GetIndexAgreed(Matrix<double> matrix)
        {
            int n = matrix.ColumnCount;
            double I = (MaxEigenValue(matrix) - n) / (n - 1);
            return I;
        }
        public static double MaxEigenValue(Matrix<double> matrix)
        {
            return matrix.Evd().EigenValues.Real().Maximum();
        }
    }
}
