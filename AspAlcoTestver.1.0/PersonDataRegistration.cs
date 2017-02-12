using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;



namespace AspAlcoTestver._1._0
{
    public class PersonDataRegistration : Registration
    {
        public delegate void LookAtName(bool name);
        private SqlConnection con = new SqlConnection();
        private bool nameIsOnStorge;
        private string namePerson;
        private string emailPerson;
        private string passPerson;
        private string confirmPass;
        private int i = 0;

        public bool Flag
        {
            get { return nameIsOnStorge; }
            set { nameIsOnStorge = value; }
        }

        public string NamePerson
        {
            get { return namePerson; }
            set { namePerson = value; }
        }

        public PersonDataRegistration(string namePerson, string emailPerson, string passPerson, 
            string confirmPass)
        {
            this.namePerson = namePerson;
            this.emailPerson = emailPerson;
            this.passPerson = passPerson;
            this.confirmPass = confirmPass;
        }

        public PersonDataRegistration()
        {
        }

        public void SetUnicqlyValue(string namePerson, string emailPerson, string passPerson, 
            string confirmPass)
        {            
            string updateData = "Insert Into AlcPrsnTable" + " (namePerson,emailPerson,passPerson,confirmPass) Values(@namePerson,@emailPerson,@passPerson,@confirmPass)";
           SqlCommand cmd = new SqlCommand();
           using (var con = new SqlConnection())
           {
               try
               {
                   con.ConnectionString = "Data Source=JAC-KOMPUTER\\SQLEXPRESS;Initial Catalog=AlcoPersonalDataSql;Integrated Security=True";
                   cmd.CommandText = updateData;
                   con.Open();
                   ScanPerson scnPrs = new ScanPerson();
                   cmd.CommandText = "SELECT * FROM [AlcPrsnTable]";
                   cmd.Connection = con;
               }
               catch (SqlException se)
               {
                   wrongInfoLbl.Text = "Błąd dostępu do Bazy Danych" + se.StackTrace;
               }
               SqlDataReader rd = cmd.ExecuteReader();
               while (rd.Read())
               {
                   if (rd[1].ToString() == NamePerson)
                   {
                       nameIsOnStorge = true;
                       con.Close();
                       break;
                   }
                   //   powtarzajacy sie kod
                   i = rd.GetInt32(0);
                   Session["imieUsera"] = i + 1;
               }
               rd.Close();
               if (nameIsOnStorge == true)
               {
                   con.Close();
               }
               if (nameIsOnStorge == false)
               {
                   cmd.CommandText = updateData;
                   Session["Nick"] = namePerson;
                   cmd.Parameters.AddWithValue("@namePerson", namePerson);
                   cmd.Parameters.AddWithValue("@emailPerson", emailPerson);
                   cmd.Parameters.AddWithValue("@passPerson", passPerson);
                   cmd.Parameters.AddWithValue("@confirmPass", confirmPass);
                   cmd.ExecuteNonQuery();
               }
           }
        }
       
        public void lookAtName(LookAtName o)
        {
            o(nameIsOnStorge);
        }
    }
}