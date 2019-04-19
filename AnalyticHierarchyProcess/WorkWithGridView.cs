using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NamespaceMatrixTable;
using MathNet.Numerics.LinearAlgebra;

namespace NamespaceWorkWithGridView
{
  
   public  class WorkWithGridView
    {
        private static Dictionary<int, string> scalesInt = new Dictionary<int, string>()
        {
            {-1,"Обратное симметричному"},
            {1, "Одинаковая значимость"},
            {2, "Почти слабая значимость"},
            {3, "Cлабая значимость"},
            {4, "Почти существенная значимость"},
            {5, "Существенная значимость"},
            {6, "Почти очевидная значимость"},
            {7, "Очевидная значимость"},
            {8, "Почти абсолютная значимость"},
            {9, "Абсолютная значимость"}
        };
        private static Dictionary<string, int> scalesString = new Dictionary<string, int>()
        {
            {"Обратное симметричному",-1},
            {"Одинаковая значимость",1},
            {"Почти слабая значимость",2},
            {"Cлабая значимость",3},
            {"Почти существенная значимость",4},
            {"Существенная значимость",5},
            {"Почти очевидная значимость",6},
            {"Очевидная значимость",7},
            {"Почти абсолютная значимость",8},
            {"Абсолютная значимость",9}
        };
        public static DataGridViewComboBoxCell GetDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
            foreach (string value in scalesInt.Values)
            {
                dataGridViewComboBoxCell.Items.Add(value);
            }
            return dataGridViewComboBoxCell;
        }
        public static bool AddRow(DataGridView dataGridView, string addingValue)
        {
                dataGridView.Rows.Add(addingValue);
            return true;
        }
        public static bool DeleteRow(DataGridView dataGridView, int indexDelitingRow)
        {
            if ((dataGridView.Rows.Count < indexDelitingRow) || (indexDelitingRow < 0))
                return false;

            dataGridView.Rows.RemoveAt(indexDelitingRow);
            return true;
        }
        public static bool UpdateRow(DataGridView dataGridView, int indexRow,string newValue)
        {
            if ((dataGridView.Rows.Count < indexRow) || (indexRow < 0))
                return false;

            dataGridView.Rows[indexRow].Cells[0].Value = newValue;
            return true;
        }
        public static bool SetCell(DataGridView dataGridView,int indexRow, int indexColumn, double cellValue)
        {
            if ((dataGridView.Rows.Count < indexRow) || (indexRow < 0) || (dataGridView.Columns.Count < indexColumn) || (indexColumn < 0))
                return false;

            dataGridView[indexRow, indexColumn].Value = cellValue;
            return true;
        }
        public static int GetIndexSelectedRow(DataGridView dataGridView)
        {
            if (dataGridView.SelectedCells.Count < 1)
                return -1;
            
            return dataGridView.SelectedCells[0].RowIndex;
        }

        
        public static string ValueSelectedCell(DataGridView dataGridView)
        {
            if (dataGridView.SelectedCells.Count < 1)
                return null;

            string valueSelectedCell;

            DataGridViewCell selectedCell = dataGridView.SelectedCells[0];

            if (selectedCell.Value != null)
                valueSelectedCell = selectedCell.Value.ToString();
            else
                valueSelectedCell = selectedCell.RowIndex.ToString() + "." + selectedCell.ColumnIndex.ToString();
            selectedCell.Value = valueSelectedCell;

            return valueSelectedCell;
        }
        public static bool UpdateValueSymmetricCellDataGridView(DataGridView dataGridView, ref int indexRow, ref int indexColumn, ref double cellValue)
        {
            //если ячейка выбрана
            if (dataGridView.SelectedCells.Count == 1)
            {
                DataGridViewCell selectedCell = dataGridView.SelectedCells[0];
                //если  элемент не диагональный
                if (selectedCell.RowIndex != selectedCell.ColumnIndex)
                {
                    dataGridView.Rows[selectedCell.ColumnIndex].Cells[selectedCell.RowIndex].Value = scalesInt[-1];
                    return true;
                }
            }
            return false;
        }
        public static bool UpdateValueSymmetricCellDataGridView(DataGridView dataGridView)
        {
            //если ячейка выбрана
            if (dataGridView.SelectedCells.Count == 1)
            {
               DataGridViewCell selectedCell = dataGridView.SelectedCells[0];
                //если  элемент не диагональный
                if (selectedCell.RowIndex != selectedCell.ColumnIndex)
                {
                    dataGridView.Rows[selectedCell.ColumnIndex].Cells[selectedCell.RowIndex].Value = scalesInt[-1];
                    return true;
                }
            }
            return false;
        }

        public static bool OutputMatrix(DataGridView dataGridView, MatrixTable table, bool clear = true)
        {
            if (clear == true)
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }

            if ((table == null) || (table.fields.Count < 0))
                return false;

            table.fields.ForEach(x => dataGridView.Columns.Add(x, x));
            for (int i = 0; i < table.CountFiields(); i++)
            {
                dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView.Rows.Add();
                dataGridView.Rows[i].HeaderCell.Value = table.fields[i];
            }
            dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView.TopLeftHeaderCell.Value = table.name;

            for (int i = 0; i < dataGridView.RowCount; i++)
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    dataGridView.Rows[i].Cells[j].ValueType = typeof(DataGridViewComboBoxCell);
                    dataGridView.Rows[i].Cells[j] = GetDataGridViewComboBoxCell();

                    if (table.GetCellMatrix(i, j) % 1 == 0)
                        dataGridView.Rows[i].Cells[j].Value = scalesInt[Convert.ToInt32(table.GetCellMatrix(i, j))].ToString();
                    else
                        dataGridView.Rows[i].Cells[j].Value = scalesInt[-1].ToString();

                    if (i == j)
                    {
                        dataGridView.Rows[i].Cells[j].Value = scalesInt[1].ToString();
                        dataGridView.Rows[i].Cells[j].ReadOnly = true;
                    }
                };

            return true;
        }
        public static bool OutputVector(DataGridView dataGridView, Vector<double> vector, string newColumnName, bool clear = true)
        {
            if ((vector == null) || (newColumnName == null) || (newColumnName == string.Empty))
                return false;

                if (clear == true)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                }

                dataGridView.Columns.Add(newColumnName, newColumnName);
                dataGridView.Columns[dataGridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                int ColumnCount = dataGridView.ColumnCount;
                for (int i = 0; i < vector.Count; i++)
                {
                    dataGridView.Rows[i].Cells[ColumnCount - 1].ValueType = typeof(double);
                    dataGridView.Rows[i].Cells[ColumnCount - 1].Value = vector[i].ToString();
                    dataGridView.Rows[i].Cells[ColumnCount - 1].ReadOnly = true;
                }
            return true;
        }
        public static bool UpdateMatrix(MatrixTable table, DataGridView dataGridView)
        {
            double valueCells = 0;
            for (int i = 0; i < dataGridView.RowCount; i++)
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    valueCells = scalesString[dataGridView.Rows[i].Cells[j].Value.ToString()];
                    if (valueCells == -1)
                        valueCells = 1.0 / (scalesString[dataGridView.Rows[j].Cells[i].Value.ToString()]);

                    table.matrix[i, j] = valueCells;
                }

            return true;
        }
    }
}