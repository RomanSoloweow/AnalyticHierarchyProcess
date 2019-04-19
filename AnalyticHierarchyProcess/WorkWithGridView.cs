using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace NamespaceWorkWithGridView
{

    public class WorkWithGridView
    {
        private static List<string> itemsComboBox = new List<string>()
        {
            {"Обратное симметричному"},
            {"Одинаковая значимость"},
            {"Почти слабая значимость"},
            {"Cлабая значимость"},
            {"Почти существенная значимость"},
            {"Существенная значимость"},
            {"Почти очевидная значимость"},
            {"Очевидная значимость"},
            {"Почти абсолютная значимость"},
            {"Абсолютная значимость"}
        };
        public static DataGridViewComboBoxCell GetDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
            itemsComboBox.ForEach(item => dataGridViewComboBoxCell.Items.Add(item));
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
        public static bool UpdateRow(DataGridView dataGridView, int indexRow, string newValue)
        {
            if ((dataGridView.Rows.Count < indexRow) || (indexRow < 0))
                return false;

            dataGridView.Rows[indexRow].Cells[0].Value = newValue;
            return true;
        }
        public static bool SetCell(DataGridView dataGridView, int indexRow, int indexColumn, string cellValue)
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
        public static string ValueSelectedCell(DataGridView dataGridView, ref int indexRow, ref int indexColumn)
        {
            if (dataGridView.SelectedCells.Count < 1)
                return null;
            indexRow = dataGridView.SelectedCells[0].RowIndex;
            indexColumn = dataGridView.SelectedCells[0].ColumnIndex;
            string valueSelectedCell = dataGridView.SelectedCells[0].Value.ToString();

            return valueSelectedCell;
        }
        public static string ValueSelectedCell(DataGridView dataGridView)
        {
            if (dataGridView.SelectedCells.Count < 1)
                return null;

            string valueSelectedCell = dataGridView.SelectedCells[0].Value.ToString();

            return valueSelectedCell;
        }
        
        public static bool OutputTable(DataGridView dataGridView, DataTable table, bool clear = true)
        {

            if ((dataGridView == null)|| (table == null) || (table.Columns.Count < 1) || (table.Rows.Count < 1))
                      return false;

                if (clear == true)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                }

                foreach (DataColumn column in  table.Columns)
                {
                    DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                    dataGridViewColumn.HeaderText = column.Caption;
                    dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridViewColumn.CellTemplate = new DataGridViewComboBoxCell();
                    dataGridView.Columns.Add(dataGridViewColumn);
                    
                    DataGridViewRow dataGridViewRow = new DataGridViewRow();
                    dataGridViewRow.HeaderCell.Value = column.Caption;
                    dataGridView.Rows.Add(dataGridViewRow);
                }

                  dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                  dataGridView.TopLeftHeaderCell.Value = table.TableName;

                  for (int i = 0; i < table.Columns.Count; i++)
                      for (int j = 0; j < table.Columns.Count; j++)
                      {
                        dataGridView.Rows[i].Cells[j] = GetDataGridViewComboBoxCell();
                    dataGridView.Rows[i].Cells[j].Value = itemsComboBox[1]; //для теста
                        //dataGridView.Rows[i].Cells[j].Value = table.Rows[i].ItemArray[j].ToString();              
                      };

                  return true;
         }
        public static bool OutputColumn(DataGridView dataGridView, List<string> column,string nameColumn="", bool clear = true)
        {

            if ((dataGridView == null) || (column == null) || (column.Count < 1))
                return false;

            if (clear == true)
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }

            DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
            dataGridViewColumn.HeaderText = nameColumn;
            dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewColumn.CellTemplate = new DataGridViewTextBoxCell();
            dataGridView.Columns.Add(dataGridViewColumn);


            for (int i=0;i< column.Count;i++)
            {
                if (i == dataGridView.Rows.Count)
                    dataGridView.Rows.Add();

                dataGridView.Rows[i].Cells[dataGridView.ColumnCount - 1].Value = column[i];
            }

            return true;
        }

    }
}