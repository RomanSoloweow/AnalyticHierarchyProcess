using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using NamespaceConst;
namespace NamespaceWorkWithGridView
{

    public class WorkWithGridView
    {  
        private static DataGridViewComboBoxCell GetDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
            Const.Scale().ForEach(item => dataGridViewComboBoxCell.Items.Add(item));
            return dataGridViewComboBoxCell;
        }
        public static bool Contract(DataGridView dataGridView,int indexExpand)
        {
            if (HaveErorInputData(7, dataGridView, indexColumn: indexExpand, indexRow: indexExpand))
                return false;

            dataGridView.Columns.RemoveAt(indexExpand);
            dataGridView.Rows.RemoveAt(indexExpand);
            return true;
        }
        public static bool Expand(DataGridView dataGridView, string header)
        {
            if (HaveErorInputData(9, dataGridView,  inputValue: header))
                return false;

            DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
            dataGridViewColumn.HeaderText = header;
            dataGridViewColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewColumn.CellTemplate = new DataGridViewComboBoxCell();
            dataGridView.Columns.Add(dataGridViewColumn);
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.HeaderCell.Value = header;
            dataGridView.Rows.Add(dataGridViewRow);

            int IndexNewRow = dataGridView.RowCount- 1;
            int IndexNewColumn = dataGridView.ColumnCount - 1;
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                dataGridView.Rows[i].Cells[IndexNewColumn] = GetDataGridViewComboBoxCell();
                dataGridView.Rows[i].Cells[IndexNewColumn].Value = Const.defaultScaleValue;
                if (IndexNewColumn == i)
                    dataGridView.Rows[i].Cells[IndexNewColumn].ReadOnly = true;
            }
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Rows[IndexNewRow].Cells[i] = GetDataGridViewComboBoxCell();
                dataGridView.Rows[IndexNewRow].Cells[i].Value = Const.defaultScaleValue;
                if (IndexNewRow == i)
                    dataGridView.Rows[IndexNewRow].Cells[i].ReadOnly = true;
            }
            return true;
        }
        private static bool HaveErorInputData(int codeError, DataGridView dataGridView=null, int indexRow=-1, int indexColumn=-1, string inputValue=null)
        {
            string textError = string.Empty;
            if (((codeError & 1) > 0) && (dataGridView == null))
            {
                textError = "1";
            }
            else if (((codeError & 2) > 0) && ((dataGridView.Rows.Count < indexRow) || (indexRow < 0)))
            {
                textError = "2";
            }
            else if (((codeError & 4) > 0) && ((dataGridView.Columns.Count < indexColumn) || (indexColumn < 0)))
            {
                textError = "4";
            }
            else if (((codeError & 8) > 0) && (string.IsNullOrEmpty(inputValue)))
            {
                textError = "8";
            }
            else if (((codeError & 16) > 0) && ((dataGridView.SelectedCells.Count < 1)|| (dataGridView.SelectedCells[0].Value==null)))
            {
                textError = "16";
            }
      

            if (!string.IsNullOrEmpty(textError))
                return true;


            return false;
    }            
        public static bool AddRow(DataGridView dataGridView, string addingValue)
        {
            if(HaveErorInputData(codeError:9,dataGridView: dataGridView,inputValue: addingValue))
                return false;

               dataGridView.Rows.Add(addingValue);
            return true;
        }
        public static bool DeleteRow(DataGridView dataGridView, int indexDelitingRow)
        {
            if (HaveErorInputData(codeError: 3, dataGridView: dataGridView, indexRow: indexDelitingRow))
                return false;

            dataGridView.Rows.RemoveAt(indexDelitingRow);
            return true;
        }
        public static bool UpdateRow(DataGridView dataGridView, int indexRow, string newValue)
        {
            if (HaveErorInputData(codeError: 11,dataGridView: dataGridView,indexRow: indexRow,inputValue: newValue))
                return false;

            dataGridView.Rows[indexRow].Cells[0].Value = newValue;
            return true;
        }
        public static string GetRow(DataGridView dataGridView, int indexRow)
        {
            if (HaveErorInputData(codeError: 3, dataGridView: dataGridView, indexRow: indexRow))
                return null;

            return dataGridView.Rows[indexRow].Cells[0].Value.ToString();
        }
        public static bool UpdateCellValue(DataGridView dataGridView, int indexRow, int indexColumn, string cellValue)
        {
            if (HaveErorInputData(codeError: 15, dataGridView: dataGridView, indexRow: indexRow,indexColumn: indexColumn,inputValue: cellValue))
                return false;

            dataGridView.Rows[indexRow].Cells[indexColumn].Value = cellValue;
            return true;
        }
        public static int GetIndexSelectedRow(DataGridView dataGridView)
        {
            if (HaveErorInputData(codeError: 17, dataGridView: dataGridView))
                return -1;

            return dataGridView.SelectedCells[0].RowIndex;
        }
        public static string GetValue(DataGridView dataGridView,  int indexRow,  int indexColumn)
        {
            if (HaveErorInputData(codeError: 7, dataGridView: dataGridView, indexRow: indexRow, indexColumn: indexColumn))
                return null;

            string valueSelectedCell = dataGridView.Rows[indexRow].Cells[indexColumn].Value.ToString();
            return valueSelectedCell;
        }
        public static string ValueSelectedCell(DataGridView dataGridView)
        {
            if (HaveErorInputData(codeError: 17, dataGridView: dataGridView))
                return null;

            string valueSelectedCell = dataGridView.SelectedCells[0].Value.ToString();

            return valueSelectedCell;
        }      
        public static bool OutputTable(DataGridView dataGridView, DataTable table, bool clear = true)
        {

            if (HaveErorInputData(codeError:1,dataGridView: dataGridView))
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
                        dataGridView.Rows[i].Cells[j].Value = table.Rows[i].ItemArray[j].ToString();
                        if (i == j)
                            dataGridView.Rows[i].Cells[j].ReadOnly = true;
                      };

                  return true;
         }
        public static bool OutputColumn(DataGridView dataGridView, List<string> column,string nameColumn="", bool clear = true)
        {

            if (HaveErorInputData(codeError: 1,dataGridView: dataGridView))
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