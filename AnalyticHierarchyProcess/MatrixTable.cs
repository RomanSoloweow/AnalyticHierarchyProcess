using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
namespace MatrixTable
{
    public class MatrixTable
    {
        public MatrixTable(string _name,List<string> _fields)
        {
            name = _name;
            fields = new List<string>(_fields);
            matrix = Matrix<double>.Build.Dense(fields.Count, fields.Count, 1);          
        }
        /// <summary>
        /// Критерии
        /// </summary>
        public List<string> fields = null;
        string name;
        /// <summary>
        /// Матрица сравнений критериев
        /// </summary>
        public Matrix<double> matrix;     
        /// Добавить критерий. Матрица сравнений будет расширена.
        /// </summary>
        /// <param name="indexAddingField">Индекс добавляемого критерия</param>
        /// <param name="newField">Добавляемый критерий</param>
        public void AddField(int indexAddingField, string newField)
        {
            if (indexAddingField == -1)
                indexAddingField = fields.Count;

            fields.Insert(indexAddingField, newField);
            //расширяем матрицу
            ExpandMatrix(indexAddingField);
        }
        /// <summary>
        /// Добавить критерий в конец.
        /// </summary>
        /// <param name="newField">Добавляемый критерий</param>
        public void AddField(string newField)
        {
            AddField(-1, newField);
        }
        /// <summary>
        /// Удалить критерий. Матрица сравнений будет сокращена
        /// </summary>
        /// <param name="indexDeletingField"></param>
        public void DeleteField(int indexDeletingField = -1)
        {
            if (indexDeletingField == -1)
                indexDeletingField = fields.Count - 1;

            fields.RemoveAt(indexDeletingField);
            //сокращаем матрицу
            ContractMatrix(indexDeletingField);
        }
        /// <summary>
        /// Расширить матрицу (добавиться и строка и столбец)
        /// </summary>
        /// <param name="indexAdding">Индекс добавляемого элемента</param>
        public void ExpandMatrix(int indexAdding)
        {
            //Длина добавляемой строки = RowCount т.к. если была матрица 3 на 3, нужно добавить строку длиной 3 и будет 4 на 3
            matrix = matrix.InsertRow(indexAdding, Vector<double>.Build.Dense(matrix.RowCount, 1));
            //Высота добавляемого столбца = RowCount т.к. если матрица стала  4 на 3, нужно добавить столбец высотой 4 и будет 4 на 4
            matrix = matrix.InsertColumn(indexAdding, Vector<double>.Build.Dense(matrix.RowCount, 1));
        }
        /// <summary>
        /// Сократить матрицу (удалится строка и столбец)
        /// </summary>
        /// <param name="indexDeleting">Номер удаляемого элемента</param>
        public void ContractMatrix(int indexDeleting)
        {
            matrix.RemoveColumn(indexDeleting);
            matrix.RemoveRow(indexDeleting);
        }
        /// <summary>
        /// Установить значение ячейки матрицы
        /// </summary>
        /// <param name="numberRow">Номер строки</param>
        /// <param name="numberColumn">Номер столбца</param>
        /// <param name="cellValue">Значение</param>
        public void SetCellMatrix(int numberRow, int numberColumn, double cellValue)
        {
            matrix[numberRow, numberColumn] = cellValue;
        }
        /// <summary>
        /// Установить значение ячейки матрицы
        /// </summary>
        /// <param name="numberRow">Критерий по строке</param>
        /// <param name="numberColumn">Критерий по столбцу</param>
        /// <param name="cellValue">Значение</param>
        public void SetCellMatrix(string FieldRow, string FieldColumn, double cellValue)
        {
            matrix[fields.IndexOf(FieldRow), fields.IndexOf(FieldColumn)] = cellValue;
        }
        /// <summary>
        /// Получить значение ячейки марицы
        /// </summary>
        /// <param name="numberRow">Номер строки</param>
        /// <param name="numberColumn">Номер столбца</param>
        /// <returns></returns>
        public double GetCellMatrix(string FieldRow, string FieldColumn)
        {
            return matrix[fields.IndexOf(FieldRow), fields.IndexOf(FieldColumn)];
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
        public void FillMatrix()
        {
            for (int i = 0; i < matrix.ColumnCount; i++)
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    if (i == j)
                    {
                        //элементы главной диагонали делаем =1
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        /*чтобы сделать матрицу обратно - симметричной
                         * если текущее отношение не задано - берем обратное значение от симметричного элемента
                       */
                        if (matrix[i, j] == 1)
                            matrix[i, j] = 1 / matrix[j, i];
                    }

                }
        }
        
    }
}
