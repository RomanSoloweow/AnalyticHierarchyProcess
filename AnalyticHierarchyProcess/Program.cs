using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NamespacePresenter;
using NamespaceModel;
namespace AnalyticHierarchyProcess
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormView view = new FormView();
            Model model = new Model();
            Presenter presenter = new Presenter(model,view);         
            Application.Run(view);
        }
    }
}
