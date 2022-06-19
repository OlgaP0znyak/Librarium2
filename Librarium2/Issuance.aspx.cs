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
    public partial class Issuance : System.Web.UI.Page
    {
        int IssuanceID = 0;
        DateTime date;
        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IssuanceID"] != null)
            {
                IssuanceID = 0;
                int.TryParse(Request.QueryString["IssuanceID"], out IssuanceID);

                if (IssuanceID > 0)
                {
                    getIssuance();
                    getIssuedBooks();
                }

            }
        }

        private void getIssuance()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetIssuanceByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@id", IssuanceID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@issuanceid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@issuancedate",
                        SqlDbType = SqlDbType.Date,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbIssuanceID.Text = DBConnection.command.Parameters["@issuanceid"].Value.ToString().Trim();
                    date = Convert.ToDateTime(DBConnection.command.Parameters["@issuancedate"].Value);
                    tbIssuanceDate.Text = date.ToString("yyyy-MM-dd");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getIssuedBooks()
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();

                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetIssuedBooks, DBConnection.connection);
                    DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DBConnection.adapter.SelectCommand.Parameters.Add("@issuanceid", SqlDbType.Int, 0).Value = IssuanceID;
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