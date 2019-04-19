using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamespaceIView;
using NamespaceModel;
using NamespaceMatrixIO;
using NamespaceMatrixTable;
using NamespaceWorkWithGridView;
using NamespaceCalculations;
using System.Windows.Forms;
using NamespaceIPresenter;
namespace NamespacePresenter
{
    class Presenter:IPresenter
    {
        private IView _view;
        private Model _model;
    
        private string selectedMatrix = string.Empty;
        private int selectedtabIndex = 0;
        private bool result = false;
        private bool calc = false;

        public Presenter(Model model, IView view)
        {
            _model = model;
            _view = view;
        }
        public bool AddCriterion(string newCriterionName)
        {
            _model.task.AddField(newCriterionName);
            _model.matrixsCompare.Add(newCriterionName, new MatrixTable(newCriterionName, _model.options));
            result = false;
            _view.AddCriterion(newCriterionName);
            return true;
        }
        public bool UpdateCriterion(int indexRowstring, string criterionNewName)
        {
            return true;
        }
        public bool DeleteCriterion(int indexDelitingCriterion)
        {
            _model.task.DeleteField(indexDelitingCriterion);
            _model.matrixsCompare.Remove(_model.matrixsCompare.Keys.ElementAt(indexDelitingCriterion));
            result = false;
            _view.DeleteCriterion(indexDelitingCriterion);
            return true;
        }
       
        public bool UpdateOption(int indexRow, string optionNewName)
        {

            /* string newOptionName = "";
       if (selectedCell.Value != null)
           newOptionName = selectedCell.Value.ToString();
       else
           newOptionName = "Объект " + selectedCell.RowIndex.ToString();

       _model.options[selectedCell.RowIndex] = newOptionName;
       _model.matrixsCompare.Values.ToList().ForEach(x => x.fields[selectedCell.RowIndex] = newOptionName);*/
            return true;
        }
        public bool AddOption(string newOptionName)
        {
            result = false;
            _model.options.Add(newOptionName);
            _model.matrixsCompare.Values.ToList().ForEach(x => x.AddField(newOptionName));
            UpdateOptions();
            return true;
        }
        public bool DeleteOption(int indexDelitingOption)
        {
            _model.matrixsCompare.Values.ToList().ForEach(x => x.DeleteField(indexDelitingOption));
            _model.options.RemoveAt(indexDelitingOption);
            UpdateOptions();
            return true;
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
        public bool DeleteCriterion(string delitingCriterionName)
        {
            // GMIKE dataGridViewCriterions.Rows.RemoveAt(DeletedRow.Index);
            _model.task.DeleteField(delitingCriterionName);
            _model.matrixsCompare.Remove(delitingCriterionName);
            result = false;
            return true;
        }

        public bool SetValueCellMatrixCompare(int indexRow, int indexColumn, double cellValue)
        {
            return true;
        }
        public bool SetValueCellTaskMatrixCompare(int indexRow, int indexColumn, double cellValue)
        {
            return true;
        }




        public bool AddTask(string newTaskName)
        {

            // if ((HaveErrors(1,null, true))||(!HaveErrors(1, null, true)&&(MessageBox.Show("Цель уже была создана, удалить предыдущую?", "Предупреждение", MessageBoxButtons.YesNo) == DialogResult.Yes)))
            selectedMatrix = string.Empty;
            _model.task = new MatrixTable(newTaskName);
            result = false;
            return true;
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

        public bool SaveTaskInFile()
        {
            if (HaveErrors(1))
                return false;

            MatrixIO.SaveInFile(_model.task);
            return true;
        }
        public bool LoadTaskFromFile()
        {
            if (!HaveErrors(1, null, true) && (MessageBox.Show("Цель уже была создана, удалить предыдущую?", "Предупреждение", MessageBoxButtons.YesNo) != DialogResult.Yes))
                return false;

                selectedMatrix = string.Empty;
                _model.matrixsCompare.Clear();                
                _model.task = MatrixIO.LoadFromFile();
                _model.task.fields.ForEach(x => _model.matrixsCompare.Add(x, new MatrixTable(x, _model.options)));
                result = false;
                return true;

        }





        public MatrixTable GetTask()
        {
            return _model.task;
        }
    




      

        public  List<string> GetAllCriterionsName()
        {
            return _model.task.fields;
        }
        public List<string> GetAllOptionsName()
        {
            return _model.options;
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


        public bool ShowCalculation()
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
        public bool Calculation()
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
        public bool SelectMatrixCompare(string SelectedMatrixCompareName)
        {
            if (!_model.matrixsCompare.ContainsKey(SelectedMatrixCompareName))
                return false;
            selectedMatrix = SelectedMatrixCompareName;

            //GMIKE вывести выбранную матрицу
            return true;
        }
        public MatrixTable GetMatrixCompare(string matrixCompareName)
        {
            return _model.matrixsCompare[matrixCompareName];
        }
        private bool HaveErrors(int code, string nameNewObject = null, bool mute = false)
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
    }
}
