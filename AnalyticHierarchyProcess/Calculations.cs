using System;
using System.Collections.Generic;
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
            matrix = matrix.RemoveRow(n - 1);

            //вычисляем решение 
            Vector<double> result = Vector<double>.Build.Dense(n, 1);
            matrix.Solve(_vector).CopySubVectorTo(result, 0, 1, _vector.Count);

            return result;
        }
        public static Vector<double> CalcNormalizedPriorities(Vector<double> _vector)
        {
            //вычисляем сумму вектора
            double summ = _vector.Sum();

            //делим каждый элемент вектора на сумму
            _vector.Divide(summ);

            return (_vector);
        }
        public static Vector<double> CalcIdealizePriorities(Vector<double> _vector)
        {
            // ищем максимальный элемент вектора и его индекс
            var normalizedPriorities = CalcNormalizedPriorities(_vector);
            double max = _vector.Maximum();
            int maxi = _vector.MaximumIndex();

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
            double summ =result.Sum();
            result.Divide(summ);
            return (result.Maximum());
        }
    }
}