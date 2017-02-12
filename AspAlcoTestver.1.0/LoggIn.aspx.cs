using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace AspAlcoTestver._1._0
{
    public partial class LoggIn : System.Web.UI.Page
    {
        public delegate void UserIsOnStaff(bool usrPresent);
        private bool _userRegistered; 
        private bool _rightUser=false;
        private int _numberOfUserFromSQL;
        private string newPass = GenerateNewPass();

        public bool RightUser
        {
            get { return _rightUser; }
            set { _rightUser = value; }
        }
           
        protected void Page_Load(object sender, EventArgs e)
        {
            ScanPerson scnPerson = (ScanPerson)Session["session"];        
        }

        protected void enterUserBtn_Click(object sender, EventArgs e)
        {
            ScanPerson scnPerson = new ScanPerson();          
                try
                {
                    string nameUser = nameUserTxb.Text;
                    string passUser = passUserTxb.Text;
                    string emailUser = emailUserTxb.Text;
                    Session["imie"] = nameUser;
                    logUser(nameUser, emailUser, passUser);
                    UserOnStaff(userAccepted);
                    nameUserTxb.MaxLength.Equals(10);
                    passUserTxb.MaxLength.Equals(10);
                    emailUserTxb.MaxLength.Equals(10);
                    Session["session"] = scnPerson;                    
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "error", "alert('Wystąpił błąd podczas ładowania strony');", true);                 
                }                                 
        }
 
        public void userAccepted(bool userOk)
        {
            ScanPerson scPerson = new ScanPerson();
            if (userOk == false)          
              wrongNameEmailLogLbl.Text = "Niepoprawny login lub haslo";         
            else
            {
                AlcoRaportChart alcrptCha = new AlcoRaportChart();
               _rightUser = true;
               Session["correctLogin"] = _rightUser;
                Response.Redirect("USerPanelForm.aspx");                              
            }
        }

        public virtual void logUser(string namePerson, string emailPerson, string passPerson)
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
                    if (rd[1].ToString() == namePerson && rd[3].ToString() == passPerson)
                    {
                        _userRegistered = true;
                        _numberOfUserFromSQL = rd.GetInt32(0);
                        Session["imieUsera"] = _numberOfUserFromSQL;
                        string nick = rd.GetString(1);
                        Session["Nick"] = nick;
                        con.Close();
                        break;
                    }
                }
            }
        }
            
        private void UserOnStaff(UserIsOnStaff usIn)
        {           
            usIn(_userRegistered);
        }

        private static string GenerateNewPass()
        {
            Random rnd = new Random();
            Dictionary<int, char> baseOfSign = new Dictionary<int, char>()
        {
                {0 ,'a'}, {1 ,'B'}, {2 ,'C'}, {3 ,'D'}, {4 ,'E'}, 
                {5 ,'f'}, {6 ,'G'}, {7 ,'H'}, {8 ,'I'}, {9 ,'j'}, 
                {10,'K'}, {11,'L'}, {12,'M'}, {13,'n'}, {14,'O'}, 
                {15,'p'}, {16,'Q'}, {17,'r'}, {18,'s'}, {19,'T'}, 
                {20,'u'}, {21,'v'}, {22,'w'}, {23,'x'}, {24,'y'}, 
                {25,'Z'}, {26,'1'}, {27,'2'}, {28,'3'}, {29,'4'}, {30,'5'},
                {31,'6'}, {32,'7'}, {33,'8'}, {34,'9'}, {35,'0'}                 
        };
            int setKey;
            string generatedPAss = "";
            setKey = rnd.Next(0, 35);
            while (generatedPAss.Length <= 8)
            {
                foreach (KeyValuePair<int, char> sign in baseOfSign)
                {
                    if (sign.Key == setKey && generatedPAss.Length <= 8)
                    {
                        generatedPAss += sign.Value;
                        setKey = rnd.Next(0, 35);
                    }
                }
            }
            return generatedPAss;
        }
     
        protected void sendNewPassBtn_Click(object sender, EventArgs e)
        {
            // to musze walnąć w metode zeby w trakcie rejestracji nie logowac sie indywidualnie na mailu tylko nie chce kopiowac do klasy registration
            string emaila = emailUserTxb.Text;
            SqlCommand cmd = new SqlCommand();
            using (var con = new SqlConnection())
            {
                try
                {
                    con.ConnectionString = "Data Source=JAC-KOMPUTER\\SQLEXPRESS;Initial Catalog=AlcoPersonalDataSql;Integrated Security=True";
                    con.Open();
                    cmd.CommandText = "UPDATE  AlcPrsnTable SET passPerson = '" + newPass + "'" + " Where emailPerson='" + emaila + "'";
                    cmd.Connection = con;
               

                    //SqlDataReader rd = cmd.ExecuteReader();

                    //SmtpClient smtpClioent = new SmtpClient();

                    //NetworkCredential basicCredintial = new NetworkCredential("Login", "Haslo");
                    //System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                    //smtpClioent.Host = "NazwaSerwera";
                    //smtpClioent.UseDefaultCredentials = false; // nie uzywamy domyslnego uwierzytelnienia
                    //smtpClioent.Credentials = basicCredintial;
                    //message.Subject = "Reset hasła do virtualnego  alkomatu ";
                    //message.From = new System.Net.Mail.MailAddress("rydzolr@gmail.com");
                    //message.Body = " Witaj twoje nowe hasło do serwisu to: " + newPass;
                    //message.To.Add(emaila.ToString());
                    //smtpClioent.Send(message);
                    con.Close();
                }
                catch (Exception exception)
                {
                    InvalidDataInfoLbl.Text = "Wystąpił nieoczekiwany błąd. Spróbuj później."+exception;
                }
              CheckIsEmailOnDatabase(emaila);
            }
        }

        public void CheckIsEmailOnDatabase(string email)
        {
            bool emailExistOnDatabase=false;
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
                        InvalidDataInfoLbl.Text="Sprawdź adres email. Wysłaliśmy nowe hasło.";                       
                    emailExistOnDatabase=true;                      
                        con.Close();                       
                       break;
                    }
                }
                if (emailExistOnDatabase == false)
                    InvalidDataInfoLbl.Text = "Podany adres email nie istnieje";
            }           
        }
        // kurw raz jest raz nie ma
       
    }
}