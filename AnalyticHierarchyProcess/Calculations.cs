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
    public class Calculations
    {
        public Calculations(Task.Task task) {
            task.GetIndexAgreed();

        }

        public int CalcCR() {
            return 0;
        }

        public void Sole(Matrix<double> _matrix) {

            /*
                на вход подается матрица
                вычисляем ее максимальное собственное значение
                из главной диагонали матрицы вычитаем это собственное значение
                создаем вектор, необходимый для решения слау
                изменяем матрицу для решения слау
                решаем слау 
            */

            // максимальное собственное значение
            double MaxEigenVal = MaxEigenValue(_matrix);

            //из главной диагонали матрицы вычитаем это собственное значение
            for (int i=0; i < _matrix.RowCount; i++) {
                for (int j = 0; j < _matrix.ColumnCount; j++)
                {
                    if (i == j)
                        _matrix[i, j] = MaxEigenVal;
                }
            }

            //создаем вектор, необходимый для решения слау
            var _vector = Vector<double>.Build.Dense(_matrix.RowCount-1);
            _vector = _matrix.Column(0)*(-1);

            _matrix = _matrix.RemoveColumn(0);
            _matrix = _matrix.RemoveRow(0);


            double[,] data = new double[,]
        {
            {  2,  0,  3},
            { 10, -3, -6},
            { -1,  0, -2}
        };

            Matrix<double> matrix = DenseMatrix.OfArray(data);
            Console.WriteLine(matrix);

            var eigen = matrix.Evd();
            var values = eigen.EigenValues.Enumerate().GetEnumerator();
            var vectors = eigen.EigenVectors.EnumerateColumns().GetEnumerator();

            while (vectors.MoveNext() && values.MoveNext())
            {
                Console.WriteLine("Собственный вектор при {0}:\n{1}",
                    values.Current, vectors.Current);
            }
        }
    }
}
