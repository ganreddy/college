using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;

namespace BusinessLayer
{
    public class MessBL
    {
        DataSet ds;
        DAC.MessDAC objMess = new DAC.MessDAC();
        public DataSet CheckDuplicatesDishItems(DateTime Date)
        {
            ds = new DataSet();
            try
            {
                ds = objMess.CheckDuplicatesDishItems(Date);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddItemCalculation(DateTime Date,int DishName, int ItemName, int Quantity, decimal UnitCost, decimal TotalCost, decimal LabourCost, decimal MiscellaneousCost, decimal EntireTotalCost)
        {
            int i = 0;
            try
            {
                i = objMess.AddItemCalculation(Date, DishName, ItemName, Quantity, UnitCost, TotalCost, LabourCost, MiscellaneousCost, EntireTotalCost);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetItemByCategory(int Category)
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetItemByCategory(Category);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetMessDishItemCalc()
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetMessDishItemCalc();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetMessClosingBalance(int Month, int Year, int ItemId)
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetMessClosingBalance(Month, Year, ItemId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetMessDish()
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetMessDish();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


        public DataSet GetMealType()
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetMealType();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddMessDish(string DishName, int MealType)
        {
            int i = 0;
            try
            {
                i = objMess.AddMessDish(DishName, MealType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditMessDish(int DishID, string DishName, int MealType)
        {
            int i = 0;
            try
            {
                i = objMess.EditMessDish(DishID, DishName, MealType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteMessDish(int DishID)
        {
            int i = 0;
            try
            {
                i = objMess.DeleteMessDish(DishID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddMessDishConsumption(DateTime Date, int DishID, int MealType, int NoofStudents)
        {
            int i = 0;
            try
            {
                i = objMess.AddMessDishConsumption(Date, DishID, MealType, NoofStudents);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetMessDishConsumption(int MealType)
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetMessDishConsumption(MealType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddItemConsumption(DateTime Date, int ItemID, decimal Quantity,int UOMID)
        {
            int i = 0;
            try
            {
                i = objMess.AddItemConsumption(Date, ItemID, Quantity, UOMID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteItemConsumption(DateTime Date, int ItemID, decimal Quantity)
        {
            int i = 0;
            try
            {
                i = objMess.DeleteItemConsumption(Date, ItemID, Quantity);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public int AddMessPurchases(int MonthofPurchase, int YearofPurchase, int ItemID, decimal OpeningQuantity, decimal OpeningRate, decimal OpeningAmt, decimal purchaseQuantity, decimal purchaseRate, decimal purchaseAmt, decimal ConsumptionQuantity, decimal ConsumptionRate, decimal ConsumptionAmt, decimal ClosingQuantity, decimal ClosingRate, decimal ClosingAmt)
        {
            int i = 0;
            try
            {
                i = objMess.AddMessPurchases(MonthofPurchase, YearofPurchase, ItemID, OpeningQuantity, OpeningRate, OpeningAmt, purchaseQuantity, purchaseRate, purchaseAmt, ConsumptionQuantity, ConsumptionRate, ConsumptionAmt, ClosingQuantity, ClosingRate, ClosingAmt);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetItemConsumption()
        {
            ds = new DataSet();
            try
            {
                ds = objMess.GetItemConsumption();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        

    }
}
