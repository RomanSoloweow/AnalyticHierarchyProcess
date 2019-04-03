using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;
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
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    if (i == j)
                        matrix[i, j] = matrix[i, j] - MaxEigenVal;
                }
            }
            //создаем вектор, необходимый для решения слау
            var _vector = Vector<double>.Build.Dense(matrix.RowCount - 1);
            _vector = matrix.Column(0) * (-1);
            _vector = _vector.SubVector(0, _vector.Count - 1);

            //преобразуем матрицу для слау
            matrix = matrix.RemoveColumn(0);
            matrix = matrix.RemoveRow(matrix.RowCount - 1);

            //вычисляем решение
            var result = matrix.Solve(_vector);

            //создаем результирующий вектор
            var result1 = Vector<double>.Build.Dense(result.Count + 1);
            result1[0] = 1;
            for (int i = 1; i < result1.Count; i++)
            {
                result1[i] = result[i - 1];
            }
            Console.WriteLine(result1);
            return (result1);
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
