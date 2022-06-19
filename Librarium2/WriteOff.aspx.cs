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
    public partial class WriteOff : System.Web.UI.Page
    {
        int WriteOffID = 0;
        DateTime date;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["WriteOffID"] != null)
            {
                WriteOffID = 0;
                int.TryParse(Request.QueryString["WriteOffID"], out WriteOffID);

                if (WriteOffID > 0)
                {
                    getWriteOff();
                    getWritedOffBooks();
                }
            }
        }

        protected void getWriteOff()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetWriteOffByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@id", WriteOffID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@writeoffid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@writeoffdate",
                        SqlDbType = SqlDbType.Date,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbWriteOffID.Text = DBConnection.command.Parameters["@writeoffid"].Value.ToString().Trim();
                    date = Convert.ToDateTime(DBConnection.command.Parameters["@writeoffdate"].Value);
                    tbWriteOffDate.Text = date.ToString("yyyy-MM-dd");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void getWritedOffBooks()
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();

                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetWritedOffBooks, DBConnection.connection);
                    DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DBConnection.adapter.SelectCommand.Parameters.Add("@writeoffid", SqlDbType.Int, 0).Value = WriteOffID;
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
    }
}