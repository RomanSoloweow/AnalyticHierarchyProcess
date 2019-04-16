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

using NamespaceIView;

namespace AnalyticHierarchyProcess
{
    public partial class FormView : Form, IView
    {
        public FormView()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }
   
        private void comboBoxCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (HaveErrors(64))
                return;
            
           
            if (selectedMatrix != string.Empty)
                MatrixDataGridView.UpdateMatrix(matrixsCompare[selectedMatrix], dataGridViewCompare);

            selectedMatrix = comboBoxCompare.Text;

            MatrixDataGridView.UpdateDataGridView(dataGridViewCompare, matrixsCompare[selectedMatrix]);*/
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
            //MatrixDataGridView.DeleteCellFromDataGridView(dataGridViewCriterions, e.KeyCode, DeleteCriterion);
        }
        private void dataGridViewCriterions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // MatrixDataGridView.SetValueCellFromDataGridView(dataGridViewCriterions, UpdateCriterion);
        }
        private void dataGridViewOptions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //MatrixDataGridView.SetValueCellFromDataGridView(dataGridViewOptions, UpdateOption);
        }
        private void dataGridViewOptions_KeyDown(object sender, KeyEventArgs e)
        {
           // MatrixDataGridView.DeleteCellFromDataGridView(dataGridViewCriterions, e.KeyCode, DeleteOption);
        }
        private void dataGridViewTaskCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // MatrixDataGridView.UpdateValueSymmetricCellDataGridView(dataGridViewTaskCompare);
        }
        private void dataGridViewCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           // MatrixDataGridView.UpdateValueSymmetricCellDataGridView(dataGridViewCompare);
        }
  
        private void buttonSaveTaskInFile_Click(object sender, EventArgs e)
        {
           // SaveTaskInFile();

        }
        private void buttonLoadTaskFromFile_Click(object sender, EventArgs e)
        {
           // LoadTaskFromFile();
        }
        private void buttonShowCalc_Click(object sender, EventArgs e)
        {
           // ShowCalc();
        }
        private void buttonGetResult_Click(object sender, EventArgs e)
        {
           // Calc();
        }





        private void buttonAddTask_Click(object sender, EventArgs e)
        {
          /*  string newTaskName = String.Empty;
            if ((HaveErrors(1,null, true))||(!HaveErrors(1, null, true)&&(MessageBox.Show("Цель уже была создана, удалить предыдущую?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)))
                if (InputBoxs.InputBox("Создать цель", "Введите цель", ref newTaskName) != DialogResult.Cancel)
                    AddTask(newTaskName);  */        
        }
        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {
           /* string newCriterionName = "";
            if (!HaveErrors(1))
                if (InputBoxs.InputBox("Создать критерий", "Введите критерий", ref newCriterionName) != DialogResult.Cancel)
                    if (!HaveErrors(25, newCriterionName))
                        AddCriterion(newCriterionName);*/
        }
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
           /* string newOptionName = "";
            if (!HaveErrors(7))                              
                if (InputBoxs.InputBox("Создать объект", "Введите объект", ref newOptionName) != DialogResult.Cancel)
                    if (!HaveErrors(47, newOptionName))
                        AddOption(newOptionName);*/
        }
    }
}
