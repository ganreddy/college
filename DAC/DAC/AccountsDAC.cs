using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
namespace DAC
{
    public class AccountsDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;

        public int AddLeaves(string LeaveName, int MaxLeaves)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@LeaveName", SqlDbType.VarChar, 20);
            param[0].Value = LeaveName;
            param[1] = new SqlParameter("@MaxLeaves", SqlDbType.Int, 4);
            param[1].Value = MaxLeaves;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLeaves", param);
            return i;


        }
        public int EditLeaves(int LeaveID, string LeaveName, int MaxLeaves)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
            param[0].Value = LeaveID;
            param[1] = new SqlParameter("@LeaveName", SqlDbType.VarChar, 20);
            param[1].Value = LeaveName;
            param[2] = new SqlParameter("@MaxLeaves", SqlDbType.Int, 4);
            param[2].Value = MaxLeaves;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditLeaves", param);
            return i;


        }
        public int DeleteLeave(int LeaveID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
            param[0].Value = LeaveID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteLeave", param);
            return i;


        }

        public int EditCashBookEntry(int TransactionID, DateTime Entrydate, string VoucherNo, int FundType, int Head, int SubHead, int TransactionType, int PlanNonPlan, string Particulars, string LedgerFolio, int CashType, decimal Cash, string Remarks)
        {

            SqlParameter[] param = new SqlParameter[13];

            param[0] = new SqlParameter("@Entrydate", SqlDbType.DateTime, 8);
            param[0].Value = Entrydate;
            param[1] = new SqlParameter("@VoucherNo", SqlDbType.VarChar, 20);
            param[1].Value = VoucherNo;
            param[2] = new SqlParameter("@FundType", SqlDbType.Int, 4);
            param[2].Value = @FundType;
            param[3] = new SqlParameter("@Head", SqlDbType.Int, 4);
            param[3].Value = Head;
            param[4] = new SqlParameter("@SubHead", SqlDbType.Int, 4);
            param[4].Value = SubHead;
            param[5] = new SqlParameter("@TransactionType", SqlDbType.Int, 4);
            param[5].Value = TransactionType;
            param[6] = new SqlParameter("@PlanNonPlan", SqlDbType.Int, 4);
            param[6].Value = PlanNonPlan;
            param[7] = new SqlParameter("@Particulars", SqlDbType.VarChar, 200);
            param[7].Value = Particulars;
            param[8] = new SqlParameter("@LedgerFolio", SqlDbType.VarChar, 20);
            param[8].Value = LedgerFolio;
            param[9] = new SqlParameter("@CashType", SqlDbType.Int, 4);
            param[9].Value = CashType;
            param[10] = new SqlParameter("@Cash", SqlDbType.Decimal, 8);
            param[10].Value = Cash;
            param[11] = new SqlParameter("@Remarks", SqlDbType.VarChar, 200);
            param[11].Value = Remarks;
            param[12] = new SqlParameter("@TransactionID", SqlDbType.Int, 4);
            param[12].Value = TransactionID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditCashBookEntry", param);
            return i;
        }
        public DataSet GetAccountCashBook(DateTime EntryDate)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@EntryDate", SqlDbType.DateTime, 8);
            param.Value = EntryDate;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccountCashBook", param);
            return ds;
        }

        public DataSet GetCMS(int HeadID, int SubHeadID, int Plan, string FinancialYear, int Month)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            param[1] = new SqlParameter("@SubHeadID", SqlDbType.Int, 4);
            param[1].Value = SubHeadID;
            param[2] = new SqlParameter("@Plan", SqlDbType.Int, 4);
            param[2].Value = Plan;
            param[3] = new SqlParameter("@FinancialYear", SqlDbType.VarChar, 7);
            param[3].Value = FinancialYear;
            param[4] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[4].Value = Month;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetCMS", param);
            return ds;
        }
        
        public int AddCashBookEntry(DateTime Entrydate, string VoucherNo, int FundType, int Head, int SubHead, int TransactionType, int PlanNonPlan, string Particulars, string LedgerFolio, int CashType, decimal Cash, string Remarks)
        {

            SqlParameter[] param = new SqlParameter[12];
            param[0] = new SqlParameter("@Entrydate", SqlDbType.DateTime,8);
            param[0].Value = Entrydate;
            param[1] = new SqlParameter("@VoucherNo", SqlDbType.VarChar, 20);
            param[1].Value = VoucherNo;
            param[2] = new SqlParameter("@FundType", SqlDbType.Int,4);
            param[2].Value = @FundType;
            param[3] = new SqlParameter("@Head", SqlDbType.Int,4);
            param[3].Value = Head;
            param[4] = new SqlParameter("@SubHead", SqlDbType.Int, 4);
            param[4].Value = SubHead;
            param[5] = new SqlParameter("@TransactionType", SqlDbType.Int,4);
            param[5].Value = TransactionType;
            param[6] = new SqlParameter("@PlanNonPlan", SqlDbType.Int, 4);
            param[6].Value = PlanNonPlan;
            param[7] = new SqlParameter("@Particulars", SqlDbType.VarChar, 200);
            param[7].Value = Particulars;
            param[8] = new SqlParameter("@LedgerFolio", SqlDbType.VarChar, 20);
            param[8].Value = LedgerFolio;
            param[9] = new SqlParameter("@CashType", SqlDbType.Int, 4);
            param[9].Value = CashType;
            param[10] = new SqlParameter("@Cash", SqlDbType.Decimal, 8);
            param[10].Value = Cash;
            param[11] = new SqlParameter("@Remarks", SqlDbType.VarChar,200);
            param[11].Value = Remarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddCashBookEntry", param);
            return i;
        }
         public DataSet GetOpeningBalance(string FinancialYear)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FinancialYear", SqlDbType.VarChar,7);
            param[0].Value = FinancialYear;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetOpeningBalance", param);
            return ds;
        }
    }
}
