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
    public partial class Receipts : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetAllReceipts, DBConnection.connection);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;

            //  Ключевое поле можно извлечь из свойства SelectedDataKey
            int ReceiptID = (int)GridView1.SelectedDataKey.Values["ReceiptID"];

            // Перенаправляем на другую страницу с нужным индификатором
            Response.Redirect("Receipt.aspx?ReceiptID=" + ReceiptID);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {            
           
                using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.command =
                            new SqlCommand(DBConnection.spInsertReceipt, DBConnection.connection);
                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                    //зададим параметры команды
                    DBConnection.command.Parameters.Add(new SqlParameter("@receiptdate", DateTime.Now.Date));
                    DBConnection.command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@receiptid",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    });

                    DBConnection.command.ExecuteNonQuery();

                    int ReceiptID = Convert.ToInt32(DBConnection.command.Parameters["@receiptid"].Value);
                    Response.Redirect("NewReceipt.aspx?ReceiptID=" + ReceiptID);
                }
            
            
        }
    }
}