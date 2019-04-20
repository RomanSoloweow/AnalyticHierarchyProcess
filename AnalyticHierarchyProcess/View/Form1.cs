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
        /*
        public string GetCriterion(int indexCriterion)
        {
            string criterion = WorkWithGridView.GetRow(dataGridViewCriterions, indexCriterion);
            return criterion;
        }
        public string GetOption(int indexOption)
        {
            string option = WorkWithGridView.GetRow(dataGridViewOptions, indexOption);
            return option;
        }
        public string GetCellValueMatrixCompare(int indexRow, int indexColumn)
        {
            string value = WorkWithGridView.GetValueCell(dataGridViewCompare, indexRow, indexColumn);
            return value;
        }
        public string GetCellValueTaskMatrix(int indexRow, int indexColumn)
        {
            string value = WorkWithGridView.GetValueCell(dataGridViewTaskCompare, indexRow, indexColumn);
            return value;
        }*/



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
           WorkWithGridView.OutputTable(dataGridViewCompare, table,true);
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
            if (MessageBox.Show(QuestionText, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
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
            comboBoxCompare.Items.Add(nameNewCriterion);
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
            comboBoxCompare.Items.RemoveAt(indexDelitingCriterion);
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
       public bool UpdateValueCellValueMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            WorkWithGridView.UpdateCellValue(dataGridViewCompare, indexRow, indexColumn, cellValue);
            return true;
        }
       public bool UpdateValueCellTaskMatrix(int indexRow, int indexColumn, string cellValue)
        {
            WorkWithGridView.UpdateCellValue(dataGridViewTaskCompare, indexRow, indexColumn, cellValue);
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
        private void dataGridViewOptions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int indexRow = 0, indexColumn = 0; string cellValue = "";
            cellValue = WorkWithGridView.GetValueSelectedCell(dataGridViewCriterions, ref indexRow, ref indexColumn);
            _presenter.UpdateOption(indexRow, cellValue);
        }
        private void dataGridViewCriterions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = 0, indexColumn = 0; string cellValue = "";
            cellValue = WorkWithGridView.GetValueSelectedCell(dataGridViewCriterions, ref indexRow, ref indexColumn);
            _presenter.UpdateCriterion(indexRow, cellValue);
        }
        private void dataGridViewTaskCompare_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = 0, indexColumn = 0; string cellValue = "";

            cellValue = WorkWithGridView.GetValueSelectedCell(dataGridViewTaskCompare, ref indexRow, ref indexColumn);
            _presenter.UpdateValueCellTaskMatrix(indexRow, indexColumn);
        }
        private void dataGridViewCompare_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = 0, indexColumn = 0; string cellValue = "";

            cellValue = WorkWithGridView.GetValueSelectedCell(dataGridViewCompare, ref indexRow, ref indexColumn);
            _presenter.UpdateValueCellValueMatrixCompare(indexRow, indexColumn, cellValue);
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
            _presenter.AddTask();        
        }
        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {      
            _presenter.AddCriterion();
        }
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            _presenter.AddOption();
        }

        private void comboBoxCompare_DropDown(object sender, EventArgs e)
        {
            _presenter.SelectingMatrixCompare();
        }
    }
}
