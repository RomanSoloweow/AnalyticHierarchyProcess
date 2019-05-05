using System;
using System.Collections.Generic;
using System.Linq;
using NamespaceCalculations;
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
        /// <summary>
        /// Имя выбранной матрицы сравнений
        /// </summary>
        private string selectedMatrix = string.Empty;
        /// <summary>
        /// Флаг  корректности расчетов
        /// </summary>
        private bool calculationCorrect = false;

        public Presenter(Model model, IView view)
        {
            _model = model;
            _view = view;
        }
        /// <summary>
        /// Коды ошибок состояний которые нужно проверить для функции
        /// </summary>
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
            {"UpdateTask",1},
            {"DeleteTask",1},
            {"SaveTaskInFile",3},
            {"LoadTaskFromFile",32},
            {"SelectMatrixCompare",15},
            {"SelectingMatrixCompare",15},
            {"Calculation",15},
            {"ShowCalculation",31},
        };
        /// <summary>
        /// Коды ошибок входных данных, которые нужно проверить для функции
        /// </summary>
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
            {"UpdateTask",1},
            {"DeleteTask",0},
            {"SaveTaskInFile",0},
            {"LoadTaskFromFile",0},
            {"SelectMatrixCompare",9},
            {"SelectingMatrixCompare",9},
            {"Calculation",0},
            {"ShowCalculation",0},
        };
        /// <summary>
        /// Коды ошибок индексации, которые нужно проверить для функции
        /// </summary>
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
            {"UpdateTask",0},
            {"DeleteTask",0},
            {"SaveTaskInFile",0},
            {"LoadTaskFromFile",0},
            {"SelectMatrixCompare",0},
            {"SelectingMatrixCompare",0},
            {"Calculation",0},
            {"ShowCalculation",0},
        };
        /// <summary>
        /// Преобразовываем матрицу в таблицу (т.к. view ничего не знает о бизнес модели)
        /// </summary>
        /// <param name="matrix"> Матрица сравнений</param>
        /// <returns>Таблица строк</returns>
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
        /// <summary>
        /// Преобразовываем вектор в список значений (т.к. view ничего не знает о бизнес модели)
        /// </summary>
        /// <param name="vector"> Вектор значений</param>
        /// <returns>Список значений</returns>
        private List<string> VectorToList(Vector<double> vector)
        {
            if (vector == null)
                return null;
            return vector.ToList().Select(number => number.ToString()).ToList();
        }
        /// <summary>
        /// Функция проверки всех ошибок состояния
        /// </summary>
        /// <param name="functionName">Имя функции, для которой проверяем ошибки</param>
        /// <param name="mute">Флаг того, нужно ли выводить ошибку</param>
        /// <returns>Флаг есть ли ошибки</returns>
        private bool HaveErrorsState(string functionName,bool mute = false)
        {
            //Получаем код ошибки для данной функции
            int codeError = CodesErrorsState[functionName];
            string textError = String.Empty;

            if (codeError < 1)
                return false;
            
            if (((codeError & 1) > 0) && (_model.task == null))
            {
                textError = "Необходимо создать цель";
            }
            else if (((codeError & 2) > 0) && (_model.task.CountFiields() < 1))
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
            else if (((codeError & 16) > 0) && ((!calculationCorrect) || (_model.NormResult == null) || (_model.IdealResult == null)))
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
        /// <summary>
        /// Функция проверки всех входных данных
        /// </summary>
        /// <param name="functionName">Имя функции, для которой проверяем ошибки</param>
        /// <param name="newValue">Проверяемое значение</param>
        /// <param name="mute">Флаг того, нужно ли выводить ошибку</param>
        /// <returns>Флаг есть ли ошибки</returns>
        private bool HaveErrorsInputData(string functionName, string newValue = null,bool mute = false)
        {
            //Получаем код ошибки для данной функции
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
        /// <summary>
        /// Функция проверки индексации
        /// </summary>
        /// <param name="functionName">Имя функции, для которой проверяем ошибки</param>
        /// <param name="indexRow">Проверяемый номер строки</param>
        /// <param name="indexColumn">Проверяемый номер столбца</param>
        /// <param name="mute">Флаг того, нужно ли выводить ошибку</param>
        /// <returns>Флаг есть ли ошибки</returns>
        private bool HaveErrorsIndexs(string functionName, int indexRow = -1, int indexColumn = -1, bool mute = false)
        {
            //Получаем код ошибки для данной функции
            int codeError = CodesErrorsIndexs[functionName];
            string textError = String.Empty;

            if (codeError < 1)
                return false;

            if (((codeError & 1) > 0) && ((indexRow < 0) || (_model.task.CountFiields() < indexRow)))
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

        public bool AddTask(string nameNewTask = null)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;

            if ((HaveErrorsState(functionName, mute: true)) && (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            nameNewTask = _view.GetStringValue("Создать цель", "Введите цель");

            if (HaveErrorsInputData(functionName, nameNewTask))
                return false;

            selectedMatrix = string.Empty;
            _model.task = new MatrixTable(nameNewTask);

            calculationCorrect = false;
            _view.AddTask(nameNewTask);
            return true;
        }
        public bool UpdateTask(string nameNewTask = null)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;
            nameNewTask = _view.GetStringValue("Изменить цель", "Введите новое название цели");
            if (HaveErrorsInputData(functionName, nameNewTask))
                return false;
            _model.task.SetName(nameNewTask);
            _view.UpdateTask(nameNewTask);
            return true;
        }
        public bool DeleteTask()
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            for (int i = (_model.options.Count() - 1); i > -1; i--)
                DeleteOption(i);
            for (int i = (_model.task.CountFiields() - 1); i > -1; i--)
                DeleteCriterion(i);
            selectedMatrix = string.Empty;
            calculationCorrect = false;
            if (_model.IdealResult != null)
                _model.IdealResult.Clear();
            if (_model.NormResult != null)
                _model.NormResult.Clear();
            _model.task = null;
            _view.DeleteTask();
            _view.OutputMatrixTask(MatrixToDataTable(_model.task));
            return true;
        }

        public bool AddCriterion(string nameNewCriterion = null)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;

            if (HaveErrorsState(functionName))
                return false;
            //Запрашиваем имя нового критерия
            nameNewCriterion = _view.GetStringValue("Создать критерий", "Введите критерий");

            if (HaveErrorsInputData(functionName, nameNewCriterion))
                return false;
            //Добавляем критерий в список критериев
            _model.task.AddField(nameNewCriterion);
           //Создаем для нового критерия матрицу сравнений
            _model.matrixsCompare.Add(nameNewCriterion, new MatrixTable(nameNewCriterion, _model.options));
            //Выводим новый критерий 
            _view.AddCriterion(nameNewCriterion);
            //Выводим новый критерий в список матриц сравнений
            _view.AddCriterionInList(nameNewCriterion);
            //Расширяем матрицу цели
            _view.ExpandMatrixTask(nameNewCriterion);

            calculationCorrect = false;
            return true;
        }
        public bool UpdateCriterion(int indexRow, string nameNewCriterion)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) ||HaveErrorsIndexs(functionName, indexRow)|| (_model.task.fields[indexRow] == nameNewCriterion))
                return false;

            //Генерирум новое имя критерия если имя неверное
           while(HaveErrorsInputData(functionName, nameNewCriterion))
                nameNewCriterion += indexRow.ToString();

            //Меняем имя критерия
            _model.task.fields[indexRow] = nameNewCriterion;
            //Получаем старое имя критерия
            string oldkey = _model.matrixsCompare.Keys.ElementAt(indexRow);
            //Запоминаем матрицу критерия
            MatrixTable oldvalue = _model.matrixsCompare[oldkey];
            //Меняем имя критерия для таблицы
            oldvalue.name = nameNewCriterion;
            //Удаляем старый критерия вместе с таблицей
            _model.matrixsCompare.Remove(oldkey);
            //Записываем матрицу с новым именем в список матриц сравнений
            _model.matrixsCompare.Add(nameNewCriterion, oldvalue);
            
            _view.UpdateCriterion(indexRow, nameNewCriterion);
            _view.UpdateCriterionInList(indexRow, nameNewCriterion);

            calculationCorrect = false;
            return true;
        }
        public bool DeleteCriterion(int indexDelitingCriterion)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsIndexs(functionName, indexDelitingCriterion))
                return false;

            //Удаляем критерий у цели
            _model.task.DeleteField(indexDelitingCriterion);
            //Удаляем соответствующую матрицу сравненимй
            _model.matrixsCompare.Remove(_model.matrixsCompare.Keys.ElementAt(indexDelitingCriterion));

            _view.DeleteCriterion(indexDelitingCriterion);
            _view.DeleteCriterionInList(indexDelitingCriterion);

            calculationCorrect = false;
            return true;
        }

        public bool AddOption(string nameNewOption = null)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            nameNewOption = _view.GetStringValue("Создать объект", "Введите объект");

            if (HaveErrorsInputData(functionName, nameNewOption))
                return false;
            //Добавляем объект
            _model.options.Add(nameNewOption);
            //Добавляем поле в кажду матрицу сравнений
            _model.matrixsCompare.Values.ToList().ForEach(x => x.AddField(nameNewOption));

            _view.AddOption(nameNewOption);
            calculationCorrect = false;
            return true;
        }
        public bool UpdateOption(int indexRow, string optionNewName)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsIndexs(functionName, indexRow) || (_model.task.fields[indexRow] == optionNewName))
                return false;

            while (HaveErrorsInputData(functionName, optionNewName))
                optionNewName += indexRow.ToString();
            //Обновляем имя объекта
            _model.options[indexRow] = optionNewName;
            //Обновляем поле в каждой матрице сравнений
            _model.matrixsCompare.Values.ToList().ForEach(x => x.fields[indexRow] = optionNewName);
            _view.UpdateOption(indexRow, optionNewName);
            return true;
        }
        public bool DeleteOption(int indexDelitingOption)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsIndexs(functionName, indexDelitingOption))
                return false;
            //Удаляем поле в каждой матрице сравнений
            _model.matrixsCompare.Values.ToList().ForEach(x => x.DeleteField(indexDelitingOption));
            //Удаляем объект
            _model.options.RemoveAt(indexDelitingOption);
            _view.DeleteOption(indexDelitingOption);
            return true;
        }

        public bool UpdateValueCellValueMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsInputData(functionName, newValue: cellValue)||HaveErrorsIndexs(functionName, indexRow, indexColumn))
                return false;

            //Устанавливаем значение в матрицу ( Преобразовав строку в число)
            _model.matrixsCompare[selectedMatrix].SetCellMatrix(indexRow, indexColumn,Const.Scale(cellValue));
            //Считаем значение для симметричной ячейки
            double value = 1.0 / _model.matrixsCompare[selectedMatrix].GetCellMatrix(indexRow, indexColumn);
            //Обновляем значение симметричной ячейки
            _model.matrixsCompare[selectedMatrix].SetCellMatrix(indexColumn, indexRow, value);

            _view.UpdateValueCellValueMatrixCompare(indexColumn, indexRow, Const.Scale(value));
            return true;
        }
        public bool UpdateValueCellTaskMatrix(int indexRow, int indexColumn, string cellValue)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) || HaveErrorsInputData(functionName, newValue: cellValue) || HaveErrorsIndexs(functionName, indexRow, indexColumn))
                return false;
            //Устанавливаем значение в матрицу ( Преобразовав строку в число)
            _model.task.SetCellMatrix(indexRow, indexColumn, Const.Scale(cellValue));
            //Считаем значение для симметричной ячейки
            double value = 1.0 / _model.task.GetCellMatrix(indexRow, indexColumn);
            //Обновляем значение симметричной ячейки
            _model.task.SetCellMatrix(indexColumn, indexRow, value);

            _view.UpdateValueCellTaskMatrix(indexColumn, indexRow, Const.Scale(_model.task.matrix[indexColumn, indexRow]));
            return true;
        }
       
        public bool SaveTaskInFile()
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;
            
            MatrixIO.SaveInFile(_model.task);
            return true;
        }
        public bool LoadTaskFromFile()
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if ((HaveErrorsState(functionName))&& (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            _model.matrixsCompare.Clear();
            _model.task = null;

            _model.task = MatrixIO.LoadFromFile();

            if (_model.task?.fields != null)
            {
                foreach (string criterion in _model.task.fields)
                {
                    _model.matrixsCompare.Add(criterion, new MatrixTable(criterion, _model.options));
                    _view.AddCriterion(criterion);
                    _view.AddCriterionInList(criterion);

                }
                selectedMatrix = _model.task?.name;
            }
            _view.OutputMatrixTask(MatrixToDataTable(_model.task));
            
            calculationCorrect = true;
            return true;
        }

        public bool SelectMatrixCompare(string SelectedMatrixCompareName)
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName) ||HaveErrorsInputData(functionName, SelectedMatrixCompareName,mute:true))
                return false;
            selectedMatrix = SelectedMatrixCompareName;
            _view.OutputMatrixCompare(MatrixToDataTable(_model.matrixsCompare[selectedMatrix]));
            return true;
        }
        public bool SelectingMatrixCompare()
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            return true;
        }
        public bool Calculation()
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            _model.NormResult = Calculations.CalcGlobalDistributedPriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());
            _model.IdealResult = Calculations.CalcGlobalIdealizePriority(Calculations.GetVectorPriority(_model.task.matrix), _model.matrixsCompare.Values.ToList().Select(x => x.matrix).ToList());

            calculationCorrect = true;
            return true;
        }
        public bool ShowCalculation()
        {
            //Получаем имя текущей функции
            string functionName = MethodInfo.GetCurrentMethod().Name;
            if (HaveErrorsState(functionName))
                return false;

            _view.OutputCalculationsResult(_model.options[_model.NormResult.MaximumIndex()], _model.options[_model.IdealResult.MaximumIndex()]);
            _view.OutputVectorCalculations(VectorToList(_model.IdealResult), "IdealResult");
            _view.OutputVectorCalculations(VectorToList(_model.NormResult), "NormResult");
            return true;
        }
    }
}
