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
        public  Task(string _name,List<string> _fields):base(_fields)
        {
            name = _name;
        }
        public new void AddField(int indexAddingField, string newField)
        {
            base.AddField(indexAddingField, newField);
                //UpdateAgreed();
        }
        public new void AddField(string newField)
        {
            base.AddField(newField);
                //UpdateAgreed();
        }
        public new void DeleteField(int indexDeletingField = -1)
        {
            base.DeleteField(indexDeletingField);
            //UpdateAgreed();
        }
        /// <summary>
        /// Получить коэффициент согласованности
        /// </summary>
        /// <returns>коэффициент согласованности</returns>
        public double GetIndexAgreed()
        {
            //если индекс согласованности < 0 - запускаем перерасчет
            //if (I < 0)
            //UpdateAgreed();
            return I;
        }
        /// <summary>
        /// Получить вектор приоритетов
        /// </summary>
        /// <returns>Вектор приоритетов</returns>
        public Vector<double> GetVectorPriority()
        {
            //если вектор приоритетов пуст - запускаем перерасчет
           /// if (vectorPriority.Count<1)
              //  UpdateAgreed();

            return vectorPriority;
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
    }
}
