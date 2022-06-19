using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Librarium2
{
    public class DBConnection
    {
        public static SqlConnection connection = null;
        public static SqlCommand command = null;
        public static SqlDataAdapter adapter;
        public static SqlCommandBuilder commandBuilder;

        //строка соединения с базой
        public static string connectionString = @"Data Source=DESKTOP-VBSEF5C;Initial Catalog=DB_Lib;Integrated Security=True";

        //строки с наименованиями хранимых процедур

        //получение пароля пользователя
        public static string spGetUserData = "sp_GetPassword";
        //добавление новой книги в базу
        public static string spInsertNewBook = "sp_InsertNewBook";
        //выбор списка всех книг
        public static string spGetAllBooks = "sp_GetAllBooks";
        //поиск книг по названию
        public static string spGetBooksByName = "sp_GetBooksByName";
        //поиск книг по автору
        public static string spGetBooksByAuthor = "sp_GetBooksByAuthor";
        //поиск книг по автору и названию
        public static string spGetBooksByAuthorAndName = "sp_GetBooksByAuthorAndName";

        public static string spGetBookByID = "sp_GetBookByID";
        public static string spUpdateBook = "sp_UpdateBook";

        public static string spInsertNewReader = "sp_InsertNewReader";
        public static string spGetAllReaders = "sp_GetAllReaders";
        public static string spGetReaders = "sp_GetReaders";
        public static string spGetReadersByName = "sp_GetReadersByName";
        public static string spGetReadersBySurname = "sp_GetReadersBySurname";
        public static string spGetReadersBySurnameAndName = "sp_GetReadersBySurnameAndName";
        public static string spGetReaderByID = "sp_GetReaderByID";
        public static string spUpdateReader = "sp_UpdateReader";

        public static string spGetAllReceipts = "sp_GetAllReceipts";
        public static string spInsertReceipt = "sp_InsertReceipt";
        public static string spGetReceiptedBooks = "sp_GetReceiptedBooks";
        public static string spInsertReceiptedBooks = "sp_InsertReceiptedBooks";
        public static string spGetReceiptByID = "sp_GetReceiptByID";
        public static string spGetReceiptsByID = "sp_GetReceiptsByID";
        public static string spGetReceiptsByDate = "sp_GetReceiptsByDate";
        public static string spGetReceiptsByIDAndDate = "sp_GetReceiptsByIDAndDate";

        public static string spGetAllWriteOffs = "sp_GetAllWriteOffs";
        public static string spInsertWriteOff = "sp_InsertWriteOff";
        public static string spGetWriteOffByID = "sp_GetWriteOffByID";
        public static string spGetWritedOffBooks = "sp_GetWritedOffBooks";
        public static string spInsertWritedOffBooks = "sp_InsertWritedOffBooks";
        public static string spGetRemnantByBook = "sp_GetRemnantByBook";
        /*
        public static string spGetReceiptsByID = "sp_GetReceiptsByID";
        public static string spGetReceiptsByDate = "sp_GetReceiptsByDate";
        public static string spGetReceiptsByIDAndDate = "sp_GetReceiptsByIDAndDate";
         */

        public static string spGetIssuedBooks = "sp_GetIssuedBooks";
        public static string spGetBooks = "sp_GetBooks";
        public static string spInsertIssuance = "sp_InsertIssuance";
        public static string spInsertIssuedBooks = "sp_InsertIssuedBooks";

        public static string spGetRemnants = "sp_GetRemnants";
        public static string spGetRemnantsByBookID = "sp_GetRemnantsByBookID";
        public static string spGetRemnantByBookID = "sp_GetRemnantByBookID";

        public static string spGetAllIssuances = "sp_GetAllIssuances";

        public static string spGetIssuanceByID = "sp_GetIssuanceByID";

        public static string spGetBooksOnHand = "sp_GetBooksOnHand";
        public static string spGetBooksonhandByBookid = "sp_GetBooksonhandByBookid";
        public static string spGetBooksonhandByReaderid = "sp_GetBooksonhandByReaderid";
        public static string spGetBooksonhandByReader = "sp_GetBooksonhandByReader";
        public static string spGetBooksonhandByBookidAndReaderid = "sp_GetBooksonhandByBookidAndReaderid";

        public static string spGetRetractedBooks = "sp_GetRetractedBooks";
        public static string spInsertRetract = "sp_InsertRetract";
        public static string spInsertRetractedBooks = "sp_InsertRetractedBooks";

        public static string spGetAllRetracts = "sp_GetAllRetracts";

        public static string spGetRetractByID = "sp_GetRetractByID";
    }
}