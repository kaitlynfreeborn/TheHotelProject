using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace KL_Hotel.Models
{
    public class customerBusinessLayer
    {
        public void AddCustomer(Customer cust)
        {
            String connString = ConfigurationManager.ConnectionStrings["CustomerCon"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("spAddCustomer", sqlCon);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFirstName = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = cust.FirstName
                };

                command.Parameters.Add(paramFirstName);

                SqlParameter paramLastName = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = cust.LastName
                };
                command.Parameters.Add(paramLastName);

                SqlParameter paramUser_ID = new SqlParameter
                {
                    ParameterName = "@User_ID",
                    Value = cust.User_ID
                };
                command.Parameters.Add(paramUser_ID);

                SqlParameter paramPassword = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = cust.Password
                };
                command.Parameters.Add(paramPassword);

                //open the connection
                sqlCon.Open();
                //execute the procedure
                command.ExecuteNonQuery();
            }
        }
    }
}
