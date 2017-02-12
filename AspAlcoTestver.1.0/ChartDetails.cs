using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspAlcoTestver._1._0
{ 
    public class ChartDetails        
    {
        int takiInt = 1;
        double takiDouble = 1;
  
        public bool takibBOL(bool ook)
        {
            return ook;
        }

        public int ten(Dictionary<TimeSpan, double> slownik)
        {
            return takiInt = slownik.Count();
        }

        public double tamten(Dictionary<TimeSpan, double> slownik)
        {
            return takiDouble = Math.Round(slownik.Values.Max(), 2);
        }
    }
}