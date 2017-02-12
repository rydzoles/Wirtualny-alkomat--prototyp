using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace AspAlcoTestver._1._0
{
    public partial class Registration : System.Web.UI.Page
    {
        private string namePerson;
        private string emailPerson;
        private string passPerson, confirmPass;
        private bool correctEmail;
        public string taki;

        SqlConnection con = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {          
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            ScanPerson scnPerson = new ScanPerson();
            LoggIn logg = new LoggIn();
            try
            {
                namePerson = nameTxb.Text;
                emailPerson = emailTxb.Text;
                passPerson = passTxb.Text;
                confirmPass = confirmPassTxb.Text;
                string wrongInfo = wrongInfoEmailLbl.Text;
                correctEmail = isValidEmail(emailPerson);
                if (!correctEmail)
                    wrongInfoEmailLbl.Text = "Podaj poprawny mail";
                else
                {
                    PersonDataRegistration prsnDataReg = new PersonDataRegistration(namePerson, emailPerson, passPerson, confirmPass);
                    prsnDataReg.SetUnicqlyValue(namePerson, emailPerson, passPerson, confirmPass);                   
                    logg.logUser(namePerson, emailPerson, passPerson);
                    prsnDataReg.lookAtName(CheckIsNickIn);                
                }
            }
            catch (Exception exception)
            {
                wrongInfoLbl.Text="Wystąpił nieoczekiwany błąd" + exception;
                // wysylaj maila
            }
            EmailOnDatabase(emailPerson);           
        }

        public void EmailOnDatabase(string email)
        {           
            SqlCommand cmd = new SqlCommand();
            using (var con = new SqlConnection())
            {
                con.ConnectionString = "Data Source=JAC-KOMPUTER\\SQLEXPRESS;Initial Catalog=AlcoPersonalDataSql;Integrated Security=True";
                con.Open();
                cmd.CommandText = "SELECT * FROM [AlcPrsnTable]";
                cmd.Connection = con;
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd[2].ToString() == email)
                    {
                        wrongInfoEmailLbl.Text = "Podany Adres istnieje. POdaj inny email.";                  
                        con.Close();
                        break;
                    }
                }          
            }
        }

        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public void CheckIsNickIn(bool takenNick)
        {
            if (takenNick == true)
                wrongInfoEmailLbl.Text = " Istnieje podany Nick. Możejść przejść do strony logowania jesli znasz hasło";          
            else
            {
                Session["correctLogin"] = true;
                Response.Redirect("UserPanelForm.aspx");
            }
        }
    }
}