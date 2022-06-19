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
    public partial class Retract : System.Web.UI.Page
    {
        int RetractID = 0;
        DateTime date;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RetractID"] != null)
            {
                RetractID = 0;
                int.TryParse(Request.QueryString["RetractID"], out RetractID);

                if (RetractID > 0)
                {
                    getRetract();
                    getRetractedBooks();
                }

            }
        }

        private void getRetract()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetRetractByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@id", RetractID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@retractid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@retractdate",
                        SqlDbType = SqlDbType.Date,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbRetractID.Text = DBConnection.command.Parameters["@retractid"].Value.ToString().Trim();
                    date = Convert.ToDateTime(DBConnection.command.Parameters["@retractdate"].Value);
                    tbRetractDate.Text = date.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getRetractedBooks()
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();

                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetRetractedBooks, DBConnection.connection);
                    DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DBConnection.adapter.SelectCommand.Parameters.Add("@retractid", SqlDbType.Int, 0).Value = RetractID;
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@readerid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@surname",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@name",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.adapter.SelectCommand.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@patronymic",
                        SqlDbType = SqlDbType.VarChar,
                        Size = 50,
                        Direction = ParameterDirection.Output
                    });
                    ds = new DataSet();
                    DBConnection.adapter.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();

                    tbReader.Text = "(" + DBConnection.adapter.SelectCommand.Parameters["@readerid"].Value.ToString().Trim() + ")" +
                        " " + DBConnection.adapter.SelectCommand.Parameters["@surname"].Value.ToString().Trim() +
                        " " + DBConnection.adapter.SelectCommand.Parameters["@name"].Value.ToString().Trim() +
                        " " + DBConnection.adapter.SelectCommand.Parameters["@patronymic"].Value.ToString().Trim();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}