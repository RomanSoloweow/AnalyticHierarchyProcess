using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
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
                UpdateAgreed();
        }
        public new void AddField(string newField)
        {
            base.AddField(newField);
                UpdateAgreed();
        }
        public new void DeleteField(int indexDeletingField = -1)
        {
            base.DeleteField(indexDeletingField);
            UpdateAgreed();
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
            if (fields.Count > 3)
            {
                //на всякий случай корректируем матрицу
                FillMatrix();
                //расчет по формуле из методички
                int n = fields.Count;
                Matrix<double> e = Matrix<double>.Build.Dense(n, 1, 1);
                Matrix<double> eT = Matrix<double>.Build.Dense(1, n, 1);
                Matrix<double> Ae = matrix * e;
                double eTAe = (eT * Ae)[0, 0];            //как бы преобразовываем матрицу(1,1) в число (всегда получается число)
                Matrix<double> W = Ae / eTAe;
                vectorPriority = W.Column(0);           //как бы преобразовываем матрицу(N,1) в вектор (всегда получается вектор)
                double Lmax = (eT * matrix * W)[0, 0];    //как бы преобразовываем матрицу(1,1) в число (всегда получается число)
                I = (Lmax - n) / (n - 1);
                isAgreed = I < 0.1;
            }
            else
            {
                I = -1;
                isAgreed = false;
                vectorPriority = null;
            }
        }

    }
}
