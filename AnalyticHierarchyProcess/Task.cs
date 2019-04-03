using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;
using System;
namespace Task
{
    public class Task
    {
        /// <summary>
        /// Имя цели
        /// </summary>
        public string name;
        /// <summary>
        /// Критерии, пара критерий - индекс
        /// </summary>
        private List<string> criterions=null;
        /// <summary>
        /// Матрица сравнений критериев
        /// </summary>
        private Matrix<double> matrix;
        /// <summary>
        /// Вектор приоритетов
        /// </summary>
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
        /// <param name="_criterions"> Критерии цели</param>
        public  Task(string _name,List<string> _criterions)
        {
            name = _name;
            criterions = new List<string>(_criterions);
            matrix = Matrix<double>.Build.Dense(criterions.Count, criterions.Count,1);
        }
        /// <summary>
        /// Добавить критерий. Матрица сравнений будет расширена. Вектор приоритетов и индек согласованности пересчитаны
        /// </summary>
        /// <param name="indexAddingCriterion">Индекс добавляемого критерия</param>
        /// <param name="newCriterion">Добавляемый критерий</param>
        public void AddCriterion(int indexAddingCriterion, string newCriterion)
        {
            if (indexAddingCriterion == -1)
                indexAddingCriterion = criterions.Count;

            criterions.Insert(indexAddingCriterion, newCriterion);
            //расширяем матрицу
            ExpandMatrix(indexAddingCriterion);
        }
        /// <summary>
        /// Добавить критерий в конец. Матрица сравнений будет расширена. Вектор приоритетов и индек согласованности пересчитаны
        /// </summary>
        /// <param name="newCriterion">Добавляемый критерий</param>
        public void AddCriterion(string newCriterion)
        {
            AddCriterion(-1, newCriterion);
        }
        /// <summary>
        /// Удалить критерий. Матрица сравнений будет сокращена. Вектор приоритетов и индек согласованности пересчитаны
        /// </summary>
        /// <param name="indexDeletingCriterion"></param>
        public void DeleteCriterion(int indexDeletingCriterion = -1)
        {
            if (indexDeletingCriterion == -1)
                indexDeletingCriterion = criterions.Count - 1;

            criterions.RemoveAt(indexDeletingCriterion);
            //сокращаем матрицу
            ContractMatrix(indexDeletingCriterion);
        }
        /// <summary>
        /// Расширить матрицу (добавиться и строка и столбец)
        /// </summary>
        /// <param name="indexAdding">Индекс добавляемого элемента</param>
        private void ExpandMatrix(int indexAdding)
        {
            //Длина добавляемой строки = RowCount т.к. если была матрица 3 на 3, нужно добавить строку длиной 3 и будет 4 на 3
            matrix = matrix.InsertRow(indexAdding, Vector<double>.Build.Dense(matrix.RowCount, 1));
            //Высота добавляемого столбца = RowCount т.к. если матрица стала  4 на 3, нужно добавить столбец высотой 4 и будет 4 на 4
            matrix = matrix.InsertColumn(indexAdding, Vector<double>.Build.Dense(matrix.RowCount, 1));
            UpdateAgreed();
        }
        /// <summary>
        /// Сократить матрицу (удалится строка и столбец)
        /// </summary>
        /// <param name="indexDeleting">Номер удаляемого элемента</param>
        private void ContractMatrix(int indexDeleting)
        {
            matrix.RemoveColumn(indexDeleting);
            matrix.RemoveRow(indexDeleting);
            UpdateAgreed();
        }
        /// <summary>
        /// Установить значение ячейки матрицы
        /// </summary>
        /// <param name="numberRow">Номер строки</param>
        /// <param name="numberColumn">Номер столбца</param>
        /// <param name="cellValue">Значение</param>
        public void SetCellMatrix(int numberRow, int numberColumn,double cellValue)
        {
            matrix[numberRow, numberColumn] = cellValue;
        }
        /// <summary>
        /// Установить значение ячейки матрицы
        /// </summary>
        /// <param name="numberRow">Критерий по строке</param>
        /// <param name="numberColumn">Критерий по столбцу</param>
        /// <param name="cellValue">Значение</param>
        public void SetCellMatrix(string criterionRow, string criterionColumn, double cellValue)
        {
            matrix[criterions.IndexOf(criterionRow), criterions.IndexOf(criterionColumn)] = cellValue;
        }
        /// <summary>
        /// Получить значение ячейки марицы
        /// </summary>
        /// <param name="numberRow">Номер строки</param>
        /// <param name="numberColumn">Номер столбца</param>
        /// <returns></returns>
        public double GetCellMatrix (string criterionRow, string criterionColumn)
        {
           return  matrix[criterions.IndexOf(criterionRow), criterions.IndexOf(criterionColumn)];
        }
        /// <summary>
        /// Получить значение ячейки марицы
        /// </summary>
        /// <param name="numberRow">Критерий по строке</param>
        /// <param name="numberColumn">Критерий по столбцу</param>
        /// <returns></returns>
        public double GetCellMatrix(int numberRow, int numberColumn)
        {
            return matrix[numberRow, numberColumn];
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
            double eTAe = (eT*Ae)[0, 0];            //как бы преобразовываем матрицу(1,1) в число (всегда получается число)
            Matrix<double> W = Ae / eTAe;
            vectorPriority = W.Column(0);           //как бы преобразовываем матрицу(N,1) в вектор (всегда получается вектор)
            double Lmax = (eT * matrix*W)[0, 0];    //как бы преобразовываем матрицу(1,1) в число (всегда получается число)
            I = (Lmax-n)/(n-1);
            Console.WriteLine(matrix);
            isAgreed = I < 0.1;
        }

    }
}
