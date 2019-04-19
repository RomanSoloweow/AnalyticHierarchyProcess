using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using NamespaceWorkWithGridView;
using NamespaceIView;
using NamespaceIPresenter;
using NamespaceInputBox;

namespace AnalyticHierarchyProcess
{
    public partial class FormView : Form, IView
    {
       private IPresenter _presenter;
       public FormView()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
           
            InitializeComponent();
            dataGridViewOptions.Rows.Add("ter");
        }

       public bool SetIPresenter(IPresenter iPresenter)
        {
            _presenter = iPresenter;
            return true;
        }
       public bool OuputTaskMatrix(DataTable table)
        {
           WorkWithGridView.OutputTable(dataGridViewTaskCompare, table);
            return true;
        }
       public bool OuputMatrixCompare(DataTable table)
        {
           WorkWithGridView.OutputTable(dataGridViewTaskCompare, table,true);
            return true;
        }
       public bool OuputVectorCalculations(List<string> column, string nameColumn)
        {
            WorkWithGridView.OutputColumn(dataGridViewCalculation, column, nameColumn,true);
            return true;
        }
       public bool OuputCalculationsResult(string idealizedResult, string normalizedResult)
        {
            labelIdealResult.Text = idealizedResult;
            labelNormResult.Text = normalizedResult;
            return true;
        }
      
       
       public bool ShowError(string errorText)
        {
            MessageBox.Show(errorText, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return true;
        }
       public bool AskQuestion(string QuestionText)
        {
            if (MessageBox.Show(QuestionText, "", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return false;

            return true;
        }

       public  string GetStringValue(string title, string label_text)
        {
            string stringValue = String.Empty;

            if (InputBoxs.InputBox(title, label_text, ref stringValue) != DialogResult.OK)
                return null;

            return stringValue;
        }
       public bool AddCriterion(string nameNewCriterion)
        {
            WorkWithGridView.AddRow(dataGridViewCriterions, nameNewCriterion);
            return true;
        }
       public bool UpdateCriterion(int indexRow, string criterionNewName)
        {
            WorkWithGridView.UpdateRow(dataGridViewCriterions, indexRow, criterionNewName);
            return true;
        }
       public bool DeleteCriterion(int indexDelitingCriterion)
        {
            WorkWithGridView.DeleteRow(dataGridViewCriterions, indexDelitingCriterion);
            return true;
        }
       public bool AddOption(string newOptionName)
        {
            WorkWithGridView.AddRow(dataGridViewOptions, newOptionName);
            return true;
        }
       public bool UpdateOption(int indexRow, string optionNewName)
        {
            WorkWithGridView.UpdateRow(dataGridViewOptions, indexRow, optionNewName);
            return true;
        }
       public bool DeleteOption(int indeDelitingOption)
        {
            WorkWithGridView.DeleteRow(dataGridViewOptions, indeDelitingOption);
            return true;
        }
       public bool SetValueCellMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            WorkWithGridView.SetCell(dataGridViewCompare, indexRow, indexColumn, cellValue);
            return true;
        }
       public bool SetValueCellTaskMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            WorkWithGridView.SetCell(dataGridViewTaskCompare, indexRow, indexColumn, cellValue);
            return true;
        }
       private void comboBoxCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedMatrixCompareName = comboBoxCompare.Text;
            _presenter.SelectMatrixCompare(SelectedMatrixCompareName);
        }




        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if((selectedtabIndex == 1)&&(selectedMatrix!=string.Empty))
            {
                MatrixDataGridView.UpdateMatrix(matrixsCompare[selectedMatrix], dataGridViewCompare);
            }
            if (selectedtabIndex == 2)
            {
                MatrixDataGridView.UpdateMatrix(task,dataGridViewTaskCompare);
            }
            

            if (tab.SelectedTab == tabOptions)
            {            
                    UpdateOptions();
            }
            if (tab.SelectedTab==tabCriterions)
            {
                dataGridViewCriterions.Rows.Clear();
                if(task!=null)
                task.fields.ForEach(x => dataGridViewCriterions.Rows.Add(x));
            }
            if (tab.SelectedTab == tabCompares)
            {
                  
                dataGridViewCompare.Rows.Clear();
                dataGridViewCompare.Columns.Clear();
                comboBoxCompare.Items.Clear();
                if (!HaveErrors(1))
                    task.fields.ForEach(x => comboBoxCompare.Items.Add(x));               
                else
                    tab.SelectedTab = tabTask;

            }
            if (tab.SelectedTab == tabTask)
            {
                dataGridViewTaskCompare.Rows.Clear();
                if (task != null)
                    MatrixDataGridView.UpdateDataGridView(dataGridViewTaskCompare, task);
            }
            selectedtabIndex = tab.SelectedIndex;*/
        }
        private void dataGridViewCriterions_KeyDown(object sender, KeyEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewCriterions);
            _presenter.DeleteCriterion(indexRow);
        }
        private void dataGridViewOptions_KeyDown(object sender, KeyEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewOptions);
                _presenter.DeleteOption(indexRow);
        }
        private void dataGridViewTaskCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow=0, indexColumn = 0; string cellValue="";

            cellValue = WorkWithGridView.ValueSelectedCell(dataGridViewTaskCompare,ref indexRow,ref indexColumn);
            _presenter.SetValueCellMatrixCompare(indexRow, indexColumn, cellValue);
        }
        private void dataGridViewCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = 0, indexColumn = 0; string cellValue = "";

            cellValue = WorkWithGridView.ValueSelectedCell(dataGridViewCompare, ref indexRow, ref indexColumn);
            _presenter.SetValueCellMatrixCompare(indexRow, indexColumn, cellValue);
        }
        private void dataGridViewOptions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewOptions);
            _presenter.UpdateOption(indexRow);
        }
        private void dataGridViewCriterions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewCriterions);
            _presenter.UpdateCriterion(indexRow);
        }
        private void buttonSaveTaskInFile_Click(object sender, EventArgs e)
        {
            _presenter.SaveTaskInFile();
        }
        private void buttonLoadTaskFromFile_Click(object sender, EventArgs e)
        {
            _presenter.LoadTaskFromFile();
        }
        private void buttonShowCalc_Click(object sender, EventArgs e)
        {
            _presenter.ShowCalculation();
        }
        private void buttonGetResult_Click(object sender, EventArgs e)
        {
            _presenter.Calculation();
        }
        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            
            System.Data.DataTable table = new DataTable("ParentTable");
            // Declare variables for DataColumn and DataRow objects.
            DataColumn column;
            DataRow row;

            // Create new DataColumn, set DataType, 
            // ColumnName and add to DataTable.    
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ParentItem";
            column.AutoIncrement = false;
            column.Caption = "ParentItem";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the column to the table.
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;

            // Instantiate the DataSet variable.
          DataSet  dataSet = new DataSet();
            // Add the new DataTable to the DataSet.
            dataSet.Tables.Add(table);

            // Create three new DataRow objects and add 
            // them to the DataTable
            for (int i = 0; i <= 2; i++)
            {
                row = table.NewRow();
                row["id"] = i;
                row["ParentItem"] = "ParentItem " + i;
                table.Rows.Add(row);
            }
            WorkWithGridView.OutputTable(dataGridViewTaskCompare, table, true);
            // _presenter.AddTask();        
        }
        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {      
            _presenter.AddCriterion();
        }
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            _presenter.AddOption();
        }
        

    }
}
