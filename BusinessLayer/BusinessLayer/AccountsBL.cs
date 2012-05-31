using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;

namespace BusinessLayer
{
    public class AccountsBL
    {
        DataSet ds;
        DAC.AccountsDAC objAcc = new AccountsDAC();
        public int AddCashBookEntry(DateTime Entrydate, string VoucherNo, int FundType, int Head, int SubHead, int TransactionType, int PlanNonPlan, string Particulars, string LedgerFolio, int CashType, decimal Cash, string Remarks)
        {
            int i = 0;
            try
            {
                i = objAcc.AddCashBookEntry(Entrydate,VoucherNo,FundType,Head,SubHead,TransactionType,PlanNonPlan,Particulars,LedgerFolio,CashType,Cash,Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetOpeningBalance(string FinancialYear)
        {
            ds = new DataSet();
            try
            {
                ds = objAcc.GetOpeningBalance(FinancialYear);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetCMS(int HeadID, int SubHeadID, int Plan, string FinancialYear, int Month)
        {
            ds = new DataSet();
            try
            {
                ds = objAcc.GetCMS(HeadID, SubHeadID, Plan, FinancialYear, Month);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int EditCashBookEntry(int TransactionID, DateTime Entrydate, string VoucherNo, int FundType, int Head, int SubHead, int TransactionType, int PlanNonPlan, string Particulars, string LedgerFolio, int CashType, decimal Cash, string Remarks)
        {
            int i = 0;
            try
            {
                i = objAcc.EditCashBookEntry(TransactionID, Entrydate, VoucherNo, FundType, Head, SubHead, TransactionType, PlanNonPlan, Particulars, LedgerFolio, CashType, Cash, Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetAccountCashBook(DateTime EntryDate)
        {
            ds = new DataSet();
            try
            {
                ds = objAcc.GetAccountCashBook(EntryDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

    }
}
