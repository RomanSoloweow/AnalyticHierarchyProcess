using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamespaceIView;
using NamespaceModel;
using NamespaceMatrixIO;
using NamespaceMatrixTable;
using NamespaceMatrixDataGridView;
using NamespaceCalculations;
using System.Windows.Forms;
namespace NamespacePresenter
{
    class Presenter
    {
        private IView _view;
        private Model _model;

        private string selectedMatrix = string.Empty;
        private int selectedtabIndex = 0;
        private bool result = false;
        private bool calc = false;

        public Presenter(Model model,IView view)
        {
            _model = model;
            _view = view;          
        }
        public bool LoadTaskFromFile()
        {
            if ((HaveErrors(1, null, true)) || (!HaveErrors(1, null, true) && (MessageBox.Show("Цель уже была создана, удалить предыдущую?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)))
            {
                _model.matrixsCompare.Clear();
                //dataGridViewTaskCompare.Rows.Clear();
               // dataGridViewTaskCompare.Columns.Clear();
                //comboBoxCompare.Items.Clear();


                selectedMatrix = string.Empty;
                _model.task = MatrixIO.LoadFromFile();
                _model.task.fields.ForEach(x => _model.matrixsCompare.Add(x, new MatrixTable(x, _model.options)));

                // GMIKE MatrixDataGridView.UpdateDataGridView(dataGridViewTaskCompare, _model.task);
                //labelSelectedTask.Text = _model.task.name;
                result = false;
                return true;
            }
            else
                return false;
        }
        public void SaveTaskInFile()
        {
            if (!HaveErrors(1))
            {
               //GMIKE MatrixDataGridView.UpdateMatrix(_model.task, dataGridViewTaskCompare);
                MatrixIO.SaveInFile(_model.task);
            }
        }
        bool HaveErrors(int code, string nameNewObject = null, bool mute = false)
        {
            string textError = String.Empty;
            if (((code & 1) > 0) && (_model.task == null))
            {
                textError = "Необходимо создать цель";
            }
            else if (((code & 2) > 0) && (_model.task.fields.Count < 1))
            {
                textError = "Необходимо добавить критерии";
            }
            else if (((code & 4) > 0) && (Calculations.GetIndexAgreed(_model.task.matrix) > 0.1))
            {
                textError = "Цель должна быть согласованна";
            }
            else if (((code & 8) > 0) && (nameNewObject == String.Empty))
            {
                textError = "Необходимо вести название";
            }
            else if (((code & 16) > 0) && (_model.task.fields.Contains(nameNewObject)))
            {
                textError = "Критерий уже существует";
            }
            else if (((code & 32) > 0) && (_model.options.Contains(nameNewObject)))
            {
                textError = "Объект уже существует";
            }
            else if (((code & 64) > 0) && (_model.options.Count < 1))
            {
                textError = "Таблица пуста. Необходимо добавить объекты для сравнения";
            }
            else if (((code & 128) > 0) && (!result))
            {
                textError = "Необходимо провести расчеты";
            }
            if (textError != String.Empty)
            {
                if (!mute)
                    MessageBox.Show(textError);

                return true;
            }
            return false;
        }
        public void AddTask(string NewTaskName)
        {
            // GMIKE _model.matrixsCompare.Clear();
            // GMIKE dataGridViewTaskCompare.Rows.Clear();
            // GMIKE dataGridViewTaskCompare.Columns.Clear();
            // GMIKE comboBoxCompare.Items.Clear();

            selectedMatrix = string.Empty;

            _model.task = new MatrixTable(NewTaskName);
            //labelSelectedTask.Text = NewTaskName;
            result = false;
        }
        public void UpdateOptions()
        {
            // GMIKE dataGridViewOptions.Rows.Clear();
            // GMIKE dataGridViewOptions.Columns.Clear();
            // GMIKE labelNormResult.Text = String.Empty;
            // GMIKE labelIdealResult.Text = String.Empty;
            // GMIKE dataGridViewOptions.Columns.Add("Объекты", "Объекты");
            // GMIKE dataGridViewOptions.Columns[dataGridViewOptions.Columns.Count - 1].SortMode = DataGridViewColumnSortMode.NotSortable;

            if (_model.task != null)
            {
                // GMIKE _model.options.ForEach(x => dataGridViewOptions.Rows.Add(x));
                // GMIKE if (result)
                // GMIKE buttonGetResult_Click(null, null);

            }

        }
        public void AddCriterion(string newCriterionName)
        {
            _model.task.AddField(newCriterionName);
            _model.matrixsCompare.Add(newCriterionName, new MatrixTable(newCriterionName, _model.options));
            // GMIKE dataGridViewCriterions.Rows.Add(newCriterionName);
            result = false;
        }

        public bool UpdateCriterion(DataGridViewCell selectedCell)
        {
            if (selectedCell.Value == null)
            {
                selectedCell.Value = "Критерий " + selectedCell.RowIndex.ToString();
                // GMIKE dataGridViewCriterions.Rows[selectedCell.RowIndex].Cells[selectedCell.ColumnIndex].Value = selectedCell.Value;
            }

            string newCriterionName = selectedCell.Value.ToString();
            _model.task.fields[selectedCell.RowIndex] = newCriterionName;
            string oldkey = _model.matrixsCompare.Keys.ToList()[selectedCell.RowIndex];
            MatrixTable oldvalue = _model.matrixsCompare[oldkey];
            oldvalue.name = newCriterionName;
            _model.matrixsCompare.Remove(oldkey);
            _model.matrixsCompare.Add(newCriterionName, oldvalue);
            result = false;
            return true;
        }
        public bool DeleteCriterion(DataGridViewCell deletingCell)
        {
            // GMIKE dataGridViewCriterions.Rows.RemoveAt(DeletedRow.Index);
            string nameDeletintCell = deletingCell.Value.ToString();
            _model.task.DeleteField(nameDeletintCell);
            _model.matrixsCompare.Remove(nameDeletintCell);
            result = false;
            return true;
        }

        public void AddOption(string newOptionName)
        {
            result = false;
            _model.options.Add(newOptionName);
            _model.matrixsCompare.Values.ToList().ForEach(x => x.AddField(newOptionName));
            UpdateOptions();
        }
        public bool UpdateOption(DataGridViewCell selectedCell)
        {
            string newOptionName = "";
            if (selectedCell.Value != null)
                newOptionName = selectedCell.Value.ToString();
            else
                newOptionName = "Объект " + selectedCell.RowIndex.ToString();

            _model.options[selectedCell.RowIndex] = newOptionName;
            _model.matrixsCompare.Values.ToList().ForEach(x => x.fields[selectedCell.RowIndex] = newOptionName);
            UpdateOptions();
            return true;
        }
        public bool DeleteOption(DataGridViewCell DeletingOption)
        {
            string deletingOptionName = DeletingOption.Value.ToString();
            _model.matrixsCompare.Values.ToList().ForEach(x => x.DeleteField(deletingOptionName));
            _model.options.Remove(deletingOptionName);
            UpdateOptions();
            return true;
        }

        public bool ShowCalc()
        {
            if (HaveErrors(128))
                return false;

            if ((_model.NormResult != null) && (_model.IdealResult != null))
            {
                calc = true;
                // GMIKE MatrixDataGridView.UpdateDataGridView(dataGridViewOptions, _model.IdealResult, "Идеализированные приоритеты", false);
                // GMIKE MatrixDataGridView.UpdateDataGridView(dataGridViewOptions, _model.NormResult, "Нормированные приоритеты", false);
                calc = false;
            }
            return true;
        }
        public bool Calc()
        {
            if (HaveErrors(1))
                return false;

            _model.NormResult = Calculations.CalcGlobalDistributedPriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());
            _model.IdealResult = Calculations.CalcGlobalIdealizePriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());
            if ((_model.NormResult != null) && (_model.IdealResult != null))
            {
                result = true;
                // GMIKE  labelNormResult.Text = _model.options[_model.NormResult.MaximumIndex()].ToString();
                // GMIKE labelIdealResult.Text = _model.options[_model.IdealResult.MaximumIndex()].ToString();
                return true;
            }

            return false;
        }


        // Presenter(IView view);
    }
}
