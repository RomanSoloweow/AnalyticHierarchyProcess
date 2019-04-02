using System;
using System.Collections.Generic;
using System.Data;
namespace Task
{
    public class Task
    {
        public List<List<double>> matrix = new List<List<double>>();
        private bool isAgreed = false;
        private double I = 1;
        public string name;
        public List<string> criterions;
        public  Task(string _name,List<string> _criterions)
        {
            name = _name;
            criterions = new List<string>(_criterions);
            for (int i = 0; i < criterions.Count; i++)
            {
                matrix.Add(new List<double>());
                for (int j = 0; j < criterions.Count; j++)
                   matrix[i].Add(1);
            }            
        }
        public void AddCriterion(int indexNewCriterion=-1)
        {
            if (indexNewCriterion != 0)
            {
                matrix.Insert(indexNewCriterion, new List<double>());
                for (int i = 0; i < matrix.Count; i++)
                    matrix[i].Insert(indexNewCriterion, 1);
            }
            else
            {
                matrix.Add(new List<double>());
                for (int i = 0; i < matrix.Count; i++)
                    matrix[i].Add(1);
            }

            CheckAgreed();
        }
        public void DeleteCriterion(int indexNewCriterion = -1)
        {
            if (indexNewCriterion == -1)
                indexNewCriterion = matrix.Count-1;

                for (int i = 0; i < matrix.Count; i++)
                    matrix[i].RemoveAt(indexNewCriterion);
                matrix.RemoveAt(indexNewCriterion);

            CheckAgreed();
        }
        private void FillMatrix()
        {       
            for (int i = 0; i < matrix.Count; i++)
                for (int j = 0; j < matrix.Count; j++)
                {
                    if (i == j)
                    {
                        matrix[i][j] = 1;
                    }
                    else
                    {
                        if (matrix[i][j]==1)
                         matrix[i][j] = 1 / matrix[j][i];
                    }

                }

             for (int i = 0; i < matrix.Count; i++)
                 {
                  for (int j = 0; j < matrix.Count; j++)
                      Console.Write(matrix[i][j].ToString() + "  ");
                  Console.WriteLine();
                }
        }
        public void CheckAgreed()
        {
            FillMatrix();
            double eTAe = 0;
            List<double> Ae = new List<double>();
            for (int i = 0; i < matrix.Count; i++)
            {
                double result = 0;
                for (int j = 0; j < matrix[i].Count; j++)
                    result += matrix[i][j];               
                Ae.Add(result);
                eTAe += result;
            }
            double L = 0;
            Console.WriteLine("Вектор");
            for (int i = 0; i < matrix.Count; i++)
            {
                double result = 0;
                for (int j = 0; j < matrix[i].Count; j++)
                    result += matrix[j][i];
               
                Console.WriteLine(result);
                L += result * Ae[i] / eTAe;
            }
           
            I = (L - Ae.Count) / (Ae.Count - 1);
            Console.WriteLine("L="+L);
            Console.WriteLine(I);
            isAgreed = I < 0.1;
        }

    }
}
