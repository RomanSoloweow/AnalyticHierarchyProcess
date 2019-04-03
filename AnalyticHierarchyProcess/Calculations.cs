using System;
using MathNet.Numerics.LinearAlgebra;

namespace AnalyticHierarchyProcess
{
    public static class Calculations
    {

        public static Vector<double> Sole(Matrix<double> _matrix)
        {
            // максимальное собственное значение
            double MaxEigenVal = _matrix.Evd().EigenValues.Real().Maximum();
            //из главной диагонали матрицы вычитаем это собственное значение
            for (int i = 0; i < _matrix.RowCount; i++)
            {
                for (int j = 0; j < _matrix.ColumnCount; j++)
                {
                    if (i == j)
                        _matrix[i, j] = _matrix[i, j] - MaxEigenVal;
                }
            }
            //создаем вектор, необходимый для решения слау
            var _vector = Vector<double>.Build.Dense(_matrix.RowCount - 1);
            _vector = _matrix.Column(0) * (-1);
            _vector = _vector.SubVector(0, _vector.Count - 1);

            //преобразуем матрицу для слау
            _matrix = _matrix.RemoveColumn(0);
            _matrix = _matrix.RemoveRow(_matrix.RowCount - 1);

            //вычисляем решение
            var result = _matrix.Solve(_vector);

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

        public static Vector<double> CalcNormalizedPriorities(Vector<double> _vector)
        {
            double summ = 0;
            for (int i = 0; i < _vector.Count; i++)
            {
                summ += _vector[i];
            }

            for (int i = 0; i < _vector.Count; i++)
            {
                _vector[i] = _vector[i] / summ;
            }
            return (_vector);
        }

        public static Vector<double> CalcIdealizePriorities(Vector<double> _vector)
        {
            var normalizedPriorities = CalcNormalizedPriorities(_vector);
            double max = 0;
            int maxi = 0;
            for (int i = 0; i < normalizedPriorities.Count; i++)
            {
                if (normalizedPriorities[i] > max)
                {
                    max = normalizedPriorities[i];
                    maxi = i;
                }
            }
            normalizedPriorities[maxi] = 1;
            for (int i = 0; i < normalizedPriorities.Count; i++)
            {
                if (i!=maxi)
                    normalizedPriorities[i] = normalizedPriorities[i] / normalizedPriorities[maxi];
            }

            return (normalizedPriorities);
        }
    }
}