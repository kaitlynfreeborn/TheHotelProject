using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;


namespace KL_Hotel.Models
{
    public class ReservationBusinessLayer : Controller
    {

        public void DeleteReservation(Reservations res)
        {
            String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("spDeleteReservation", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //add the parameters to the command object. 

                SqlParameter paramReservationID = new SqlParameter
                {
                    ParameterName = "@ReservationID",
                    Value = res.ReservationID
                };
                command.Parameters.Add(paramReservationID);

                //open the connection
                sqlCon.Open();
                //execute the procedure
                command.ExecuteNonQuery();
            }


        }
        public void EditReservation(Reservations res)
        {
            String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("spEditReservation", sqlCon);
                command.CommandType = CommandType.StoredProcedure;
                //add the parameters to the command object. 

                SqlParameter paramStartDate = new SqlParameter
                {
                    ParameterName = "@StartDate",
                    Value = res.StartDate
                };

                command.Parameters.Add(paramStartDate);

                SqlParameter paramReservationID = new SqlParameter
                {
                    ParameterName = "@ReservationID",
                    Value = res.ReservationID
                };
                command.Parameters.Add(paramReservationID);

                SqlParameter paramEndDate = new SqlParameter
                {
                    ParameterName = "@EndDate",
                    Value = res.EndDate
                };
                command.Parameters.Add(paramEndDate);

                SqlParameter paramRoomType = new SqlParameter
                {
                    ParameterName = "@RoomType",
                    Value = res.RoomType
                };
                command.Parameters.Add(paramRoomType);

                //open the connection
                sqlCon.Open();
                //execute the procedure
                command.ExecuteNonQuery();
            }
        }
        public void AddReservation(Reservations res)
        {
            String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
            using (SqlConnection sqlCon = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("spAddReservation", sqlCon)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter paramStartDate = new SqlParameter
                {
                    ParameterName = "@StartDate",
                    Value = res.StartDate
                };

                command.Parameters.Add(paramStartDate);

                //SqlParameter paramReservationID = new SqlParameter
                //{
                //    ParameterName = "@ReservationID",
                //    Value = res.ReservationID
                //};
                //command.Parameters.Add(paramReservationID);

                SqlParameter paramEndDate = new SqlParameter
                {
                    ParameterName = "@EndDate",
                    Value = res.EndDate
                };
                command.Parameters.Add(paramEndDate);

                SqlParameter paramRoomType = new SqlParameter
                {
                    ParameterName = "@RoomType",
                    Value = res.RoomType
                };
                command.Parameters.Add(paramRoomType);

                //open the connection
                sqlCon.Open();
            }
        }
        public IEnumerable<Reservations> Reservations
        {
            get
            {
                String connString = ConfigurationManager.ConnectionStrings["AddCustInfo"].ConnectionString;
                List<Reservations> cust = new List<Reservations>();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("select * from Reservations WHERE CustomerID=CustomerID", connection)
                    {
                        CommandType = CommandType.Text
                    };
                    connection.Open();
                    // read the info from the database table reservations and store it in reader object

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Reservations reservation = new Reservations
                        {
                            ReservationID = Convert.ToInt32(reader[0]),
                            CustomerID = Convert.ToInt32(reader[1]),
                            //StartDate = Convert.ToDateTime(reader[2]).ToString("MM/dd/yyyy"),
                            //EndDate = Convert.ToDateTime(reader[3]).ToString("MM/dd/yyyy"),
                            //RoomType = reader[4].ToString();

                          

                        };
                        cust.Add(reservation);
                    };


                }

                //return the list to the calling method
                return cust;

            }

        }
    }
}