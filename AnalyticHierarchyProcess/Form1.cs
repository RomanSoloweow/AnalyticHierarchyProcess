using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.IO;
using NamespaceWorkWithGridView;
using NamespaceIView;
using NamespaceIPresenter;
using NamespaceMatrixTable;
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
       public bool OuputTaskMatrix(MatrixTable matrixTable)
        {
            WorkWithGridView.OutputMatrix(dataGridViewTaskCompare, matrixTable);
            return true;
        }
       public bool OuputCalculations(Vector<double> vectorCalculation1, Vector<double> vectorCalculation2)
        {
            WorkWithGridView.OutputVector(dataGridViewCalculation,vectorCalculation1, "", false);
            WorkWithGridView.OutputVector(dataGridViewCalculation, vectorCalculation2, "", false);
            return true;
        }
       public bool OuputMatrixCompare(MatrixTable matrixTable)
        {
            WorkWithGridView.OutputMatrix(dataGridViewTaskCompare, matrixTable);
            return true;
        }


       public bool AddCriterion(string newCriterionName)
        {
            WorkWithGridView.AddRow(dataGridViewCriterions, newCriterionName);
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
       public bool SetValueCellMatrixCompare(int indexRow, int indexColumn, double cellValue)
        {
            WorkWithGridView.SetCell(dataGridViewCompare, indexRow, indexColumn, cellValue);
            return true;
        }
       public bool SetValueCellTaskMatrixCompare(int indexRow, int indexColumn, double cellValue)
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
            if (indexRow < 0)
                return;
             _presenter.DeleteCriterion(indexRow);
        }
        private void dataGridViewOptions_KeyDown(object sender, KeyEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewOptions);
            if (indexRow < 0)
                return;
              _presenter.DeleteOption(indexRow);
        }

        private void dataGridViewTaskCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow=0, indexColumn = 0; double cellValue=0;
            WorkWithGridView.UpdateValueSymmetricCellDataGridView(dataGridViewTaskCompare,ref indexRow,ref indexColumn,ref cellValue);
            _presenter.SetValueCellMatrixCompare(indexRow, indexColumn, cellValue);
        }
        private void dataGridViewCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = 0, indexColumn = 0; double cellValue = 0;
            WorkWithGridView.UpdateValueSymmetricCellDataGridView(dataGridViewCompare, ref indexRow, ref indexColumn, ref cellValue);
            _presenter.SetValueCellMatrixCompare(indexRow, indexColumn, cellValue);
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
            string newTaskName = String.Empty;

            if (InputBoxs.InputBox("Создать цель", "Введите цель", ref newTaskName) != DialogResult.OK)
                return;
            _presenter.AddTask(newTaskName);        
        }
        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {
            string newCriterionName = String.Empty;

            if (InputBoxs.InputBox("Создать критерий", "Введите критерий", ref newCriterionName) != DialogResult.OK)
                return;

            _presenter.AddCriterion(newCriterionName);
        }
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            string newOptionName = String.Empty;

            if (InputBoxs.InputBox("Создать объект", "Введите объект", ref newOptionName) != DialogResult.OK)
                return;

            _presenter.AddOption(newOptionName);
        }

        private void dataGridViewOptions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewOptions);
            if (indexRow < 0)
                return;

            string newValue = WorkWithGridView.ValueSelectedCell(dataGridViewOptions);
            _presenter.UpdateOption(indexRow,newValue);
        }
        private void dataGridViewCriterions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int indexRow = WorkWithGridView.GetIndexSelectedRow(dataGridViewCriterions);
            if (indexRow < 0)
                return;

            string newValue = WorkWithGridView.ValueSelectedCell(dataGridViewCriterions);
            _presenter.UpdateCriterion(indexRow, newValue);
        }

    }
}
