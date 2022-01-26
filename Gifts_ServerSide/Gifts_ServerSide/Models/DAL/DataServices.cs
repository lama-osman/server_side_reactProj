using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gifts_ServerSide.Models;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Net;
using System.Web.Http;
using System.Text;

namespace Gifts_ServerSide.Models.DAL
{
    public class DataServices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        // =========== //
        //    Items    //
        // =========== // 
        public int Insert(Items item)
        {
           
            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception)
            {
                return 0;
            }

            String cStr = BuildInsertItem(item);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }
        }
        // Build the Insert command String
        private String BuildInsertItem(Items u)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}')", u.Name, u.Description, u.Image,u.Price,u.Category);
            String prefix = "INSERT INTO Gifts_Items " + "(name, description, image, price, category)";
            command = prefix + sb.ToString();

            return command;
        }


        //// ======================================= //
        ////     DB Comminication Configuration      //
        //// ======================================= // 
        public SqlConnection connect(String conString)
        {
            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }
        private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(); // create the command object
            cmd.Connection = con;              // assign the connection to the command object
            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure
            return cmd;
        }
    }
}