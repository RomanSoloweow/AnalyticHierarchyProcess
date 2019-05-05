namespace NamespaceIBase
{
    public  interface IBase
    {
        bool AddTask(string nameNewTask=null);
        bool UpdateTask(string nameNewTask=null);
        bool DeleteTask();
        bool AddCriterion(string nameNewCriterion=null);
        bool UpdateCriterion(int indexRow, string nameNewCriterion);
        bool DeleteCriterion(int indexDelitingCriterion);


        bool AddOption(string nameNewOption=null);
        bool UpdateOption(int indexRow,string optionNewName);
        bool DeleteOption(int indexDelitingOption);

        bool UpdateValueCellValueMatrixCompare(int indexRow, int indexColumn, string cellValue);
        bool UpdateValueCellTaskMatrix(int indexRow , int indexColumn, string cellValue);
    }
}
