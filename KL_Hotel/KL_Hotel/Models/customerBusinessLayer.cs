﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


namespace KL_Hotel.Models
{
    public class CustomerBusinessLayer

    {
        public void AddCustomer(Customer cust)
        {
            String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("spAddCustomer", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };

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
        public void EditCustomer(Customer cust)
        {
            String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("spEditCustomer", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //add the parameters to the command object. 

                SqlParameter paramFirstName = new SqlParameter
                {
                    ParameterName = "@FirstName",
                    Value = cust.FirstName
                };

                command.Parameters.Add(paramFirstName);

                SqlParameter paramCustomerID = new SqlParameter
                {
                    ParameterName = "@CustomerId",
                    Value = cust.CustomerID
                };
                command.Parameters.Add(paramCustomerID);


                SqlParameter paramLastName = new SqlParameter
                {
                    ParameterName = "@LastName",
                    Value = cust.LastName
                };
                command.Parameters.Add(paramLastName);

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

        public Customer ShowCustInfo(string u)
        {
                String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customer WHERE [CustomerID] ='" + u
                   + "'", con);

                    //open the connection
                    con.Open();
                Customer customer = new Customer();
                    //read the info from the database table customer and store it in reader object
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    CustomerBusinessLayer customerBusiness = new CustomerBusinessLayer();


                    customer.CustomerID = Convert.ToInt32(reader["CustomerID"]);
                    customer.FirstName = reader["FirstName"].ToString();
                    customer.LastName = reader["LastName"].ToString();
                    customer.Password = reader["Password"].ToString();

                        
                    }
                    return customer;
                }
            }


            //public IEnumerable<Customer> Customers
            //{
            //    get
            //    {
            //        String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            //        List<Customer> cust = new List<Customer>();
            //        using (SqlConnection con = new SqlConnection(connString))
            //        {
            //            SqlCommand cmd = new SqlCommand("Select * from Customer", con);
            //            cmd.CommandType = CommandType.Text;
            //            con.Open();

            //            // read the info from the database table customer and store it in reader object
            //            SqlDataReader reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                Customer customer = new Customer();
            //                customer.CustomerID = Convert.ToInt32(reader[0]);
            //                customer.FirstName = reader[1].ToString();
            //                customer.LastName = reader[2].ToString();
            //                customer.street = reader[3].ToString();
            //                customer.city = reader[4].ToString();
            //                customer.state = reader[5].ToString();
            //                customer.ZipCode = Convert.ToInt32(reader[6]);
            //                // add the object to the list
            //                cust.Add(customer);


            //            }

            //            // return the list to the calling method
            //            return cust;
            //        }
            //    }
            //}

        }

    }