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
    public partial class NewReceipt : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DateTime date;
        string selectedbook;
        string inputedBook;
        int countListBoxRow = 0;
        public int bookID;
        string receiptDate;
        int ReceiptID;
        int a = 0;
        protected void Page_Load(object sender, EventArgs e)
        {  
            inputedBook = tbBook.Text;
            countListBoxRow = lbBooks.Items.Count;            
            receiptDate = tbReceiptDate.Text;
            Label3.Text = "";

            if (Request.QueryString["ReceiptID"] != null)
            {            

                ReceiptID = 0;
                int.TryParse(Request.QueryString["ReceiptID"], out ReceiptID);  
            }

            getReceipt();
            getReceiptedBooks();
           
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

        protected void Button1_Click(object sender, EventArgs e)
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
            
            
            if (String.IsNullOrEmpty(tbBook.Text.Trim()) || String.IsNullOrEmpty(tbCount.Text.Trim()))
            {
                Label3.Text = "Не выбрана книга и/или не введено количество!";
            }
            else
            {
                //MessageBox.Show(bookID.ToString());
                try
                {
                    
                    using (DBConnection.connection =
                    new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.command =
                                new SqlCommand(DBConnection.spInsertReceiptedBooks, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        //зададим параметры команды
                        DBConnection.command.Parameters.Add(new SqlParameter("@bookid", bookID));
                        DBConnection.command.Parameters.Add(new SqlParameter("@quantity", tbCount.Text));
                        DBConnection.command.Parameters.Add(new SqlParameter("@receiptid", ReceiptID));
                        
                        DBConnection.command.ExecuteNonQuery();
                                                
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            tbBook.Text = "";
            tbCount.Text = "";
            getReceiptedBooks();
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
                                new SqlCommand(DBConnection.spGetBooksByName, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        DBConnection.command.Parameters.Add("@bookname", SqlDbType.VarChar, 100).Value = inputedBook;

                        SqlDataReader reader = DBConnection.command.ExecuteReader();

                        string result;

                        lbBooks.Items.Clear();
                        lbBooks.Visible = true;

                        //вывод на экран
                        while (reader.Read()) //пока есть, что читать
                        {
                            countListBoxRow++;
                            result = $"({reader.GetValue(0)}) " +
                                $"{reader.GetValue(1)} " +
                                $"\"{reader.GetValue(2)}\"";
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
            selectedbook = (string)lbBooks.SelectedValue;
            tbBook.Text = selectedbook;
            lbBooks.Visible = false;            
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}