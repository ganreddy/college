using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace DAC
{
    public class StoresDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public DataSet GetunitOfMeasurement()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetUnitMeasurement");
            return ds;
        }
        public DataSet GetAvailableQuantity(int Itemid)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ItemId", SqlDbType.Int, 8);
            param[0].Value = Itemid;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAvailableQuantity", param);
            return ds;
        }
        //public decimal GetAvailableItems()
        //{
        //    int i;
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[1] = new SqlParameter("@id", SqlDbType.Decimal, 8);
        //    param[1].Direction = ParameterDirection.Output;
        //    i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spGetAvailableItems", param);
        //    return Convert.ToDecimal(param[1].Value);

        //}
        public decimal GetAvailableItems(int Itemid)
        {
            int i;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 8);
            param[0].Value = Itemid;
            param[1] = new SqlParameter("@id", SqlDbType.Decimal, 8);
            param[1].Direction = ParameterDirection.Output;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spGetAvailableItems", param);
            return Convert.ToDecimal(param[1].Value);

        }
        public DataSet GetStaffAvailableItems(int Itemid)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 8);
            param[0].Value = Itemid;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffProductsAvailability", param);
            return ds;
        }
        public DataSet GetStudentAvailableItems(int Itemid)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 8);
            param[0].Value = Itemid;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentProductsAvailability", param);
            return ds;
        }
        public DataSet GetQuantityProcurred(int Itemid)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ItemID", SqlDbType.Int, 8);
            param[0].Value = Itemid;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetQuantityProcurred", param);
            return ds;
        }

        public int AddStoreNewProcurement(int Product, int Purpose, decimal ItemRate, decimal Quantity, decimal Amount, DateTime DeliveryDate, DateTime DateofOrder, DateTime DateofDeliveryJNV, DateTime PACDate)
        {

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Product", SqlDbType.Int, 4);
            param[0].Value = Product;
            param[1] = new SqlParameter("@Purpose", SqlDbType.Int, 4);
            param[1].Value = Purpose;
            param[2] = new SqlParameter("@ItemRate", SqlDbType.Decimal, 8);
            param[2].Value = ItemRate;
            param[3] = new SqlParameter("@Quantity", SqlDbType.Decimal, 8);
            param[3].Value = Quantity;
            param[4] = new SqlParameter("@Amount", SqlDbType.Decimal, 4);
            param[4].Value = Amount;
            param[5] = new SqlParameter("@DeliveryDate", SqlDbType.DateTime, 8);
            param[5].Value = DeliveryDate;
            param[6] = new SqlParameter("@DateofOrder", SqlDbType.DateTime, 8);
            param[6].Value = DateofOrder;
            param[7] = new SqlParameter("@DateofDeliveryJNV", SqlDbType.DateTime, 8);
            param[7].Value = DateofDeliveryJNV;
            param[8] = new SqlParameter("@PACDate", SqlDbType.DateTime, 8);
            param[8].Value = PACDate;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStoreNewProcurement", param);
            return i;


        }

        public DataSet GetItemsbyType(int Type, int Periodicity, int SubCategory)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Type", SqlDbType.Int, 8);
            param[0].Value = Type;
            param[1] = new SqlParameter("@Periodicity", SqlDbType.Int, 8);
            param[1].Value = Periodicity;
            param[2] = new SqlParameter("@SubCategory", SqlDbType.Int, 8);
            param[2].Value = SubCategory;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetItemsbyType", param);
            return ds;
        }

        public int AddStudProductIssue(int Product, int Purpose, int BatchID, int ClassID, int SectionID, int StudID, decimal ItemRate, int Quantity, decimal Amount, DateTime DateOFIssue)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Product", SqlDbType.Int, 4);
            param[0].Value = Product;
            param[1] = new SqlParameter("@Purpose", SqlDbType.Int, 4);
            param[1].Value = Purpose;
            param[2] = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            param[2].Value = BatchID;
            param[3] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
            param[3].Value = ClassID;
            param[4] = new SqlParameter("@SectionID", SqlDbType.Int, 4);
            param[4].Value = SectionID;
            param[5] = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param[5].Value = StudID;
            param[6] = new SqlParameter("@ItemRate", SqlDbType.Decimal, 8);
            param[6].Value = ItemRate;
            param[7] = new SqlParameter("@Quantity", SqlDbType.Decimal, 8);
            param[7].Value = Quantity;
            param[8] = new SqlParameter("@amount", SqlDbType.Decimal, 8);
            param[8].Value = Amount;
            param[9] = new SqlParameter("@DateOfIssue", SqlDbType.DateTime, 8);
            param[9].Value = DateOFIssue;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudProduceIssue", param);
            return i;


        }
        public int AddStaffProductIssue(int Product, int Purpose, int StaffID, decimal ItemRate, decimal Quantity, decimal Amount, DateTime DateOFIssue)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@Product", SqlDbType.Int, 4);
            param[0].Value = Product;
            param[1] = new SqlParameter("@Purpose", SqlDbType.Int, 4);
            param[1].Value = Purpose;
            param[2] = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param[2].Value = StaffID;
            param[3] = new SqlParameter("@ItemRate", SqlDbType.Decimal, 8);
            param[3].Value = ItemRate;
            param[4] = new SqlParameter("@Quantity", SqlDbType.Decimal, 8);
            param[4].Value = Quantity;
            param[5] = new SqlParameter("@amount", SqlDbType.Decimal, 8);
            param[5].Value = Amount;
            param[6] = new SqlParameter("@DateOfIssue", SqlDbType.DateTime, 8);
            param[6].Value = DateOFIssue;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spStaffProductIssue", param);
            return i;


        }

        public DataSet GetStudentProductIssue(int StudID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentProductIssue", param);
            return ds;
        }
        public DataSet GetStaffProductIssue()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffProductIssue");
            return ds;
        }
        public int DeleteStudentProductIssue(int Product, int StudID, DateTime DateOfIssue)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Product", SqlDbType.Int, 4);
            param[0].Value = Product;
            param[1] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[1].Value = StudID;
            param[2] = new SqlParameter("@DateOfIssue", SqlDbType.DateTime, 8);
            param[2].Value = DateOfIssue;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteStudentProductIssue", param);
            return i;
        }
        public int DeleteStaffProductIssue(int Product, int StaffID, DateTime DateOfIssue)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Product", SqlDbType.Int, 4);
            param[0].Value = Product;
            param[1] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[1].Value = StaffID;
            param[2] = new SqlParameter("@DateOfIssue", SqlDbType.DateTime, 8);
            param[2].Value = DateOfIssue;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteStaffProduceIssue", param);
            return i;
        }
        public int AddStorePurchases(int MonthofPurchase, int YearofPurchase, int ItemID, decimal OpeningQuantity, decimal OpeningRate, decimal OpeningAmt, decimal purchaseQuantity, decimal purchaseRate, decimal purchaseAmt, decimal ConsumptionQuantity, decimal ConsumptionRate, decimal ConsumptionAmt, decimal ClosingQuantity, decimal ClosingRate, decimal ClosingAmt)
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
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStorePurchases", param);
            return i;
        }
        public DataSet GetStoreClosingBalance(int Month, int Year, int ItemId)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[0].Value = Month;
            param[1] = new SqlParameter("@Year", SqlDbType.Int, 8);
            param[1].Value = Year;
            param[2] = new SqlParameter("@ItemId", SqlDbType.Int, 4);
            param[2].Value = ItemId;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetClosingStoreBalance", param);
            return ds;


        }

    }
}
