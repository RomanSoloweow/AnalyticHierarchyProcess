using System;
using System.Collections.Generic;
using System.Data;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.Random;
using MathNet.Numerics.Distributions;
using System.Numerics;
namespace Task
{
    public class Task
    {
        /// <summary>
        /// Имя цели
        /// </summary>
        public string name;
        /// <summary>
        /// Список критериев цели
        /// </summary>
        public List<string> criterions = null;
        public Matrix<double> matrix;
        /// <summary>
        /// Вектор приоритетов
        /// </summary>
        private Vector<double> vectorPriority = null;
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
        /// <param name="_criterions"> Критерии цели</param>
        public  Task(string _name,List<string> _criterions)
        {
            name = _name;
            criterions = new List<string>(_criterions);
            matrix = Matrix<double>.Build.Dense(criterions.Count, criterions.Count,1);
        }
        /// <summary>
        ///  Добавление критерия в существующую цель. Согласованность будет пересчитана
        /// </summary>
        /// <param name="indexNewCriterion">Индекс добавлено критерия(по умолчанию добавит в конец)/param>
        public void AddCriterion(int indexAddingCriterion=-1)
        {
            if (indexAddingCriterion == -1)
                indexAddingCriterion = matrix.ColumnCount;

           //Длина добавляемой строки = RowCount т.к. если была матрица 3 на 3, нужно добавить строку длиной 3 и будет 4 на 3
            matrix = matrix.InsertRow(indexAddingCriterion, Vector<double>.Build.Dense(matrix.RowCount , 1));
            //Высота добавляемого столбца = RowCount т.к. если матрица стала  4 на 3, нужно добавить столбец высотой 4 и будет 4 на 4
            matrix = matrix.InsertColumn(indexAddingCriterion, Vector<double>.Build.Dense(matrix.RowCount, 1));
            UpdateAgreed();
        }
        /// <summary>
        /// Удаление критерия в существующую цель. Согласованность будет пересчитана
        /// </summary>
        /// <param name="indexNewCriterion">Индекс удаленного критерия(по умолчанию удаляет последний )</param>
        public void DeleteCriterion(int indexDeletingCriterion = -1)
        {
            if (indexDeletingCriterion == -1)
                indexDeletingCriterion = matrix.ColumnCount - 1;

            matrix.RemoveColumn(indexDeletingCriterion);
            matrix.RemoveRow(indexDeletingCriterion);
            GetIndexAgreed();
        }
        /// <summary>
       /// Элементы диагонали сделать равным 1. Не заданный элементы 1/значение
       /// </summary>
        private void FillMatrix()
        {
            for (int i = 0; i < matrix.ColumnCount; i++)
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    if (i == j) 
                    {
                        //элементы главной диагонали делаем =1
                        matrix[i,j] = 1;
                    }
                    else
                    {
                        /*чтобы сделать матрицу обратно - симметричной
                         * если текущее отношение не задано - берем обратное значение от симметричного элемента
                       */
                        if (matrix[i,j] == 1)
                            matrix[i,j] = 1 / matrix[j,i];
                    }

                }
        }
        /// <summary>
        /// Получить коэффициент согласованности
        /// </summary>
        /// <returns>коэффициент согласованности</returns>
        public double GetIndexAgreed()
        {
            //если индекс согласованности < 0 - запускаем перерасчет
            if (I < 0)
            UpdateAgreed();
            return I;
        }
        /// <summary>
        /// Получить вектор приоритетов
        /// </summary>
        /// <returns>Вектор приоритетов</returns>
        public Vector<double> GetVectorPriority()
        {
            //если вектор приоритетов пуст - запускаем перерасчет
            if (vectorPriority.Count<1)
                UpdateAgreed();

            return vectorPriority;
        }

        /// <summary>
        /// Обновить коэффициент согласованности и вектор приоритетов
        /// </summary>
        public void UpdateAgreed()
        {   
           //на всякий случай корректируем матрицу
            FillMatrix();

            //расчет по формуле из методички
            int n = criterions.Count;
            Matrix<double> e = Matrix<double>.Build.Dense(n, 1, 1);
            Matrix<double> eT = Matrix<double>.Build.Dense(1, n, 1);
            Matrix<double> Ae = matrix*e;
            double eTAe = (eT*Ae)[0, 0];
            Matrix<double> W = Ae / eTAe;
            vectorPriority = W.Column(0);
            double Lmax = (eT * matrix*W)[0, 0];
            I = (Lmax-n)/(n-1);
            isAgreed = I < 0.1;
        }

    }
}
