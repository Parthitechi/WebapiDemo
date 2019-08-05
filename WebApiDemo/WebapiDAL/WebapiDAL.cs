using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApiDemo.WebapiDAL
{
    public class WebapiDAL
    {
        private int result = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public DataSet GetRecordFromDb()

        {

            SqlCommand com = new SqlCommand("sp_getAllBikes", con);

            com.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(com);

            DataSet ds = new DataSet();

            da.Fill(ds);

            return ds;

        }

        public int GetLoginStatus()
        {
            //http://localhost:49630/api/Login?a=Parthiban&b=123
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Login", con);

            cmd.CommandType = CommandType.StoredProcedure;
            string qusername = HttpContext.Current.Request.QueryString["a"];
            string qpassword = HttpContext.Current.Request.QueryString["b"];
            cmd.Parameters.AddWithValue("@Username", qusername);
            cmd.Parameters.AddWithValue("@Password", qpassword);
            var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            result = (int)returnParameter.Value;
            con.Close();
            return result;

        }
    }
}