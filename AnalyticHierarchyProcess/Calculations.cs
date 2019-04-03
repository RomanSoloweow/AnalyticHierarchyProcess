using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;

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
            //вычисляем сумму вектора
            double summ = 0;
            for (int i = 0; i < _vector.Count; i++)
            {
                summ += _vector[i];
            }

            //делим каждый элемент вектора на сумму
            for (int i = 0; i < _vector.Count; i++)
            {
                _vector[i] = _vector[i] / summ;
            }
            return (_vector);
        }

        public static Vector<double> CalcIdealizePriorities(Vector<double> _vector)
        {
            // ищем максимальный элемент вектора и его индекс
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
            // максимальный элемент вектора объявляем единицей
            normalizedPriorities[maxi] = 1;
            // вычисляем вес элемента относительно максимального
            for (int i = 0; i < normalizedPriorities.Count; i++)
            {
                if (i!=maxi)
                    normalizedPriorities[i] = normalizedPriorities[i] / normalizedPriorities[maxi];
            }

            return (normalizedPriorities);
        }

        public static double CalcGlobalDistributedPriority(Vector<double> priority_vector, List<Matrix<double>> matrixList)
        {
            // Посчет нормированных приоритетов для каждого из критериев
            List<Vector<double>> vectorList = new List<Vector<double>>();
            for (int i = 0; i < matrixList.Count; i++)
            {
                vectorList.Add(CalcNormalizedPriorities(Sole(matrixList[i])));
            }

            // Подсчет глобальных нормализированных приоритетов
            int lengthOfVector = vectorList[0].Count;
            var result = Vector<double>.Build.Dense(lengthOfVector, 0);
            for (int i = 0; i < vectorList.Count; i++)
            {
                for (int j = 0; j < lengthOfVector; j++)
                    result[j] += vectorList[i][j];
            }

            return (result.Maximum());
        }

        public static double CalcGlobalIdealizePriority(Vector<double> priority_vector, List<Matrix<double>> matrixList)
        {
            // Посчет идеализированных приоритетов для каждого из критериев
            List<Vector<double>> vectorList = new List<Vector<double>>();
            for (int i = 0; i < matrixList.Count; i++)
            {
                vectorList.Add(CalcIdealizePriorities(Sole(matrixList[i])));
            }

            // Подсчет глобальных идеализированных приоритетов
            int lengthOfVector = vectorList[0].Count;
            var result = Vector<double>.Build.Dense(lengthOfVector, 0);
            for (int i = 0; i < vectorList.Count; i++)
            {
                for (int j = 0; j < lengthOfVector; j++)
                    result[j] += vectorList[i][j];
            }
            double summ = 0;
            for (int i = 0; i < result.Count; i++)
            {
                summ += result[i];
            }
            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i]/summ;
            }
            return (result.Maximum());
        }
    }
}