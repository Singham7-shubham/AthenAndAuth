using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthorizeandAuthenticate.Models
{
    public class UserAuthenticationManager
    {
        public UserModel UserAuth(UserModel userModel)
        {
            string scn = ConfigurationManager.ConnectionStrings["scn"].ConnectionString;
            using(SqlConnection cn=new SqlConnection(scn))
            {
                using(SqlCommand cmd=new SqlCommand("SP_UserAuthentication", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserEmail", userModel.UserEmail);
                    cmd.Parameters.AddWithValue("@UserPassword",userModel.UserPassword);
                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if( dr.Read())
                        {

                                userModel.Role = Convert.ToString(dr["Role"]);
                                userModel.UserEmail = Convert.ToString(dr["UserEmail"]);
                                userModel.UserName = Convert.ToString(dr["UserName"]);
                                userModel.IsValid = 1;
                                return userModel;
                         }
                        else
                        {
                                userModel.IsValid = 0;
                                return userModel;
                        }
                        
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }
            return null;
        }
    }
}