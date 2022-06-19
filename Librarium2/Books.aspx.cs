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
    public partial class About : Page
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
                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetAllBooks, DBConnection.connection);
                    ds = new DataSet();
                    DBConnection.adapter.Fill(ds); //делаем копию базы в adapter
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
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = GridView1.SelectedIndex;

            //  Ключевое поле можно извлечь из свойства SelectedDataKey
            int BookID = (int)GridView1.SelectedDataKey.Values["BookID"];
            
            // Перенаправляем на другую страницу с нужным индификатором
            Response.Redirect("NewBook.aspx?BookID=" + BookID);
        }
    }
}