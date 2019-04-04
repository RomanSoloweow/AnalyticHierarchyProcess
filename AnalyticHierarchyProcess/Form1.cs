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
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using matrixTable = MatrixTable.MatrixTable;
using calculations=Calculations.Calculations;

namespace AnalyticHierarchyProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string selectedTaskName;
        int selectedtabIndex = 0;
        Dictionary<int,string> scalesInt = new Dictionary<int, string>()
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
        Dictionary<string,int> scalesString = new Dictionary<string,int>()
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
        private DataGridViewComboBoxCell GetDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
            foreach (string value in scalesInt.Values)
            {
                dataGridViewComboBoxCell.Items.Add(value);
            }
            return dataGridViewComboBoxCell;
        }
        private Dictionary<string, matrixTable> tasks = new Dictionary<string, matrixTable>();
        private Dictionary<string, matrixTable> options = new Dictionary<string, matrixTable>();
           
        public matrixTable GetSelectedTask()
        {
            if (dataGridViewTasks.SelectedCells.Count == 0)
                return null;

                string selectedTaskName = dataGridViewTasks.SelectedCells[0].Value.ToString();

            if (!tasks.ContainsKey(selectedTaskName))
                return null;

            return  tasks[selectedTaskName];
        }
        public matrixTable GetSelectedMatrix()
        {
            return null;
        }
        public List<matrixTable> GetOptions()
        {
            matrixTable selectedTask = GetSelectedTask();
            return options.Values.Where(x => x.fields.SequenceEqual(selectedTask.fields)).ToList();
        }
       
        private void UpdateDataGridViewCompare(matrixTable table)
        {
            dataGridViewCompare.Rows.Clear();
            dataGridViewCompare.Columns.Clear();
           if(table!=null)
            if (table.fields.Count > 0)
            {
                dataGridViewCompare.Columns.Add(" ", " ");
                table.fields.ForEach(x => dataGridViewCompare.Columns.Add(x, x));
                table.fields.ForEach(x => dataGridViewCompare.Rows.Add(x, x));
                for (int i = 0; i < table.CountFiields(); i++)
                    dataGridViewCompare.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                     for (int i = 0; i < dataGridViewCompare.RowCount; i++)
                        for (int j = 0; j < dataGridViewCompare.Columns.Count-1; j++)
                        {
                                dataGridViewCompare.Rows[i].Cells[j+1].ValueType = typeof(DataGridViewComboBoxCell);
                                dataGridViewCompare.Rows[i].Cells[j + 1] = GetDataGridViewComboBoxCell();

                                if (table.GetCellMatrix(i, j) % 1 == 0)
                                    dataGridViewCompare.Rows[i].Cells[j + 1].Value = scalesInt[Convert.ToInt32(table.GetCellMatrix(i, j))].ToString();
                                else
                                dataGridViewCompare.Rows[i].Cells[j + 1].Value = scalesInt[-1].ToString();

                                // dataGridViewCompare[j, i].Value = scalesInt[9].ToString();
                                if (i == j)
                                {
                                dataGridViewCompare.Rows[i].Cells[j + 1].Value = scalesInt[1].ToString();
                                dataGridViewCompare.Rows[i].Cells[j + 1].ReadOnly = true;
                                }                       
                        };
            }
        }
        private void UpdateSelectedMatrixCompare()
        {
            double valueCells = 0;
            matrixTable selectedMatrix = GetSelectedMatrix();
            for (int i = 0; i < dataGridViewCompare.RowCount; i++)
                for (int j = 0; j < dataGridViewCompare.Columns.Count-1; j++)
                {
                    valueCells = scalesString[dataGridViewCompare.Rows[i].Cells[j + 1].Value.ToString()];
                    if (valueCells == -1)
                        valueCells = 1.0 /(scalesString[dataGridViewCompare.Rows[j].Cells[i + 1].Value.ToString()]);

                        selectedMatrix.matrix[i, j] = valueCells;
                }
                 

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetSelectedTask().SetCellMatrix(0, 1, 2);
            GetSelectedTask().SetCellMatrix(0, 2, 3);
            GetSelectedTask().SetCellMatrix(1, 0, 4);
            GetSelectedTask().SetCellMatrix(1, 2, 6);
            GetSelectedTask().SetCellMatrix(2, 0, 7);
            GetSelectedTask().SetCellMatrix(2, 1, 8);
           // Console.WriteLine(Math.Pow(32,5)%72);
            /*
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
            tasks.Values.ElementAt(0).fields.ForEach(x => dataGridViewCompare.Columns.Add(x,x));*/

        }


        private void dataGridViewCriterions_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow DeletedRow = dataGridViewCriterions.CurrentRow;
            if((e.KeyCode == Keys.Delete) && (DeletedRow != null))
            {              
                dataGridViewCriterions.Rows.RemoveAt(DeletedRow.Index);
                GetSelectedTask().DeleteField(DeletedRow.Index);
            }
        }
        private void dataGridViewOptions_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow DeletedRow = dataGridViewOptions.CurrentRow;
            if ((e.KeyCode == Keys.Delete)&&(DeletedRow!=null))
            {
                dataGridViewOptions.Rows.RemoveAt(DeletedRow.Index);
                options.Remove(DeletedRow.Cells[0].Value.ToString());
            }
        }
        private void dataGridViewTasks_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow DeletedRow = dataGridViewTasks.CurrentRow;
            if ((e.KeyCode == Keys.Delete) && (DeletedRow != null))
            {
                dataGridViewTasks.Rows.RemoveAt(DeletedRow.Index);
                tasks.Remove(DeletedRow.Cells[0].Value.ToString());
                labelSelectedTask.Text = String.Empty;
            }
        }

        private void dataGridViewTasks_SelectionChanged(object sender, EventArgs e)
        {
            matrixTable SelectedTask = GetSelectedTask();
            if (SelectedTask != null)
            {
                labelSelectedTask.Text = GetSelectedTask()?.name;
            }
        }
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectedtabIndex == 1)
            {
                UpdateSelectedMatrixCompare();
            }          
            if (tabs.SelectedTab == tabOptions)
            {
                dataGridViewOptions.Rows.Clear();
                GetOptions().ForEach(x => dataGridViewOptions.Rows.Add(x));
            }
            if (tabs.SelectedTab==tabCriterions)
            {
                dataGridViewCriterions.Rows.Clear();
                GetSelectedTask()?.fields.ForEach(x => dataGridViewCriterions.Rows.Add(x));
            }
            if (tabs.SelectedTab == tabCompares)
            {
                UpdateDataGridViewCompare(GetSelectedTask());
            }
            if (tabs.SelectedTab == tabTasks)
            {
                dataGridViewTasks.Rows.Clear();
                tasks.Keys.ToList().ForEach(x => dataGridViewTasks.Rows.Add(x));
            }
            selectedtabIndex = tabs.SelectedIndex;
        }

        private void dataGridViewTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTasks.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridViewTasks.SelectedCells[0];
                string oldkey = tasks.Keys.ToList()[selectedCell.RowIndex];
                matrixTable oldvalue = tasks[oldkey];
                tasks.Remove(oldkey);
                tasks.Add(selectedCell.Value.ToString(), oldvalue);
                GetSelectedTask().name= selectedCell.Value.ToString();
                labelSelectedTask.Text = selectedCell.Value.ToString();
            }
        }
        private void dataGridViewCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //если ячейка выбрана
            if (dataGridViewCompare.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridViewCompare.SelectedCells[0];
               //если не первый столбец(там заголовки) и не диагональные элементы
                if ((selectedCell.ColumnIndex > 0)&&(selectedCell.RowIndex!= selectedCell.ColumnIndex-1))
                    dataGridViewCompare.Rows[selectedCell.ColumnIndex - 1].Cells[selectedCell.RowIndex+1].Value = scalesInt[-1];

            }
        }
        private void dataGridViewCriterions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCriterions.SelectedCells.Count>0)
            {
                DataGridViewCell selectedCell = dataGridViewCriterions.SelectedCells[0];
                GetSelectedTask().fields[selectedCell.RowIndex] = selectedCell.Value.ToString();
            }
        }
        private void dataGridViewOptions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewOptions.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridViewOptions.SelectedCells[0];
                string oldkey = options.Keys.ToList()[selectedCell.RowIndex];
                matrixTable oldvalue = options[oldkey];                
                options.Remove(oldkey);
                oldvalue.name = selectedCell.Value.ToString();
                options.Add(selectedCell.Value.ToString(), oldvalue);

            }
        }

        private void buttonSaveMatrix_Click(object sender, EventArgs e)
        {
            UpdateSelectedMatrixCompare();
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
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            matrixTable SelectedTask = GetSelectedTask();
            if (SelectedTask != null)
            {
                if (calculations.GetIndexAgreed(SelectedTask.matrix)<0.01)
                {
                   string newOptionName = textBoxOptionName.Text;
                    if (newOptionName != String.Empty)
                    {
                        if (!options.ContainsKey(newOptionName))
                        {
                            options.Add(newOptionName, new matrixTable(newOptionName));
                            dataGridViewOptions.Rows.Add(newOptionName);
                            textBoxOptionName.Text = String.Empty;
                        }
                        else
                            MessageBox.Show("Объект уже существует");
                    }
                    else
                        MessageBox.Show("Необходимо вести название объекта");
                }
                else
                    MessageBox.Show("Цель должна быть согласованна");
            }
            else
                MessageBox.Show("Необходимо выбрать или создать цель");
        }

        private void buttonSaveTaskInFile_Click(object sender, EventArgs e)
        {

        }
    }
}
