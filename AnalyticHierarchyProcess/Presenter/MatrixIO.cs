using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;
using System;
using System.IO;
using NamespaceMatrixTable;
using System.Data;
using System.Linq;
using System.Windows.Forms;
namespace NamespaceMatrixIO
{
    class MatrixIO
    {
        public static MatrixTable LoadFromFile(string fileNameWithPath)
        {
            if (!System.IO.File.Exists(fileNameWithPath))
                throw new ArgumentNullException("Указанного файла не существует");

            string matrixName = Path.GetFileNameWithoutExtension(fileNameWithPath);
            using (StreamReader File = new StreamReader(fileNameWithPath))
            {
                List<string> criterions = new List<string>(File.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList());
                MatrixTable matrix = new MatrixTable(matrixName, criterions);
                Vector<double> vector = null;
                string line = File.ReadLine();
                int countLineInMatrix = criterions.Count;
                int indexLineInFile = -1;
                while ((line != null) && ((++indexLineInFile) < countLineInMatrix))
                {
                    vector = Vector<double>.Build.DenseOfArray(line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(x => double.Parse(x)).ToArray());
                    for (int j = 0; j < vector.Count; j++)
                        matrix.matrix[indexLineInFile, j] = vector[j];
                    line = File.ReadLine();
                }
                if (indexLineInFile != countLineInMatrix-1)
                    throw new ArgumentNullException("Ошибка чтения файла");

                File.Close();
                return matrix;
            }

        }
        public static MatrixTable LoadFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return null;

               return LoadFromFile(openFileDialog.FileName);
        }
        public static void SaveInFile(MatrixTable matrix, string fileNameWithPath)
        {

            if (matrix==null)
             throw new ArgumentNullException("Сохраняемая матрица пуста");
            if (String.IsNullOrEmpty(fileNameWithPath))
               throw new ArgumentNullException("Необходимо выбрать файл");

            matrix.FillMatrix();
            using (StreamWriter file = new StreamWriter(fileNameWithPath, false))
            {
                file.WriteLine(string.Join(",", matrix.fields));
                for (int i = 0; i < matrix.matrix.RowCount; i++)
                {
                    file.WriteLine(string.Join(",", matrix.matrix.Row(i).ToList().Select(x => x.ToString()).ToList()));
                }
                file.Close();
            }

        }
        public static bool SaveInFile(MatrixTable matrix)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = matrix.name;
            saveFileDialog.Filter = "CSV|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return false;
            SaveInFile(matrix, saveFileDialog.FileName);
            return true;
        }
    }
}
