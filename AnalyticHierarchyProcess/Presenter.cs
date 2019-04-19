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
namespace NamespacePresenter
{
    class Presenter:IPresenter
    {   
        private static Dictionary<int, string> scalesInt = new Dictionary<int, string>()
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
        private static Dictionary<string, int> scalesString = new Dictionary<string, int>()
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
                    if (matrix.matrix[i, j] < 1)
                        table.Rows[i][j] = scalesInt[-1];
                    else
                        table.Rows[i][j] = scalesInt[Convert.ToInt32(matrix.matrix[i, j])];
                }
            return table;
        }
        private List<string> VectorToList(Vector<double> vector)
        {
            return vector.ToList<double>().Select(number => number.ToString()).ToList();
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
        public bool AddCriterion(string nameNewCriterion=null)
        {
            if (HaveErrors(1))
                return false;

            nameNewCriterion = _view.GetStringValue("Создать критерий", "Введите критерий");

            if (HaveErrors(25, nameNewCriterion))
                return false;

            _model.task.AddField(nameNewCriterion);
            _model.matrixsCompare.Add(nameNewCriterion, new MatrixTable(nameNewCriterion, _model.options));          
            _view.AddCriterion(nameNewCriterion);
            result = false;
            return true;
        }
        public bool UpdateCriterion(int indexRow, string nameNewCriterion=null)
        {
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

            if (HaveErrors(7))
                return false;

            nameNewOption = _view.GetStringValue("Создать объект", "Введите объект");

            if (HaveErrors(47, nameNewOption))
                return false;

            _model.options.Add(nameNewOption);
            _model.matrixsCompare.Values.ToList().ForEach(x => x.AddField(nameNewOption));
            _view.AddOption(nameNewOption);
            result = false;
            return true;
        }
        public bool UpdateOption(int indexRow, string optionNewName)
        {
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

        public bool SetValueCellMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            return true;
        }
        public bool SetValueCellTaskMatrixCompare(int indexRow, int indexColumn, string cellValue)
        {
            return true;
        }


        public bool AddTask()
        {
            if ((!HaveErrors(1,null,true)) && (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            string nameNewTask = _view.GetStringValue("Создать цель", "Введите цель");
            if (nameNewTask == null)
                nameNewTask = "Цель";

            selectedMatrix = string.Empty;
            _model.task = new MatrixTable(nameNewTask);
            result = false;
            return true;
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
            if ((!HaveErrors(1))&& (!_view.AskQuestion("Цель уже была создана, удалить предыдущую?")))
                return false;

            _model.matrixsCompare.Clear();
            _model.task = null;

            _model.task = MatrixIO.LoadFromFile();
            _model.task.fields.ForEach(x => _model.matrixsCompare.Add(x, new MatrixTable(x, _model.options)));
            selectedMatrix = _model.task.name;
            _view.OuputTaskMatrix(MatrixToDataTable(_model.task));
            result = false;
            return true;
        }

        public bool SelectMatrixCompare(string SelectedMatrixCompareName)
        {
            if (HaveErrors(64))
                return false;
            selectedMatrix = SelectedMatrixCompareName;
            _view.OuputMatrixCompare(MatrixToDataTable(_model.matrixsCompare[selectedMatrix]));
            return true;
        }
        public bool Calculation()
        {
            if (HaveErrors(1))
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
