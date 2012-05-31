using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;
namespace BusinessLayer
{
    public class StoresBL
    {
        DataSet ds;
        DAC.StoresDAC objStores = new StoresDAC();
        public DataSet GetAvailableQuantity(int Itemid)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetAvailableQuantity(Itemid);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetUnitOfMeasurement()
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetunitOfMeasurement();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


        public DataSet GetStudentAvailableItems(int Itemid)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetStudentAvailableItems(Itemid);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStaffAvailableItems(int Itemid)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetStaffAvailableItems(Itemid);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public decimal GetAvailableItems(int Item)
        {
            decimal i = 0;
            try
            {
                i = objStores.GetAvailableItems(Item);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        //public decimal GetAvailableItems(int Itemid)
        //{
        //    decimal i = 0;
        //    try
        //    {
        //        i = objStores.GetAvailableItems(Itemid);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return i;
        //}
        public DataSet GetQuantityProcurred(int Itemid)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetQuantityProcurred(Itemid);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


        public int AddStoreNewProcurement(int Product, int Purpose, decimal ItemRate, decimal Quantity, decimal Amount, DateTime DeliveryDate, DateTime DateofOrder, DateTime DateofDeliveryJNV, DateTime PACDate)
        {
            int i = 0;
            try
            {
                i = objStores.AddStoreNewProcurement(Product,Purpose,ItemRate, Quantity,Amount, DeliveryDate,DateofOrder,DateofDeliveryJNV,PACDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetItemsbyType(int Type, int Periodicity, int SubCategory)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetItemsbyType(Type,Periodicity,SubCategory);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStudProductIssue(int Product, int Purpose, int BatchID, int ClassID, int SectionID, int StudID, decimal ItemRate, int Quantity, decimal Amount, DateTime DateOFIssue)
        {
            int i = 0;
            try
            {
                i = objStores.AddStudProductIssue(Product, Purpose, BatchID, ClassID, SectionID, StudID, ItemRate, Quantity, Amount, DateOFIssue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffProductIssue(int Product, int Purpose, int StaffID, decimal ItemRate, decimal Quantity, decimal Amount, DateTime DateOFIssue)
        {
            int i = 0;
            try
            {
                i = objStores.AddStaffProductIssue(Product, Purpose, StaffID, ItemRate, Quantity, Amount, DateOFIssue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetStudentProductIssue(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetStudentProductIssue(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStaffProductIssue()
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetStaffProductIssue();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int DeleteStudentProductIssue(int Product, int StudID, DateTime DateOfIssue)
        {
            int i = 0;
            try
            {
                i = objStores.DeleteStudentProductIssue(Product, StudID, DateOfIssue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteStaffProductIssue(int Product, int StaffID, DateTime DateOfIssue)
        {
            int i = 0;
            try
            {
                i = objStores.DeleteStaffProductIssue(Product, StaffID, DateOfIssue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStorePurchases(int MonthofPurchase, int YearofPurchase, int ItemID, decimal OpeningQuantity, decimal OpeningRate, decimal OpeningAmt, decimal purchaseQuantity, decimal purchaseRate, decimal purchaseAmt, decimal ConsumptionQuantity, decimal ConsumptionRate, decimal ConsumptionAmt, decimal ClosingQuantity, decimal ClosingRate, decimal ClosingAmt)
        {
            int i = 0;
            try
            {
                i = objStores.AddStorePurchases(MonthofPurchase, YearofPurchase, ItemID, OpeningQuantity, OpeningRate, OpeningAmt, purchaseQuantity, purchaseRate, purchaseAmt, ConsumptionQuantity, ConsumptionRate, ConsumptionAmt, ClosingQuantity, ClosingRate, ClosingAmt);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStoreClosingBalance(int Month, int Year, int ItemId)
        {
            ds = new DataSet();
            try
            {
                ds = objStores.GetStoreClosingBalance(Month, Year, ItemId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


    }
}
