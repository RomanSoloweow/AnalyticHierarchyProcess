using System;
using System.Collections.Generic;
using System.Linq;

namespace NamespaceConst
{
    public static class Const
    {

        public static string Scale(double scale)
        {
            if (scale < 1)
                scale = -1;
            string ScaleValue = ScaleValues.ElementAt(Convert.ToInt32(scale - 1));
            return ScaleValue;
        }
        public static double Scale(string scale)
        {
            double ScaleValue = ScaleValues.IndexOf(scale);

            if (ScaleValue < 1)
                ScaleValue = -1;
            else
                ScaleValue = ScaleValue + 1;

            return ScaleValues.IndexOf(scale);
        }
        public static List<string> Scale()
        {
            return ScaleValues;
        }
        private static List<string> ScaleValues = new List<string>()
        {
            {"Обратное симметричному"},
            {"Одинаковая значимость"},
            {"Почти слабая значимость"},
            {"Cлабая значимость"},
            {"Почти существенная значимость"},
            {"Существенная значимость"},
            {"Почти очевидная значимость"},
            {"Очевидная значимость"},
            {"Почти абсолютная значимость"},
            {"Абсолютная значимость"}
        };

    }
}
