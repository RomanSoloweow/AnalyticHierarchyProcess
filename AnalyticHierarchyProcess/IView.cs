using dataTable = System.Data.DataTable;
using Presenter = NamespaceIPresenter.IPresenter;
using iBase = NamespaceIBase.IBase;
using listString = System.Collections.Generic.List<string>;
namespace NamespaceIView
{

    public interface IView:iBase
    {

        string GetCriterion(int indexCriterion);
        string GetOption(int indexOption);
        string GetCellValueMatrixCompare(int indexRow, int indexColumn);
        string GetCellValueTaskMatrix(int indexRow, int indexColumn);


        bool SetIPresenter(Presenter iPresenter);
        bool OuputTaskMatrix(dataTable table);
        bool OuputMatrixCompare(dataTable table);
        bool OuputVectorCalculations(listString column, string nameColumn);
        bool OuputCalculationsResult(string idealizedResult, string normalizedResult);
        bool ShowError(string errorText);
        bool AskQuestion(string QuestionText);
        string GetStringValue(string title, string label_text);

    }

}
