using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
namespace AspAlcoTestver._1._0
{
    public partial class UserPanelForm : System.Web.UI.Page
    {          
        ScanPerson scnPerson = new ScanPerson();
        private string doSql { get; set; }
        private double weightValue, amountsOfDrinkedAlcValue, genderValueToReducaAlcoholPerHour, alcoVoltageValToReducaAlcoholPerHour;
        private int drinkStartVal, drinkTimeValue;     

        public string DoSql
        {
            get { return doSql; }
            set { doSql = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {              
                string nicki = (string)Session["Nick"];
                ScanPerson scnPerson = (ScanPerson)Session["session"];
                if (Session["correctLogin"] != null)               
                    logInInfoLbl.Text = "WITAJ " + nicki + " !!!";            
                else
                    if (Session["correctLogin"] != null)
                        logInInfoLbl.Text = "Zaloguj się";
            }
            catch (Exception exception)
            {
               ScriptManager.RegisterStartupScript(this, GetType(), "error", "alert('Wystąpił błąd podczas ładowania strony');", true);
            }
        }
        
        protected void countPromiles_Click(object sender, EventArgs e)
        {          
            try
            {
                if (
                !double.TryParse(genderRBtn.Text, out genderValueToReducaAlcoholPerHour) || 
                !double.TryParse(weightPersonTbx.Text, out weightValue) || weightValue <= 0 || // && weightPersonTbx.MaxLength.Equals(1) ||
                !double.TryParse(alcoholAmountsTbx.Text, out amountsOfDrinkedAlcValue) || amountsOfDrinkedAlcValue <= 0 ||
                !int.TryParse(drinkStartDdl.Text, out drinkStartVal) || drinkStartVal <= 0 ||
                !int.TryParse(drinkTimeTxb.Text, out drinkTimeValue) || drinkTimeValue <= 0 ||
                !double.TryParse(alcoholAmountsTbx.Text, out amountsOfDrinkedAlcValue) || amountsOfDrinkedAlcValue <= 0 ||
                !double.TryParse(alcoholVoltageTxb.Text, out alcoVoltageValToReducaAlcoholPerHour) || alcoVoltageValToReducaAlcoholPerHour <= 0 || alcoVoltageValToReducaAlcoholPerHour > 96)
                {
                    if (alcoVoltageValToReducaAlcoholPerHour > 96)
                    {
                        invalidDataLbl.Text = "W naszej bazie nie istnieje alkohol trunek mocniejszy niż 96% alk. Wpisz innną wartość.";
                        alcoholVoltageTxb.BorderColor = System.Drawing.Color.Red;
                    }
                    else
                        invalidDataLbl.Text = "błąd podaj opdowiednia wartosc";
                }
                else
                {
                    if (genderValueToReducaAlcoholPerHour == 0)
                        genderValueToReducaAlcoholPerHour = 0.6;
                    else
                        genderValueToReducaAlcoholPerHour = 0.7;

                    alcoVoltageValToReducaAlcoholPerHour = alcoVoltageValToReducaAlcoholPerHour * 0.01;
                    double maxAlcoCOncentrationVal;
                    maxAlcoCOncentrationVal = CalculateAlcoVoltage(genderValueToReducaAlcoholPerHour, weightValue  //@
                    , amountsOfDrinkedAlcValue, alcoVoltageValToReducaAlcoholPerHour);
                    ScanPerson scnPerson = new ScanPerson(genderValueToReducaAlcoholPerHour, weightValue
                       , amountsOfDrinkedAlcValue, alcoVoltageValToReducaAlcoholPerHour, drinkStartVal, drinkTimeValue, maxAlcoCOncentrationVal);
                    Dictionary<TimeSpan, double> DictionaryAlkInTime = new Dictionary<TimeSpan, double>();
                    Session["session"] = scnPerson;
                    Response.Redirect("AlcoRaportChart.aspx");
                }
            }
            catch (Exception ex)
            {
                invalidDataLbl.Text = ex.StackTrace;
            }
        }

        private double CalculateAlcoVoltage(double gender, double weight
          , double alcoMiniliters, double alcoVoltage)
        {
            double maxInstantPromiles;
            double pureAlcoholGramms = alcoMiniliters * alcoVoltage;
            pureAlcoholGramms = pureAlcoholGramms - (pureAlcoholGramms / 5);
            maxInstantPromiles = pureAlcoholGramms / (gender * weight);
            return maxInstantPromiles;
        }                  
    }
}