using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartLibrary.Utils
{
    public static class EnumerableUtil
    {

        public static Double Min(this IEnumerable enumerable)
        {
            Double minValue = Double.NaN;
            foreach (DataPoint item in enumerable)
            {
                if (minValue.Equals(Double.NaN))
                    minValue = item.DependentValue;

                if (minValue > item.DependentValue)
                    minValue = item.DependentValue;
            }

            return minValue;
        }

        public static Double Max(this IEnumerable ienumerable)
        {
            Double maxValue = Double.NaN;

            foreach (DataPoint item in ienumerable)
            {
                if (maxValue.Equals(Double.NaN))
                    maxValue = item.DependentValue;

                if (maxValue < item.DependentValue)
                    maxValue = item.DependentValue;
            }

            return maxValue;
        }


    }
}
