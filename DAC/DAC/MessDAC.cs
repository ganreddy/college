using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;


namespace DAC
{

    public class MessDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public DataSet CheckDuplicatesDishItems(DateTime Date)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[0].Value = Date;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCheckMessDishItemsDuplicates", param);
            return ds;


        }
        public int AddItemCalculation(DateTime Date, int DishName, int ItemName, int Quantity,decimal UnitCost,decimal TotalCost,decimal LabourCost,decimal MiscellaneousCost,decimal EntireTotalCost)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[0].Value = Date;
            param[1] = new SqlParameter("@DishName", SqlDbType.Int, 4);
            param[1].Value = DishName;
            param[2] = new SqlParameter("@ItemName", SqlDbType.Int, 5);
            param[2].Value = ItemName;
            param[3] = new SqlParameter("@Quantity", SqlDbType.Int, 100);
            param[3].Value = Quantity;
            param[4] = new SqlParameter("@UnitCost", SqlDbType.Decimal, 8);
            param[4].Value = UnitCost;
            param[5] = new SqlParameter("@TotalCost", SqlDbType.Decimal, 8);
            param[5].Value = TotalCost;
            param[6] = new SqlParameter("@LabourCost", SqlDbType.Decimal, 8);
            param[6].Value = LabourCost;
            param[7] = new SqlParameter("@MiscellaneousCost", SqlDbType.Decimal, 8);
            param[7].Value = MiscellaneousCost;
            param[8] = new SqlParameter("@EntireTotalCost", SqlDbType.Decimal, 8);
            param[8].Value = EntireTotalCost;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddItemCalculation", param);
            return i;
        }
        public DataSet GetItemByCategory(int Category)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Category", SqlDbType.Int, 8);
            param[0].Value = Category;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetItemByCategory", param);
            return ds;


        }
        public DataSet GetMessDishItemCalc()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMeshDishByItemCalc");
            return ds;
        }
        public DataSet GetMessClosingBalance(int Month, int Year,int ItemId)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[0].Value = Month;
            param[1] = new SqlParameter("@Year", SqlDbType.Int, 8);
            param[1].Value = Year;
            param[2] = new SqlParameter("@ItemId", SqlDbType.Int, 4);
            param[2].Value = ItemId;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetClosingBalance", param);
            return ds;


        }
        public DataSet GetMessDish()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMessDish");
            return ds;
        }
        public DataSet GetMealType()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMealType");
            return ds;
        }
        public int AddMessDish(string DishName, int MealType)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DishName", SqlDbType.VarChar, 20);
            param[0].Value = DishName;
            param[1] = new SqlParameter("@MealType", SqlDbType.Int, 4);
            param[1].Value = MealType;
            
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddMessDish", param);
            return i;


        }
        public int EditMessDish(int DishID, string DishName, int MealType)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@DishID", SqlDbType.Int, 4);
            param[0].Value = DishID;

            param[1] = new SqlParameter("@DishName", SqlDbType.VarChar, 200);
            param[1].Value = DishName;
            param[2] = new SqlParameter("@MealType", SqlDbType.Int, 4);
            param[2].Value = MealType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditMessDish", param);
            return i;


        }
        public int DeleteMessDish(int DishID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@DishID", SqlDbType.Int, 4);
            param[0].Value = DishID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteMessDish", param);
            return i;


        }
        public int AddMessDishConsumption(DateTime Date, int DishID, int MealType, int NoofStudents)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[0].Value = Date;
            param[1] = new SqlParameter("@DishID", SqlDbType.Int, 4);
            param[1].Value = DishID;
            param[2] = new SqlParameter("@MealType", SqlDbType.Int, 5);
            param[2].Value = MealType;
            param[3] = new SqlParameter("@NoOfStudents", SqlDbType.Int, 100);
            param[3].Value = NoofStudents;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddMeshDishConsumption", param);
            return i;
        }
        public DataSet GetMessDishConsumption(int MealType)
        {


            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MealType", SqlDbType.Int, 4);
            param[0].Value = MealType;
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMeshDishByMealType", param);
            return ds;
        }

        public int AddItemConsumption(DateTime Date, int ItemID, decimal Quantity, int UOMID)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[0].Value = Date;
            param[1] = new SqlParameter("@ItemID", SqlDbType.Int, 8);
            param[1].Value = ItemID;
            param[2] = new SqlParameter("@Quantity", SqlDbType.Decimal, 8);
            param[2].Value = Quantity;
            param[3] = new SqlParameter("UOMID", SqlDbType.Int);
            param[3].Value = UOMID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddItemConsumption", param);
            return i;

        }

        public int DeleteItemConsumption(DateTime Date, int ItemID, decimal Quantity)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[0].Value = Date;
            param[1] = new SqlParameter("@ItemID", SqlDbType.Int, 4);
            param[1].Value = ItemID;
            param[2] = new SqlParameter("@Quantity", SqlDbType.Int, 4);
            param[2].Value = Quantity;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteItemConsumption", param);
            return i;
        }
        public int AddMessPurchases(int MonthofPurchase,int YearofPurchase,int ItemID, decimal OpeningQuantity, decimal OpeningRate, decimal OpeningAmt, decimal purchaseQuantity, decimal purchaseRate, decimal purchaseAmt, decimal ConsumptionQuantity, decimal ConsumptionRate, decimal ConsumptionAmt, decimal ClosingQuantity, decimal ClosingRate, decimal ClosingAmt)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@MonthofPurchase", SqlDbType.Int, 4);
            param[0].Value = MonthofPurchase;
            param[1] = new SqlParameter("@YearofPurchase", SqlDbType.Int, 4);
            param[1].Value = YearofPurchase;
            param[2] = new SqlParameter("@ItemID", SqlDbType.Int, 4);
            param[2].Value = ItemID;
            param[3] = new SqlParameter("@OpeningQuantity", SqlDbType.Decimal, 8);
            param[3].Value = OpeningQuantity;
            param[4] = new SqlParameter("@OpeningRate", SqlDbType.Decimal, 4);
            param[4].Value = OpeningRate;
            param[5] = new SqlParameter("@OpeningAmt", SqlDbType.Decimal, 4);
            param[5].Value = OpeningAmt;
            param[6] = new SqlParameter("@purchaseQuantity", SqlDbType.Decimal, 8);
            param[6].Value = purchaseQuantity;
            param[7] = new SqlParameter("@purchaseRate", SqlDbType.Decimal, 4);
            param[7].Value = purchaseRate;
            param[8] = new SqlParameter("@purchaseAmt", SqlDbType.Decimal, 4);
            param[8].Value = purchaseAmt;
            param[9] = new SqlParameter("@ConsumptionQuantity", SqlDbType.Decimal, 8);
            param[9].Value = ConsumptionQuantity;
            param[10] = new SqlParameter("@ConsumptionRate", SqlDbType.Decimal, 4);
            param[10].Value = ConsumptionRate;
            param[11] = new SqlParameter("@ConsumptionAmt", SqlDbType.Decimal, 4);
            param[11].Value = ConsumptionAmt;
            param[12] = new SqlParameter("@ClosingQuantity", SqlDbType.Decimal, 8);
            param[12].Value = ClosingQuantity;
            param[13] = new SqlParameter("@ClosingRate", SqlDbType.Decimal, 4);
            param[13].Value = ClosingRate;
            param[14] = new SqlParameter("@ClosingAmt", SqlDbType.Decimal, 4);
            param[14].Value = ClosingAmt;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddMessPurchases", param);
            return i;
        }
        public DataSet GetItemConsumption()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetItemConsumption");
            return ds;
        }


    }
}
