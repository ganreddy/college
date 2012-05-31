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
    public class StaffDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public DataSet GetDuplicateStaffSalaryByHeads(int StaffID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            //param[1] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            //param[1].Value = Heads;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetDuplicateStaffSalaryByHeads", param);
            return ds;
        }
        public int UpdateStaffSalaryByHeads(int StaffID, int HeadID, decimal Amount)
        {

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 100);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[1].Value = HeadID;
            param[2] = new SqlParameter("@Amount", SqlDbType.Decimal, 4);
            param[2].Value = Amount;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaffSalaryByHeads", param);
            return i;
        }
       

        public int DeleteStaffLeaves(int RecordID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@RecordID", SqlDbType.Int, 4);
            param[0].Value = RecordID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteStaffLeaves", param);
            return i;
        }
        public int UpdateStaffLeaves(int RecordID, int LeaveID, DateTime From, DateTime To, string Purpose, int Authority)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@RecordID", SqlDbType.Int, 4);
            param[0].Value = RecordID;
            param[1] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
            param[1].Value = LeaveID;
            param[2] = new SqlParameter("@From", SqlDbType.DateTime, 8);
            param[2].Value = From;
            param[3] = new SqlParameter("@To", SqlDbType.DateTime, 8);
            param[3].Value = To;
            param[4] = new SqlParameter("@Purpose", SqlDbType.VarChar, 200);
            param[4].Value = Purpose;
            param[5] = new SqlParameter("@Authority", SqlDbType.Int, 4);
            param[5].Value = Authority;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaffLeaves", param);
            return i;
        }

        public DataSet GetStaffLeaves(int StaffID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffLeaves", param);
            return ds;
        }
        public int AddStaffLeaves(int StaffID, int LeaveID, DateTime From, DateTime To, string Purpose, int Authority)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
            param[1].Value = LeaveID;
            param[2] = new SqlParameter("@From", SqlDbType.DateTime, 8);
            param[2].Value = From;
            param[3] = new SqlParameter("@To", SqlDbType.DateTime, 8);
            param[3].Value = To;
            param[4] = new SqlParameter("@Purpose", SqlDbType.VarChar, 200);
            param[4].Value = Purpose;
            param[5] = new SqlParameter("@Authority", SqlDbType.Int, 4);
            param[5].Value = Authority;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffLeaves", param);
            return i;


        }
        public DataSet GetLeavesbyStaffType(int StaffType)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffType", SqlDbType.Int, 4);
            param[0].Value = StaffType;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLeavesbyStaffType", param);
            return ds;
        }
        public DataSet GetLeaves(int LeaveTypeID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
            param[0].Value = LeaveTypeID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLeaves", param);
            return ds;
        }
        public DataSet GetStaffPayslipByLeaves(int StaffID, int Month, int Year)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[1].Value = Month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = Year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffPaySlipByLeaves", param);
            return ds;
        }
        public DataSet GetStaffAvailableLeaves(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffAvailableLeaves", param);
            return ds;
        }
        public int AddLeaves(string LeaveType, int StaffType, int NoofDays, int Cummulative)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@LeaveType", SqlDbType.VarChar, 50);
            param[0].Value = LeaveType;
            param[1] = new SqlParameter("@StaffType", SqlDbType.Int, 4);
            param[1].Value = StaffType;
            param[2] = new SqlParameter("@NoofDays", SqlDbType.Int, 4);
            param[2].Value = NoofDays;
            param[3] = new SqlParameter("@Cummulative", SqlDbType.Int, 4);
            param[3].Value = Cummulative;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddLeaves", param);
            return i;
        }
        public int EditLeaves(int LeaveTypeID, string LeaveType, int StaffType, int NoofDays, int Cummulative)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int, 4);
            param[0].Value = LeaveTypeID;
            param[1] = new SqlParameter("@LeaveType", SqlDbType.VarChar, 50);
            param[1].Value = LeaveType;
            param[2] = new SqlParameter("@StaffType", SqlDbType.Int, 4);
            param[2].Value = StaffType;
            param[3] = new SqlParameter("@NoofDays", SqlDbType.Int, 4);
            param[3].Value = NoofDays;
            param[4] = new SqlParameter("@Cummulative", SqlDbType.Int, 4);
            param[4].Value = Cummulative;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditLeaves", param);
            return i;
        }

        public int DeleteLeaves(int LeaveTypeID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@LeaveTypeID", SqlDbType.Int, 4);
            param[0].Value = LeaveTypeID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteLeaves", param);
            return i;
        }
        public int TotalStaffSalPaySlip(int StaffID, int Month, Int64 Year, int HeadID, int Type, decimal Amount, int NoOfWorkingDays)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 100);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[1].Value = Month;
            param[2] = new SqlParameter("@Year", SqlDbType.BigInt, 4);
            param[2].Value = Year;
            param[3] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[3].Value = HeadID;
            param[4] = new SqlParameter("@Type", SqlDbType.Int, 8);
            param[4].Value = Type;
            param[5] = new SqlParameter("@Amount", SqlDbType.Decimal, 8);
            param[5].Value = Amount;
            param[6] = new SqlParameter("@NoOfWorkingDays", SqlDbType.Int, 4);
            param[6].Value = NoOfWorkingDays;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddTotalStaffSalPaySlip", param);
            return i;
        }
        public DataSet GetStaffSalaryPaySlip(int StaffID)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 200);
            param[0].Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffSalaryPaySlip", param);
            return ds;
        }
        public DataSet AddTotalStaffSalPaySlipDuplicates(int StaffID, int Months, int Years)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 200);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Months", SqlDbType.Int, 200);
            param[1].Value = Months;
            param[2] = new SqlParameter("@Years", SqlDbType.Int, 200);
            param[2].Value = Years;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spAddTotalStaffSalPaySlipDuplicates", param);
            return ds;
        }

        public DataSet GetStaffSal()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffSal");
            return ds;
        }

        public DataSet GetStaffSalHeadByHeadID(int HeadID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSalaryHeadsbyHeadID", param);
            return ds;
        }
        public DataSet GetStaffHeader()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffHeader");
            return ds;
        }
        public int AddStaffSalary(string HeadName, int Type, int CalculationType, int Header, decimal Percentage, int Status)
        {

            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@HeadName", SqlDbType.VarChar, 100);
            param[0].Value = HeadName;
            param[1] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[1].Value = Type;
            param[2] = new SqlParameter("@CalculationType", SqlDbType.Int, 4);
            param[2].Value = CalculationType;
            param[3] = new SqlParameter("@Header", SqlDbType.Int, 4);
            param[3].Value = Header;
            param[4] = new SqlParameter("@Percentage", SqlDbType.Decimal, 8);
            param[4].Value = Percentage;
            param[5] = new SqlParameter("@Status", SqlDbType.Int, 4);
            param[5].Value = Status;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffSal", param);
            return i;
        }

        public int AddStaffSalaryByHead(int StaffID, int HeadID, decimal Amount)
        {

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 100);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[1].Value = HeadID;
            param[2] = new SqlParameter("@Amount", SqlDbType.Decimal, 4);
            param[2].Value = Amount;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffSalary", param);
            return i;
        }
        public int UpdateStaffSalary(int HeadID, string HeadName, int Type, int CalculationType, int Header, double Percentage)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@HeadID", SqlDbType.Int, 4);
            param[0].Value = HeadID;
            param[1] = new SqlParameter("@HeadName", SqlDbType.VarChar, 100);
            param[1].Value = HeadName;
            param[2] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[2].Value = Type;
            param[3] = new SqlParameter("@CalculationType", SqlDbType.Int, 4);
            param[3].Value = CalculationType;
            param[4] = new SqlParameter("@Header", SqlDbType.Int, 4);
            param[4].Value = Header;
            param[5] = new SqlParameter("@Percentage", SqlDbType.Decimal);
            param[5].Value = Percentage;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaffSal", param);
            return i;
        }
        public int DeleteStaffSalary(string Ids)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Ids", SqlDbType.VarChar, 500);
            param[0].Value = Ids;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteSalaryHeadsbyHeadID", param);
            return i;

        }

        public DataSet GetTeachingStaff(int StaffID)
        {
            DataSet ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;

            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetTeachingStaff", param);

            return ds;
        }
        public DataSet GetDaysPeriods()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetDaysperiod");
            return ds;
        }
        public int AddTimetable(int TeacherId, int DayId, int PeriodId, int ClassId, int SectionId, int SubjectId, int YearId)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@TeacherId", SqlDbType.Int, 4);
            param[0].Value = TeacherId;
            param[1] = new SqlParameter("@DayId", SqlDbType.Int, 4);
            param[1].Value = DayId;
            param[2] = new SqlParameter("@PeriodId", SqlDbType.Int, 4);
            param[2].Value = PeriodId;
            param[3] = new SqlParameter("@ClassId", SqlDbType.Int, 4);
            param[3].Value = ClassId;
            param[4] = new SqlParameter("@SectionId", SqlDbType.Int, 4);
            param[4].Value = SectionId;
            param[5] = new SqlParameter("@SubjectId", SqlDbType.Int, 4);
            param[5].Value = SubjectId;
            param[6] = new SqlParameter("@YearId", SqlDbType.Int, 4);
            param[6].Value = YearId;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddTimetabledata", param);
            return i;
        }
        public DataSet GetClassTimetable(int ClassId, int SectionId, int YearId)
        {
            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ClassId", SqlDbType.Int, 4);
            param[0].Value = ClassId;
            param[1] = new SqlParameter("@SectionId", SqlDbType.Int, 4);
            param[1].Value = SectionId;
            param[2] = new SqlParameter("@YearId", SqlDbType.Int, 4);
            param[2].Value = YearId;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetClassTimetable", param);
            return ds;
        }
        public int UpdateTimetable(int TeacherId, int DayId, int PeriodId, int ClassId, int SectionId, int YearId)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@TeacherId", SqlDbType.Int, 4);
            param[0].Value = TeacherId;
            param[1] = new SqlParameter("@DayId", SqlDbType.Int, 4);
            param[1].Value = DayId;
            param[2] = new SqlParameter("@PeriodId", SqlDbType.Int, 4);
            param[2].Value = PeriodId;
            param[3] = new SqlParameter("@ClassId", SqlDbType.Int, 4);
            param[3].Value = ClassId;
            param[4] = new SqlParameter("@SectionId", SqlDbType.Int, 4);
            param[4].Value = SectionId;

            param[5] = new SqlParameter("@YearId", SqlDbType.Int, 4);
            param[5].Value = YearId;

            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateTimetable", param);
            return i;
        }
        public DataSet GetTimetableClasswise(int ClassId, int SectionId,int YearId)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@ClassId", SqlDbType.Int, 4);
                param[0].Value = ClassId;
                param[1] = new SqlParameter("@SectionId", SqlDbType.Int, 4);
                param[1].Value = SectionId;
                param[2] = new SqlParameter("@YearId", SqlDbType.Int, 4);
                param[2].Value = YearId;
                ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetTimetableClasswise", param);

            }
            catch (Exception)
            {

                throw;
            }
            return ds;

        }
        public DataSet GetStaffwiseTimetable(int YearId)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@YearId", SqlDbType.Int, 4);
                param[0].Value = YearId;

                ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffwisetimetable", param);

            }
            catch (Exception)
            {

                throw;
            }
            return ds;

        }
        public DataSet GetDaysPeriods(int Classid, int Sectionid, int Yearid)
        {
            DataSet ds;
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@Classid", SqlDbType.Int);
                param[0].Value = Classid;
                param[1] = new SqlParameter("@Sectionid", SqlDbType.Int);
                param[1].Value = Sectionid;
                param[2] = new SqlParameter("@Yearid", SqlDbType.Int);
                param[2].Value = Yearid;

                ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetDaysPeriods", param);


            }
            catch (Exception)
            {

                throw;
            }
            return ds;
        }

        public DataSet DeleteStaffDetails(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spDeleteStaffDetails", param);
            return ds;
        }
        public int UpdateStaffAttendance(int StaffID, int NoOfDays)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@NoOfDaysPresent", SqlDbType.Int, 4);
            param[1].Value = NoOfDays;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaffAttendance", param);
            return i;
        }
        public DataSet GetEditStaffAttendance(int months, int year)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[0].Value = months;
            param[1] = new SqlParameter("@Year", SqlDbType.BigInt, 4);
            param[1].Value = year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffEditAttendance", param);
            return ds;
        }
        public DataSet CheckDuplicatesStaffAttendance(int StaffID, int months, int year)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Months", SqlDbType.Int, 4);
            param[1].Value = months;
            param[2] = new SqlParameter("@Years", SqlDbType.BigInt, 4);
            param[2].Value = year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCheckStaffAttendanceDuplicates", param);
            return ds;
        }
        
        public int UpdateStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, int DateOfRetirement, DateTime RetirementDate)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Nominee", SqlDbType.VarChar, 50);
            param[1].Value = Nominee;
            param[2] = new SqlParameter("@TerminalBenifits", SqlDbType.Int, 8);
            param[2].Value = TerminalBenifits;
            param[3] = new SqlParameter("@GPFAccountNo", SqlDbType.VarChar, 20);
            param[3].Value = GPFAccountNo;
            param[4] = new SqlParameter("@GslisRecordNO", SqlDbType.VarChar, 4);
            param[4].Value = GslisRecordNO;
            param[5] = new SqlParameter("@CertificateSubmit", SqlDbType.Int, 8);
            param[5].Value = CertificateSubmit;
            param[6] = new SqlParameter("@YearsOfExperience", SqlDbType.Int, 20);
            param[6].Value = YearsOfExperience;
            param[7] = new SqlParameter("@DateOfRetirement", SqlDbType.Int, 8);
            param[7].Value = DateOfRetirement;
            param[8] = new SqlParameter("@RetirementDate", SqlDbType.DateTime, 8);
            param[8].Value = RetirementDate;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaff_Accounts", param);
            return i;
        }

        public int AddStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, int DateOfRetirement, DateTime RetirementDate)
        {
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Nominee", SqlDbType.VarChar, 50);
            param[1].Value = Nominee;
            param[2] = new SqlParameter("@TerminalBenifits", SqlDbType.Int, 8);
            param[2].Value = TerminalBenifits;
            param[3] = new SqlParameter("@GPFAccountNo", SqlDbType.VarChar, 20);
            param[3].Value = GPFAccountNo;
            param[4] = new SqlParameter("@GslisRecordNO", SqlDbType.VarChar, 4);
            param[4].Value = GslisRecordNO;
            param[5] = new SqlParameter("@CertificateSubmit", SqlDbType.Int, 8);
            param[5].Value = CertificateSubmit;
            param[6] = new SqlParameter("@YearsOfExperience", SqlDbType.Int, 20);
            param[6].Value = YearsOfExperience;
            param[7] = new SqlParameter("@DateOfRetirement", SqlDbType.Int, 8);
            param[7].Value = DateOfRetirement;
            param[8] = new SqlParameter("@RetirementDate", SqlDbType.DateTime, 8);
            param[8].Value = RetirementDate;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaff_Accounts", param);
            return i;
        }


        public DataSet GetStaffAttendanceByLeaves(int StaffID, int Month, int Year)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[1].Value = Month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = Year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffAttendanceByStaffLeaves", param);
            return ds;
        }

        public DataSet GetStaffPreviousPostings(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPreviousPostings", param);
            return ds;
        }
        public DataSet GetStaff_TrainingCourses(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGet_StaffTrainingCources", param);
            return ds;
        }

        public DataSet GetStaff_Identification(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaff_Identification", param);
            return ds;
        }

        public DataSet GetStaffAccount(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaff_Accounts", param);
            return ds;
        }

        public int AddStaffIdentification(int StaffID, string Mole1, string Mole2)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Mole1", SqlDbType.VarChar, 250);
            param[1].Value = Mole1;
            param[2] = new SqlParameter("@Mole2", SqlDbType.VarChar, 250);
            param[2].Value = Mole2;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffIdentification", param);
            return i;


        }

        public int UpdateStaff(int StaffID, string StaffNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int Nationality, int StaffType, string Religion, string HomeDistrict, int PhysicallyChallenged, int Caste, int MartialStatus, int AppointmentMode, string PostName, int Cader, int PostType, int PostSanction, decimal BasicSalary, DateTime DateOfJoining, DateTime CurrJD, string PermanentAddress, string PresentAddress, string Telephone, string Mobile)
        {

            SqlParameter[] param = new SqlParameter[26];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@StaffNo", SqlDbType.VarChar, 20);
            param[1].Value = StaffNo;
            param[2] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime, 8);
            param[2].Value = AdmissionDate;
            param[3] = new SqlParameter("@FullName", SqlDbType.VarChar, 75);
            param[3].Value = FullName;
            param[4] = new SqlParameter("@MotherTounge", SqlDbType.Int, 4);
            param[4].Value = MotherTounge;
            param[5] = new SqlParameter("@Gender", SqlDbType.Int, 4);
            param[5].Value = Gender;
            param[6] = new SqlParameter("@Nationality", SqlDbType.Int, 4);
            param[6].Value = Nationality;
            param[7] = new SqlParameter("@StaffType", SqlDbType.Int, 4);
            param[7].Value = StaffType;
            param[8] = new SqlParameter("@Religion", SqlDbType.VarChar, 30);
            param[8].Value = Religion;
            param[9] = new SqlParameter("@HomeDistrict", SqlDbType.VarChar, 50);
            param[9].Value = HomeDistrict;
            param[10] = new SqlParameter("@PhysicallyChallenged", SqlDbType.Int, 4);
            param[10].Value = PhysicallyChallenged;
            param[11] = new SqlParameter("@Caste", SqlDbType.Int, 4);
            param[11].Value = Caste;
            param[12] = new SqlParameter("@MartialStatus", SqlDbType.Int, 4);
            param[12].Value = MartialStatus;
            param[13] = new SqlParameter("@AppointmentMode", SqlDbType.Int, 4);
            param[13].Value = AppointmentMode;
            param[14] = new SqlParameter("@PostName", SqlDbType.VarChar, 50);
            param[14].Value = PostName;
            param[15] = new SqlParameter("@PostType", SqlDbType.Int, 4);
            param[15].Value = PostType;
            param[16] = new SqlParameter("@PostSanction", SqlDbType.Int, 4);
            param[16].Value = PostSanction;
            param[17] = new SqlParameter("@BasicSalary", SqlDbType.Decimal, 8);
            param[17].Value = BasicSalary;
            param[18] = new SqlParameter("@DateOfJoining", SqlDbType.DateTime, 8);
            param[18].Value = DateOfJoining;
            param[19] = new SqlParameter("@CurrJD", SqlDbType.DateTime, 8);
            param[19].Value = CurrJD;
            param[20] = new SqlParameter("@PermanentAddress", SqlDbType.VarChar, 150);
            param[20].Value = PermanentAddress;
            param[21] = new SqlParameter("@PresentAddress", SqlDbType.VarChar, 150);
            param[21].Value = PresentAddress;
            param[22] = new SqlParameter("@Telephone", SqlDbType.VarChar, 20);
            param[22].Value = Telephone;
            param[23] = new SqlParameter("@Mobile", SqlDbType.VarChar, 20);
            param[23].Value = Mobile;
            param[24] = new SqlParameter("@DOB", SqlDbType.DateTime, 8);
            param[24].Value = DOB;
            param[25] = new SqlParameter("@Cader", SqlDbType.Int, 4);
            param[25].Value = Cader;
            //param[25] = new SqlParameter("@staffid", SqlDbType.Int, 4);
            //param[25].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaffDEtails", param);
            // return Convert.ToInt32(param[25].Value);
            return i;
        }
        public int UpdateStaffQualification(int StaffID, int Degree, int Subject, string University, int Yearofpassing, int Percentage)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Degree", SqlDbType.Int, 4);
            param[1].Value = Degree;
            param[2] = new SqlParameter("@Subject", SqlDbType.Int, 4);
            param[2].Value = Subject;
            param[3] = new SqlParameter("@University", SqlDbType.VarChar, 50);
            param[3].Value = University;
            param[4] = new SqlParameter("@Yearofpassing", SqlDbType.Int, 4);
            param[4].Value = Yearofpassing;
            param[5] = new SqlParameter("@Percentage", SqlDbType.Int, 4);
            param[5].Value = Percentage;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaff_Qualification", param);
            return i;
        }
        public int UpdateStaff_Family(int staffid, string SpouseName, string SpousePlace, string SpouseContactNo, int SpouseEmpStatus, string ChildName, string ChildPlace, string ChildContactNo, int ChildEmpStatus, string ParentName, string ParentPlace, string ParentContactNo, int ParentEmpStatus)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = staffid;
            param[1] = new SqlParameter("@SpouseName", SqlDbType.VarChar, 40);
            param[1].Value = SpouseName;
            param[2] = new SqlParameter("@SpousePlace", SqlDbType.VarChar, 30);
            param[2].Value = SpousePlace;
            param[3] = new SqlParameter("@SpouseEmpStatus", SqlDbType.Int, 4);
            param[3].Value = SpouseEmpStatus;
            param[4] = new SqlParameter("@SpouseContactNo", SqlDbType.VarChar, 20);
            param[4].Value = SpouseContactNo;
            param[5] = new SqlParameter("@ChildName", SqlDbType.VarChar, 40);
            param[5].Value = ChildName;
            param[6] = new SqlParameter("@ChildPlace", SqlDbType.VarChar, 30);
            param[6].Value = ChildPlace;
            param[7] = new SqlParameter("@ChildEmpStatus", SqlDbType.Int, 4);
            param[7].Value = ChildEmpStatus;
            param[8] = new SqlParameter("@ChildContactNo", SqlDbType.VarChar, 20);
            param[8].Value = ChildContactNo;


            param[9] = new SqlParameter("@ParentName", SqlDbType.VarChar, 40);
            param[9].Value = ParentName;
            param[10] = new SqlParameter("@ParentPlace ", SqlDbType.VarChar, 30);
            param[10].Value = ParentPlace;
            param[11] = new SqlParameter("@ParentEmpStatus", SqlDbType.Int, 4);
            param[11].Value = ParentEmpStatus;
            param[12] = new SqlParameter("@ParentContactNo", SqlDbType.VarChar, 20);
            param[12].Value = ParentContactNo;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaff_Family", param);
            return i;
        }
        public int UpdateStaffIdentification(int StaffID, string Mole1, string Mole2)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Mole1", SqlDbType.VarChar, 250);
            param[1].Value = Mole1;
            param[2] = new SqlParameter("@Mole2", SqlDbType.VarChar, 250);
            param[2].Value = Mole2;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaff_Identification", param);
            return i;
        }
        public int AddStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, string NativePlace, int DateOfRetirement, DateTime RetirementDate)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Nominee", SqlDbType.VarChar, 50);
            param[1].Value = Nominee;
            param[2] = new SqlParameter("@TerminalBenifits", SqlDbType.Int, 8);
            param[2].Value = TerminalBenifits;
            param[3] = new SqlParameter("@GPFAccountNo", SqlDbType.VarChar, 20);
            param[3].Value = GPFAccountNo;
            param[4] = new SqlParameter("@GslisRecordNO", SqlDbType.VarChar, 4);
            param[4].Value = GslisRecordNO;
            param[5] = new SqlParameter("@CertificateSubmit", SqlDbType.Int, 8);
            param[5].Value = CertificateSubmit;
            param[6] = new SqlParameter("@YearsOfExperience", SqlDbType.Int, 20);
            param[6].Value = YearsOfExperience;
            param[7] = new SqlParameter("@NativePlace", SqlDbType.VarChar, 30);
            param[7].Value = NativePlace;
            param[8] = new SqlParameter("@DateOfRetirement", SqlDbType.Int, 8);
            param[8].Value = DateOfRetirement;
            param[9] = new SqlParameter("@RetirementDate", SqlDbType.DateTime, 8);
            param[9].Value = RetirementDate;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaff_Accounts", param);
            return i;
        }
        public int UpdateStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, string NativePlace, int DateOfRetirement, DateTime RetirementDate)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Nominee", SqlDbType.VarChar, 50);
            param[1].Value = Nominee;
            param[2] = new SqlParameter("@TerminalBenifits", SqlDbType.Int, 8);
            param[2].Value = TerminalBenifits;
            param[3] = new SqlParameter("@GPFAccountNo", SqlDbType.VarChar, 20);
            param[3].Value = GPFAccountNo;
            param[4] = new SqlParameter("@GslisRecordNO", SqlDbType.VarChar, 4);
            param[4].Value = GslisRecordNO;
            param[5] = new SqlParameter("@CertificateSubmit", SqlDbType.Int, 8);
            param[5].Value = CertificateSubmit;
            param[6] = new SqlParameter("@YearsOfExperience", SqlDbType.Int, 20);
            param[6].Value = YearsOfExperience;
            param[7] = new SqlParameter("@NativePlace", SqlDbType.VarChar, 30);
            param[7].Value = NativePlace;
            param[8] = new SqlParameter("@DateOfRetirement", SqlDbType.Int, 8);
            param[8].Value = DateOfRetirement;
            param[9] = new SqlParameter("@RetirementDate", SqlDbType.DateTime, 8);
            param[9].Value = RetirementDate;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaff_Accounts", param);
            return i;
        }

        
        public DataSet GetStaffDetailsData(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffDetailsData", param);
            return ds;
        }
        
        public DataSet GetLoanType()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetLoanType");
            return ds;
        }

        public int AddStaffGrandsalary(int StaffId, int Month, int year, float AddTota, float DelTotal, float GrandTotal)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[1].Value = Month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = year;
            param[3] = new SqlParameter("@AddTota", SqlDbType.Float, 8);
            param[3].Value = AddTota;
            param[4] = new SqlParameter("@DelTotal", SqlDbType.Float, 8);
            param[4].Value = DelTotal;
            param[5] = new SqlParameter("@GrandTotal", SqlDbType.Float, 8);
            param[5].Value = GrandTotal;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffGrandTotalSal", param);
            return i;
        }
        public int AddStaffApplyForLoan(int StaffId, int LoanId, DateTime Date, decimal AmountSanctioned, int NumberOfInstallments, decimal FirstInstallmentAmount, decimal SecondInstallmentAmount, decimal RemainingAmountEMI, DateTime AmountRecoveryStartedFrom, int AuthorisedBy, int Status, string Remarks, DateTime AmountPaidDate)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@LoanId", SqlDbType.Int, 4);
            param[1].Value = LoanId;
            param[2] = new SqlParameter("@Date", SqlDbType.DateTime, 4);
            param[2].Value = Date;
            param[3] = new SqlParameter("@AmountSanctioned", SqlDbType.Decimal, 8);
            param[3].Value = AmountSanctioned;
            param[4] = new SqlParameter("@NumberOfInstallments", SqlDbType.Int, 4);
            param[4].Value = NumberOfInstallments;
            param[5] = new SqlParameter("@FirstInstallmentAmount", SqlDbType.Decimal, 8);
            param[5].Value = FirstInstallmentAmount;
            param[6] = new SqlParameter("@SecondInstallmentAmount", SqlDbType.Decimal, 8);
            param[6].Value = SecondInstallmentAmount;
            param[7] = new SqlParameter("@RemainingAmountEMI", SqlDbType.Decimal, 8);
            param[7].Value = RemainingAmountEMI;
            param[8] = new SqlParameter("@AmountRecoveryStartedFrom", SqlDbType.DateTime, 8);
            param[8].Value = AmountRecoveryStartedFrom;
            param[9] = new SqlParameter("@AuthorisedBy", SqlDbType.Int, 8);
            param[9].Value = AuthorisedBy;
            param[10] = new SqlParameter("@Status", SqlDbType.Int, 8);
            param[10].Value = Status;
            param[11] = new SqlParameter("@Remarks", SqlDbType.VarChar, 8);
            param[11].Value = Remarks;
            param[12] = new SqlParameter("@AmountPaidDate", SqlDbType.DateTime, 8);
            param[12].Value = AmountPaidDate;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffApplyForLoan", param);
            return i;
        }







        public int AddStaff(string StaffNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int Nationality, int StaffType, string Religion, string HomeDistrict, int PhysicallyChallenged, int Caste, int MartialStatus, int AppointmentMode, string PostName,int Cader, int PostType, int PostSanction, decimal BasicSalary, DateTime DateOfJoining, DateTime CurrJD, string PermanentAddress, string PresentAddress, string Telephone, string Mobile)
        {

            SqlParameter[] param = new SqlParameter[26];
            param[0] = new SqlParameter("@StaffNo", SqlDbType.VarChar, 20);
            param[0].Value = StaffNo;
            param[1] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime, 8);
            param[1].Value = AdmissionDate;
            param[2] = new SqlParameter("@FullName", SqlDbType.VarChar, 75);
            param[2].Value = FullName;
            param[3] = new SqlParameter("@MotherTounge", SqlDbType.Int, 4);
            param[3].Value = MotherTounge;
            param[4] = new SqlParameter("@Gender", SqlDbType.Int, 4);
            param[4].Value = Gender;
            param[5] = new SqlParameter("@Nationality", SqlDbType.Int, 4);
            param[5].Value = Nationality;
            param[6] = new SqlParameter("@StaffType", SqlDbType.Int, 4);
            param[6].Value = StaffType;
            param[7] = new SqlParameter("@Religion", SqlDbType.VarChar, 30);
            param[7].Value = Religion;
            param[8] = new SqlParameter("@HomeDistrict", SqlDbType.VarChar, 50);
            param[8].Value = HomeDistrict;
            param[9] = new SqlParameter("@PhysicallyChallenged", SqlDbType.Int, 4);
            param[9].Value = PhysicallyChallenged;
            param[10] = new SqlParameter("@Caste", SqlDbType.Int, 4);
            param[10].Value = Caste;
            param[11] = new SqlParameter("@MartialStatus", SqlDbType.Int, 4);
            param[11].Value = MartialStatus;
            param[12] = new SqlParameter("@AppointmentMode", SqlDbType.Int, 4);
            param[12].Value = AppointmentMode;
            param[13] = new SqlParameter("@PostName", SqlDbType.VarChar, 50);
            param[13].Value = PostName;
            param[14] = new SqlParameter("@PostType", SqlDbType.Int, 4);
            param[14].Value = PostType;
            param[15] = new SqlParameter("@PostSanction", SqlDbType.Int, 4);
            param[15].Value = PostSanction;
            param[16] = new SqlParameter("@BasicSalary", SqlDbType.Decimal, 8);
            param[16].Value = BasicSalary;
            param[17] = new SqlParameter("@DateOfJoining", SqlDbType.DateTime, 8);
            param[17].Value = DateOfJoining;
            param[18] = new SqlParameter("@CurrJD", SqlDbType.DateTime, 8);
            param[18].Value = CurrJD;
            param[19] = new SqlParameter("@PermanentAddress", SqlDbType.VarChar, 150);
            param[19].Value = PermanentAddress;
            param[20] = new SqlParameter("@PresentAddress", SqlDbType.VarChar, 150);
            param[20].Value = PresentAddress;
            param[21] = new SqlParameter("@Telephone", SqlDbType.VarChar, 20);
            param[21].Value = Telephone;
            param[22] = new SqlParameter("@Mobile", SqlDbType.VarChar, 20);
            param[22].Value = Mobile;
            param[23] = new SqlParameter("@DOB", SqlDbType.DateTime, 8);
            param[23].Value = DOB;
            param[24] = new SqlParameter("@Cader", SqlDbType.Int,4);
            param[24].Value =Cader;
            param[25] = new SqlParameter("@staffid", SqlDbType.Int, 4);
            param[25].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaff", param);
            return Convert.ToInt32(param[25].Value);


        }

        public int AddStaffQualification(int StaffID, int Degree, int Subject, string University, int Yearofpassing, int Percentage)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@Degree", SqlDbType.Int,4);
            param[1].Value = Degree;
            param[2] = new SqlParameter("@Subject", SqlDbType.Int,4);
            param[2].Value = Subject;
            param[3] = new SqlParameter("@University", SqlDbType.VarChar,50);
            param[3].Value = University;
            param[4] = new SqlParameter("@Yearofpassing", SqlDbType.Int,4);
            param[4].Value = Yearofpassing;
            param[5] = new SqlParameter("@Percentage", SqlDbType.Int, 4);
            param[5].Value = Percentage;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffQualification", param);
            return i;


        }
        public int AddStaffLeaves(int StaffID, int LeaveID, DateTime From,DateTime To,string Remarks)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@StaffID", SqlDbType.Int, 4);
            param[0].Value = StaffID;
            param[1] = new SqlParameter("@LeaveID", SqlDbType.Int, 4);
            param[1].Value = LeaveID;
            param[2] = new SqlParameter("@From", SqlDbType.DateTime,8);
            param[2].Value = From;
            param[3] = new SqlParameter("@To", SqlDbType.DateTime,8);
            param[3].Value = To;
            param[4] = new SqlParameter("@Descr", SqlDbType.VarChar, 200);
            param[4].Value = Remarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffLeaves", param);
            return i;


        }
        
        public DataSet spGetStaffDetails(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaffDetails", param);
            return ds;
        }
        public DataSet GetStaff_Qualifiaction(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaff_Qualifiaction", param);
            return ds;
        }
        public DataSet GetStaff_Family(int StaffID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StaffID", SqlDbType.Int, 8);
            param.Value = StaffID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStaff_Family", param);
            return ds;
        }
        public int AddStaff_Family(int staffid, string SpouseName, string SpousePlace, string SpouseContactNo, int SpouseEmpStatus, string ChildName, string ChildPlace, string ChildContactNo, int ChildEmpStatus, string ParentName, string ParentPlace, string ParentContactNo, int ParentEmpStatus)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@staffid", SqlDbType.Int, 4);
            param[0].Value = staffid;
            param[1] = new SqlParameter("@SpouseName", SqlDbType.VarChar, 40);
            param[1].Value = SpouseName;
            param[2] = new SqlParameter("@SpousePlace", SqlDbType.VarChar, 30);
            param[2].Value = SpousePlace;
            param[3] = new SqlParameter("@SpouseEmpStatus", SqlDbType.Int, 4);
            param[3].Value = SpouseEmpStatus;
            param[4] = new SqlParameter("@SpouseContactNo", SqlDbType.VarChar, 20);
            param[4].Value = SpouseContactNo;
            param[5] = new SqlParameter("@ChildName", SqlDbType.VarChar, 40);
            param[5].Value = ChildName;
            param[6] = new SqlParameter("@ChildPlace", SqlDbType.VarChar, 30);
            param[6].Value = ChildPlace;
            param[7] = new SqlParameter("@ChildEmpStatus", SqlDbType.Int, 4);
            param[7].Value = ChildEmpStatus;
            param[8] = new SqlParameter("@ChildContactNo", SqlDbType.VarChar, 20);
            param[8].Value = ChildContactNo;


            param[9] = new SqlParameter("@ParentName", SqlDbType.VarChar, 40);
            param[9].Value = ParentName;
            param[10] = new SqlParameter("@ParentPlace ", SqlDbType.VarChar, 30);
            param[10].Value = ParentPlace;
            param[11] = new SqlParameter("@ParentEmpStatus", SqlDbType.Int, 4);
            param[11].Value = ParentEmpStatus;
            param[12] = new SqlParameter("@ParentContactNo", SqlDbType.VarChar, 20);
            param[12].Value = ParentContactNo;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffFamily", param);
            return i;


        }

        public DataSet GetStaffType()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStatestafftype");
            return ds;
        }

        public int AddStaffAttendance(int StudID, int month, int year, int DaysPresent, int NoOfWorkingDays)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@month", SqlDbType.Int, 4);
            param[1].Value = month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = year;
            param[3] = new SqlParameter("@DaysPresent", SqlDbType.Int, 4);
            param[3].Value = DaysPresent;
            param[4] = new SqlParameter("@Noofworkingdays", SqlDbType.Int, 4);
            param[4].Value = NoOfWorkingDays;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffAttendance", param);
            return i;


        }

        public int AddStaffPreviousPostings(int StaffId, int NameOfPost, string WorkPlace, DateTime FromDate, DateTime ToDate, string ReasonForTransfer)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@NameOfPost", SqlDbType.Int, 4);
            param[1].Value = NameOfPost;
            param[2] = new SqlParameter("@WorkPlace", SqlDbType.VarChar, 30);
            param[2].Value = WorkPlace;
            param[3] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[3].Value = FromDate;
            param[4] = new SqlParameter("@ToDate", SqlDbType.DateTime, 8);
            param[4].Value = ToDate;
            param[5] = new SqlParameter("@ReasonForTransfer", SqlDbType.VarChar, 200);
            param[5].Value = ReasonForTransfer;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffPreviousPostings", param);
            return i;
        }

        public int AddStaffTrainingCourses(int StaffId, string CourseName, string PlaceHeld, DateTime Fromdate, DateTime toDate)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@CourseName", SqlDbType.VarChar, 30);
            param[1].Value = CourseName;
            param[2] = new SqlParameter("@PlaceHeld", SqlDbType.VarChar, 30);
            param[2].Value = PlaceHeld;
            param[3] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[3].Value = Fromdate;
            param[4] = new SqlParameter("@toDate", SqlDbType.DateTime, 8);
            param[4].Value = toDate;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "AddStaffTrainingsures", param);
            return i;
        }


        
        public DataSet GetSalary()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSalary"); 
               
            return ds;
        }
       


        public int AddStaffMontlysalary(int StaffId, int Month, int year, int Type, int FailedId, float Failedvalue)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[1].Value = Month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = year;
            param[3] = new SqlParameter("@Type", SqlDbType.Int, 4);
            param[3].Value = Type;
            param[4] = new SqlParameter("@FailedId", SqlDbType.Int, 4);
            param[4].Value = FailedId;
            param[5] = new SqlParameter("@Failedvalue", SqlDbType.Float, 8);
            param[5].Value = Failedvalue;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStaffMonthlysalary", param);
            return i;
        }
        public int UpdateStaffTrainingCourses(int StaffId, string CourseName, string PlaceHeld, DateTime Fromdate, DateTime toDate)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@CourseName", SqlDbType.VarChar, 30);
            param[1].Value = CourseName;
            param[2] = new SqlParameter("@PlaceHeld", SqlDbType.VarChar, 30);
            param[2].Value = PlaceHeld;
            param[3] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[3].Value = Fromdate;
            param[4] = new SqlParameter("@toDate", SqlDbType.DateTime, 8);
            param[4].Value = toDate;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStaffTrainingsures", param);
            return i;
        }

        public int DeleteStaffTrainingCourses(int StaffId, string TraingCoursName)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@CourseName", SqlDbType.VarChar, 200);
            param[1].Value = TraingCoursName;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteStaffTrainingsures", param);
            return i;
        }
        public int EditStaffPreviousPostings(int StaffId, int NameOfPost, string WorkPlace, DateTime FromDate, DateTime ToDate, string ReasonForTransfer, int recordID)
        {
            int i = 0;
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@StaffId", SqlDbType.Int, 4);
            param[0].Value = StaffId;
            param[1] = new SqlParameter("@NameOfPost", SqlDbType.Int, 4);
            param[1].Value = NameOfPost;
            param[2] = new SqlParameter("@WorkPlace", SqlDbType.VarChar, 30);
            param[2].Value = WorkPlace;
            param[3] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[3].Value = FromDate;
            param[4] = new SqlParameter("@ToDate", SqlDbType.DateTime, 8);
            param[4].Value = ToDate;
            param[5] = new SqlParameter("@ReasonForTransfer", SqlDbType.VarChar, 200);
            param[5].Value = ReasonForTransfer;
            param[6] = new SqlParameter("@RecordID", SqlDbType.Int, 4);
            param[6].Value = recordID;
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditStaffPreviousPostings", param);
            return i;
        }


    }
}
