﻿using System;
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
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using matrixTable = MatrixTable.MatrixTable;

namespace AnalyticHierarchyProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          /// dataGridViewCriterions.Columns.Add("Критерии", "Критерии");
            // dataGridViewCriterions.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
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
        private Dictionary<string, matrixTable> tasks = new Dictionary<string, matrixTable>();
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
        public matrixTable GetSelectedTask()
        {
            if (dataGridViewTasks.SelectedCells.Count == 0)
                return null;

            string selectedTaskName = dataGridViewTasks.SelectedCells[0].Value.ToString();

            if (!tasks.ContainsKey(selectedTaskName))
                return null;

            return tasks[selectedTaskName];
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
        public void UpdateDataGridViewCompare(matrixTable table)
        {
            dataGridViewCompare.Rows.Clear();
            dataGridViewCompare.Columns.Clear();
           // dataGridViewCompare.Width = 0;
           if(table!=null)
            if (table.fields.Count > 0)
            {
                string columnName = "";
                dataGridViewCompare.Columns.Add(" ", " ");
                table.fields.ForEach(x => dataGridViewCompare.Columns.Add(x, x));
                table.fields.ForEach(x => dataGridViewCompare.Rows.Add(x, x));
                for (int i = 0; i < table.CountFiields(); i++)
                    dataGridViewCompare.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;


                for (int i = 0; i < dataGridViewCompare.RowCount; i++)
                    for (int j = 0; j < dataGridViewCompare.Columns.Count; j++)
                    {
                        if (j >= 1)
                        {

                            dataGridViewCompare[j, i] = GetDataGridViewComboBoxCell();
                            // dataGridViewTasks[j, i].Value = scales[tasks[comboBoxAllTask.Text].matrix[i,j - 1]].ToString();
                            dataGridViewCompare[j, i].Value = scales[9].ToString();
                            if (i == (j-1))
                            {
                                dataGridViewCompare[j, i].Value = scales[1].ToString();
                                dataGridViewCompare[j, i].ReadOnly = true;
                            }
                        }
                       
                    };
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            double[,] data = new double[,]
            {
                {  1,  5,  7},
                { 0.2, 1, 3},
                { 0.142857,  0.33333, 1}
            };

            Matrix<double> _matrix = DenseMatrix.OfArray(data);
            Calculations.Sole(_matrix);

            List<string> ty = new List<string>();
            for(int i=0;i<3;i++)
            ty.Add("Критерий №"+i.ToString());
            tasks.Add("1", new matrixTable("1", ty));
            tasks.Values.ElementAt(0).SetCellMatrix(0,1,5);
            tasks.Values.ElementAt(0).SetCellMatrix(0,2,7);
            tasks.Values.ElementAt(0).SetCellMatrix(1,2,3);
            tasks.Values.ElementAt(0).FillMatrix();
        //  Console.WriteLine(tasks.Values.ElementAt(0).GetVectorPriority(tasks.Values.ElementAt(0).matrix));
          //  Console.WriteLine(tasks.Values.ElementAt(0).matrix);
           // Console.WriteLine(tasks.Values.ElementAt(0).MaxEigenValue(tasks.Values.ElementAt(0).matrix));
            tasks.Values.ElementAt(0).fields.ForEach(x => dataGridViewCompare.Columns.Add(x,x));

        }


        private void dataGridViewCriterions_KeyDown(object sender, KeyEventArgs e)
        {
            int indexDeletedRow = dataGridViewCriterions.CurrentRow.Index;
            if ((e.KeyCode == Keys.Delete)&&(indexDeletedRow<(dataGridViewCriterions.RowCount - 1)))
            {              
                dataGridViewCriterions.Rows.RemoveAt(indexDeletedRow);
                GetSelectedTask().DeleteField(indexDeletedRow);
            }
        }


        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {
            matrixTable SelectedTask = GetSelectedTask();
            if (SelectedTask != null)
            {
                string newCriterionName = textBoxCriterionName.Text;
                if (newCriterionName != String.Empty)
                {
                    if (!SelectedTask.fields.Contains(newCriterionName))
                    {
                        SelectedTask.AddField(newCriterionName);
                        dataGridViewCriterions.Rows.Add(newCriterionName);
                        textBoxCriterionName.Text = String.Empty;
                    }
                    else
                        MessageBox.Show("Критерий уже существует");
                }
                else
                    MessageBox.Show("Необходимо вести название критерия");
            }
            else
                MessageBox.Show("Необходимо выбрать или создать цель");

        }

        private void buttonAddTask_Click(object sender, EventArgs e)
        {

            string newTaskName = textBoxTaskName.Text;

            if (newTaskName != string.Empty)
            {
                if (!tasks.ContainsKey(newTaskName))
                {
                    tasks.Add(newTaskName, new matrixTable(newTaskName));
                    dataGridViewTasks.Rows.Add(newTaskName);
                    textBoxTaskName.Text = String.Empty;
                }
                else
                    MessageBox.Show("Цель уже существует");

            }
            else
                MessageBox.Show("Введите название цели");
        }
        private void dataGridViewTasks_SelectionChanged(object sender, EventArgs e)
        {
            matrixTable SelectedTask = GetSelectedTask();
            if (SelectedTask != null)
            {
                labelSelectedTask.Text = GetSelectedTask()?.name;
                UpdateDataGridViewCompare(SelectedTask);
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabs.SelectedTab==tabCriterions)
            {
                dataGridViewCriterions.Rows.Clear();
                GetSelectedTask()?.fields.ForEach(x => dataGridViewCriterions.Rows.Add(x));
            }

            if (tabs.SelectedTab == tabCompare)
            {
                UpdateDataGridViewCompare(GetSelectedTask());
            }

        }
    }
}
