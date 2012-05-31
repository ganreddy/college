using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;

namespace BusinessLayer
{
    public class LibraryBL
    {
        DataSet ds;
        DAC.LibraryDAC objLibrary = new LibraryDAC();
        public DataSet GetLibSubCategory()
         {
             ds = new DataSet();
             try
             {
                 ds = objLibrary.GetLibSubCategory();
             }
             catch (Exception Ex)
             {
                 ErrHandler.WriteError(Ex.Message);
             }
             return ds;
         }
         public int AddLibBookSubCategory(string SubCategory, string SubCategoryNumber, int Category)
         {
             int i = 0;
             try
             {
                 i = objLibrary.AddLibBookSubCategory(SubCategory, SubCategoryNumber, Category);
             }
             catch (Exception Ex)
             {
                 ErrHandler.WriteError(Ex.Message);
             }
             return i;
         }
         public int EditLibBookSubCategory(int SubCategoryID, string SubCategory, string SubCategoryNumber, int Category)
         {
             int i = 0;
             try
             {
                 i = objLibrary.EditLibBookSubCategory(SubCategoryID, SubCategory, SubCategoryNumber, Category);
             }
             catch (Exception Ex)
             {
                 ErrHandler.WriteError(Ex.Message);
             }
             return i;
         }
         public int DeleteLibBookSubCategory(int SubCategoryID)
         {
             int i = 0;
             try
             {
                 i = objLibrary.DeleteLibBookSubCategory(SubCategoryID);
             }
             catch (Exception Ex)
             {
                 ErrHandler.WriteError(Ex.Message);
             }
             return i;
         }


    

        public int UpdateLibraryBooks(int BookID, string AccessionNo, string Title, DateTime DateofAccession, int Medium, string Author, string Publisher, string PlaceofPublication, string ISBNNO, decimal Cost, string Volume, int BookStatus, string ClassNo, int Pagination, string Classification, int BookCategory, int SubCategory, int TypeofBook, string PhysicalDesc, string Edition, string YearofPublication, int BookSubject, int TypeofCurrency, int Collections, DateTime DateofInvoice, string Vendor, string BookNO, int Source, string OtherSource)
        {
            int i = 0;
            try
            {
                i = objLibrary.UpdateLibraryBooks(BookID, AccessionNo, Title, DateofAccession, Medium, Author, Publisher, PlaceofPublication, ISBNNO, Cost, Volume, BookStatus, ClassNo, Pagination, Classification, BookCategory, SubCategory, TypeofBook, PhysicalDesc, Edition, YearofPublication, BookSubject, TypeofCurrency, Collections, DateofInvoice, Vendor, BookNO, Source, OtherSource);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetLibBookCategory()
        {
            ds = new DataSet();
            try
            {
                ds = objLibrary.GetLibBookCategory();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetLibBookData(int BookID)
        {
            ds = new DataSet();
            try
            {
                ds = objLibrary.GetLibBookData(BookID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddLibBookCategory(string Category, string CategoryNumber)
        {
            int i = 0;
            try
            {
                i = objLibrary.AddLibBookCategory(Category, CategoryNumber);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditLibBookCategory(int CategoryID, string Category, string CategoryNumber)
        {
            int i = 0;
            try
            {
                i = objLibrary.EditLibBookCategory(CategoryID, Category, CategoryNumber);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteLibBookCategory(int CategoryID)
        {
            int i = 0;
            try
            {
                i = objLibrary.DeletelibBookCategory(CategoryID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        
        public DataSet GetLibBookSubCategory(int Category)
        {
            ds = new DataSet();
            try
            {
                ds = objLibrary.GetLibBookSubCategory(Category);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
         public int AddLibraryBooks(string AccessionNo, string Title, DateTime DateofAccession, int Medium, string Author, string Publisher, string PlaceofPublication, string ISBNNO, decimal Cost, string Volume, int BookStatus, string  ClassNo, int Pagination, string Classification, int BookCategory, int SubCategory, int TypeofBook, string PhysicalDesc, string Edition, string YearofPublication, int BookSubject, int TypeofCurrency, int Collections, DateTime DateofInvoice, string Vendor, string BookNO, int Source, string OtherSource)
        {
            int i = 0;
            try
            {
                i = objLibrary.AddLibraryBooks(AccessionNo,Title, DateofAccession,Medium,Author,Publisher, PlaceofPublication,ISBNNO,Cost,Volume,BookStatus,ClassNo, Pagination,Classification,BookCategory,SubCategory,TypeofBook,PhysicalDesc,Edition,YearofPublication,BookSubject, TypeofCurrency,Collections,DateofInvoice,Vendor,BookNO,Source,OtherSource);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
         public DataSet GetLibBooksbyAcessionNo(string AcessionNo)
        {
            ds = new DataSet();
            try
            {
                ds = objLibrary.GetLibBooksbyAcessionNo(AcessionNo);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetBookDetailsbyTypeandID(int IssueType, int RecieverID)
         {
             ds = new DataSet();
             try
             {
                 ds = objLibrary.GetBookDetailsbyTypeandID(IssueType, RecieverID);
             }
             catch (Exception Ex)
             {
                 ErrHandler.WriteError(Ex.Message);
             }
             return ds;
         }
        public int LibraryBookIssue(int BookID, int IssueType, int RecieverID, DateTime IssueDate, DateTime DueDate, int ReturnStatus)
         {
             int i = 0;
             try
             {
                 i = objLibrary.LibraryBookIssue(BookID,IssueType,RecieverID,IssueDate,DueDate,ReturnStatus);
             }
             catch (Exception Ex)
             {
                 ErrHandler.WriteError(Ex.Message);
             }
             return i;
         }
         public int LibraryBookReturn(int BookID, int IssueType, int RecieverID, DateTime ReturnDate, int FineType, decimal Amount, string FineRecieptNo, DateTime PaymentDate)
        {
            int i = 0;
            try
            {
                i = objLibrary.LibraryBookReturn(BookID,IssueType,RecieverID, ReturnDate,FineType,Amount,FineRecieptNo,PaymentDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
    }
}
