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
using InputBox;
using System.Data.OleDb;
using Task;
using Excel = Microsoft.Office.Interop.Excel;
using MathNet.Numerics;
namespace AnalyticHierarchyProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridViewCriterions.Columns.Add("Критерии", "Критерии");
        }
        string selectedTaskName;
        Dictionary<int, string> scales = new Dictionary<int, string>()
        {
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
        private Dictionary<string, Task.Task> tasks = new Dictionary<string, Task.Task>();
        public List<string> GetCriterions()
        {
            List<string> сriterions = new List<string>();
            for (int i = 0; i < dataGridViewCriterions.Rows.Count - 1; i++)
            {
                сriterions.Add(dataGridViewCriterions[0, i].Value.ToString());

            }
            return сriterions;
        }
        public void UpdateForm()
        {
           // this.Text = formName;
            this.Visible = true;
            this.Show();
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            dataGridViewCriterions.Width = 25;
            dataGridViewCriterions.Height = 25;

            int j = 1;
            if (dataGridViewCriterions.Columns.Count == 1)
                j = 0;

            for (int i = j; i < dataGridViewCriterions.Columns.Count; i++)
                dataGridViewCriterions.Width += dataGridViewCriterions.Columns[i].Width;

            for (int i = 0; i < dataGridViewCriterions.Rows.Count; i++)
            {
                if ((dataGridViewCriterions.Height + dataGridViewCriterions.Rows[i].Height) < resolution.Height)
                    dataGridViewCriterions.Height += dataGridViewCriterions.Rows[i].Height;
                else
                    dataGridViewCriterions.Width += 30;
            }

            this.Width = dataGridViewCriterions.Width;
            this.Height = dataGridViewCriterions.Height + 40;
        }
        /// <summary>
        /// Получить текущую выбранную цель
        /// </summary>
        /// <returns>Task, если выбрана цель, null если не выбрана</returns>
        public Task.Task GetSelectedTask()
        {
            if (!tasks.ContainsKey(selectedTaskName))
                return null;

            return tasks[selectedTaskName];
        }
       
        public void AddTasks(string newTaskName)
        {
            tasks.Add(newTaskName, new Task.Task(newTaskName, GetCriterions()));
        }
        public List<string> GetTasksNames()
        {
            return tasks.Keys.ToList<string>();
        }
        public void AddCriterionForAllTask(int index = -1)
        {
            for (int i = 0; i < tasks.Count; i++)
                tasks.ElementAt(i).Value.AddCriterion(index);
        }
        public void DeleteCriterion(int indexDeletedRow)
        {
            for (int i = 0; i < tasks.Count; i++)
                tasks.ElementAt(i).Value.DeleteCriterion(indexDeletedRow);
        }
        private DataGridViewComboBoxCell GetDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
            foreach (string value in scales.Values)
            {
                dataGridViewComboBoxCell.Items.Add(value);
            }
            return dataGridViewComboBoxCell;
        }     
        public void updateDataGridViewCompare(string selectedTaskName)
        {
            dataGridViewCompare.Rows.Clear();
            dataGridViewCompare.Columns.Clear();
            dataGridViewCompare.Width = 0;
            if (!tasks.ContainsKey(selectedTaskName))
                return;

            dataGridViewCompare.Columns.Add(" ", " ");

            List<string> columnsNames = GetCriterions();
            columnsNames.ForEach(columnName => dataGridViewCompare.Columns.Add(columnName, columnName));

            foreach (string columnName in columnsNames)
                dataGridViewCompare.Rows.Add(columnName);

            for (int i = 0; i < dataGridViewCompare.Rows.Count; i++)
                for (int j = 0; j < dataGridViewCompare.ColumnCount; j++)
                {
                    if ((i < j - 1) && (j >= 1))
                    {
                        dataGridViewCompare[j, i] = GetDataGridViewComboBoxCell();
                        // dataGridViewTasks[j, i].Value = scales[tasks[comboBoxAllTask.Text].matrix[i,j - 1]].ToString();
                        dataGridViewCompare[j, i].Value = scales[9].ToString();
                    }
                    if ((i >= j - 1) && (j >= 1))
                    {
                        dataGridViewCompare[j, i].ReadOnly = true;
                        dataGridViewCompare[j, i].Value = scales[-1].ToString();
                    }
                };
        }
        
        private void AddTask_Click(object sender, EventArgs e)
        {          
            string taskName = string.Empty;

            if (InputBoxs.InputBox("Input task", "Введите цель", ref taskName) == DialogResult.Cancel)
                return;

            comboBoxAllTask.DataSource = GetTasksNames();
            comboBoxAllTask.SelectedIndex = -1;
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxAllTask.SelectedIndex = -1;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            List<string> ty = new List<string>();
            for(int i=0;i<3;i++)
            ty.Add("1");
            tasks.Add("1", new Task.Task("1", ty));
             
            tasks.Values.ElementAt(0).matrix[0,1] = 3;
            tasks.Values.ElementAt(0).matrix[0,2] = 5;
            tasks.Values.ElementAt(0).matrix[1,2] = 2;
            tasks.Values.ElementAt(0).AddCriterion();
            /* 
             tasks.Values.ElementAt(0).matrix[0][1] = 5;
             tasks.Values.ElementAt(0).matrix[0][2] = 3;
             tasks.Values.ElementAt(0).matrix[0][3] = 7;
             tasks.Values.ElementAt(0).matrix[0][4] = 6;
             tasks.Values.ElementAt(0).matrix[0][5] = 6;
             tasks.Values.ElementAt(0).matrix[1][3] = 5;
             tasks.Values.ElementAt(0).matrix[1][4] = 3;
             tasks.Values.ElementAt(0).matrix[1][5] = 3;
             tasks.Values.ElementAt(0).matrix[2][1] = 3;
             tasks.Values.ElementAt(0).matrix[2][3] = 6;
             tasks.Values.ElementAt(0).matrix[2][4] = 3;
             tasks.Values.ElementAt(0).matrix[2][5] = 4;
             tasks.Values.ElementAt(0).matrix[4][3] = 3;
             tasks.Values.ElementAt(0).matrix[5][3] = 4;
             tasks.Values.ElementAt(0).matrix[5][4] = 2;
             tasks.Values.ElementAt(0).matrix[6][0] = 3;
             tasks.Values.ElementAt(0).matrix[6][1] = 5;
             tasks.Values.ElementAt(0).matrix[6][2] = 2;
             tasks.Values.ElementAt(0).matrix[6][3] = 7;
             tasks.Values.ElementAt(0).matrix[6][4] = 5;
             tasks.Values.ElementAt(0).matrix[6][5] = 5;
             tasks.Values.ElementAt(0).matrix[7][0] = 4;
             tasks.Values.ElementAt(0).matrix[7][1] = 7;
             tasks.Values.ElementAt(0).matrix[7][2] = 5;
             tasks.Values.ElementAt(0).matrix[7][3] = 8;
             tasks.Values.ElementAt(0).matrix[7][4] = 6;
             tasks.Values.ElementAt(0).matrix[7][5] = 6;
             tasks.Values.ElementAt(0).matrix[7][6] = 2;*/

            tasks.Values.ElementAt(0).UpdateAgreed();
        

            /* tasks.Values.ElementAt(0).matrix[0][1] =5;
            tasks.Values.ElementAt(0).matrix[0][2] = 9;
            tasks.Values.ElementAt(0).matrix[1][2] = 4;
            tasks.Values.ElementAt(0).CheckAgreed();*/


            // tabs.TabPages[1].Parent = tabs;
            //  tabs.Update();
            //tasks.First().Value.CheckAgreed();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //Program.formCriterions.UpdateForm();
        }

        private void comboBoxAllTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDataGridViewCompare(comboBoxAllTask.Text);

        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        private void dataGridViewCriterions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int indexDeletedRow = dataGridViewCriterions.CurrentRow.Index;
                dataGridViewCriterions.Rows.RemoveAt(indexDeletedRow);
                //   Program.formTasks.DeleteCriterionForAllTask(indexDeletedRow);

                //this.UpdateForm();
            }
        }

        private void dataGridViewCriterions_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            AddCriterionForAllTask();
        }

        private void tabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!tasks.ContainsKey(comboBoxAllTask.Text))
                tabs.SelectedTab = tabTask;
        }

        private void buttonAddOption_Click(object sender, EventArgs e)
        {
        
        }
    }
}
