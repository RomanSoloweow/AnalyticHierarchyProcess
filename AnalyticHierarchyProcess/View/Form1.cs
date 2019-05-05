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
            InicializationCalculatonResult();
        }
        private void  InicializationCalculatonResult()
        {
            DataGridViewRow dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.HeaderCell.Value = "Расчет на основании идеализированых приоритетов:";
            dataGridViewRow.Selected = false;
            dataGridViewCalculationResult.Rows.Add(dataGridViewRow);

            dataGridViewRow = new DataGridViewRow();
            dataGridViewRow.HeaderCell.Value = "Расчет на основании нормализированых приоритетов:";
            dataGridViewRow.Selected = false;
            dataGridViewCalculationResult.Rows.Add(dataGridViewRow);
            dataGridViewCalculationResult.Rows[0].Cells[0].Value = "";
            dataGridViewCalculationResult.Rows[1].Cells[0].Value = "";
            dataGridViewCalculationResult.DefaultCellStyle.SelectionBackColor = dataGridViewCalculationResult.DefaultCellStyle.BackColor;
            dataGridViewCalculationResult.DefaultCellStyle.SelectionForeColor = dataGridViewCalculationResult.DefaultCellStyle.ForeColor;
            dataGridViewCalculation.DefaultCellStyle.SelectionBackColor = dataGridViewCalculationResult.DefaultCellStyle.BackColor;
            dataGridViewCalculation.DefaultCellStyle.SelectionForeColor = dataGridViewCalculationResult.DefaultCellStyle.ForeColor;
        }
        public bool AddTask(string nameNewTask)
        {
            labelTaskName.Text = nameNewTask;
            return true;
        }
        public bool UpdateTask(string nameNewTask)
        {
            labelTaskName.Text = nameNewTask;
            return true;
        }
        public bool DeleteTask()
        {
            labelTaskName.Text = "";
            return true;
        }
        public bool AddCriterion(string nameNewCriterion)
        {
            return WorkWithGridView.AddRow(dataGridViewCriterions, nameNewCriterion);
        }
        public bool UpdateCriterion(int indexRow, string criterionNewName)
        {
            return WorkWithGridView.UpdateRow(dataGridViewCriterions, indexRow, criterionNewName);
        }
        public bool DeleteCriterion(int indexDelitingCriterion)
        {
            return WorkWithGridView.DeleteRow(dataGridViewCriterions, indexDelitingCriterion);
        }
        public bool AddOption(string newOptionName)
        {
            return WorkWithGridView.AddRow(dataGridViewOptions, newOptionName);
        }
        public bool UpdateOption(int indexRow, string optionNewName)
        {
            return WorkWithGridView.UpdateRow(dataGridViewOptions, indexRow, optionNewName);
        }
        public bool DeleteOption(int indeDelitingOption)
        {
            return WorkWithGridView.DeleteRow(dataGridViewOptions, indeDelitingOption);
        }
        public bool UpdateValueCellValueMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            return WorkWithGridView.UpdateCellValue(dataGridViewCompare, indexRow, indexColumn, cellValue);
        }
        public bool UpdateValueCellTaskMatrix(int indexRow, int indexColumn, string cellValue)
        {
            return WorkWithGridView.UpdateCellValue(dataGridViewTaskCompare, indexRow, indexColumn, cellValue);
        }

        public bool SetIPresenter(IPresenter iPresenter)
        {
            _presenter = iPresenter;
            return true;
        }
        public bool ContractMatrixCompare(int indexExpand)
        {
            return WorkWithGridView.Contract(dataGridViewCompare, indexExpand);
        }
        public bool ExpandMatrixCompare(string nameNewElement)
        {
            return WorkWithGridView.Expand(dataGridViewCompare, nameNewElement);
        }
        public bool ContractMatrixTask(int indexExpand)
        {
            return WorkWithGridView.Contract(dataGridViewTaskCompare, indexExpand);
        }
        public bool ExpandMatrixTask(string nameNewElement)
        {
            return WorkWithGridView.Expand(dataGridViewTaskCompare, nameNewElement);
        }

        public bool OutputMatrixTask(DataTable table)
        {
            return WorkWithGridView.OutputTable(dataGridViewTaskCompare, table);
        }
        public bool OutputMatrixCompare(DataTable table)
        {
            return WorkWithGridView.OutputTable(dataGridViewCompare, table, true);
        }
        public bool OutputVectorCalculations(List<string> column, string nameColumn)
        {
            return WorkWithGridView.OutputColumn(dataGridViewCalculation, column, nameColumn, false);
        }
        public bool OutputCalculationsResult(string idealizedResult, string normalizedResult)
        {
            WorkWithGridView.UpdateCellValue(dataGridViewCalculationResult, 0, 0, idealizedResult);
            WorkWithGridView.UpdateCellValue(dataGridViewCalculationResult, 1, 0, normalizedResult);
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
        public string GetStringValue(string title, string label_text)
        {
            string stringValue = String.Empty;

            if (InputBoxs.InputBox(title, label_text, ref stringValue) != DialogResult.OK)
                return null;

            return stringValue;
        }


        public bool AddCriterionInList(string nameNewCriterion)
        {
            if (string.IsNullOrEmpty(nameNewCriterion))
                return false;

            comboBoxCompare.Items.Add(nameNewCriterion);
            return true;

        }
        public bool UpdateCriterionInList(int indexRow, string nameNewCriterion)
        {
            if((indexRow < 0)||(comboBoxCompare.Items.Count < indexRow)||(string.IsNullOrEmpty(nameNewCriterion)))
                return false;

            comboBoxCompare.Items[indexRow] = nameNewCriterion;
            return true;
        }
        public bool DeleteCriterionInList(int indexRow)
        {
            if ((indexRow <0) || (comboBoxCompare.Items.Count < indexRow))
                return false;

            comboBoxCompare.Items.RemoveAt(indexRow);
            return true;
        }


        private void dataGridViewOptions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = WorkWithGridView.GetValue(dataGridViewOptions, e.RowIndex, e.ColumnIndex);
            _presenter.UpdateOption(e.RowIndex, cellValue);
        }
        private void dataGridViewCriterions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = WorkWithGridView.GetValue(dataGridViewCriterions, e.RowIndex, e.ColumnIndex);
            _presenter.UpdateCriterion(e.RowIndex, cellValue);
        }
        private void dataGridViewTaskCompare_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = WorkWithGridView.GetValue(dataGridViewTaskCompare, e.RowIndex, e.ColumnIndex);
            _presenter.UpdateValueCellTaskMatrix(e.RowIndex, e.ColumnIndex, cellValue);
        }
        private void dataGridViewCompare_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = WorkWithGridView.GetValue(dataGridViewCompare, e.RowIndex, e.ColumnIndex);
            _presenter.UpdateValueCellValueMatrixCompare(e.RowIndex, e.ColumnIndex, cellValue);
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
        private void buttonRenameTask_Click(object sender, EventArgs e)
        {
            _presenter.UpdateTask();
        }
        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            _presenter.DeleteTask();
        }
        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {      
            _presenter.AddCriterion();
        }
        private void buttonDeleteOption_Click(object sender, EventArgs e)
        {          
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewOptions);
            _presenter.DeleteOption(indexRow);
        }
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            _presenter.AddOption();
        }
        private void buttonDeleteCriterion_Click(object sender, EventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewCriterions);
            _presenter.DeleteCriterion(indexRow);
        }
        private void comboBoxCompare_DropDown(object sender, EventArgs e)
        {
            _presenter.SelectingMatrixCompare();
        }
        private void comboBoxCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SelectedMatrixCompareName = comboBoxCompare.Text;
            _presenter.SelectMatrixCompare(SelectedMatrixCompareName);
        }

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Обнуляем все
            comboBoxCompare.SelectedIndex = -1;
            dataGridViewCompare.Rows.Clear();
            dataGridViewCompare.Columns.Clear();
            dataGridViewCalculationResult.Rows[0].Cells[0].Value = "";
            dataGridViewCalculationResult.Rows[1].Cells[0].Value = "";
            dataGridViewCalculation.Rows.Clear();
            dataGridViewCalculation.Columns.Clear();
        }

        private void dataGridViewCompare_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //если поле пустое - откатываем изменение
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                ((DataGridView)sender).CancelEdit();
        }
        private void dataGridViewTaskCompare_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //если поле пустое - откатываем изменение
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                ((DataGridView)sender).CancelEdit();
        }
        private void dataGridViewOptions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //если поле пустое - откатываем изменение
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                ((DataGridView)sender).CancelEdit();
        }
        private void dataGridViewCriterions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //если поле пустое - откатываем изменение
            if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                ((DataGridView)sender).CancelEdit();
        }     
    }
}
