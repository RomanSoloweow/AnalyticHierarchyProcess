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
using System.IO;
using matrixTable = MatrixTable.MatrixTable;
using calculations=Calculations.Calculations;

namespace AnalyticHierarchyProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            InitializeComponent();
        }
        string selectedMatrix = string.Empty;
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
        matrixTable task = null;
        private DataGridViewComboBoxCell GetDataGridViewComboBoxCell()
        {
            DataGridViewComboBoxCell dataGridViewComboBoxCell = new DataGridViewComboBoxCell();
            foreach (string value in scalesInt.Values)
            {
                dataGridViewComboBoxCell.Items.Add(value);
            }
            return dataGridViewComboBoxCell;
        }
        //private Dictionary<string, matrixTable> tasks = new Dictionary<string, matrixTable>();
        private Dictionary<string, matrixTable> matrixsCompare = new Dictionary<string, matrixTable>();
        private List<string> options = new List<string>();
        public void LoadTaskFromFile(string FullFileName)
        {        

            string taskName = Path.GetFileNameWithoutExtension(FullFileName);
            using (StreamReader File = new StreamReader(FullFileName))
            {
            List<string> criterions = new List<string>(File.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
            task = new matrixTable(taskName, criterions);
            criterions.ForEach(x => matrixsCompare.Add(x, new matrixTable(x, options)));
                Vector<double> vector = null;
                for(int i=0;i< criterions.Count;i++)
                {
                    vector = Vector<double>.Build.DenseOfArray(File.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => double.Parse(x)).ToArray());
                    for(int j=0;j<vector.Count;j++)
                    task.matrix[i,j] = vector[j];
                }
               File.Close();
            }
            UpdateDataGridView(dataGridViewTaskCompare,task);
            labelSelectedTask.Text = task.name;
        }
        public void SaveTaskInFile(string FullFileName)
        {
            UpdateMatrix(task, dataGridViewTaskCompare);
            using (StreamWriter file = new StreamWriter(FullFileName, true))
            {
                file.WriteLine(string.Join(",", task.fields));
                for (int i = 0; i < task.matrix.RowCount;i++)
                {
                    file.WriteLine(string.Join(",", task.matrix.Row(i).ToList().Select(x => x.ToString()).ToList()));
                }
                file.Close();
            }
            
        }
        
        public matrixTable GetSelectedMatrix()
        {
            if (comboBoxCompare.SelectedIndex== -1)
                return null;

            List<string> selectedMatrixName = comboBoxCompare.Text.ToString().Split(new char[] { ':' }).ToList();

            if (selectedMatrixName[0].Contains("Цель"))
                return task;
            else
                return matrixsCompare[selectedMatrixName[1]];
        }
        public List<string> GetListAvailableMatrixs()
        {
            List<string> availableMatrixs = new List<string>();
            if (task!= null)
            {
                availableMatrixs.Add("Цель:"+ task.name);
                if (options.Count > 0)
                    task.fields.ForEach(x => availableMatrixs.Add("Критерий:" + x));
            }
            return availableMatrixs;
        }
        public void AddCriterion(string newCriterionName)
        {
            task.AddField(newCriterionName);
            matrixsCompare.Add(newCriterionName, new matrixTable(newCriterionName, options));
            dataGridViewCriterions.Rows.Add(newCriterionName);
        }
        public void UpdateCriterion(DataGridViewCell selectedCell)
        {
            if (selectedCell.Value == null)
            {            
                selectedCell.Value = "Критерий " + selectedCell.RowIndex.ToString();
                dataGridViewCriterions.Rows[selectedCell.RowIndex].Cells[selectedCell.ColumnIndex].Value = selectedCell.Value;
            }

                string newCriterionName = selectedCell.Value.ToString();         
                task.fields[selectedCell.RowIndex] = newCriterionName;
                string oldkey = matrixsCompare.Keys.ToList()[selectedCell.RowIndex];
                matrixTable oldvalue = matrixsCompare[oldkey];
                oldvalue.name = newCriterionName;
                matrixsCompare.Remove(oldkey);
                matrixsCompare.Add(newCriterionName, oldvalue);
            
        }
        public void DeleteCriterion(DataGridViewRow DeletedRow)
        {
            dataGridViewCriterions.Rows.RemoveAt(DeletedRow.Index);
            task.DeleteField(DeletedRow.Index);
            matrixsCompare.Remove(DeletedRow.Cells[0].Value.ToString());

        }

        public void AddOption(string newOptionName)
        {
            options.Add(newOptionName);
            dataGridViewOptions.Rows.Add(newOptionName);
            matrixsCompare.Values.ToList().ForEach(x => x.AddField(newOptionName));
        }
        public void UpdateOption(DataGridViewCell selectedCell)
        {
            string newOptionName = selectedCell.Value.ToString();
            options[selectedCell.RowIndex] = newOptionName;
            matrixsCompare.Values.ToList().ForEach(x => x.fields[selectedCell.RowIndex] = newOptionName);
        }
        public void DeleteOption(DataGridViewRow DeletedOption)
        {
            int indexDeletedOption = DeletedOption.Index;
            dataGridViewOptions.Rows.RemoveAt(indexDeletedOption);
            matrixsCompare.Values.ToList().ForEach(x => x.DeleteField(indexDeletedOption));
            options.RemoveAt(indexDeletedOption);
        }

        private void UpdateDataGridView(DataGridView dataGridView, matrixTable table,bool clear=true)
        {
            if (clear==true)
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
           if(table!=null)
            if (table.fields.Count > 0)
            {
                table.fields.ForEach(x => dataGridView.Columns.Add(x, x));
                for (int i = 0; i < table.CountFiields(); i++)
                    { 
                        dataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                        dataGridView.Rows.Add();
                        dataGridView.Rows[i].HeaderCell.Value = table.fields[i];
                    }
                    dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
                    dataGridView.TopLeftHeaderCell.Value = table.name;


                    for (int i = 0; i < dataGridView.RowCount; i++)
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            dataGridView.Rows[i].Cells[j].ValueType = typeof(DataGridViewComboBoxCell);
                            dataGridView.Rows[i].Cells[j] = GetDataGridViewComboBoxCell();

                            if (table.GetCellMatrix(i, j) % 1 == 0)
                                dataGridView.Rows[i].Cells[j].Value = scalesInt[Convert.ToInt32(table.GetCellMatrix(i, j))].ToString();
                            else
                                dataGridView.Rows[i].Cells[j ].Value = scalesInt[-1].ToString();

                            if (i == j)
                            {
                                dataGridView.Rows[i].Cells[j].Value = scalesInt[1].ToString();
                                dataGridView.Rows[i].Cells[j].ReadOnly = true;
                            }
                        };

                }
        }
        public void UpdateDataGridView(DataGridView dataGridView, Vector<double> vector, string newColumnName, bool clear=true)
        {
            if ((vector != null) && (newColumnName != null) && (newColumnName != string.Empty))
            {
                if (clear == true)
                {
                    dataGridView.Rows.Clear();
                    dataGridView.Columns.Clear();
                }

                dataGridView.Columns.Add(newColumnName, newColumnName);
                dataGridView.Columns[dataGridView.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

                int RowsCount = dataGridView.Rows.Count;
                for (int i = 0; i < vector.Count; i++)
                {
                    dataGridView.Rows[i].Cells[RowsCount - 1].ValueType = typeof(double);
                    dataGridView.Rows[i].Cells[RowsCount - 1].Value = vector[i];
                    dataGridView.Rows[i].Cells[RowsCount - 1].ReadOnly = true;
                }
            }
        }
        private void UpdateMatrix(matrixTable table,DataGridView dataGridView)
        {
            double valueCells = 0;
            for (int i = 0; i < dataGridView.RowCount; i++)
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    valueCells = scalesString[dataGridView.Rows[i].Cells[j].Value.ToString()];
                    if (valueCells == -1)
                        valueCells = 1.0 /(scalesString[dataGridView.Rows[j].Cells[i].Value.ToString()]);

                        table.matrix[i, j] = valueCells;
                }
                 

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(task!=null)
            labelIdealizeResultHeader.Text=calculations.CalcGlobalDistributedPriority(calculations.GetVectorPriority(task.matrix), matrixsCompare.Values.ToList().Select(x => x.matrix).ToList()).ToString();
            else
                MessageBox.Show("Необходимо создать цель");
            
        }


        private void dataGridViewCriterions_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow DeletedRow = dataGridViewCriterions.CurrentRow;
            if((e.KeyCode == Keys.Delete) && (DeletedRow != null))
            {
                DeleteCriterion(DeletedRow);              
            }
        }
        private void dataGridViewOptions_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow DeletedRow = dataGridViewOptions.CurrentRow;
            if ((e.KeyCode == Keys.Delete)&&(DeletedRow!=null))
            {
                DeleteOption(DeletedRow);
            }
        }


        private void comboBoxCompare_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedMatrix != string.Empty)
                UpdateMatrix(matrixsCompare[selectedMatrix], dataGridViewCompare);

                selectedMatrix = comboBoxCompare.Text;
                UpdateDataGridView(dataGridViewCompare, matrixsCompare[selectedMatrix]);
            
        }
        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((selectedtabIndex == 1)&&(selectedMatrix!=string.Empty))
            {
                UpdateMatrix(matrixsCompare[selectedMatrix], dataGridViewCompare);
            }
            if (selectedtabIndex == 2)
            {
                UpdateMatrix(task,dataGridViewTaskCompare);
            }
            

            if (tab.SelectedTab == tabOptions)
            {
                dataGridViewOptions.Rows.Clear();
                if (task != null)
                {
                    options.ForEach(x => dataGridViewOptions.Rows.Add(x));
                }
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
                if (task != null)
                    task.fields.ForEach(x => comboBoxCompare.Items.Add(x));
                 
            }
            if (tab.SelectedTab == tabTask)
            {
                dataGridViewTaskCompare.Rows.Clear();
                if (task != null)
                    UpdateDataGridView(dataGridViewTaskCompare, task);
            }
            selectedtabIndex = tab.SelectedIndex;
        }

        private void dataGridViewTaskCompare_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //если ячейка выбрана
            if (dataGridViewTaskCompare.SelectedCells.Count > 0)
            {
                DataGridViewCell selectedCell = dataGridViewTaskCompare.SelectedCells[0];
                //если не первый столбец(там заголовки) и не диагональные элементы
                if ((selectedCell.ColumnIndex > 0) && (selectedCell.RowIndex != selectedCell.ColumnIndex - 1))
                    dataGridViewTaskCompare.Rows[selectedCell.ColumnIndex - 1].Cells[selectedCell.RowIndex + 1].Value = scalesInt[-1];

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
                UpdateCriterion(dataGridViewCriterions.SelectedCells[0]);               
            }
        }
        private void dataGridViewOptions_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewOptions.SelectedCells.Count > 0)
            {
                UpdateOption(dataGridViewOptions.SelectedCells[0]);
            }
        }


        private void buttonAddTask_Click(object sender, EventArgs e)
        {
            string taskName = String.Empty;
            if (task == null)
            {             
                if (InputBoxs.InputBox("Создать цель", "Введите название цели", ref taskName)!= DialogResult.Cancel)
                task = new matrixTable(taskName);
                labelSelectedTask.Text = taskName;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Цель уже была создана, удалить предыдущую?","Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    matrixsCompare.Clear();
                    dataGridViewTaskCompare.Rows.Clear();
                    dataGridViewTaskCompare.Columns.Clear();
                    comboBoxCompare.Items.Clear();
                    selectedMatrix = string.Empty;
                    if (InputBoxs.InputBox("Создать цель", "Введите название цели", ref taskName) != DialogResult.Cancel)
                        task = new matrixTable(taskName);
                    labelSelectedTask.Text = taskName;
                }
            }
          
        }
        private void buttonAddCriterion_Click(object sender, EventArgs e)
        {
            if (task != null)
            {
                string newCriterionName="";
                if (InputBoxs.InputBox("Добавить критерий", "Введите критерий", ref newCriterionName) == DialogResult.Cancel)
                    return;
                if (newCriterionName != String.Empty)
                {
                    if (!task.fields.Contains(newCriterionName))
                    {
                        AddCriterion(newCriterionName);
                    }
                    else
                        MessageBox.Show("Критерий уже существует");
                }
                else
                    MessageBox.Show("Необходимо вести название критерия");
            }
            else
                MessageBox.Show("Необходимо создать цель");

        }
        private void buttonAddOption_Click(object sender, EventArgs e)
        {
            if (task != null)
            {
                if (calculations.GetIndexAgreed(task.matrix) < 0.1)
                {
                    string newOptionName="";
                    if (InputBoxs.InputBox("Добавить объект", "Введите название объекта", ref newOptionName) == DialogResult.Cancel)
                        return;

                    if (newOptionName != String.Empty)
                    {
                        if (!options.Contains(newOptionName))
                        {
                            AddOption(newOptionName);                           
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
                MessageBox.Show("Необходимо создать цель");
        }

        private void buttonSaveTaskInFile_Click(object sender, EventArgs e)
        {         
            if (task != null)
            {
                
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = task.name;
                saveFileDialog.Filter = "CSV|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                SaveTaskInFile(saveFileDialog.FileName);
            }
            else
                MessageBox.Show("Необходимо создать цель");
        }    
        private void buttonLoadTaskFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV|*.csv";
            if (task == null)
            {            
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;
                LoadTaskFromFile(openFileDialog.FileName);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Цель уже была создана, удалить предыдущую?", "Предупреждение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    matrixsCompare.Clear();
                    dataGridViewTaskCompare.Rows.Clear();
                    dataGridViewTaskCompare.Columns.Clear();
                    comboBoxCompare.Items.Clear();
                    selectedMatrix = string.Empty;
                    if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;
                    LoadTaskFromFile(openFileDialog.FileName);                    
                }
              
            }

        }
    }
}
