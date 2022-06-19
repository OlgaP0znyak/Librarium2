using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace Librarium2
{
    public partial class Retracts : System.Web.UI.Page
    {
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetAllRetracts, DBConnection.connection);
                    ds = new DataSet();
                    DBConnection.adapter.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
            {
                DBConnection.connection.Open();
                DBConnection.command =
                        new SqlCommand(DBConnection.spInsertRetract, DBConnection.connection);
                DBConnection.command.CommandType = CommandType.StoredProcedure;

                //зададим параметры команды
                DBConnection.command.Parameters.Add(new SqlParameter("@retractdate", DateTime.Now.Date));
                DBConnection.command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@retractid",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                });

                DBConnection.command.ExecuteNonQuery();

                int RetractID = Convert.ToInt32(DBConnection.command.Parameters["@retractid"].Value);
                Response.Redirect("NewRetract.aspx?RetractID=" + RetractID);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Ключевое поле можно извлечь из свойства SelectedDataKey
            int RetractID = (int)GridView1.SelectedDataKey.Values["RetractID"];
            // Перенаправляем на другую страницу с нужным индификатором
            Response.Redirect("Retract.aspx?RetractID=" + RetractID);
        }
    }
}