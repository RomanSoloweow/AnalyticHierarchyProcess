using dataTable = System.Data.DataTable;
using Presenter = NamespaceIPresenter.IPresenter;
using iBase = NamespaceIBase.IBase;
using listString = System.Collections.Generic.List<string>;
namespace NamespaceIView
{

    public interface IView:iBase
    {

        bool SetIPresenter(Presenter iPresenter);
        bool ContractMatrixCompare(int indexExpand);
        bool ExpandMatrixCompare(string nameNewElement);
        bool ContractMatrixTask(int indexAdding);
        bool ExpandMatrixTask(string nameNewElement);

        bool AddCriterionInList(string nameNewCriterion);
        bool UpdateCriterionInList(int indexRow, string nameNewCriterion);
        bool DeleteCriterionInList(int indexRow);

        bool OutputMatrixTask(dataTable table);
        bool OutputMatrixCompare(dataTable table);
        bool OutputVectorCalculations(listString column, string nameColumn);
        bool OutputCalculationsResult(string idealizedResult, string normalizedResult);
        bool ShowError(string errorText);
        bool AskQuestion(string QuestionText);
        string GetStringValue(string title, string label_text);

    }

}
