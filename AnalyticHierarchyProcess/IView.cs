using NamespaceIPresenter;
using NamespaceMatrixTable;
using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using NamespaceIBase;
namespace NamespaceIView
{

    public interface IView:IBase
    {
        bool SetIPresenter(IPresenter iPresenter);
        bool OuputTaskMatrix(MatrixTable matrixTable);
        bool OuputCalculations(Vector<double> vectorCalculation1, Vector<double> vectorCalculation2);
        bool OuputMatrixCompare(MatrixTable matrixTable);
        //bool OuputCriterions(List<string> criterions);
        //bool OuputListOptions(List<string> Options);
    }

}
