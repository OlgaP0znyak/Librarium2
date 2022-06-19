using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Librarium2
{
    public partial class LogIn : System.Web.UI.Page
    {
        String result = "";
        string login = null;
        string password = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginAction_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetUserData, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    //зададим параметры команды
                    DBConnection.command.Parameters.Add(new SqlParameter("@login", UsernameText.Text));

                    //параметр, чтобы возвращать значение пароля из БД
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@password",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.ExecuteNonQuery();

                    //сохраним значение пароля из запроса
                    String temp = DBConnection.command.Parameters["@password"].Value.ToString().Trim();


                    if (String.IsNullOrEmpty(temp) || temp != PasswordText.Text.Trim())
                    {
                        result = "Неверный логин и/или пароль";
                    }
                    else
                    {
                        login = DBConnection.command.Parameters["@login"].Value.ToString().Trim();
                        password = temp;

                        result = "1"; //метка, что все прошло успешно
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }

            //что делаем после запроса в базу
            if (result == "1")
            {
                //загрузим форму

                FormsAuthentication.RedirectFromLoginPage(UsernameText.Text, false);

               
            }
            else MessageBox.Show(result);
        }


    }
}