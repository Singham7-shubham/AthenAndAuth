using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace AuthorizeandAuthenticate.Models
{
    public class UserRegistrationManager
    {
        public UserModel RegisterUserDetail(UserModel userModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using (SqlConnection con = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Register", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@Name", userModel.UserName);
                        cmd.Parameters.AddWithValue("@Email", userModel.UserEmail);
                        cmd.Parameters.AddWithValue("@password", userModel.UserPassword);
                        cmd.Parameters.AddWithValue("@Role", userModel.Role);
                        con.Open();
                        userModel.IsValid = cmd.ExecuteNonQuery();
                        if (userModel.IsValid > 0)
                        {
                            
                            userModel.LoginErrorMessage = "Registration Completed";
                        }
                        else
                        {
                            userModel.LoginErrorMessage = "Registration Failed";
                        }
                        return userModel;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (con.State == System.Data.ConnectionState.Open)
                        {
                            con.Close();
                        }
                    }
                }
            }
        }

    }
}