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
    public class CommonDataDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public DataSet getbatch()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "GetBatch");
            return ds;
        }
        public DataSet GetSection(int SectionID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SectionID", SqlDbType.Int, 4);
            param[0].Value = SectionID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSection1", param);
            return ds;
        }
        public DataSet GetBatch(int BatchID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            param[0].Value = BatchID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetBatch1", param);
            return ds;
        }
        public DataSet GetReasion()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetReasion");
            return ds;
        }


        public int AddReasion(string Reason)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Reason", SqlDbType.VarChar, 150);
            param[0].Value = Reason;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddReasion", param);
            return i;


        }

        public int EditReasion(int ReasonID, string Reason)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ReasonID", SqlDbType.Int, 4);
            param[0].Value = ReasonID;
            param[1] = new SqlParameter("@Reason", SqlDbType.VarChar, 150);
            param[1].Value = Reason;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditReasion", param);
            return i;


        }
        public int DeleteReasion(int ReasonID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ReasonID", SqlDbType.Int, 4);
            param[0].Value = ReasonID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteReasion", param);
            return i;
        }

        public DataSet GetEligibleCriteria(int Year)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[0].Value = Year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetEligibleCriteria", param);
            return ds;
        }

        public DataSet GetSelectionApplication(string RollNo, int Year)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@RollNo", SqlDbType.VarChar, 50);
            param[0].Value = RollNo;
            param[1] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[1].Value = Year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSelectionApplication", param);
            return ds;
        }

        public int EditSelectionApplication1(string RollNo, string FirstName, string MiddleName, string LastName, int Category, string DOB, int Nationality, string Religion, string Mole1,
             string Mole2, int Gender, int UrbnRural, int DisabledPH, int DisabledVI, int DisabledHI, string FatherName, string MotherName, string GuardianName, string RelationshipWithCandidate, string PersentPostalAddress,
             string PinCode1, string PermanentAddress, string Pincode2, string TelephoneNo, string EmailId)
        {

            SqlParameter[] param = new SqlParameter[25];
            param[0] = new SqlParameter("@RollNo", SqlDbType.VarChar, 20);
            param[0].Value = RollNo;
            param[1] = new SqlParameter("@FirstName", SqlDbType.VarChar, 50);
            param[1].Value = FirstName;
            param[2] = new SqlParameter("@MiddleName", SqlDbType.VarChar, 50);
            param[2].Value = MiddleName;
            param[3] = new SqlParameter("@LastName", SqlDbType.VarChar, 50);
            param[3].Value = LastName;
            param[4] = new SqlParameter("@Category", SqlDbType.Int, 4);
            param[4].Value = Category;
            param[5] = new SqlParameter("@DOB", SqlDbType.VarChar, 20);
            param[5].Value = DOB;
            param[6] = new SqlParameter("@Nationality", SqlDbType.Int, 4);
            param[6].Value = Nationality;
            param[7] = new SqlParameter("@Religion", SqlDbType.VarChar, 20);
            param[7].Value = Religion;
            param[8] = new SqlParameter("@Mole1", SqlDbType.VarChar, 100);
            param[8].Value = Mole1;
            param[9] = new SqlParameter("@Mole2", SqlDbType.VarChar, 100);
            param[9].Value = Mole2;
            param[10] = new SqlParameter("@Gender", SqlDbType.Int, 4);
            param[10].Value = Gender;
            param[11] = new SqlParameter("@UrbnRural", SqlDbType.Int, 4);
            param[11].Value = UrbnRural;
            param[12] = new SqlParameter("@DisabledPH ", SqlDbType.Int, 4);
            param[12].Value = DisabledPH;
            param[13] = new SqlParameter("@DisabledVI", SqlDbType.Int, 4);
            param[13].Value = DisabledVI;
            param[14] = new SqlParameter("@DisabledHI ", SqlDbType.Int, 4);
            param[14].Value = DisabledHI;
            param[15] = new SqlParameter("@FatherName", SqlDbType.VarChar, 50);
            param[15].Value = FatherName;
            param[16] = new SqlParameter("@MotherName", SqlDbType.VarChar, 50);
            param[16].Value = MotherName;
            param[17] = new SqlParameter("@GuardianName", SqlDbType.VarChar, 50);
            param[17].Value = GuardianName;
            param[18] = new SqlParameter("@RelationshipWithCandidate", SqlDbType.VarChar, 50);
            param[18].Value = RelationshipWithCandidate;
            param[19] = new SqlParameter("@PersentPostalAddress", SqlDbType.VarChar, 250);
            param[19].Value = PersentPostalAddress;
            param[20] = new SqlParameter("@PinCode1", SqlDbType.VarChar, 20);
            param[20].Value = PinCode1;
            param[21] = new SqlParameter("@PermanentAddress", SqlDbType.VarChar, 250);
            param[21].Value = PermanentAddress;
            param[22] = new SqlParameter("@Pincode2", SqlDbType.VarChar, 20);
            param[22].Value = Pincode2;
            param[23] = new SqlParameter("@TelephoneNo", SqlDbType.VarChar, 20);
            param[23].Value = TelephoneNo;
            param[24] = new SqlParameter("@EmailId", SqlDbType.VarChar, 20);
            param[24].Value = EmailId;


            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditSelectionApplication1", param);
            return i;


        }





        public int EditSelectionApplication2(string RollNo, string NameoftheSchoolIII, int CategoryofSchoolIII, int MonthofjoiningIII, int YearofjoingIII, int MonthofpassingIII, int YearofpassingIII, string NameofthevillageorTownIII, string NameoftheBlockIII, int NameoftheDistrictIII, int SchoollLocUrbanOrRuralIII, string NameoftheSchoolIV, int CategoryofSchoolIV, int MonthofjoiningIV, int YearofjoiningIV, int MonthofpassingIV, int YearofpassingIV, string NameofthevillageorTownIV, string NameoftheBlockIV, int NameoftheDistrictIV, int SchoollLocUrbanOrRuralIV, string NameoftheSchoolV, int CategoryofSchoolV, int MonthofjoiningV, int YearofjoiningV, int MonthofpassingV, int YearofpassingV, string NameofthevillageorTownV, string NameoftheBlockV, int NameoftheDistrictV, int SchoollLocUrbanOrRuralV)
        {

            SqlParameter[] param = new SqlParameter[31];
            param[0] = new SqlParameter("@RollNo", SqlDbType.VarChar, 20);
            param[0].Value = RollNo;
            param[1] = new SqlParameter("@NameoftheSchoolIII", SqlDbType.VarChar, 50);
            param[1].Value = NameoftheSchoolIII;
            param[2] = new SqlParameter("@CategoryofSchoolIII", SqlDbType.Int, 4);
            param[2].Value = CategoryofSchoolIII;
            param[3] = new SqlParameter("@MonthofjoiningIII", SqlDbType.Int, 4);
            param[3].Value = MonthofjoiningIII;
            param[4] = new SqlParameter("@YearofjoingIII", SqlDbType.Int, 4);
            param[4].Value = YearofjoingIII;
            param[5] = new SqlParameter("@MonthofpassingIII", SqlDbType.Int, 4);
            param[5].Value = MonthofpassingIII;
            param[6] = new SqlParameter("@YearofpassingIII", SqlDbType.Int, 4);
            param[6].Value = YearofpassingIII;
            param[7] = new SqlParameter("@NameofthevillageorTownIII", SqlDbType.VarChar, 50);
            param[7].Value = NameofthevillageorTownIII;
            param[8] = new SqlParameter("@NameoftheBlockIII", SqlDbType.VarChar, 50);
            param[8].Value = NameoftheBlockIII;
            param[9] = new SqlParameter("@NameoftheDistrictIII", SqlDbType.Int, 4);
            param[9].Value = NameoftheDistrictIII;
            param[10] = new SqlParameter("@SchoollLocUrbanOrRuralIII", SqlDbType.Int, 4);
            param[10].Value = SchoollLocUrbanOrRuralIII;
            param[11] = new SqlParameter("@NameoftheSchoolIV", SqlDbType.VarChar, 50);
            param[11].Value = NameoftheSchoolIV;
            param[12] = new SqlParameter("@CategoryofSchoolIV", SqlDbType.Int, 4);
            param[12].Value = CategoryofSchoolIV;
            param[13] = new SqlParameter("@MonthofjoiningIV", SqlDbType.Int, 4);
            param[13].Value = MonthofjoiningIV;
            param[14] = new SqlParameter("@YearofjoiningIV", SqlDbType.Int, 4);
            param[14].Value = YearofjoiningIV;
            param[15] = new SqlParameter("@MonthofpassingIV", SqlDbType.Int, 4);
            param[15].Value = MonthofpassingIV;
            param[16] = new SqlParameter("@YearofpassingIV", SqlDbType.Int, 4);
            param[16].Value = YearofpassingIV;
            param[17] = new SqlParameter("@NameofthevillageorTownIV", SqlDbType.VarChar, 50);
            param[17].Value = NameofthevillageorTownIV;
            param[18] = new SqlParameter("@NameoftheBlockIV", SqlDbType.VarChar, 50);
            param[18].Value = NameoftheBlockIV;
            param[19] = new SqlParameter("@NameoftheDistrictIV", SqlDbType.Int, 4);
            param[19].Value = NameoftheDistrictIV;
            param[20] = new SqlParameter("@SchoollLocUrbanOrRuralIV", SqlDbType.Int, 4);
            param[20].Value = SchoollLocUrbanOrRuralIV;
            param[21] = new SqlParameter("@NameoftheSchoolV", SqlDbType.VarChar, 50);
            param[21].Value = NameoftheSchoolV;
            param[22] = new SqlParameter("@CategoryofSchoolV", SqlDbType.Int, 4);
            param[22].Value = CategoryofSchoolV;
            param[23] = new SqlParameter("@MonthofjoiningV", SqlDbType.Int, 4);
            param[23].Value = MonthofjoiningV;
            param[24] = new SqlParameter("@YearofjoiningV", SqlDbType.Int, 4);
            param[24].Value = YearofjoiningV;
            param[25] = new SqlParameter("@MonthofpassingV", SqlDbType.Int, 4);
            param[25].Value = MonthofpassingV;
            param[26] = new SqlParameter("@YearofpassingV", SqlDbType.Int, 4);
            param[26].Value = YearofpassingV;
            param[27] = new SqlParameter("@NameofthevillageorTownV", SqlDbType.VarChar, 50);
            param[27].Value = NameofthevillageorTownV;
            param[28] = new SqlParameter("@NameoftheBlockV", SqlDbType.VarChar, 50);
            param[28].Value = NameoftheBlockV;
            param[29] = new SqlParameter("@NameoftheDistrictV", SqlDbType.Int, 4);
            param[29].Value = NameoftheDistrictV;
            param[30] = new SqlParameter("@SchoollLocUrbanOrRuralV", SqlDbType.Int, 4);
            param[30].Value = SchoollLocUrbanOrRuralV;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditSelectionApplication2", param);
            return i;


        }


        public int AddEligible(string RollNo, int Year, int Eligible, string Reason)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@RollNo", SqlDbType.VarChar, 20);
            param[0].Value = RollNo;
            param[1] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[1].Value = Year;
            param[2] = new SqlParameter("@Eligible", SqlDbType.Int, 4);
            param[2].Value = Eligible;
            param[3] = new SqlParameter("@Reason", SqlDbType.VarChar, 250);
            param[3].Value = Reason;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddEligible", param);
            return i;

        }



        public int EditEligible(string RollNo, int Year, int Eligible, string Reason)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@RollNo", SqlDbType.VarChar, 20);
            param[0].Value = RollNo;
            param[1] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[1].Value = Year;
            param[2] = new SqlParameter("@Eligible", SqlDbType.Int, 4);
            param[2].Value = Eligible;
            param[3] = new SqlParameter("@Reason", SqlDbType.VarChar, 250);
            param[3].Value = Reason;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditEligible", param);
            return i;

        }







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

        public DataSet GetunitOfMeasurement()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetUnitMeasurement");
            return ds;
        }



        public int AddUnitOfMeasurement(string UOMName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UOM", SqlDbType.VarChar, 20);
            param[0].Value = UOMName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddUnitOfMeasurement", param);
            return i;
        }

        public int EditUnitOfMeasurement(int UOMID, string UOMName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UOMID", SqlDbType.Int, 4);
            param[0].Value = UOMID;
            param[1] = new SqlParameter("@UOM", SqlDbType.VarChar, 20);
            param[1].Value = UOMName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditUnitOfMeasurement", param);
            return i;
        }

        public int DeleteUnitMeasurement(int UOMID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UOMID", SqlDbType.Int, 4);
            param[0].Value = UOMID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteunitOfMeasurement", param);
            return i;


        }

        public DataSet GetItem()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetItem");
            return ds;
        }






        public DataSet GetUOM()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetUOM");
            return ds;
        }
        public int AddUOM(string UOM)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UOM", SqlDbType.VarChar, 20);
            param[0].Value = UOM;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddUOM", param);
            return i;


        }
        public int EditUOM(int UOMID, string UOM)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UOMID", SqlDbType.Int, 4);
            param[0].Value = UOMID;
            param[1] = new SqlParameter("@UOM", SqlDbType.VarChar, 20);
            param[1].Value = UOM;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditUOM", param);
            return i;


        }
        public int DeleteUOM(int UOMID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@UOMID", SqlDbType.Int, 4);
            param[0].Value = UOMID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteUOM", param);
            return i;


        }

        public int EditBudgetAllocation(int YearID, int FinancialYear, decimal BudgetAmount, decimal Imprest)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@YearID", SqlDbType.Int, 4);
            param[0].Value = YearID;
            param[1] = new SqlParameter("@FinancialYear", SqlDbType.Int, 4);
            param[1].Value = FinancialYear;
            param[2] = new SqlParameter("@BudgetAmount", SqlDbType.Decimal, 4);
            param[2].Value = BudgetAmount;
            param[3] = new SqlParameter("@Imprest", SqlDbType.Decimal, 4);
            param[3].Value = Imprest;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditBudgetAllocation", param);
            return i;


        }

        public int AddBudgetAllocation(int FinancialYear, int Budget, int Imprest)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FinancialYear", SqlDbType.Int, 4);
            param[0].Value = FinancialYear;
            param[1] = new SqlParameter("@Budget", SqlDbType.Int, 4);
            param[1].Value = Budget;
            param[2] = new SqlParameter("@Imprest", SqlDbType.Int, 50);
            param[2].Value = Imprest;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddBudgetAllocation", param);
            return i;
        }
        public int EditBudgetAllocation(int YearID, int FinancialYear, decimal BudgetAmount)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@YearID", SqlDbType.Int, 4);
            param[0].Value = YearID;
            param[1] = new SqlParameter("@FinancialYear", SqlDbType.Int, 4);
            param[1].Value = FinancialYear;
            param[2] = new SqlParameter("@BudgetAmount", SqlDbType.Decimal, 4);
            param[2].Value = BudgetAmount;
            //param[3] = new SqlParameter("@Imprest", SqlDbType.Decimal, 4);
            //param[3].Value = Imprest;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditBudgetAllocation", param);
            return i;


        }
        public DataSet GetBudgetAllocation()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetBudgetAllocate");
            return ds;
        }
        public int DeleteBudgetAllocation(int YearID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@YearID", SqlDbType.Int, 4);
            param[0].Value = YearID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteBudgetAllocation", param);
            return i;
        }

        public DataSet GetAccountFund()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccFundsI");
            return ds;
        }
        public DataSet GetAccountHead(int FundId)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FundID", SqlDbType.Int, 4);
            param[0].Value = FundId;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccountHead", param);
            return ds;
        }
        public int AddAccountHead(int FundId, string HeadName, decimal FundAmount)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FundId", SqlDbType.Int, 4);
            param[0].Value = FundId;
            param[1] = new SqlParameter("@HeadName", SqlDbType.VarChar, 50);
            param[1].Value = HeadName;
            param[2] = new SqlParameter("@FundAmount", SqlDbType.Decimal, 18);
            param[2].Value = FundAmount;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAccountHead", param);
            return i;
        }

        public int EditAccountHeads(int HeadID, int FundID, string HeadName, decimal FundAmount)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            param[1] = new SqlParameter("@FundID", SqlDbType.Int, 4);
            param[1].Value = FundID;
            param[2] = new SqlParameter("@HeadName", SqlDbType.VarChar, 20);
            param[2].Value = HeadName;
            param[3] = new SqlParameter("@FundAmount", SqlDbType.Decimal, 18);
            param[3].Value = FundAmount;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditAccountHead", param);
            return i;
        }


        public int DeleteAccountHead(int HeadID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteAccountHead", param);
            return i;
        }
        public DataSet GetAccountSubHead(int HeadID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@HeadID", SqlDbType.Int, 8);
            param.Value = HeadID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccountSubHead", param);
            return ds;
        }

        public int AddAccountSubHead(int HeadID, string SubHeadName, decimal FundAmount)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            param[1] = new SqlParameter("@SubHeadName", SqlDbType.VarChar, 50);
            param[1].Value = SubHeadName;
            param[2] = new SqlParameter("@FundAmount", SqlDbType.Decimal, 18);
            param[2].Value = FundAmount;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAccountSubHead", param);
            return i;


        }

        public int EditAccountSubHead(int SubHeadID, string SubHeadName, int HeadID, decimal FundAmount)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@SubHeadID", SqlDbType.Int, 4);
            param[0].Value = SubHeadID;
            param[1] = new SqlParameter("@SubHeadName", SqlDbType.VarChar, 50);
            param[1].Value = SubHeadName;
            param[2] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[2].Value = HeadID;
            param[3] = new SqlParameter("@FundAmount", SqlDbType.Decimal, 18);
            param[3].Value = FundAmount;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditAcountSubHead", param);
            return i;
        }
        public int DeleteAccountSubHead(int SubHeadID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SubHeadID", SqlDbType.Int, 4);
            param[0].Value = SubHeadID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteAcountSubHead", param);
            return i;
        }
        //public DataSet GetAccountHead(int FundId)
        //{
        //    ds = new DataSet();
        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@FundID", SqlDbType.Int, 4);
        //    param[0].Value = FundId;
        //    ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccountHead",param);
        //    return ds;
        //}

        //public int AddAccountHead(int FundId, string HeadName)
        //{

        //    SqlParameter[] param = new SqlParameter[2];
        //    param[0] = new SqlParameter("@FundId", SqlDbType.Int, 4);
        //    param[0].Value = FundId;
        //    param[1] = new SqlParameter("@HeadName", SqlDbType.VarChar, 50);
        //    param[1].Value = HeadName;

        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAccountHead", param);
        //    return i;
        //}
        //public int EditAccountHead(int HeadID, int FundId, string HeadName)
        //{

        //    SqlParameter[] param = new SqlParameter[3];
        //    param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
        //    param[0].Value = HeadID;
        //    param[1] = new SqlParameter("@FundId", SqlDbType.Int, 4);
        //    param[1].Value = FundId;
        //    param[2] = new SqlParameter("@Headname", SqlDbType.VarChar, 50);
        //    param[2].Value = HeadName;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditAccountHead", param);
        //    return i;
        //}

        //public int DeleteAccountHead(int HeadID)
        //{

        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
        //    param[0].Value = HeadID;

        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteAccountHead", param);
        //    return i;
        //}

        public DataSet GetAccFundsI()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccFundsI");
            return ds;
        }

        public int AddAccFundsI(string FundName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FundName", SqlDbType.VarChar, 100);
            param[0].Value = FundName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAccFundsI", param);
            return i;


        }


        public int EditAccFundsI(int FundID, string FundName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FundID", SqlDbType.Int, 4);
            param[0].Value = FundID;
            param[1] = new SqlParameter("@FundName", SqlDbType.VarChar, 20);
            param[1].Value = FundName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditAccFundsI", param);
            return i;
        }


        public int DeleteAccFundsI(int FundID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FundID", SqlDbType.Int, 4);
            param[0].Value = FundID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteAccFundsI", param);
            return i;


        }

        //public int EditAccountSubHead(int SubHeadID, string SubHeadName, int HeadID)
        //{

        //    SqlParameter[] param = new SqlParameter[3];
        //    param[0] = new SqlParameter("@SubHeadID", SqlDbType.Int, 4);
        //    param[0].Value = SubHeadID;
        //    param[1] = new SqlParameter("@SubHeadName", SqlDbType.VarChar, 50);
        //    param[1].Value = SubHeadName;
        //    param[2] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
        //    param[2].Value = HeadID;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditAcountSubHead", param);
        //    return i;


        //}
        //public int DeleteAccountSubHead(int SubHeadID)
        //{

        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@SubHeadID", SqlDbType.Int, 4);
        //    param[0].Value = SubHeadID;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteAcountSubHead", param);
        //    return i;
        //}



        //public DataSet GetAccountSubHead(int HeadID)
        //{
        //    ds = new DataSet();
        //    SqlParameter param = new SqlParameter("@HeadID", SqlDbType.Int, 8);
        //    param.Value = HeadID;
        //    ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccountSubHead", param);
        //    return ds;
        //}
        public DataSet GetAccountSubHead()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAccount_SubHead");
            return ds;
        }
        public DataSet GetAppointmentMode()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetAppointMentMode");
            return ds;
        }
        public DataSet GetBatch()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetBatch");
            return ds;
        }
        public DataSet GetCader()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetCader");
            return ds;
        }
        public DataSet GetCaste()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetCaste");
            return ds;
        }
        public DataSet GetClasses()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetClasses");
            return ds;
        }
        public DataSet GetClasses(int ClassID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 4);
            param[0].Value = ClassID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetClasses1", param);
            return ds;
        }
        public DataSet GetExtraCurricular()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetExtraCurricular");
            return ds;
        }
        public DataSet GetGroups()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetGroups");
            return ds;
        }
        public DataSet GetJoiningType()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetJoiningType");
            return ds;
        }
        public DataSet GetLocality()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLocality");
            return ds;
        }
        public DataSet GetMartialStatus()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMartialStatus");
            return ds;
        }
        public DataSet GetMedium()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMedium");
            return ds;
        }
        public DataSet GetModeofPayment()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetModeofPayment");
            return ds;
        }
        public DataSet GetMotherTounge()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetMotherTounge");
            return ds;
        }
        public DataSet GetNationality()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetNationality");
            return ds;
        }
        public int EditAccountHead(int HeadID, string HeadName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            param[1] = new SqlParameter("@Headname", SqlDbType.VarChar, 20);
            param[1].Value = HeadName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditAccountHead", param);
            return i;
        }

        public int EditNationality(int NationalityID, string Nation)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@NationalityID", SqlDbType.Int, 4);
            param[0].Value = NationalityID;
            param[1] = new SqlParameter("@Nation", SqlDbType.VarChar, 20);
            param[1].Value = Nation;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditNationality", param);
            return i;


        }
        public int DeleteNationality(int NationalityID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@NationalityID", SqlDbType.Int, 4);
            param[0].Value = NationalityID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteNationality", param);
            return i;


        }
        public DataSet GetPhysicallyChallenged()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPhysicallyChallenged");
            return ds;
        }
        public int EditPhysicallychallenged(int PHId, string PHType)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@PHId", SqlDbType.Int, 4);
            param[0].Value = PHId;
            param[1] = new SqlParameter("@PHType", SqlDbType.VarChar, 20);
            param[1].Value = PHType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditPhysicallychallenged", param);
            return i;


        }
        public int Deletephysicallychallenged(int PHID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PHID", SqlDbType.Int, 4);
            param[0].Value = PHID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeletephysicallychallenged", param);
            return i;


        }
        public DataSet spGetPostType()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPostType");
            return ds;
        }
        public DataSet GetQualification()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetQualification");
            return ds;
        }
        public DataSet GetSanctionOfPost()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSanctionOfPost");
            return ds;
        }
        public DataSet GetSection()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSection");
            return ds;
        }
        public int EditSection(int SectionID, string SectionName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@SectionID", SqlDbType.Int, 4);
            param[0].Value = SectionID;
            param[1] = new SqlParameter("@SectionName", SqlDbType.VarChar, 20);
            param[1].Value = SectionName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditSection", param);
            return i;


        }
        public int DeleteSection(int SectionID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SectionID", SqlDbType.Int, 4);
            param[0].Value = SectionID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteSection", param);
            return i;


        }
        public DataSet GetState()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetState");
            return ds;
        }

        public int AddAccountHead(string HeadName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HeadName", SqlDbType.VarChar, 20);
            param[0].Value = HeadName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAccountHead", param);
            return i;


        }
        //public int AddAccountSubHead(int HeadID, string SubHeadName)
        //{

        //    SqlParameter[] param = new SqlParameter[2];
        //    param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
        //    param[0].Value = HeadID;
        //    param[1] = new SqlParameter("@SubHeadName", SqlDbType.VarChar, 50);
        //    param[1].Value = SubHeadName;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAccountSubHead", param);
        //    return i;


        //}
        public int AddAppointmentMode(string Mode)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Mode", SqlDbType.VarChar, 20);
            param[0].Value = Mode;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddAppointmentMode", param);
            return i;


        }


        public int AddBatch(string Batchno)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Batchno", SqlDbType.VarChar, 20);
            param[0].Value = Batchno;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddBatch", param);
            return i;


        }
        public int AddCader(string CaderType)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CaderType", SqlDbType.VarChar, 20);
            param[0].Value = CaderType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddCader", param);
            return i;


        }
        public int AddCaste(string Caste)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Caste", SqlDbType.VarChar, 20);
            param[0].Value = Caste;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddCaste", param);
            return i;


        }
        public int AddClasses(string Classname)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Classname", SqlDbType.VarChar, 20);
            param[0].Value = Classname;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddClasses", param);
            return i;


        }
        public int AddExtraCircular(string Activity)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Activity", SqlDbType.VarChar, 30);
            param[0].Value = Activity;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddExtraCircular", param);
            return i;


        }
        public int AddGroups(string GroupName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@GroupName", SqlDbType.VarChar, 20);
            param[0].Value = GroupName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddGroups", param);
            return i;


        }
        public int AddJoiningType(string JTName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@JTName", SqlDbType.VarChar, 20);
            param[0].Value = JTName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddJoiningType", param);
            return i;


        }
        public int AddLocality(string LocalityName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LocalityName", SqlDbType.VarChar, 20);
            param[0].Value = LocalityName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLocality", param);
            return i;


        }
        public int AddMartialStatus(string Status)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Status", SqlDbType.VarChar, 20);
            param[0].Value = Status;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddMartialStatus", param);
            return i;


        }
        public int AddMedium(string Medium)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Language", SqlDbType.VarChar, 20);
            param[0].Value = Medium;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddMedium", param);
            return i;


        }
        public int AddModeofPayment(string ModeofPay)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MOP", SqlDbType.VarChar, 20);
            param[0].Value = ModeofPay;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddModeofPayment", param);
            return i;


        }

        public int AddMotherTounge(string Language)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Language", SqlDbType.VarChar, 20);
            param[0].Value = Language;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddMotherTounge", param);
            return i;


        }
        public int AddNationality(string Nation)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Nation", SqlDbType.VarChar, 20);
            param[0].Value = Nation;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddNationality", param);
            return i;


        }
        public int AddPhysicallyChallenged(string PHType)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PHType", SqlDbType.VarChar, 20);
            param[0].Value = PHType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddPhysicallyChallenged", param);
            return i;


        }
        public int AddPostType(string PostType)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@PostType", SqlDbType.VarChar, 20);
            param[0].Value = PostType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddPostType", param);
            return i;


        }
        public int AddQualification(string Qualification)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@QualificationDetails", SqlDbType.VarChar, 20);
            param[0].Value = Qualification;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddQualification", param);
            return i;


        }
        public int AddSanctionOfPost(string SanctionType)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SanctionType", SqlDbType.VarChar, 20);
            param[0].Value = SanctionType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddSanctionOfPost", param);
            return i;


        }
        public int AddSection(string Section)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SectionName", SqlDbType.VarChar, 20);
            param[0].Value = Section;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddSection", param);
            return i;


        }
        public int EditBatch(int BatchID, string BatchNo)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            param[0].Value = BatchID;
            param[1] = new SqlParameter("@BatchNo", SqlDbType.VarChar, 20);
            param[1].Value = BatchNo;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditBatch", param);
            return i;


        }


        public int DeleteBatch(int BatchID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@BatchID", SqlDbType.Int, 4);
            param[0].Value = BatchID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteBatch", param);
            return i;


        }
        public int EditClass(int ClassID, string ClassName)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 4);
            param[0].Value = ClassID;
            param[1] = new SqlParameter("@ClassName", SqlDbType.VarChar, 30);
            param[1].Value = ClassName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditClasses", param);
            return i;
        }
        public int DeleteClass(int ClassID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 5);
            param[0].Value = ClassID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteClasses", param);
            return i;
        }
        public int EditMedium(int MediumID, string Languages)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MediumID", SqlDbType.Int, 4);
            param[0].Value = MediumID;
            param[1] = new SqlParameter("@Language", SqlDbType.VarChar, 30);
            param[1].Value = Languages;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditMedium", param);
            return i;
        }

        public int DeleteMedium(int MediumID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MediumID", SqlDbType.Int, 5);
            param[0].Value = MediumID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteMedium", param);
            return i;
        }
        public int EditExtraCurricular(int ExtraCurricularID, string Activity)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ExtraCurricularID", SqlDbType.Int, 5);
            param[0].Value = ExtraCurricularID;
            param[1] = new SqlParameter("@Activity", SqlDbType.VarChar, 50);
            param[1].Value = Activity;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditExtraCurricular", param);
            return i;
        }
        public int DeleteExtraCurricular(int ExtraCurricularID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ExtraCurricularID", SqlDbType.Int, 5);
            param[0].Value = ExtraCurricularID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteExtraCurricular", param);
            return i;
        }
        public int EditQualification(int QualificationID, string QualificationDetails)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@QualificationID", SqlDbType.Int, 5);
            param[0].Value = QualificationID;
            param[1] = new SqlParameter("@QualificationDetails", SqlDbType.VarChar, 30);
            param[1].Value = QualificationDetails;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditQualification", param);
            return i;
        }
        public int DeleteQualification(int QualificationID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@QualificationID", SqlDbType.Int, 5);
            param[0].Value = QualificationID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteQualification", param);
            return i;
        }
        public int AddState(string StateName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StateName", SqlDbType.VarChar, 20);
            param[0].Value = StateName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddState", param);
            return i;


        }
        public int EditState(int StateID, string StateName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@StateID", SqlDbType.Int, 4);
            param[0].Value = StateID;
            param[1] = new SqlParameter("@StateName", SqlDbType.VarChar, 20);
            param[1].Value = StateName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditState", param);
            return i;


        }

        public int DeleteState(int StateID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StateID", SqlDbType.Int, 4);
            param[0].Value = StateID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteState", param);
            return i;


        }


        public int EditMotherTounge(int MTID, string Language)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@MTID", SqlDbType.Int, 4);
            param[0].Value = MTID;
            param[1] = new SqlParameter("@Language", SqlDbType.VarChar, 20);
            param[1].Value = Language;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditMotherTounge", param);
            return i;


        }

        public int DeleteMotherTounge(int MTID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@MTID", SqlDbType.Int, 4);
            param[0].Value = MTID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteMoterTounge", param);
            return i;


        }

        public int EditJoiningType(int JTID, string JTName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@JTID", SqlDbType.Int, 4);
            param[0].Value = JTID;
            param[1] = new SqlParameter("@JTName", SqlDbType.VarChar, 10);
            param[1].Value = JTName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditJoiningType", param);
            return i;
        }
        public int DeleteJoiningType(int JTID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@JTID", SqlDbType.Int, 4);
            param[0].Value = JTID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteJoiningType", param);
            return i;


        }


        public int EditCaste(int CasteID, string Caste)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CasteID", SqlDbType.Int, 4);
            param[0].Value = CasteID;
            param[1] = new SqlParameter("@Caste", SqlDbType.VarChar, 20);
            param[1].Value = Caste;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditCaste", param);
            return i;


        }
        public int DeleteCaste(int CasteID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CasteID", SqlDbType.Int, 4);
            param[0].Value = CasteID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteCaste", param);
            return i;


        }
        public DataSet GetSubject()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetsubjects");
            return ds;
        }



        public int AddSubject(string SubjectName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SubjectName", SqlDbType.VarChar, 20);
            param[0].Value = SubjectName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddSubjects", param);
            return i;


        }
        public int EditSubject(int SubjectId, string SubjectName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@SubjectId", SqlDbType.Int, 4);
            param[0].Value = SubjectId;
            param[1] = new SqlParameter("@SubjectName", SqlDbType.VarChar, 20);
            param[1].Value = SubjectName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditSubjects", param);
            return i;


        }

        public int DeleteSubject(int SubjectId)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@SubjectId", SqlDbType.Int, 4);
            param[0].Value = SubjectId;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteSubjects", param);
            return i;


        }




        public int AddItem(string ItemName, int Type, int Periodicity, int SubCategory, int UOM)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ItemName", SqlDbType.VarChar, 20);
            param[0].Value = ItemName;
            param[1] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[1].Value = Type;
            param[2] = new SqlParameter("@Periodicity", SqlDbType.Int, 4);
            param[2].Value = Periodicity;
            param[3] = new SqlParameter("@SubCategory", SqlDbType.Int, 4);
            param[3].Value = SubCategory;
            param[4] = new SqlParameter("@Uom", SqlDbType.Int, 4);
            param[4].Value = UOM;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddItem", param);
            return i;


        }

        public int EditItem(int itemID, string itemName, int Type, int Periodicity, int SubCategory, int UOM)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@itemID", SqlDbType.Int, 4);
            param[0].Value = itemID;
            param[1] = new SqlParameter("@itemName", SqlDbType.VarChar, 50);
            param[1].Value = itemName;
            param[2] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[2].Value = Type;
            param[3] = new SqlParameter("@Periodicity", SqlDbType.Int, 4);
            param[3].Value = Periodicity;
            param[4] = new SqlParameter("@SubCategory", SqlDbType.Int, 4);
            param[4].Value = SubCategory;
            param[5] = new SqlParameter("@Uom", SqlDbType.Int, 4);
            param[5].Value = UOM;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEdititem", param);
            return i;

        }



        public void AddError(string Page, string ErrorMessage, DateTime MsgDate)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Page", SqlDbType.VarChar, 50);
            param[0].Value = Page;
            param[1] = new SqlParameter("@ErrorMessage", SqlDbType.VarChar, 500);
            param[1].Value = ErrorMessage;
            param[2] = new SqlParameter("@MsgDate", SqlDbType.DateTime, 8);
            param[2].Value = MsgDate;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddError", param);
        }

        public void AddUser(string Username, string Password, int UserType)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Username", SqlDbType.VarChar, 50);
            param[0].Value = Username;
            param[1] = new SqlParameter("@Password", SqlDbType.VarChar, 500);
            param[1].Value = Password;
            param[2] = new SqlParameter("@UserType", SqlDbType.Int, 4);
            param[2].Value = UserType;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddUser", param);
        }
        public int DeleteItem(int itemID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@itemID", SqlDbType.Int, 4);
            param[0].Value = itemID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spdeleteitem", param);
            return i;


        }

        public DataSet GetSalary()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSalary");
            return ds;
        }
        public int AddSalary(string NameOfField, int Type)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@NameOfField", SqlDbType.VarChar, 20);
            param[0].Value = NameOfField;
            param[1] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[1].Value = Type;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddSalary", param);
            return i;


        }
        public int EditSalary(int FieldID, string FieldName, int Type)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FieldID", SqlDbType.Int, 4);
            param[0].Value = FieldID;
            param[1] = new SqlParameter("@FieldName", SqlDbType.VarChar, 50);
            param[1].Value = FieldName;
            param[2] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[2].Value = Type;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditSalary", param);
            return i;


        }
        public int DeleteSalary(int FieldID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FieldID", SqlDbType.Int, 4);
            param[0].Value = FieldID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteSalary", param);
            return i;


        }
        public DataSet GetLeaves(int LeaveID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LeaveId", SqlDbType.Int, 4);
            param[0].Value = LeaveID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLeaves",param);
            return ds;
        }
        public DataSet GetLeaves()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLeaves");
            return ds;
        }
        //public int AddLeaves(string LeaveName, int MaxLeaves)
        //{

        //    SqlParameter[] param = new SqlParameter[2];
        //    param[0] = new SqlParameter("@LeaveName", SqlDbType.VarChar, 20);
        //    param[0].Value = LeaveName;
        //    param[1] = new SqlParameter("@MaxLeaves", SqlDbType.Int, 4);
        //    param[1].Value = MaxLeaves;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLeaves", param);
        //    return i;


        //}
        //public int EditLeaves(int LeaveID, string LeaveName, int MaxLeaves)
        //{

        //    SqlParameter[] param = new SqlParameter[3];
        //    param[0] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
        //    param[0].Value = LeaveID;
        //    param[1] = new SqlParameter("@LeaveName", SqlDbType.VarChar, 20);
        //    param[1].Value = LeaveName;
        //    param[2] = new SqlParameter("@MaxLeaves", SqlDbType.Int, 4);
        //    param[2].Value = MaxLeaves;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditLeaves", param);
        //    return i;


        //}
        //public int DeleteLeave(int LeaveID)
        //{

        //    SqlParameter[] param = new SqlParameter[1];
        //    param[0] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
        //    param[0].Value = LeaveID;
        //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteLeave", param);
        //    return i;


        //}

        public int EditGroups(int GroupId, string GroupName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@GroupId", SqlDbType.Int, 4);
            param[0].Value = GroupId;
            param[1] = new SqlParameter("@GroupName", SqlDbType.VarChar, 20);
            param[1].Value = GroupName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditGroups", param);
            return i;


        }
        public int DeleteGroups(int GroupId)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@GroupId", SqlDbType.Int, 4);
            param[0].Value = GroupId;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteGroups", param);
            return i;


        }


        public int AddStaffLoansMaster(string LoanName, int MaxAmount, int MaxNoofinstallments, string Remarks)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@LoanName", SqlDbType.VarChar, 20);
            param[0].Value = LoanName;
            param[1] = new SqlParameter("@MaxAmount", SqlDbType.Int, 8);
            param[1].Value = MaxAmount;
            param[2] = new SqlParameter("@MaxNoofinstallments", SqlDbType.Int, 8);
            param[2].Value = MaxNoofinstallments;
            param[3] = new SqlParameter("@Remarks", SqlDbType.VarChar, 200);
            param[3].Value = Remarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffLoansMaster", param);
            return i;


        }


        public int EditStaffLoansMaster(int LoanId, string LoanName, int MaxAmount, int MaxNoofinstallments, string Remarks)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@LoanId", SqlDbType.Int, 4);
            param[0].Value = LoanId;
            param[1] = new SqlParameter("@LoanName", SqlDbType.VarChar, 30);
            param[1].Value = LoanName;
            param[2] = new SqlParameter("@MaxAmount", SqlDbType.Int, 8);
            param[2].Value = MaxAmount;
            param[3] = new SqlParameter("@MaxNoofinstallments", SqlDbType.Int, 8);
            param[3].Value = MaxNoofinstallments;
            param[4] = new SqlParameter("@Remarks", SqlDbType.VarChar, 200);
            param[4].Value = Remarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditStaffLoansMaster", param);
            return i;


        }

        public DataSet GetStaffLoansMaster()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffLoansMaster");
            return ds;
        }

        public DataSet GetLoginDetails(string Username, string Password)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Username", SqlDbType.VarChar, 50);
            param[0].Value = Username;
            param[1] = new SqlParameter("@Password", SqlDbType.VarChar, 50);
            param[1].Value = Password;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLoginDetails", param);
            return ds;
        }
        public DataSet GetClub()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetClub");
            return ds;
        }
        public int AddClub(string ClubName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Club", SqlDbType.VarChar, 20);
            param[0].Value = ClubName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddClub", param);
            return i;


        }
        public int EditClub(int ClubID, string ClubName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ClubID", SqlDbType.Int, 4);
            param[0].Value = ClubID;
            param[1] = new SqlParameter("@ClubName", SqlDbType.VarChar, 30);
            param[1].Value = ClubName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditClub", param);
            return i;
        }
        public int DeleteClub(int ClubID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ClubID", SqlDbType.Int, 4);
            param[0].Value = ClubID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteClub", param);
            return i;


        }
        public DataSet GetActivities(int Type, int Club)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[0].Value = Type;
            param[1] = new SqlParameter("@Club", SqlDbType.Int, 4);
            param[1].Value = Club;
            //SqlParameter param = new SqlParameter("@Type", SqlDbType.Int, 8);
            //param.Value = Type;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetActiviti", param);
            return ds;
        }
        public int AddActivities(string Activities, int Type, int Club)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Activities", SqlDbType.VarChar, 30);
            param[0].Value = Activities;
            param[1] = new SqlParameter("@Type", SqlDbType.Int, 8);
            param[1].Value = Type;
            param[2] = new SqlParameter("@Club", SqlDbType.Int, 4);
            param[2].Value = Club;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddActivities", param);
            return i;


        }
        public int EditActivities(int ActivitiID, string Activities, int Type)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Activitiesid", SqlDbType.Int, 4);
            param[0].Value = ActivitiID;
            param[1] = new SqlParameter("@Activities", SqlDbType.VarChar, 30);
            param[1].Value = Activities;
            param[2] = new SqlParameter("@Type", SqlDbType.Int, 8);
            param[2].Value = Type;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditActivities", param);
            return i;
        }
        public int DeleteActivities(int ActivitiID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ActivitiesID", SqlDbType.Int, 4);
            param[0].Value = ActivitiID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteActivities", param);
            return i;


        }
        public DataSet GetHouse()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetHouse");
            return ds;
        }
        public int AddHouse(string HouseName)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@House", SqlDbType.VarChar, 20);
            param[0].Value = HouseName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddHouse", param);
            return i;


        }
        public int EditHouse(int HouseID, string HouseName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@HouseID", SqlDbType.Int, 4);
            param[0].Value = HouseID;
            param[1] = new SqlParameter("@House", SqlDbType.VarChar, 30);
            param[1].Value = HouseName;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditHouse", param);
            return i;
        }
        public int DeleteHouse(int HouseID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HouseID", SqlDbType.Int, 4);
            param[0].Value = HouseID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteHouse", param);
            return i;
        }
        public DataSet GetStoreItem()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStoreItem");
            return ds;
        }
        public int AddFeeHeader(int FeeTypeId, string HeadName)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FeeTypeId", SqlDbType.Int, 4);
            param[0].Value = FeeTypeId;
            param[1] = new SqlParameter("@HeadName", SqlDbType.VarChar, 50);
            param[1].Value = HeadName;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddFeeHeader", param);
            return i;
        }
        public int EditFeeHeaders(int HeadID, int FeeTypeId, string Headername)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            param[1] = new SqlParameter("@FeeTypeId", SqlDbType.Int, 4);
            param[1].Value = FeeTypeId;
            param[2] = new SqlParameter("@Headername", SqlDbType.VarChar, 50);
            param[2].Value = Headername;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditFeeHeaders", param);
            return i;
        }
        public int DeleteFeeHeader(int HeadID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteFeeHeader", param);
            return i;
        }
        public DataSet GetFeeType(int FeeTypeID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FeeTypeID", SqlDbType.Int, 4);
            param[0].Value = FeeTypeID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetFeeType", param);
            return ds;
        }
        public DataSet GetFeeHeader(int FeeType)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FeeType", SqlDbType.Int, 4);
            param[0].Value = FeeType;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetFeeHeader", param);
            return ds;
        }
        public int AddFeeType(string FeeType, string Date)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FeeType", SqlDbType.VarChar, 50);
            param[0].Value = FeeType;
            param[1] = new SqlParameter("@Date", SqlDbType.VarChar, 30);
            param[1].Value = Date;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddFeeType", param);
            return i;


        }
        public int EditFeeType(int FeeTypeID, string FeeType, string Date)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@FeeTypeID", SqlDbType.Int, 4);
            param[0].Value = FeeTypeID;
            param[1] = new SqlParameter("@FeeType", SqlDbType.VarChar, 50);
            param[1].Value = FeeType;
            param[2] = new SqlParameter("@Date", SqlDbType.VarChar, 30);
            param[2].Value = Date;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditFeeType", param);
            return i;


        }
        public int DeleteFeeType(int FeeTypeID)
        {
            int i;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@FeeTypeID", SqlDbType.Int);
            param[0].Value = FeeTypeID;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteFeeType", param);
            return i;
        }
        public int AddFeeAllocation(int Year, int Class, int Group, int HeaderId, double Amount, int Category, int FeeType)
        {

            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[0].Value = Year;
            param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[1].Value = Class;
            param[2] = new SqlParameter("@Groups", SqlDbType.Int, 4);
            param[2].Value = Group;
            param[3] = new SqlParameter("@HeaderId", SqlDbType.Int, 4);
            param[3].Value = HeaderId;
            param[4] = new SqlParameter("@Amount", SqlDbType.Decimal, 20);
            param[4].Value = Amount;
            param[5] = new SqlParameter("@Category", SqlDbType.Int, 4);
            param[5].Value = Category;
            param[6] = new SqlParameter("@FeeType", SqlDbType.Int, 4);
            param[6].Value = FeeType;
            param[7] = new SqlParameter("@Status", SqlDbType.Int, 4);
            param[7].Direction = ParameterDirection.Output;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddFeeAllocation", param);
            i = Convert.ToInt16(param[7].Value.ToString());
            return i;
        }
        public DataSet GetFeeCategory()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetFeeCategory");
            return ds;
        }
    }
}
