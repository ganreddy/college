using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;


namespace BusinessLayer
{
    public class CommonDataBL
    {
        DataSet ds;
        DAC.CommonDataDAC objComm = new CommonDataDAC();
        public DataSet getbatch()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.getbatch();
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetSection(int SectionID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetSection(SectionID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetBatch(int BatchID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetBatch(BatchID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetClasses(int ClassID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetClasses(ClassID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetReasion()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetReasion();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddReasion(string Reason)
        {
            int i = 0;
            try
            {
                i = objComm.AddReasion(Reason);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int EditReasion(int ReasonID, string Reason)
        {
            int i = 0;
            try
            {
                i = objComm.EditReasion(ReasonID, Reason);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteReasion(int ReasonID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteReasion(ReasonID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetEligibleCriteria(int Year)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetEligibleCriteria(Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetSelectionApplication(string RollNo, int Year)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetSelectionApplication(RollNo, Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int EditSelectionApplication1(string RollNo, string FirstName, string MiddleName, string LastName, int Category, string DOB, int Nationality, string Religion, string Mole1, string Mole2, int Gender, int UrbnRural, int DisabledPH, int DisabledVI, int DisabledHI, string FatherName, string MotherName, string GuardianName, string RelationshipWithCandidate, string PersentPostalAddress, string PinCode1, string PermanentAddress, string PinCode2, string TelephoneNo, string EmailId)
        {
            int i = 0;
            try
            {
                i = objComm.EditSelectionApplication1(RollNo, FirstName, MiddleName, LastName, Category, DOB, Nationality, Religion, Mole1, Mole2, Gender, UrbnRural, DisabledPH, DisabledVI, DisabledHI, FatherName, MotherName, GuardianName, RelationshipWithCandidate, PersentPostalAddress, PinCode1, PermanentAddress, PinCode2, TelephoneNo, EmailId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int EditSelectionApplication2(string RollNo, string NameoftheSchoolIII, int CategoryofSchoolIII, int MonthofjoiningIII, int YearofjoingIII, int MonthofpassingIII, int YearofpassingIII, string NameofthevillageorTownIII, string NameoftheBlockIII, int NameoftheDistrictIII, int SchoollLocUrbanOrRuralIII, string NameoftheSchoolIV, int CategoryofSchoolIV, int MonthofjoiningIV, int YearofjoiningIV, int MonthofpassingIV, int YearofpassingIV, string NameofthevillageorTownIV, string NameoftheBlockIV, int NameoftheDistrictIV, int SchoollLocUrbanOrRuralIV, string NameoftheSchoolV, int CategoryofSchoolV, int MonthofjoiningV, int YearofjoiningV, int MonthofpassingV, int YearofpassingV, string NameofthevillageorTownV, string NameoftheBlockV, int NameoftheDistrictV, int SchoollLocUrbanOrRuralV)
        {
            int i = 0;
            try
            {
                i = objComm.EditSelectionApplication2(RollNo, NameoftheSchoolIII, CategoryofSchoolIII, MonthofjoiningIII, YearofjoingIII, MonthofpassingIII, YearofpassingIII, NameofthevillageorTownIII, NameoftheBlockIII, NameoftheDistrictIII, SchoollLocUrbanOrRuralIII, NameoftheSchoolIV, CategoryofSchoolIV, MonthofjoiningIV, YearofjoiningIV, MonthofpassingIV, YearofpassingIV, NameofthevillageorTownIV, NameoftheBlockIV, NameoftheDistrictIV, SchoollLocUrbanOrRuralIV, NameoftheSchoolV, CategoryofSchoolV, MonthofjoiningV, YearofjoiningV, MonthofpassingV, YearofpassingV, NameofthevillageorTownV, NameoftheBlockV, NameoftheDistrictV, SchoollLocUrbanOrRuralV);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }





        public int AddEligible(string RollNo, int Year, int Eligible, string Reason)
        {
            int i = 0;
            try
            {
                i = objComm.AddEligible(RollNo, Year, Eligible, Reason);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditEligible(string RollNo, int Year, int Eligible, string Reason)
        {

            int i = 0;
            try
            {
                i = objComm.EditEligible(RollNo, Year, Eligible, Reason);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddLeaves(string LeaveName, int MaxLeaves)
        {
            int i = 0;
            try
            {
                i = objComm.AddLeaves(LeaveName, MaxLeaves);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditLeaves(int LeaveID, string LeaveName, int MaxLeaves)
        {
            int i = 0;
            try
            {
                i = objComm.EditLeaves(LeaveID, LeaveName, MaxLeaves);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteLeave(int LeaveID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteLeave(LeaveID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetUnitOfMeasurement()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetunitOfMeasurement();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


        public int AddUnitOfMeasurement(string UOMName)
        {
            int i = 0;
            try
            {
                i = objComm.AddUnitOfMeasurement(UOMName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditUnitOfMeasurement(int UOMID, string UOMName)
        {
            int i = 0;
            try
            {
                i = objComm.EditUnitOfMeasurement(UOMID, UOMName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteUnitMeasurement(int UOMID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteUnitMeasurement(UOMID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetItem()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetItem();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }



        public DataSet GetUOM()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetUOM();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddUOM(string UOM)
        {
            int i = 0;
            try
            {
                i = objComm.AddUOM(UOM);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditUOM(int UOMID, string UOM)
        {
            int i = 0;
            try
            {
                i = objComm.EditUOM(UOMID, UOM);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteUOM(int UOMID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteUOM(UOMID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditBudgetAllocation(int YearID, int FinancialYear, decimal BudgetAmount, decimal Imprest)
        {
            int i = 0;
            try
            {
                i = objComm.EditBudgetAllocation(YearID, FinancialYear, BudgetAmount, Imprest);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddBudgetAllocation(int FinancialYear, int Budget, int Imprest)
        {
            int i = 0;
            try
            {
                i = objComm.AddBudgetAllocation(FinancialYear, Budget, Imprest);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditBudgetAllocation(int YearID, int FinancialYear, decimal BudgetAmount)
        {
            int i = 0;
            try
            {
                i = objComm.EditBudgetAllocation(YearID, FinancialYear, BudgetAmount);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetBudgetAllocation()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetBudgetAllocation();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int DeleteBudgetAllocation(int YearID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteBudgetAllocation(YearID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        //public int EditAccountSubHead(int SubHeadID, string SubHeadName, int HeadID)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.EditAccountSubHead(SubHeadID, SubHeadName, HeadID);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}

        //public int DeleteAccountSubHead(int SubHeadID)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.DeleteAccountSubHead(SubHeadID);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}

        public DataSet GetAccountFund()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetAccountFund();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetAccountHead(int FundID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetAccountHead(FundID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddAccountHead(int FundId, string HeadName, decimal FundAmount)
        {

            int i = 0;
            try
            {
                i = objComm.AddAccountHead(FundId, HeadName, FundAmount);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditAccountHeads(int HeadID, int FundID, string HeadName, decimal FundAmount)
        {
            int i = 0;
            try
            {
                i = objComm.EditAccountHeads(HeadID, FundID, HeadName, FundAmount);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteAccountHead(int HeadID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteAccountHead(HeadID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetAccountSubHead(int HeadID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetAccountSubHead(HeadID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddAccountSubHead(int HeadID, string SubHeadName, decimal FundAmount)
        {
            int i = 0;
            try
            {
                i = objComm.AddAccountSubHead(HeadID, SubHeadName, FundAmount);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditAccountSubHead(int SubHeadID, string SubHeadName, int HeadID, decimal FundAmount)
        {
            int i = 0;
            try
            {
                i = objComm.EditAccountSubHead(SubHeadID, SubHeadName, HeadID, FundAmount);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteAccountSubHead(int SubHeadID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteAccountSubHead(SubHeadID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message); 
            }
            return i;
        }


        //public DataSet GetAccountHead(int FundID)
        //{
        //    ds = new DataSet();
        //    try
        //    {
        //        ds = objComm.GetAccountHead(FundID);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return ds;
        //}

        //public int EditAccountHead(int HeadID, int FundId, string HeadName)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.EditAccountHead(HeadID, FundId, HeadName);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}

        //public int AddAccountHead(int FundId, string HeadName)
        //{

        //    int i = 0;
        //    try
        //    {
        //        i = objComm.AddAccountHead(FundId, HeadName);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}

        //public int DeleteAccountHead(int HeadID)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.DeleteAccountHead(HeadID);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}


        public DataSet GetAccFundsI()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetAccFundsI();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


        public int AddAccFundsI(string FundName)
        {

            int i = 0;
            try
            {
                i = objComm.AddAccFundsI(FundName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int EditAccFundsI(int FundID, string FundName)
        {
            int i = 0;
            try
            {
                i = objComm.EditAccFundsI(FundID, FundName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteAccFundsI(int FundID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteAccFundsI(FundID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        //public DataSet GetAccountSubHead(int HeadID)
        //{
        //    ds = new DataSet();
        //    try
        //    {
        //        ds = objComm.GetAccountSubHead(HeadID);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return ds;
        //}
        public DataSet GetAccountSubHead()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetAccountSubHead();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetAppointmentMode()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetAppointmentMode();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetBatch()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetBatch();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetCader()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetCader();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetCaste()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetCaste();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetClasses()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetClasses();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetExtraCurricular()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetExtraCurricular();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetGroups()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetGroups();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetJoiningType()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetJoiningType();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetLocality()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetLocality();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetMartialStatus()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetMartialStatus();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetMedium()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetMedium();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }

            return ds;
        }
        public DataSet GetModeofPayment()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetModeofPayment();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetMotherTounge()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetMotherTounge();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetNationality()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetNationality();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int EditAccountHead(int HeadID, string HeadName)
        {
            int i = 0;
            try
            {
                i = objComm.EditAccountHead(HeadID, HeadName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditNationality(int NationalityID, string Nation)
        {
            int i = 0;
            try
            {
                i = objComm.EditNationality(NationalityID, Nation);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int DeleteNationality(int NationalityID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteNationality(NationalityID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetPhysicallyChallenged()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetPhysicallyChallenged();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int EditPhysicallychallenged(int PHId, string PHType)
        {
            int i = 0;
            try
            {
                i = objComm.EditPhysicallychallenged(PHId, PHType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int Deletephysicallychallenged(int PHID)
        {
            int i = 0;
            try
            {
                i = objComm.Deletephysicallychallenged(PHID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet spGetPostType()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.spGetPostType();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetQualification()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetQualification();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetSanctionOfPost()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetSanctionOfPost();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetSection()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetSection();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetState()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetState();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddAccountHead(string HeadName)
        {

            int i = 0;
            try
            {
                i = objComm.AddAccountHead(HeadName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        //public int AddAccountSubHead(int HeadID, string SubHeadName)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.AddAccountSubHead(HeadID, SubHeadName);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}
        public int AddAppointmentMode(string Mode)
        {
            int i = 0;
            try
            {
                i = objComm.AddAppointmentMode(Mode);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddBatch(string Batchno)
        {
            int i = 0;
            try
            {
                i = objComm.AddBatch(Batchno);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddCader(string CaderType)
        {
            int i = 0;
            try
            {
                i = objComm.AddCader(CaderType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddCaste(string Caste)
        {
            int i = 0;
            try
            {
                i = objComm.AddCaste(Caste);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddClasses(string Classname)
        {
            int i = 0;
            try
            {
                i = objComm.AddClasses(Classname);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddExtraCircular(string Activity)
        {
            int i = 0;
            try
            {
                i = objComm.AddExtraCircular(Activity);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddGroups(string GroupName)
        {
            int i = 0;
            try
            {
                i = objComm.AddGroups(GroupName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddJoiningType(string JTName)
        {
            int i = 0;
            try
            {
                i = objComm.AddJoiningType(JTName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddLocality(string LocalityName)
        {
            int i = 0;
            try
            {
                i = objComm.AddLocality(LocalityName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddMartialStatus(string Status)
        {
            int i = 0;
            try
            {
                i = objComm.AddMartialStatus(Status);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddMedium(string Medium)
        {
            int i = 0;
            try
            {
                i = objComm.AddMedium(Medium);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddModeofPayment(string ModeofPay)
        {
            int i = 0;
            try
            {
                i = objComm.AddModeofPayment(ModeofPay);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddMotherTounge(string Language)
        {
            int i = 0;
            try
            {
                i = objComm.AddMotherTounge(Language);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);

            }
            return i;
        }
        public int AddNationality(string Nation)
        {
            int i = 0;
            try
            {
                i = objComm.AddNationality(Nation);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddPhysicallyChallenged(string PHType)
        {
            int i = 0;
            try
            {
                i = objComm.AddPhysicallyChallenged(PHType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddPostType(string PostType)
        {
            int i = 0;
            try
            {
                i = objComm.AddPostType(PostType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddQualification(string Qualification)
        {
            int i = 0;
            try
            {
                i = objComm.AddQualification(Qualification);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddSanctionOfPost(string SanctionType)
        {
            int i = 0;
            try
            {
                i = objComm.AddSanctionOfPost(SanctionType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddSection(string Section)
        {
            int i = 0;
            try
            {
                i = objComm.AddSection(Section);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditBatch(int BatchID, string BatchNo)
        {
            int i = 0;
            try
            {
                i = objComm.EditBatch(BatchID, BatchNo);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditSection(int SectionID, string SectionName)
        {
            int i = 0;
            try
            {
                i = objComm.EditSection(SectionID, SectionName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int DeleteBatch(int BatchID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteBatch(BatchID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteSection(int SectionID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteSection(SectionID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditClass(int ClassID, string ClassName)
        {
            int i = 0;
            try
            {
                i = objComm.EditClass(ClassID, ClassName);

            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteClass(int ClassID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteClass(ClassID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditMedium(int MediumID, string Language)
        {
            int i = 0;
            try
            {
                i = objComm.EditMedium(MediumID, Language);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteMedium(int MediumID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteMedium(MediumID);
            }
            catch (Exception Ex) 
            {
                ErrHandler.WriteError(Ex.Message); 
            }
            return i;
        }
        public int EditExtraCurricular(int ExtraCurricularID, string Activity)
        {
            int i = 0;
            try
            {
                i = objComm.EditExtraCurricular(ExtraCurricularID, Activity);
            }
            catch (Exception Ex) 
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public int DeleteExtraCurricular(int ExtraCurricularID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteExtraCurricular(ExtraCurricularID);
            }
            catch (Exception Ex) 
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditQualification(int QualificationID, string QualificationDetails)
        {
            int i = 0;
            try
            {
                i = objComm.EditQualification(QualificationID, QualificationDetails);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteQualification(int QualificationID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteQualification(QualificationID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddState(string StateName)
        {
            int i = 0;
            try
            {
                i = objComm.AddState(StateName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditState(int StateID, string StateName)
        {
            int i = 0;
            try
            {
                i = objComm.EditState(StateID, StateName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteState(int StateID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteState(StateID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }








        public int EditMotherTounge(int MTID, string Language)
        {
            int i = 0;
            try
            {
                i = objComm.EditMotherTounge(MTID, Language);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteMotherTounge(int MTID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteMotherTounge(MTID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }



        public int EditJoiningType(int JTID, string JTName)
        {
            int i = 0;
            try
            {
                i = objComm.EditJoiningType(JTID, JTName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteJoiningType(int JTID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteJoiningType(JTID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }



        public int EditCaste(int CasteID, string Caste)
        {
            int i = 0;
            try
            {
                i = objComm.EditCaste(CasteID, Caste);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteCaste(int CasteID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteCaste(CasteID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddItem(string ItemName, int Type, int Periodicity, int SubCategory, int UOM)
        {
            int i = 0;
            try
            {
                i = objComm.AddItem(ItemName, Type, Periodicity, SubCategory, UOM);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditItem(int itemID, string itemName, int Type, int Periodicity, int SubCategory, int UOM)
        {

            int i = 0;
            try
            {
                i = objComm.EditItem(itemID, itemName, Type, Periodicity, SubCategory, UOM);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteItem(int itemID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteItem(itemID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public DataSet GetSubject()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetSubject();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddSubject(string SubjectName)
        {
            int i = 0;
            try
            {
                i = objComm.AddSubject(SubjectName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditSubject(int SubjectId, string SubjectName)
        {
            int i = 0;
            try
            {
                i = objComm.EditSubject(SubjectId, SubjectName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteSubject(int SubjectId)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteSubject(SubjectId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddSalary(string NameOfField, int Type)
        {
            int i = 0;
            try
            {
                i = objComm.AddSalary(NameOfField, Type);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditSalary(int FieldID, string FieldName, int Type)
        {
            int i = 0;
            try
            {
                i = objComm.EditSalary(FieldID, FieldName, Type);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteSalary(int FieldID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteSalary(FieldID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetSalary()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetSalary();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetLeaves(int LeaveID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetLeaves(LeaveID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetLeaves()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetLeaves();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        //public int AddLeaves(string LeaveName, int MaxLeaves)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.AddLeaves(LeaveName, MaxLeaves);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}
        //public int EditLeaves(int LeaveID, string LeaveName, int MaxLeaves)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.EditLeaves(LeaveID, LeaveName, MaxLeaves);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}

        //public int DeleteLeave(int LeaveID)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = objComm.DeleteLeave(LeaveID);
        //    }
        //    catch (Exception Ex)
        //    {
        //    }
        //    return i;
        //}
        public int DeleteGroups(int GroupId)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteGroups(GroupId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditGroups(int GroupId, string GroupName)
        {
            int i = 0;
            try
            {
                i = objComm.EditGroups(GroupId, GroupName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffLoansMaster(string LoanName, int MaxAmount, int MaxNoofinstallments, string Remarks)
        {
            int i = 0;
            try
            {
                i = objComm.AddStaffLoansMaster(LoanName, MaxAmount, MaxNoofinstallments, Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditStaffLoansMaster(int LoanId, string LoanName, int MaxAmount, int MaxNoofinstallments, string Remarks)
        {
            int i = 0;
            try
            {
                i = objComm.EditStaffLoansMaster(LoanId, LoanName, MaxAmount, MaxNoofinstallments, Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetStaffLoansMaster()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetStaffLoansMaster();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetLoginDetails(string Username, string Password)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetLoginDetails(Username, Password);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public void AddError(string Page, string ErrorMessage, DateTime MsgDate)
        {
           // int i = 0;
            try
            {
                objComm.AddError(Page, ErrorMessage, MsgDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }

        }

        public void AddUser(string Username, string Password, int UserType)
        {
            //int i = 0;
            try
            {
                objComm.AddUser(Username, Password, UserType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
        }
        public DataSet GetClub()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetClub();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddClub(string ClubName)
        {
            int i = 0;
            try
            {
                i = objComm.AddClub(ClubName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditClub(int ClubID, string ClubName)
        {
            int i = 0;
            try
            {
                i = objComm.EditClub(ClubID, ClubName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteClub(int ClubID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteClub(ClubID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetActivities(int Type, int Club)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetActivities(Type, Club);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddActivities(string Activities, int Type, int Club)
        {
            int i = 0;
            try
            {
                i = objComm.AddActivities(Activities, Type, Club);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditActivities(int ActivitiID, string Activities, int Type)
        {
            int i = 0;
            try
            {
                i = objComm.EditActivities(ActivitiID, Activities, Type);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteActivities(int ActivitiID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteActivities(ActivitiID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetHouse()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetHouse();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddHouse(string HouseName)
        {
            int i = 0;
            try
            {
                i = objComm.AddHouse(HouseName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditHouse(int HouseID, string HouseName)
        {
            int i = 0;
            try
            {
                i = objComm.EditHouse(HouseID, HouseName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteHouse(int HouseID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteHouse(HouseID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStoreItem()
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetStoreItem();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddFeeHeader(int FeeTypeId, string HeadName)
        {

            int i = 0;
            try
            {
                i = objComm.AddFeeHeader(FeeTypeId, HeadName);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int EditFeeHeaders(int HeadID, int FeeTypeId, string Headername)
        {
            int i = 0;
            try
            {
                i = objComm.EditFeeHeaders(HeadID, FeeTypeId, Headername);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int DeleteFeeHeader(int HeadID)
        {
            int i = 0;
            try
            {
                i = objComm.DeleteFeeHeader(HeadID);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public DataSet GetFeeType(int FeeTypeID)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetFeeType(FeeTypeID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetFeeHeader(int FeeType)
        {
            ds = new DataSet();
            try
            {
                ds = objComm.GetFeeHeader(FeeType);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public int AddFeeType(string FeeType, string Date)
        {
            int i = 0;
            try
            {
                i = objComm.AddFeeType(FeeType, Date);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int EditFeeType(int FeeTypeID, string FeeType, string Date)
        {
            int i = 0;
            try
            {
                i = objComm.EditFeeType(FeeTypeID, FeeType, Date);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int DeleteFeeType(int FeeTypeID)
        {
            int i;
            try
            {

                i = objComm.DeleteFeeType(FeeTypeID);

            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }
        public int AddFeeAllocation(int Year, int Class, int Group, int HeaderId, double Amount, int Category, int FeeType)
        {
            int i = 0;
            try
            {
                i = objComm.AddFeeAllocation(Year, Class, Group, HeaderId, Amount, Category, FeeType);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public DataSet GetFeeCategory()
        {
            ds = new DataSet();
            ds = objComm.GetFeeCategory();
            return ds;
        }
    }
}
