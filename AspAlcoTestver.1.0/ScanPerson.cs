using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspAlcoTestver._1._0
{
    internal delegate double LookForMaxPromiles(Dictionary<TimeSpan, double> maxPromilesInBloodDelegat);
    public class ScanPerson
    {

        private double _genderValue { get; set; }
        private double _weightValue { get; set; }
        private double _minilitresOfDrinkedAlcValue { get; set; }
        private double _alcoVoltageVal { get; set; }
        private int    _drinkStartVal { get; set; }
        private int    _drinkTimeValue { get; set; }
        private double _maxpromilesScore;
        private double _maxAlcoCOncentrationVal;

        public double GenderValue
        {
            get { return _genderValue; }
            set { _genderValue = value; }
        }        
     
        public double AlcoVoltageVal
        {
            get { return _alcoVoltageVal; }
            set { _alcoVoltageVal = value; }
        }        

        public double MaxpromilesScore
        {
            get { return _maxpromilesScore; }
            set { _maxpromilesScore = value; }
        }        

        public double MinilitresOfDrinkedAlcValue
        {
            get { return _minilitresOfDrinkedAlcValue; }
            set { _minilitresOfDrinkedAlcValue = value; }
        }       

        public double WeightValue
        {
            get { return _weightValue; }
            set { _weightValue = value; }
        }       
 
        public int DrinkStartVal
        {
            get { return _drinkStartVal; }
            set { _drinkStartVal = value; }
        }

        public int DrinkTimeValue
        {
            get { return _drinkTimeValue; }
            set { _drinkTimeValue = value; }
        }

        public double MaxAlcoCOncentrationVal
        {
            get { return _maxAlcoCOncentrationVal; }
            set { _maxAlcoCOncentrationVal = value; }
        }
       
        public ScanPerson(Dictionary<TimeSpan, double> DictionaryAlkInTime)
        {
        }

        public ScanPerson()
        {
        }

        public ScanPerson(double genderValue, double weightValue, double amountsOfDrinkedAlcValue, double alcoVoltageVal, int drinkStartVal, int drinkTimeValue, double maxAlcoCOncentrationVal)
        {
            this._genderValue = genderValue;
            this._weightValue = weightValue;
            this._minilitresOfDrinkedAlcValue = amountsOfDrinkedAlcValue;
            this._alcoVoltageVal = alcoVoltageVal;
            this._drinkStartVal = drinkStartVal;
            this._drinkTimeValue = drinkTimeValue;
            this._maxAlcoCOncentrationVal = maxAlcoCOncentrationVal;
        }      
      
        public Dictionary<TimeSpan, double> alcoReducingInTime(int drinkStart, int drinkTime, double maxAlcoCOncentrationVal)
        {

            double eachHourValue = maxAlcoCOncentrationVal / (drinkTime * 2);
            double alcIncreasePerHour = eachHourValue;
            Dictionary<TimeSpan, double> DictionaryAlkInTime = new Dictionary<TimeSpan, double>();

            TimeSpan ScorePerHalfHour = new TimeSpan(Convert.ToInt32(drinkStart), 00, 00);
            int allDrunkTime = 1;
            TimeSpan timeSpanEachHour = new TimeSpan(00, 30, 00);

            DictionaryAlkInTime.Add(ScorePerHalfHour, 0.00);

            for (int i = 0; i < allDrunkTime; i++)
            {
                if (i == 0)
                {
                    ScorePerHalfHour = ScorePerHalfHour + timeSpanEachHour;
                    eachHourValue = eachHourValue + 0;
                    DictionaryAlkInTime.Add(ScorePerHalfHour, eachHourValue);
                }
                if (eachHourValue <= maxAlcoCOncentrationVal && i <= (drinkTime * 2))               
                    eachHourValue = eachHourValue + alcIncreasePerHour - 0.075;                
                else               
                    eachHourValue = eachHourValue - 0.06;
               
                if (eachHourValue >= 0.1)               
                    allDrunkTime++;
                
                ScorePerHalfHour = ScorePerHalfHour + timeSpanEachHour;
                DictionaryAlkInTime.Add(ScorePerHalfHour, eachHourValue);           
                LookForMaxPromiles look = MyDictionary;
                _maxpromilesScore = look.Invoke(DictionaryAlkInTime);
            }
            return DictionaryAlkInTime;
        }
        public Dictionary<TimeSpan, double> DicToSecondPage(Dictionary<TimeSpan, double> DictionaryAlkInTime)
        {
            foreach (KeyValuePair<TimeSpan, double> item in DictionaryAlkInTime)
            {
            }
            return DictionaryAlkInTime;
        }

        private static double MyDictionary(Dictionary<TimeSpan, double> listMY)
        {
            double maxValue = listMY.Values.Max();
            return Math.Round(maxValue, 2);
        }
    }
}