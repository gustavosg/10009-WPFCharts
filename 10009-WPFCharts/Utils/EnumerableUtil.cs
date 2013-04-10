using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartTest.Utils
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

    }
}
