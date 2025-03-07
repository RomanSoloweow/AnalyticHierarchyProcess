﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamespaceCalculations;
using System.Windows.Forms;
using NamespaceIPresenter;
using System.Data;
using MathNet.Numerics.LinearAlgebra;
using System.Reflection;
using NamespaceIView;
using NamespaceModel;
using NamespaceMatrixIO;
using NamespaceMatrixTable;
using Const = NamespaceConst.Const;

namespace NamespacePresenter
{
    class Presenter : IPresenter
    {
        private IView _view;
        private Model _model;

        private string selectedMatrix = string.Empty;
        private bool result = false;

        private static Dictionary<string,int> CodesErrorsState = new Dictionary<string, int>()
        {
            {"AddCriterion",1},
            {"UpdateCriterion",3},
            {"DeleteCriterion",3},
            {"AddOption",7},
            {"UpdateOption",15},
            {"DeleteOption",15},
            {"UpdateValueCellValueMatrixCompare",79},
            {"UpdateValueCellTaskMatrix",3},
             {"AddTask",32},
            {"SaveTaskInFile",3},
            {"LoadTaskFromFile",32},
            {"SelectMatrixCompare",15},
            {"SelectingMatrixCompare",15},
            {"Calculation",15},
            {"ShowCalculation",31},
        };
        private static Dictionary<string, int> CodesErrorsInputData = new Dictionary<string, int>()
        {
            {"AddCriterion",3},
            {"UpdateCriterion",3},
            {"DeleteCriterion",9},
            {"AddOption",5},
            {"UpdateOption",5},
            {"DeleteOption",17},
            {"UpdateValueCellValueMatrixCompare",1},
            {"UpdateValueCellTaskMatrix",1},            
            {"AddTask",1},
            {"SaveTaskInFile",0},
            {"LoadTaskFromFile",0},
            {"SelectMatrixCompare",9},
            {"SelectingMatrixCompare",9},
            {"Calculation",0},
            {"ShowCalculation",0},
        };
        private static Dictionary<string, int> CodesErrorsIndexs = new Dictionary<string, int>()
        {
            {"AddCriterion",0},
            {"UpdateCriterion",1},
            {"DeleteCriterion",1},
            {"AddOption",0},
            {"UpdateOption",2},
            {"DeleteOption",2},
            {"UpdateValueCellValueMatrixCompare",48},
            {"UpdateValueCellTaskMatrix",12},
             {"AddTask",0},
            {"SaveTaskInFile",0},
            {"LoadTaskFromFile",0},
            {"SelectMatrixCompare",0},
            {"SelectingMatrixCompare",0},
            {"Calculation",0},
            {"ShowCalculation",0},
        };

        private DataTable MatrixToDataTable(MatrixTable matrix)
        {
          
            DataTable table = new DataTable();

            if (matrix == null)
                return table;
            table.TableName = matrix?.name;
            matrix.fields.ForEach(field => table.Columns.Add(field));

            for (int i = 0; i < matrix.matrix.RowCount; i++)
                for (int j = 0; j < matrix?.matrix.ColumnCount; j++)
                {
                    table.Rows.Add();
                    table.Rows[i][j] = Const.Scale(matrix.matrix[i, j]);
                }
            return table;
        }
        private List<string> VectorToList(Vector<double> vector)
        {
            if (vector == null)
                return null;
            return vector.ToList().Select(number => number.ToString()).ToList();
        }

        private bool HaveErrorsState(string functionName,bool mute = false)
        {
            int codeError = CodesErrorsState[functionName];
            string textError = String.Empty;

            if (codeError < 1)
                return false;
            
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
            else if (((codeError & 8) > 0) && (_model.matrixsCompare.Values.First().matrix == null))
            {
                textError = "Необходимо добавить объекты";
            }
            else if (((codeError & 16) > 0) && ((!result) || (_model.NormResult == null) || (_model.IdealResult == null)))
            {
                textError = "Необходимо провести расчеты";
            }
            else if(((codeError & 32) > 0) && (_model.task!= null))
            {
                textError = "Цель уже существует";
            }
            else if (((codeError & 64) > 0) && (string.IsNullOrEmpty(selectedMatrix)))
            {
                textError = "Матрица не выбрана";
            }
            if (textError != String.Empty)
            {
                if (!mute)
                    _view.ShowError(textError);
                return true;
            }
            return false;
        }
        private bool HaveErrorsInputData(string functionName, string newValue = null,bool mute = false)
        {
            int codeError = CodesErrorsInputData[functionName];
            string textError = String.Empty;

            if (codeError < 1)
                return false;

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
        private bool HaveErrorsIndexs(string functionName, int indexRow = -1, int indexColumn = -1, bool mute = false)
        {
            int codeError = CodesErrorsIndexs[functionName];
            string textError = String.Empty;

            if (codeError < 1)
                return false;

            if (((codeError & 1) > 0) && ((indexRow < 0) || (_model.task.fields.Count < indexRow)))
            {
                textError = "Ошибка в работе с матрицей Критерив";
            }
            if (((codeError & 2) > 0) && ((indexRow < 0) || (_model.matrixsCompare.Keys.Count < indexRow)))
            {
                textError = "Ошибка в работе с матрицей Объектов";
            }
            if (((codeError & 4) > 0) && ((indexRow < 0) || (_model.task.matrix.RowCount < indexRow)))
            {
                textError = "Ошибка в работе с матрицей Цели";
            }
            else if (((codeError & 8) > 0) && ((indexColumn < 0) || (_model.task.matrix.ColumnCount < indexColumn)))
            {
                textError = "Ошибка в работе с матрицей Цели";
            }
            else if (((codeError & 16) > 0) && ((indexRow < 0) || (_model.matrixsCompare[selectedMatrix].matrix.ColumnCount < indexRow)))
            {
                textError = "Ошибка в работе с матрицей Сравнений";
            }
            else if (((codeError & 32) > 0) && ((indexColumn < 0) || (_model.matrixsCompare[selectedMatrix].matrix.ColumnCount < indexColumn)))
            {
                textError = "Ошибка в работе с матрицей Сравнений";
            }

            if (textError != String.Empty)
            {
                textError = "Ошибка в работе с матрицей " + textError;
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
            string functionName = MethodInfo.GetCurrentMethod().Name;

            if (HaveErrorsState(functionName))
                return false;

            nameNewCriterion = _view.GetStringValue("Создать критерий", "Введите критерий");

            if (HaveErrorsInputData(functionName, nameNewCriterion))
                return false;

            _model.task.AddField(nameNewCriterion);
            _model.matrixsCompare.Add(nameNewCriterion, new MatrixTable(nameNewCriterion, _model.options));

            _view.AddCriterion(nameNewCriterion);
            _view.addCriterionInList(nameNewCriterion);
            _view.ExpandMatrixTask(nameNewCriterion);

            result = false;
            return true;
        }
        public bool UpdateCriterion(int indexRow, string nameNewCriterion)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) ||HaveErrorsIndexs(functionName, indexRow)|| (_model.task.fields[indexRow] == nameNewCriterion))
                return false;


           while(HaveErrorsInputData(functionName, nameNewCriterion))
                nameNewCriterion += indexRow.ToString();

            _model.task.fields[indexRow] = nameNewCriterion;
            string oldkey = _model.matrixsCompare.Keys.ElementAt(indexRow);
            MatrixTable oldvalue = _model.matrixsCompare[oldkey];
            oldvalue.name = nameNewCriterion;
            _model.matrixsCompare.Remove(oldkey);
            _model.matrixsCompare.Add(nameNewCriterion, oldvalue);

            _view.UpdateCriterion(indexRow, nameNewCriterion);
            _view.UpdateCriterionInList(indexRow, nameNewCriterion);

            result = false;
            return true;
        }
        public bool DeleteCriterion(int indexDelitingCriterion)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsIndexs(functionName, indexDelitingCriterion))
                return false;

            _model.task.DeleteField(indexDelitingCriterion);
            _model.matrixsCompare.Remove(_model.matrixsCompare.Keys.ElementAt(indexDelitingCriterion));

            _view.DeleteCriterion(indexDelitingCriterion);
            _view.DeleteCriterionInList(indexDelitingCriterion);

            result = false;
            return true;
        }

        public bool AddOption(string nameNewOption = null)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            nameNewOption = _view.GetStringValue("Создать объект", "Введите объект");

            if (HaveErrorsInputData(functionName, nameNewOption))
                return false;

            _model.options.Add(nameNewOption);
            _model.matrixsCompare.Values.ToList().ForEach(x => x.AddField(nameNewOption));
            _view.AddOption(nameNewOption);
            result = false;
            return true;
        }
        public bool UpdateOption(int indexRow, string optionNewName)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsIndexs(functionName, indexRow) || (_model.task.fields[indexRow] == optionNewName))
                return false;

            while (HaveErrorsInputData(functionName, optionNewName))
                optionNewName += indexRow.ToString();

            _model.options[indexRow] = optionNewName;
            _model.matrixsCompare.Values.ToList().ForEach(x => x.fields[indexRow] = optionNewName);
            _view.UpdateOption(indexRow, optionNewName);
            return true;
        }
        public bool DeleteOption(int indexDelitingOption)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsIndexs(functionName, indexDelitingOption))
                return false;
            _model.matrixsCompare.Values.ToList().ForEach(x => x.DeleteField(indexDelitingOption));
            _model.options.RemoveAt(indexDelitingOption);
            _view.DeleteOption(indexDelitingOption);
            return true;
        }
        public bool UpdateValueCellValueMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsInputData(functionName, newValue: cellValue)||HaveErrorsIndexs(functionName, indexRow, indexColumn))
                return false;


            _model.matrixsCompare[selectedMatrix].SetCellMatrix(indexRow, indexColumn,Const.Scale(cellValue));
            double value = 1.0 / _model.matrixsCompare[selectedMatrix].GetCellMatrix(indexRow, indexColumn);
            _model.matrixsCompare[selectedMatrix].SetCellMatrix(indexRow, indexColumn, value);

            _view.UpdateValueCellValueMatrixCompare(indexColumn, indexRow, Const.Scale(value));
            return true;
        }
        public bool UpdateValueCellTaskMatrix(int indexRow, int indexColumn, string cellValue)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsInputData(functionName, newValue: cellValue) || HaveErrorsIndexs(functionName, indexRow, indexColumn))
                return false;

            _model.task.SetCellMatrix(indexRow, indexColumn, Const.Scale(cellValue));
            double value = 1.0 / _model.task.GetCellMatrix(indexRow, indexColumn);
            _model.task.SetCellMatrix(indexColumn, indexRow, value);

            _view.UpdateValueCellTaskMatrix(indexColumn, indexRow, Const.Scale(_model.task.matrix[indexColumn, indexRow]));
            return true;
        }
       


        public bool AddTask()
        {

            string functionName =  MethodInfo.GetCurrentMethod().Name;
             
            if ((HaveErrorsState(functionName, mute:true)) && (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            string nameNewTask = _view.GetStringValue("Создать цель", "Введите цель");

            if (HaveErrorsInputData(functionName, nameNewTask))
                return false;

            selectedMatrix = string.Empty;
            _model.task = new MatrixTable(nameNewTask);

            result = false;
            return true;
        }
        public bool SaveTaskInFile()
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;
            
            MatrixIO.SaveInFile(_model.task);
            return true;
        }
        public bool LoadTaskFromFile()
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if ((HaveErrorsState(functionName))&& (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            _model.matrixsCompare.Clear();
            _model.task = null;

            _model.task = MatrixIO.LoadFromFile();

    

            _model.task?.fields.ForEach(x => _model.matrixsCompare.Add(x, new MatrixTable(x, _model.options)));
            selectedMatrix = _model.task?.name;
            _view.OuputMatrixTask(MatrixToDataTable(_model.task));
            result = false;
            return true;
        }

        public bool SelectMatrixCompare(string SelectedMatrixCompareName)
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) ||HaveErrorsInputData(functionName, SelectedMatrixCompareName,mute:true))
                return false;

            selectedMatrix = SelectedMatrixCompareName;
            _view.OuputMatrixCompare(MatrixToDataTable(_model.matrixsCompare[selectedMatrix]));
            return true;
        }
        public bool SelectingMatrixCompare()
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            return true;
        }
        public bool Calculation()
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            _model.NormResult = Calculations.CalcGlobalDistributedPriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());
            _model.IdealResult = Calculations.CalcGlobalIdealizePriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());

            result = true;
            return true;
        }
        public bool ShowCalculation()
        {
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            _view.OuputCalculationsResult(_model.options[_model.NormResult.MaximumIndex()], _model.options[_model.IdealResult.MaximumIndex()]);
            _view.OuputVectorCalculations(VectorToList(_model.IdealResult), "IdealResult");
            _view.OuputVectorCalculations(VectorToList(_model.NormResult), "NormResult");
            return true;
        }
    }
}
