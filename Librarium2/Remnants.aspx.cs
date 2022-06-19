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
    public partial class Remnants : System.Web.UI.Page
    {
        DataSet ds;        
        string inputedBook;
        string selectedBook;        
        int bookID;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            inputedBook = tbBook.Text;
            try
            {
                using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                {
                    DBConnection.connection.Open();
                    DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetRemnants, DBConnection.connection);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bool flag = false;            
            string str = "";
            

            for (int i = 0; inputedBook[i] != ')'; i++)
            {

                if (flag == true)
                {
                    str = str + inputedBook[i];

                }
                if (inputedBook[i] == '(')
                    flag = true;

            }
            bookID = Convert.ToInt32(str);
            
                        
            if (String.IsNullOrEmpty(tbBook.Text.Trim()))
            {
                Label4.Text = "Не выбрана книга!";
            }
            else
            {
                try
                {
                    using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.adapter = new SqlDataAdapter(DBConnection.spGetRemnantsByBookID, DBConnection.connection);
                        DBConnection.adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                        DBConnection.adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int, 0).Value = bookID;
                                                
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

        protected void tbBook_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(inputedBook))
                lbBooks.Visible = false;
            else
            {
                try
                {
                    using (DBConnection.connection = new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.command =
                                new SqlCommand(DBConnection.spGetBooks, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        DBConnection.command.Parameters.Add("@book", SqlDbType.VarChar, 100).Value = inputedBook;

                        SqlDataReader reader = DBConnection.command.ExecuteReader();

                        string result;

                        lbBooks.Items.Clear();
                        lbBooks.Visible = true;

                        //вывод на экран
                        while (reader.Read()) //пока есть, что читать
                        {
                            result = $"({reader.GetValue(0)}) " +
                                $"{reader.GetValue(1)} " +
                                $"\"{reader.GetValue(2)}\" ";
                            //добавим строку в listBox1
                            lbBooks.Items.Add(result);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (lbBooks.Items.Count == 0)
                    lbBooks.Visible = false;
            }
        }

        protected void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedBook = (string)lbBooks.SelectedValue;
            tbBook.Text = selectedBook;
            lbBooks.Visible = false;
        }
    }
}