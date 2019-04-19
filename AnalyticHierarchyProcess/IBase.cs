namespace NamespaceIBase
{
    public  interface IBase
    {
        bool AddCriterion(string nameNewCriterion=null);
        bool UpdateCriterion(int indexRow, string nameNewCriterion = null);
        bool DeleteCriterion(int indexDelitingCriterion);


        bool AddOption(string nameNewOption=null);
        bool UpdateOption(int indexRow,string optionNewName = null);
        bool DeleteOption(int indexDelitingOption);

        bool SetValueCellMatrixCompare(int indexRow, int indexColumn, string cellValue);
        bool SetValueCellTaskMatrixCompare(int indexRow , int indexColumn, string cellValue);

    }
}
