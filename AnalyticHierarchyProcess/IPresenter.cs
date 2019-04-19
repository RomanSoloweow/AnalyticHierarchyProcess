using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NamespaceIBase;
using NamespaceMatrixTable;

namespace NamespaceIPresenter
{
   public  interface IPresenter: IBase
    {
    
       bool SaveTaskInFile();
       bool LoadTaskFromFile();
       bool AddTask(string newTaskName);
      // MatrixTable GetTask();
       List<string> GetAllCriterionsName();
       List<string> GetAllOptionsName();
       bool Calculation();
       bool ShowCalculation();


       bool SelectMatrixCompare(string SelectedMatrixCompareName);

    }
}
