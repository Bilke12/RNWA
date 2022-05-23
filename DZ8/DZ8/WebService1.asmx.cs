using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using MySqlConnector;

namespace DZ8
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        public static DataTable SendQuerry(string querry)
        {
            string connString = "SERVER=localhost" + ";" +
                "DATABASE=birt;" +
                "UID=root;" +
                "PASSWORD=;";

            MySqlConnection cnMySQL = new MySqlConnection(connString);
            MySqlCommand cmdMySQL = cnMySQL.CreateCommand();
            MySqlDataReader reader;

            cmdMySQL.CommandText = querry;
            cnMySQL.Open();
            reader = cmdMySQL.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cnMySQL.Close();

            return dt;

        }



        [WebMethod]
        public DataTable getEmployeesById(String emp_no)
        {
            string querry = "select firstName, lastName, email, jobTitle from employees where employeeNumber =" + emp_no;
            return SendQuerry(querry);
        }
    }
}
       
