using iBase = NamespaceIBase.IBase;
namespace NamespaceIPresenter
{
   public  interface IPresenter: iBase
    {
       bool AddTask();
       bool SaveTaskInFile();
       bool LoadTaskFromFile();

       bool SelectMatrixCompare(string SelectedMatrixCompareName);
       bool Calculation();
       bool ShowCalculation();
       

    }
}
