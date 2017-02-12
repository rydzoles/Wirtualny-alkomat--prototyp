using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AspAlcoTestver._1._0
{    
    public partial class AlcoRaportChart : System.Web.UI.Page
    {    
        private int _imie;              
        
        public void Page_Load(object sender, EventArgs e)
        {    
            ScanPerson scnPerson = (ScanPerson)Session["session"];         
            LoggIn lg = new LoggIn();
            ChartDetails chrd = new ChartDetails();          
            Dictionary<TimeSpan, double> DictionaryPromilesAndHours = new Dictionary<TimeSpan, double>();
            DictionaryPromilesAndHours = scnPerson.alcoReducingInTime(scnPerson.DrinkStartVal, scnPerson.DrinkTimeValue, scnPerson.MaxAlcoCOncentrationVal);
            foreach (KeyValuePair<TimeSpan, double> item in DictionaryPromilesAndHours)
            {
                PromilesInBloodCrt.Series[0].Points.AddXY(item.Key.ToString(),Math.Round(item.Value, 2));
            }
            string nicki = (string)Session["Nick"];
            if (Session["correctLogin"] != null)                  
                lg.RightUser = (bool)Session["correctLogin"];                                 
            if (lg.RightUser == true)
            {               
                toSql(scnPerson, chrd, DictionaryPromilesAndHours);
                toRaport(scnPerson, chrd, DictionaryPromilesAndHours,nicki);
                Session["session"] = scnPerson;
                Session["correctLogin"] = null;
                _imie.ToString();
            }
            if (lg.RightUser == false)
            {
                toRaport(scnPerson, chrd, DictionaryPromilesAndHours,nicki);
            }
            if (uzytkownikLbl.Text != null)
            uzytkownikLbl.Text = _imie.ToString();    
        }           
       
        public  void toSql(ScanPerson scPerson, ChartDetails chrd, Dictionary<TimeSpan, double> oo)
        {
            _imie = (int)Session["imieUsera"];            
            string hours, maxProm;                       
            hours = Convert.ToString(chrd.ten(oo)/2-2);
            maxProm = Convert.ToString(chrd.tamten(oo));
            string weight = Convert.ToString(scPerson.WeightValue);
            string minilitres = Convert.ToString(scPerson.MinilitresOfDrinkedAlcValue);
            string testDate = dataTodayLbl.Text = DateTime.Now.ToString();            
            WhichGender(scPerson);         
            UpdateAlcoDataBase(weight, hours, minilitres, maxProm,testDate, _imie);
        }

        public  void toRaport(ScanPerson scPerson, ChartDetails chrd, Dictionary<TimeSpan, 
            double> oo,string nick)
        {           
            rprtWeightLbl.Text = Convert.ToString(scPerson.WeightValue);
            rprtAmountLbl.Text = Convert.ToString(scPerson.MinilitresOfDrinkedAlcValue);
            rprtVoltageLbl.Text = Convert.ToString(scPerson.AlcoVoltageVal * 100);
            WhichGender(scPerson);
            rprtDrunkTimeLbl.Text = Convert.ToString(chrd.ten(oo) / 2 - 2);
            rprtDataLbl.Text = dataTodayLbl.Text = DateTime.Now.ToString();
         
            if (Session["Nick"] != null)
                rprtNameLbl.Text = nick;
            Session["Nick"] = null;
        }

        private  void UpdateAlcoDataBase(string weight_hist, string drink_time_hist, string ml_drunked_hist, string max_promiles_hist, string date, int user_id)
        {
            string updateData = "INSERT INTO userHistory"
            + "(weight_hist,drink_time_hist,ml_drunked_hist,max_promiles_hist,date,user_id) VALUES(@weight_hist,@drink_time_hist,@ml_drunked_hist,@max_promiles_hist,@date,@user_id)";
            SqlCommand cmd = new SqlCommand();          
            using (var con =new SqlConnection())
            {
                con.ConnectionString = "Data Source=JAC-KOMPUTER\\SQLEXPRESS;Initial Catalog=AlcoPersonalDataSql;Integrated Security=True";
                con.Open();
                string useridString = Convert.ToString(user_id);
                cmd.Connection = con;
                cmd.CommandText = updateData;
                cmd.Parameters.AddWithValue("@weight_hist", weight_hist);
                cmd.Parameters.AddWithValue("@drink_time_hist", drink_time_hist);
                cmd.Parameters.AddWithValue("@ml_drunked_hist", ml_drunked_hist);
                cmd.Parameters.AddWithValue("@max_promiles_hist", max_promiles_hist);
                cmd.Parameters.AddWithValue("@date", Convert.ToDateTime(date));
                cmd.Parameters.AddWithValue("@user_id", useridString);
                cmd.ExecuteNonQuery();
                Session["userID"] = null;
            }
        }

        private  string WhichGender(ScanPerson scnPrsn)
        {        
           return scnPrsn.GenderValue > 0.6 ?  rprtGenderLbl.Text = "mężczyzna" 
               : rprtGenderLbl.Text = "kobieta";           
        }      
    }
}