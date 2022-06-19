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
    public partial class Receipt : System.Web.UI.Page
    {
        int ReceiptID = 0;
        DateTime date;
        DataSet ds;
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["ReceiptID"] != null)
            {
                ReceiptID = 0;
                int.TryParse(Request.QueryString["ReceiptID"], out ReceiptID);

                if (ReceiptID > 0)
                {
                    getReceipt();
                    getReceiptedBooks();
                }
            }
            
        }

        protected void getReceipt()
        {
            try
            {
                using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                        new SqlCommand(DBConnection.spGetReceiptByID, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    DBConnection.command.Parameters.Add(new SqlParameter("@id", ReceiptID));

                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@receiptid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@receiptdate",
                        SqlDbType = SqlDbType.Date,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    tbReceiptID.Text = DBConnection.command.Parameters["@receiptid"].Value.ToString().Trim();
                    date = Convert.ToDateTime(DBConnection.command.Parameters["@receiptdate"].Value);
                    tbReceiptDate.Text = date.ToString("yyyy-MM-dd");                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void getReceiptedBooks()
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();

                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetReceiptedBooks, DBConnection.connection);
                    DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DBConnection.adapter.SelectCommand.Parameters.Add("@receiptid", SqlDbType.Int, 0).Value = ReceiptID;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}