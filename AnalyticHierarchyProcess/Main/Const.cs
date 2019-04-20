using System;
using System.Collections.Generic;
using System.Linq;

namespace NamespaceConst
{
    public class Const
    {
        private static int defaultIntScaleValue = 1;
        public static string defaultScaleValue = Scale(defaultIntScaleValue);
        public static string Scale(double scale)
        {
            if (scale < 1)
                scale = 0;
            string ScaleValue = Scale().ElementAt(Convert.ToInt32(scale));
            return ScaleValue;
        }
        public static double Scale(string scale)
        {
            double ScaleValue = Scale().IndexOf(scale);
            return ScaleValue;
        }
        public static List<string> Scale()
        {
            List<string> ScaleValues = new List<string>(new string[]
            {
            "Обратное симметричному",
            "Одинаковая значимость",
            "Почти слабая значимость",
            "Cлабая значимость",
            "Почти существенная значимость",
            "Существенная значимость",
            "Почти очевидная значимость",
            "Очевидная значимость",
            "Почти абсолютная значимость",
            "Абсолютная значимость"
            });
            return ScaleValues;
        }
    }

    
}
