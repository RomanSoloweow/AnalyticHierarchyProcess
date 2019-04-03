using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using System;
namespace Task
{
    public class Task: MatrixTable.MatrixTable
    {
        /// <summary>
        /// Имя цели
        /// </summary>
        public string name;
        /// <summary>
        /// Вектор приоритетов
        /// </summary>
        /// <summary>
        private Vector<double> vectorPriority;
        /// <summary>
        /// Коэфициент согласованности
        /// </summary>
        private double I = -1;
        /// <summary>
        /// флаг согласованности
        /// </summary>
        private bool isAgreed = false;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_name"> Имя цели</param>
        /// <param name="_fields"> Критерии цели</param>
        public  Task(string _name,List<string> _fields):base(_name,_fields)
        {
            name = _name;
        }
        public double GetIndexAgreed()
        {
            //если индекс согласованности < 0 - запускаем перерасчет
            //if (I < 0)
            //UpdateAgreed();
            return I;
        }

        /// <summary>
        /// Обновить коэффициент согласованности и вектор приоритетов
        /// </summary>
        public Vector<double> GetVectorPriority(Matrix<double> matrix)
        {
            int n = matrix.ColumnCount;
            Vector<double> vectorPriority = Vector<double>.Build.Dense(n, 1);
           
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    vectorPriority[i] *= matrix[i, j];
         
            for (int i = 0; i < n; i++)
                    vectorPriority[i] = Math.Pow(vectorPriority[i],(1.0/(n-1)));
         
            double sum = vectorPriority.Sum();

            for (int i = 0; i < n; i++)
                vectorPriority[i]/= sum;
            return vectorPriority;
        }
        public double GetIndexAgreed(Matrix<double> matrix)
        {
            int n = matrix.ColumnCount;
            double I = (matrix.Evd().EigenValues.Real().Maximum() - n) / (n - 1);
            return I;
        }
        public double MaxEigenValue(Matrix<double> matrix)
        {
            return matrix.Evd().EigenValues.Real().Maximum();
        }
     }
}
