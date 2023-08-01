using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using unitee_supplier_backend.Models;
using System.Web.UI.WebControls;

namespace unitee_supplier_backend.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult Login(UserAccount user)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("UserAccount_Login", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
            cmd.Parameters.AddWithValue("@User_Password", user.User_Password);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                var role = Convert.ToInt32(reader["User_Role"]);
                var id = Convert.ToInt32(reader["User_ID"]);
                conn.Close();

                // Here you map the role integer to the respective role string
                string roleString = RoleMapper(role);

                return Ok(new { message = "Successfully Login", role = roleString, id });
            }
            else
            {
                conn.Close();
                return Ok(new { message = "Invalid ID or Password" });
            }
        }

        private string RoleMapper(int role)
        {
            switch (role)
            {
                case 1:
                    return "user";
                case 2:
                    return "supplier";
                case 3:
                    return "admin";
                default:
                    return "unknown";
            }
        }

        [HttpPost]
        [Route("Register")]
        public string Register(UserAccount user)
        {
            string msg = "";
            conn.Open();
            SqlCommand cmd = new SqlCommand("Register_Customer", conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_ID", user.User_ID);
            cmd.Parameters.AddWithValue("@User_FirstName", user.User_FirstName);
            cmd.Parameters.AddWithValue("@User_LastName", user.User_LastName);
            cmd.Parameters.AddWithValue("@User_Email", user.User_Email);
            cmd.Parameters.AddWithValue("@User_PhoneNum", user.User_PhoneNum);
            cmd.Parameters.AddWithValue("@User_Password", user.User_Password);
            cmd.Parameters.AddWithValue("@Department_ID", int.Parse(user.Department_ID.ToString()));
            cmd.Parameters.AddWithValue("@User_Gender", user.User_Gender);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                msg = "Successfully Registered";
            }
            else
            {
                msg = "Unable to Register";
            }
            conn.Close();

            return msg;
        }
    }
}
