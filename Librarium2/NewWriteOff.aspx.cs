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
    public partial class NewWriteOff : System.Web.UI.Page
    {
        DataSet ds;
        DataTable dt;
        DateTime date;
        string selectedbook;
        string inputedBook;
        int countListBoxRow = 0;
        public int bookID;
        string WriteOffDate;
        int WriteOffID;
        int coutRemnant;
        protected void Page_Load(object sender, EventArgs e)
        {
            inputedBook = tbBook.Text;
            countListBoxRow = lbBooks.Items.Count;
            WriteOffDate = tbWriteOffDate.Text;
            Label3.Text = "";

            if (Request.QueryString["WriteOffID"] != null)
            {

                WriteOffID = 0;
                int.TryParse(Request.QueryString["WriteOffID"], out WriteOffID);
            }
            getWriteOff();
            getWritedOffBooks();
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
                try
                {
                    using (DBConnection.connection =
                        new SqlConnection(DBConnection.connectionString))
                    {
                        DBConnection.connection.Open();
                        DBConnection.command =
                            new SqlCommand(DBConnection.spGetRemnantByBook, DBConnection.connection);
                        DBConnection.command.CommandType = CommandType.StoredProcedure;

                        DBConnection.command.Parameters.Add(new SqlParameter("@bookid", bookID));

                        DBConnection.command.Parameters.Add(new SqlParameter
                        {
                            ParameterName = "@quantity",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        });

                        DBConnection.command.ExecuteNonQuery();
                        coutRemnant = Convert.ToInt32(DBConnection.command.Parameters["@quantity"].Value);

                        if (Convert.ToInt32(tbCount.Text) > coutRemnant)
                            MessageBox.Show("Введенное количество превышает количество книг на остатках.\n Остаток: " + coutRemnant.ToString() + " шт.");
                        else
                        {
                            try
                            {

                                using (DBConnection.connection =
                                new SqlConnection(DBConnection.connectionString))
                                {
                                    DBConnection.connection.Open();
                                    DBConnection.command =
                                            new SqlCommand(DBConnection.spInsertWritedOffBooks, DBConnection.connection);
                                    DBConnection.command.CommandType = CommandType.StoredProcedure;

                                    //зададим параметры команды
                                    DBConnection.command.Parameters.Add(new SqlParameter("@bookid", bookID));
                                    DBConnection.command.Parameters.Add(new SqlParameter("@quantity", tbCount.Text));
                                    DBConnection.command.Parameters.Add(new SqlParameter("@writeoffid", WriteOffID));

                                    DBConnection.command.ExecuteNonQuery();

                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            tbBook.Text = "";
            tbCount.Text = "";
            getWritedOffBooks();
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