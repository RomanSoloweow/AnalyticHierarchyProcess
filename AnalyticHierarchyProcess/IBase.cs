namespace NamespaceIBase
{
    public  interface IBase
    {    
        bool AddCriterion(string newCriterionName);
        bool UpdateCriterion(int indexRowstring, string criterionNewName);
        bool DeleteCriterion(int indexDelitingCriterion);


        bool AddOption(string newOptionName);
        bool UpdateOption(int indexRow,string optionNewName);
        bool DeleteOption(int indexDelitingOption);

        bool SetValueCellMatrixCompare(int indexRow, int indexColumn, double cellValue);
        bool SetValueCellTaskMatrixCompare(int indexRow , int indexColumn, double cellValue);
    }
}
