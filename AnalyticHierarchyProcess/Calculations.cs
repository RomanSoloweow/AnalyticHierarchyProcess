using System;
using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace Calculations
{
    public static class Calculations
    {

        public static Vector<double> Sole(Matrix<double> matrix)
        {

            if ((matrix == null) || (matrix.RowCount < 1) || (matrix.ColumnCount < 1))
                return null;
            Matrix<double> matrix_copy = Matrix<double>.Build.DenseOfMatrix(matrix);
            // максимальное собственное значение
            double MaxEigenVal = MaxEigenValue(matrix_copy);

            //из главной диагонали матрицы вычитаем это собственное значение
            matrix_copy.SetDiagonal((matrix_copy.Diagonal() - MaxEigenVal));

            int n = matrix_copy.RowCount;
            //создаем вектор, необходимый для решения слау (первый столбец умножанный на -1, без 1 элемента
            Vector<double> _vector = Vector<double>.Build.DenseOfVector((matrix_copy.Column(0) * (-1)).SubVector(0, n - 1));

            //преобразуем матрицу для слау
            matrix_copy = matrix_copy.RemoveColumn(0);
            matrix_copy = matrix_copy.RemoveRow(n - 1);

            //вычисляем решение 
            Vector<double> result = Vector<double>.Build.Dense(n, 1);
            matrix_copy.Solve(_vector).CopySubVectorTo(result, 0, 1, _vector.Count);

            return result;
        }
        public static Vector<double> CalcNormalizedPriorities(Vector<double> _vector)
        {
            if (_vector == null)
                return null;
            //вычисляем сумму вектора
            double summ = _vector.Sum();

            //делим каждый элемент вектора на сумму
            _vector = _vector.Divide(summ);

            return (_vector);
        }
        public static Vector<double> CalcIdealizePriorities(Vector<double> _vector)
        {
            if (_vector == null)
                return null;
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
            if ((matrix == null) || (matrix.RowCount < 1) || (matrix.ColumnCount < 1))
                return null;

                int n = matrix.ColumnCount;
                Vector<double> vectorPriority = Vector<double>.Build.Dense(n, 1);

                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        vectorPriority[i] *= matrix[i, j];

                for (int i = 0; i < n; i++)
                    vectorPriority[i] = Math.Pow(vectorPriority[i], (1.0 / (n)));

                double sum = vectorPriority.Sum();

                for (int i = 0; i < n; i++)
                    vectorPriority[i] /= sum;
                return vectorPriority;
            
        }
        public static double GetIndexAgreed(Matrix<double> matrix)
        {
            if ((matrix == null)||(matrix.RowCount<1)||(matrix.ColumnCount < 1))
                return 1;

            int n = matrix.ColumnCount;
            double I = (MaxEigenValue(matrix) - n)*1.0 / (n - 1);
            return I;
        }
        public static double MaxEigenValue(Matrix<double> matrix)
        {
            if (matrix == null)
                return -1;
            return matrix.Evd().EigenValues.Real().Maximum();
        }
        public static Vector<double> CalcGlobalDistributedPriority(Vector<double> priority_vector, List<Matrix<double>> matrixList)
        {
            if ((priority_vector == null) || (matrixList.Count < 1))
                return null;
            // Посчет нормированных приоритетов для каждого из критериев
            List<Vector<double>> vectorList = new List<Vector<double>>();
            for (int i = 0; i < matrixList.Count; i++)
            {
                if (matrixList[i] != null)
                    vectorList.Add(CalcNormalizedPriorities(Sole(matrixList[i])));
                else
                    return null;
            }

            // Подсчет глобальных нормализированных приоритетов
            int lengthOfVector = vectorList[0].Count;
            var result = Vector<double>.Build.Dense(lengthOfVector, 0);
            for (int i = 0; i < vectorList.Count; i++)
            {
                for (int j = 0; j < lengthOfVector; j++)
                    result[j] += vectorList[i][j]* priority_vector[i];
            }

            return (result);
        }
        public static Vector<double> CalcGlobalIdealizePriority(Vector<double> priority_vector, List<Matrix<double>> matrixList)
        {
            if ((priority_vector == null) || (matrixList.Count < 1))
                return null;
            // Посчет идеализированных приоритетов для каждого из критериев
            List<Vector<double>> vectorList = new List<Vector<double>>();
            for (int i = 0; i < matrixList.Count; i++)
            {
                if (matrixList[i] != null)
                    vectorList.Add(CalcIdealizePriorities(Sole(matrixList[i])));
                else
                    return null;
            }

            // Подсчет глобальных идеализированных приоритетов
            int lengthOfVector = vectorList[0].Count;
            var result = Vector<double>.Build.Dense(lengthOfVector, 0);
            for (int i = 0; i < vectorList.Count; i++)
            {
                for (int j = 0; j < lengthOfVector; j++)
                    result[j] += vectorList[i][j] * priority_vector[i];
            }
            double summ =result.Sum();
            result = result.Divide(summ);
            return (result);
        }
    }
}