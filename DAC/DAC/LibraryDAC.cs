using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace DAC
{
    public class LibraryDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public DataSet GetLibSubCategory()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLibBookSubCategory");
            return ds;
        }
        public int AddLibBookSubCategory(string SubCategory, string SubCategoryNumber, int Category)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@SubCategory", SqlDbType.VarChar, 200);
            param[0].Value = SubCategory;
            param[1] = new SqlParameter("@SubCategoryNumber", SqlDbType.VarChar, 20);
            param[1].Value = SubCategoryNumber;
            param[2] = new SqlParameter("@Category", SqlDbType.Int, 20);
            param[2].Value = Category;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLibBookSubCategory", param);
            return i;


        }
        public int EditLibBookSubCategory(int SubCategoryID, string SubCategory, string SubCategoryNumber, int Category)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@SubCategoryID", SqlDbType.Int, 4);
            param[0].Value = SubCategoryID;
            param[1] = new SqlParameter("@SubCategory", SqlDbType.VarChar, 200);
            param[1].Value = SubCategory;
            param[2] = new SqlParameter("@SubCategoryNumber", SqlDbType.VarChar, 20);
            param[2].Value = SubCategoryNumber;
            param[3] = new SqlParameter("@Category", SqlDbType.Int, 20);
            param[3].Value = Category;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditLibBookSubCategory", param);
            return i;


        }
        public int DeleteLibBookSubCategory(int SubCategoryID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SubCategoryID", SqlDbType.Int, 4);
            param[0].Value = SubCategoryID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteLibBookSubCategory", param);
            return i;


        }
    

        public int UpdateLibraryBooks(int BookID, string AccessionNo, string Title, DateTime DateofAccession, int Medium, string Author, string Publisher, string PlaceofPublication, string ISBNNO, decimal Cost, string Volume, int BookStatus, string ClassNo, int Pagination, string Classification, int BookCategory, int SubCategory, int TypeofBook, string PhysicalDesc, string Edition, string YearofPublication, int BookSubject, int TypeofCurrency, int Collections, DateTime DateofInvoice, string Vendor, string BookNO, int Source, string OtherSource)
        {

            SqlParameter[] param = new SqlParameter[29];
            param[0] = new SqlParameter("@BookID", SqlDbType.Int, 30);
            param[0].Value = BookID;
            param[1] = new SqlParameter("@AccessionNo", SqlDbType.VarChar, 30);
            param[1].Value = AccessionNo;
            param[2] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
            param[2].Value = Title;
            param[3] = new SqlParameter("@DateofAccession", SqlDbType.DateTime, 8);
            param[3].Value = DateofAccession;
            param[4] = new SqlParameter("@Medium", SqlDbType.Int, 4);
            param[4].Value = Medium;
            param[5] = new SqlParameter("@Author", SqlDbType.VarChar, 100);
            param[5].Value = Author;
            param[6] = new SqlParameter("@Publisher", SqlDbType.VarChar, 100);
            param[6].Value = Publisher;
            param[7] = new SqlParameter("@PlaceofPublication", SqlDbType.VarChar, 100);
            param[7].Value = PlaceofPublication;
            param[8] = new SqlParameter("@ISBNNO", SqlDbType.VarChar, 20);
            param[8].Value = ISBNNO;
            param[9] = new SqlParameter("@Cost", SqlDbType.Decimal, 8);
            param[9].Value = Cost;
            param[10] = new SqlParameter("@Volume", SqlDbType.VarChar, 10);
            param[10].Value = Volume;
            param[11] = new SqlParameter("@BookStatus", SqlDbType.Int, 4);
            param[11].Value = BookStatus;
            param[12] = new SqlParameter("@ClassNo", SqlDbType.VarChar, 30);
            param[12].Value = ClassNo;
            param[13] = new SqlParameter("@Pagination", SqlDbType.Int, 4);
            param[13].Value = Pagination;
            param[14] = new SqlParameter("@Classification", SqlDbType.VarChar, 50);
            param[14].Value = Classification;
            param[15] = new SqlParameter("@BookCategory", SqlDbType.Int, 4);
            param[15].Value = BookCategory;
            param[16] = new SqlParameter("@SubCategory", SqlDbType.Int, 4);
            param[16].Value = SubCategory;
            param[17] = new SqlParameter("@TypeofBook", SqlDbType.Int, 4);
            param[17].Value = TypeofBook;
            param[18] = new SqlParameter("@PhysicalDesc", SqlDbType.VarChar, 30);
            param[18].Value = PhysicalDesc;
            param[19] = new SqlParameter("@Edition", SqlDbType.VarChar, 20);
            param[19].Value = Edition;
            param[20] = new SqlParameter("@YearofPublication", SqlDbType.VarChar, 6);
            param[20].Value = YearofPublication;
            param[21] = new SqlParameter("@BookSubject", SqlDbType.Int, 4);
            param[21].Value = BookSubject;
            param[22] = new SqlParameter("@TypeofCurrency", SqlDbType.Int, 4);
            param[22].Value = TypeofCurrency;
            param[23] = new SqlParameter("@Collections", SqlDbType.Int, 4);
            param[23].Value = Collections;
            param[24] = new SqlParameter("@DateofInvoice", SqlDbType.DateTime, 8);
            param[24].Value = DateofInvoice;
            param[25] = new SqlParameter("@Vendor", SqlDbType.VarChar, 80);
            param[25].Value = Vendor;
            param[26] = new SqlParameter("@BookNO", SqlDbType.VarChar, 20);
            param[26].Value = BookNO;
            param[27] = new SqlParameter("@Source", SqlDbType.Int, 4);
            param[27].Value = Source;
            param[28] = new SqlParameter("@OtherSource", SqlDbType.VarChar, 50);
            param[28].Value = OtherSource;
            ;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateLibraryBooks", param);
            return i;
        }


        public DataSet GetLibBookCategory()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLibBookCategory");
            return ds;
        }
        public DataSet GetLibBookData(int BookID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@BookID", SqlDbType.Int, 8);
            param.Value = BookID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLibraryBookData", param);
            return ds;
        }

        public int AddLibBookCategory(string Category, string CategoryNumber)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Category", SqlDbType.VarChar, 200);
            param[0].Value = Category;
            param[1] = new SqlParameter("@CategoryNumber", SqlDbType.VarChar, 20);
            param[1].Value = CategoryNumber;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLibBookCategory", param);
            return i;


        }
        public int EditLibBookCategory(int CategoryID, string Category, string CategoryNumber)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            param[0].Value = CategoryID;
            param[1] = new SqlParameter("@Category", SqlDbType.VarChar, 200);
            param[1].Value = Category;
            param[2] = new SqlParameter("@CategoryNumber", SqlDbType.VarChar, 20);
            param[2].Value = CategoryNumber;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditlibBookCategory", param);
            return i;


        }
        public int DeletelibBookCategory(int CategoryID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CategoryID", SqlDbType.Int, 4);
            param[0].Value = CategoryID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeletelibBookCategory", param);
            return i;


        }

        public DataSet GetLibBookSubCategory(int Category)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@Category", SqlDbType.Int, 8);
            param.Value = Category;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLibBookSubCategory", param);
            return ds;
        }

        

        public DataSet GetLibBooksbyAcessionNo(string AcessionNo)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@AcessionNo", SqlDbType.VarChar,30);
            param.Value = AcessionNo;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLibBooksbyAcessionNo", param);
            return ds;
        }

        public DataSet GetBookDetailsbyTypeandID(int IssueType, int RecieverID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IssueType", SqlDbType.Int, 4);
            param[0].Value = IssueType;
            param[1] = new SqlParameter("@RecieverID", SqlDbType.Int, 4);
            param[1].Value = RecieverID; 
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetBookDetailsbyTypeandID", param);
            return ds;
        }
        
        public int AddLibraryBooks(string AccessionNo, string Title, DateTime DateofAccession, int Medium, string Author, string Publisher, string PlaceofPublication, string ISBNNO, decimal Cost, string Volume, int BookStatus, string ClassNo, int Pagination, string Classification, int BookCategory, int SubCategory, int TypeofBook, string PhysicalDesc, string Edition, string YearofPublication, int BookSubject, int TypeofCurrency, int Collections, DateTime DateofInvoice, string Vendor, string BookNO, int Source, string OtherSource)
        {

            SqlParameter[] param = new SqlParameter[29];
            param[0] = new SqlParameter("@AccessionNo", SqlDbType.VarChar,30);
            param[0].Value = AccessionNo;
            param[1] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
            param[1].Value = Title;
            param[2] = new SqlParameter("@DateofAccession", SqlDbType.DateTime, 8);
            param[2].Value = DateofAccession;
            param[3] = new SqlParameter("@Medium", SqlDbType.Int,4);
            param[3].Value = Medium;
            param[4] = new SqlParameter("@Author", SqlDbType.VarChar,100);
            param[4].Value = Author;
            param[5] = new SqlParameter("@Publisher", SqlDbType.VarChar, 100);
            param[5].Value = Publisher;
            param[6] = new SqlParameter("@PlaceofPublication", SqlDbType.VarChar, 100);
            param[6].Value = PlaceofPublication;
            param[7] = new SqlParameter("@ISBNNO", SqlDbType.VarChar, 20);
            param[7].Value = ISBNNO;
            param[8] = new SqlParameter("@Cost", SqlDbType.Decimal, 8);
            param[8].Value = Cost;
            param[9] = new SqlParameter("@Volume", SqlDbType.VarChar,10);
            param[9].Value = Volume;
            param[10] = new SqlParameter("@BookStatus", SqlDbType.Int, 4);
            param[10].Value = BookStatus;
            param[11] = new SqlParameter("@ClassNo", SqlDbType.VarChar, 30);
            param[11].Value = ClassNo;
            param[12] = new SqlParameter("@Pagination", SqlDbType.Int, 4);
            param[12].Value = Pagination;
            param[13] = new SqlParameter("@Classification", SqlDbType.VarChar, 50);
            param[13].Value = Classification;
            param[14] = new SqlParameter("@BookCategory", SqlDbType.Int, 4);
            param[14].Value = BookCategory;
            param[15] = new SqlParameter("@SubCategory", SqlDbType.Int, 4);
            param[15].Value = SubCategory;
            param[16] = new SqlParameter("@TypeofBook", SqlDbType.Int, 4);
            param[16].Value = TypeofBook;
            param[17] = new SqlParameter("@PhysicalDesc", SqlDbType.VarChar,30);
            param[17].Value = PhysicalDesc;
            param[18] = new SqlParameter("@Edition", SqlDbType.VarChar, 20);
            param[18].Value = Edition;
            param[19] = new SqlParameter("@YearofPublication", SqlDbType.VarChar, 6);
            param[19].Value = YearofPublication;
            param[20] = new SqlParameter("@BookSubject", SqlDbType.Int, 4);
            param[20].Value = BookSubject;
            param[21] = new SqlParameter("@TypeofCurrency", SqlDbType.Int, 4);
            param[21].Value = TypeofCurrency;
            param[22] = new SqlParameter("@Collections", SqlDbType.Int, 4);
            param[22].Value = Collections;
            param[23] = new SqlParameter("@DateofInvoice", SqlDbType.DateTime, 8);
            param[23].Value = DateofInvoice;
            param[24] = new SqlParameter("@Vendor", SqlDbType.VarChar, 80);
            param[24].Value = Vendor;
            param[25] = new SqlParameter("@BookNO", SqlDbType.VarChar, 20);
            param[25].Value = BookNO;
            param[26] = new SqlParameter("@Source", SqlDbType.Int, 4);
            param[26].Value = Source;
            param[27] = new SqlParameter("@OtherSource", SqlDbType.VarChar, 50);
            param[27].Value = OtherSource;
            param[28] = new SqlParameter("@BookID", SqlDbType.Int, 4);
            param[28].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLibraryBooks", param);
            return Convert.ToInt32(param[28].Value);


        }

        public int LibraryBookIssue(int BookID, int IssueType, int RecieverID, DateTime IssueDate, DateTime DueDate, int ReturnStatus)
        {

            SqlParameter[] param = new SqlParameter[28];
            param[0] = new SqlParameter("@BookID", SqlDbType.Int, 4);
            param[0].Value = BookID;
            param[1] = new SqlParameter("@IssueType", SqlDbType.Int,4);
            param[1].Value = IssueType;
            param[2] = new SqlParameter("@RecieverID", SqlDbType.Int,4);
            param[2].Value = RecieverID;
            param[3] = new SqlParameter("@IssueDate", SqlDbType.DateTime, 8);
            param[3].Value = IssueDate;
            param[4] = new SqlParameter("@DueDate", SqlDbType.DateTime, 8);
            param[4].Value = DueDate;
            param[5] = new SqlParameter("@ReturnStatus", SqlDbType.Int, 4);
            param[5].Value = ReturnStatus;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spLibraryBookIssue", param);
            return i;


        }
        public int LibraryBookReturn(int BookID, int IssueType, int RecieverID, DateTime ReturnDate, int FineType, decimal Amount, string FineRecieptNo, DateTime PaymentDate)
        {

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@BookID", SqlDbType.Int, 4);
            param[0].Value = BookID;
            param[1] = new SqlParameter("@IssueType", SqlDbType.Int, 4);
            param[1].Value = IssueType;
            param[2] = new SqlParameter("@RecieverID", SqlDbType.Int, 4);
            param[2].Value = RecieverID;
            param[3] = new SqlParameter("@ReturnDate", SqlDbType.DateTime, 8);
            param[3].Value = ReturnDate;
            param[4] = new SqlParameter("@FineType", SqlDbType.Int, 4);
            param[4].Value = FineType;
            param[5] = new SqlParameter("@Amount", SqlDbType.Decimal, 8);
            param[5].Value = Amount;
            param[6] = new SqlParameter("@FineRecieptNo", SqlDbType.VarChar, 20);
            param[6].Value = FineRecieptNo;
            param[7] = new SqlParameter("@PaymentDate", SqlDbType.DateTime, 8);
            param[7].Value = PaymentDate;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spLibraryBookReturn", param);
            return i;


        }
    }
}
