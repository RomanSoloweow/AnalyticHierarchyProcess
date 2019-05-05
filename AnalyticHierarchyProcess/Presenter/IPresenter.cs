﻿using iBase = NamespaceIBase.IBase;
namespace NamespaceIPresenter
{
   public  interface IPresenter: iBase
    {
       
       bool SaveTaskInFile();
       bool LoadTaskFromFile();

       bool SelectMatrixCompare(string SelectedMatrixCompareName);
       bool SelectingMatrixCompare();
       bool Calculation();
       bool ShowCalculation();
    }
}
