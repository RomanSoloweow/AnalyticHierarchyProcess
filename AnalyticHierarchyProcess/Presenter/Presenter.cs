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
using System.Data;
using MathNet.Numerics.LinearAlgebra;
using Const = NamespaceConst.Const;
namespace NamespacePresenter
{
    class Presenter : IPresenter
    {

        private IView _view;
        private Model _model;

        private string selectedMatrix = string.Empty;
        private bool result = false;

        private DataTable MatrixToDataTable(MatrixTable matrix)
        {
            DataTable table = new DataTable();
            table.TableName = matrix.name;
            matrix.fields.ForEach(field => table.Columns.Add(field));

            for (int i = 0; i < matrix.matrix.RowCount; i++)
                for (int j = 0; j < matrix.matrix.ColumnCount; j++)
                {
                    table.Rows.Add();
                    table.Rows[i][j] = Const.Scale(matrix.matrix[i, j]);
                }
            return table;
        }
        private List<string> VectorToList(Vector<double> vector)
        {
            return vector.ToList().Select(number => number.ToString()).ToList();
        }

        private bool HaveErrorsState(int codeError, bool mute = false)
        {
            string textError = String.Empty;
            if (((codeError & 1) > 0) && (_model.task == null))
            {
                textError = "Необходимо создать цель";
            }
            else if (((codeError & 2) > 0) && (_model.task.fields.Count < 1))
            {
                textError = "Необходимо добавить критерии";
            }
            else if (((codeError & 4) > 0) && (Calculations.GetIndexAgreed(_model.task.matrix) > 0.1))
            {
                textError = "Цель должна быть согласованна";
            }
            else if (((codeError & 8) > 0) && (_model.matrixsCompare.Count < 1))
            {
                textError = "Необходимо добавить объекты";
            }
            else if (((codeError & 16) > 0) && ((!result) || (_model.NormResult != null) || (_model.IdealResult != null)))
            {
                textError = "Необходимо провести расчеты";
            }


            if (textError != String.Empty)
            {
                if (!mute)
                    _view.ShowError(textError);
                return true;
            }
            return false;
        }
        private bool HaveErrorsInputData(int codeError, string newValue = null, int indexRow = -1, int indexColumn = -1,bool mute = false)
        {
            string textError = String.Empty;
            if (((codeError & 1) > 0) && (string.IsNullOrEmpty(newValue)))
            {
                textError = "Необходимо вести значение";
            }
            else if (((codeError & 2) > 0) && (_model.task.fields.Contains(newValue)))
            {
                textError = "Критерий уже существует";
            }
            else if (((codeError & 4) > 0) && (_model.options.Contains(newValue)))
            {
                textError = "Объект уже существует";
            }
            else if (((codeError & 8) > 0) && (!_model.task.fields.Contains(newValue)))
            {
                textError = "Критерий не  существует";
            }
            else if (((codeError & 16) > 0) && (!_model.options.Contains(newValue)))
            {
                textError = "Объект не существует";
            }
           

            if (textError != String.Empty)
            {
                if (!mute)
                    _view.ShowError(textError);
                return true;
            }
            return false;
        }
        private bool HaveErrorsIndexs(int codeError, int indexRow = -1, int indexColumn = -1, bool mute = false)
        {
            string textError = String.Empty;
            if (((codeError & 1) > 0) && ((indexRow < 0) || (_model.task.matrix.RowCount < indexRow)))
            {
                textError = "Ошибка в работе с матрицей Цели";
            }
            else if (((codeError & 2) > 0) && ((indexColumn < 0) || (_model.task.matrix.ColumnCount < indexColumn)))
            {
                textError = "Ошибка в работе с матрицей Цели";
            }
            else if (((codeError & 4) > 0) && ((indexRow < 0) || (_model.matrixsCompare[selectedMatrix].matrix.ColumnCount < indexRow)))
            {
                textError = "Ошибка в работе с матрицей Сравнений";
            }
            else if (((codeError & 8) > 0) && ((indexColumn < 0) || (_model.matrixsCompare[selectedMatrix].matrix.ColumnCount < indexColumn)))
            {
                textError = "Ошибка в работе с матрицей Сравнений";
            }

            if (textError != String.Empty)
            {
                if (!mute)
                    _view.ShowError(textError);
                return true;
            }
            return false;
        }


        public Presenter(Model model, IView view)
        {
            _model = model;
            _view = view;
        }
        public bool AddCriterion(string nameNewCriterion = null)
        {
            if (HaveErrorsState(1))
                return false;

            nameNewCriterion = _view.GetStringValue("Создать критерий", "Введите критерий");

            if (HaveErrorsInputData(3, nameNewCriterion))
                return false;

            _model.task.AddField(nameNewCriterion);
            _model.matrixsCompare.Add(nameNewCriterion, new MatrixTable(nameNewCriterion, _model.options));
            _view.AddCriterion(nameNewCriterion);
            result = false;
            return true;
        }
        public bool UpdateCriterion(int indexRow, string nameNewCriterion = null)
        {
            if (HaveErrorsState(3) || HaveErrorsInputData(3, nameNewCriterion))
                return false;

            _model.task.fields[indexRow] = nameNewCriterion;
            string oldkey = _model.matrixsCompare.Keys.ElementAt(indexRow);
            MatrixTable oldvalue = _model.matrixsCompare[oldkey];
            oldvalue.name = nameNewCriterion;
            _model.matrixsCompare.Remove(oldkey);
            _model.matrixsCompare.Add(nameNewCriterion, oldvalue);

            _view.UpdateCriterion(indexRow, nameNewCriterion);
            result = false;
            return true;
        }
        public bool DeleteCriterion(int indexDelitingCriterion)
        {
            _model.task.DeleteField(indexDelitingCriterion);
            _model.matrixsCompare.Remove(_model.matrixsCompare.Keys.ElementAt(indexDelitingCriterion));
            _view.DeleteCriterion(indexDelitingCriterion);
            result = false;
            return true;
        }

        public bool AddOption(string nameNewOption = null)
        {

            if (HaveErrorsState(7))
                return false;

            nameNewOption = _view.GetStringValue("Создать объект", "Введите объект");

            if (HaveErrorsInputData(5, nameNewOption))
                return false;

            _model.options.Add(nameNewOption);
            _model.matrixsCompare.Values.ToList().ForEach(x => x.AddField(nameNewOption));
            _view.AddOption(nameNewOption);
            result = false;
            return true;
        }
        public bool UpdateOption(int indexRow, string optionNewName)
        {
            //проверить на пустоту
            _model.options[indexRow] = optionNewName;
            _model.matrixsCompare.Values.ToList().ForEach(x => x.fields[indexRow] = optionNewName);
            _view.UpdateOption(indexRow, optionNewName);
            return true;
        }
        public bool DeleteOption(int indexDelitingOption)
        {
            _model.matrixsCompare.Values.ToList().ForEach(x => x.DeleteField(indexDelitingOption));
            _model.options.RemoveAt(indexDelitingOption);
            _view.DeleteOption(indexDelitingOption);
            return true;
        }
        public bool UpdateValueCellValueMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            if (HaveErrorsState(7) || HaveErrorsInputData(193, newValue: cellValue, indexRow: indexRow, indexColumn: indexColumn))
                return false;


            _model.matrixsCompare[selectedMatrix].matrix[indexRow, indexColumn] = Const.Scale(cellValue);
            _model.matrixsCompare[selectedMatrix].matrix[indexColumn, indexRow] = 1 / _model.task.matrix[indexColumn, indexRow];
            _view.UpdateValueCellValueMatrixCompare(indexColumn, indexRow, Const.Scale(_model.matrixsCompare[selectedMatrix].matrix[indexColumn, indexRow]));
            return true;
        }
        public bool UpdateValueCellTaskMatrix(int indexRow, int indexColumn, string cellValue)
        {
            if (HaveErrorsState(3)||HaveErrorsInputData(49,newValue:cellValue,indexRow: indexRow,indexColumn: indexColumn))
                return false;

            _model.task.matrix[indexRow, indexColumn] = Const.Scale(cellValue);
            _model.task.matrix[indexColumn, indexRow] = 1 / _model.task.matrix[indexColumn, indexRow];
            _view.UpdateValueCellTaskMatrix(indexColumn, indexRow, Const.Scale(_model.task.matrix[indexColumn, indexRow]));
            return true;
        }
       


        public bool AddTask()
        {
            if ((!HaveErrorsState(1,mute:true)) && (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            string nameNewTask = _view.GetStringValue("Создать цель", "Введите цель");

            if (HaveErrorsInputData(1, nameNewTask))
                return false;

            selectedMatrix = string.Empty;
            _model.task = new MatrixTable(nameNewTask);

            result = false;
            return true;
        }
        public bool SaveTaskInFile()
        {
            if (HaveErrorsState(1))
                return false;
            
            MatrixIO.SaveInFile(_model.task);
            return true;
        }
        public bool LoadTaskFromFile()
        {           
            if ((!HaveErrorsState(1))&& (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            _model.matrixsCompare.Clear();
            _model.task = null;

            _model.task = MatrixIO.LoadFromFile();

            if(HaveErrorsState(1))
                return false;

            _model.task.fields.ForEach(x => _model.matrixsCompare.Add(x, new MatrixTable(x, _model.options)));
            selectedMatrix = _model.task.name;
            _view.OuputTaskMatrix(MatrixToDataTable(_model.task));
            result = false;
            return true;
        }

        public bool SelectMatrixCompare(string SelectedMatrixCompareName)
        {
            if (!HaveErrors(64))
                return false;

            selectedMatrix = SelectedMatrixCompareName;
            _view.OuputMatrixCompare(MatrixToDataTable(_model.matrixsCompare[selectedMatrix]));
            return true;
        }
        public bool SelectingMatrixCompare()
        {
            if (HaveErrors(7))
                return false;

            return true;
        }
        public bool Calculation()
        {
            if (HaveErrors(7))
                return false;

            _model.NormResult = Calculations.CalcGlobalDistributedPriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());
            _model.IdealResult = Calculations.CalcGlobalIdealizePriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());

            if ((_model.NormResult == null) || (_model.IdealResult == null))
                return false;

            result = true;
            _view.OuputCalculationsResult(_model.options[_model.NormResult.MaximumIndex()], _model.options[_model.IdealResult.MaximumIndex()]);
            return true;
        }
        public bool ShowCalculation()
        {
            if (HaveErrors(128))
                return false;
            
            if ((_model.NormResult != null) && (_model.IdealResult != null))
            {
                _view.OuputVectorCalculations(VectorToList(_model.IdealResult), "IdealResult");
                _view.OuputVectorCalculations(VectorToList(_model.NormResult), "NormResult");
            }
            return true;
        }

        /*это для матрицы
         *if (table.GetCellMatrix(i, j) % 1 == 0)
                   dataGridView.Rows[i].Cells[j].Value = scalesInt[Convert.ToInt32(table.GetCellMatrix(i, j))].ToString();
               else
                   dataGridView.Rows[i].Cells[j].Value = scalesInt[-1].ToString();*/

        //if (i == j)
        //   dataGridView.Rows[i].Cells[j].ReadOnly = true;
    }
}
