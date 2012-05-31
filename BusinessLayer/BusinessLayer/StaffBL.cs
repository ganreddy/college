using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;


namespace BusinessLayer
{
    public class StaffBL
    {
        DataSet ds;
        StaffDAC objStaff = new StaffDAC();
        public DataSet GetDuplicateStaffSalaryByHeads(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetDuplicateStaffSalaryByHeads(StaffID);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return ds;
        }
        public int UpdateStaffSalaryByHeads(int StaffID, int HeadID, decimal Amount)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffSalaryByHeads(StaffID, HeadID, Amount);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return i;
        }

        public int DeleteStaffLeaves(int RecordID)
        {
            int i = 0;
            try
            {
                i = objStaff.DeleteStaffLeaves(RecordID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaffLeaves(int RecordID, int LeaveID, DateTime From, DateTime To, string Purpose, int Authority)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffLeaves(RecordID, LeaveID, From, To, Purpose, Authority);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStaffLeaves(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffLeaves(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddStaffLeaves(int StaffID, int LeaveID, DateTime From, DateTime To, string Purpose, int Authority)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffLeaves(StaffID, LeaveID, From, To, Purpose, Authority);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetLeavesbyStaffType(int StaffType)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetLeavesbyStaffType(StaffType);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetLeaves(int LeaveTypeID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetLeaves(LeaveTypeID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStaffAvailableLeaves(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffAvailableLeaves(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddLeaves(string LeaveType, int StaffType, int NoofDays, int Cummulative)
        {
            int i = 0;
            try
            {
                i = objStaff.AddLeaves(LeaveType, StaffType, NoofDays, Cummulative);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int EditLeaves(int LeaveTypeID, string LeaveType, int StaffType, int NoofDays, int Cummulative)
        {

            int i = 0;
            try
            {
                i = objStaff.EditLeaves(LeaveTypeID, LeaveType, StaffType, NoofDays, Cummulative);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int DeleteLeaves(int LeaveTypeID)
        {
            int i = 0;
            try
            {
                i = objStaff.DeleteLeaves(LeaveTypeID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetTeachingStaff(int StaffID)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objStaff.GetTeachingStaff(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }

            return ds;
        }
        public DataSet GetStaffPayslipByLeaves(int StaffID, int Month, int Year)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffPayslipByLeaves(StaffID, Month, Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int TotalStaffSalPaySlip(int StaffID, int Month, Int64 Year, int HeadID, int Type, decimal Amount, int NoOfWorkingDays)
        {
            int i = 0;
            try
            {
                i = objStaff.TotalStaffSalPaySlip(StaffID, Month, Year, HeadID, Type, Amount, NoOfWorkingDays);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStaffSalaryPaySlip(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffSalaryPaySlip(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet AddTotalStaffSalPaySlipDuplicates(int StaffID, int Months, int Years)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.AddTotalStaffSalPaySlipDuplicates(StaffID, Months, Years);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetStaffSal()
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffSal();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStaffSalHeadByHeadID(int HeadID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffSalHeadByHeadID(HeadID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStaffHeader()
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffHeader();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddStaffSalary(string HeadName, int Type, int CalculationType, int Header, decimal Percentage, int Status)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffSalary(HeadName, Type, CalculationType, Header, Percentage, Status);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffSalaryByHead(int StaffID, int HeadID, decimal Amount)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffSalaryByHead(StaffID, HeadID, Amount);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaffSalary(int HeadID, string HeadName, int Type, int CalculationType, int Header, double Percentage)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffSalary(HeadID, HeadName, Type, CalculationType, Header, Percentage);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteStaffSalary(string Ids)
        {
            int i = 0;
            try
            {
                i = objStaff.DeleteStaffSalary(Ids);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetDaysPeriods()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objStaff.GetDaysPeriods();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddTimetable(int TeacherId, int DayId, int PeriodId, int ClassId, int SectionId, int SubjectId, int YearId)
        {
            int i = 0;
            try
            {
                i = objStaff.AddTimetable(TeacherId, DayId, PeriodId, ClassId, SectionId, SubjectId, YearId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetClassTimetable(int ClassId, int SectionId, int YearId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = objStaff.GetClassTimetable(ClassId, SectionId, YearId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }

            return ds;
        }
        public int UpdateTimetable(int TeacherId, int DayId, int PeriodId, int ClassId, int SectionId, int YearId)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateTimetable(TeacherId, DayId, PeriodId, ClassId, SectionId, YearId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetTimetableClasswise(int ClassId, int SectionId, int YearId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = objStaff.GetTimetableClasswise(ClassId, SectionId, YearId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;

        }

        public DataSet GetStaffwiseTimetable(int YearId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = objStaff.GetStaffwiseTimetable(YearId);

            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;

        }
        public DataSet GetDaysPeriods(int Classid, int Sectionid, int Yearid)
        {
            DataSet ds=new DataSet();
            try
            {
                ds = objStaff.GetDaysPeriods(Classid, Sectionid, Yearid);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet DeleteStaffDetails(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.DeleteStaffDetails(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;

        }
        public int UpdateStaffAttendance(int StaffID, int NoOfDays)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffAttendance(StaffID, NoOfDays);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetEditStaffAttendance(int months, int year)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetEditStaffAttendance(months, year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet CheckDuplicatesStaffAttendance(int StaffID, int months, int year)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.CheckDuplicatesStaffAttendance(StaffID,months, year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int UpdateStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, int DateOfRetirement, DateTime RetirementDate)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffAccount(StaffID, Nominee, TerminalBenifits, GPFAccountNo, GslisRecordNO, CertificateSubmit, YearsOfExperience, DateOfRetirement, RetirementDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, int DateOfRetirement, DateTime RetirementDate)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffAccount(StaffID, Nominee, TerminalBenifits, GPFAccountNo, GslisRecordNO, CertificateSubmit, YearsOfExperience, DateOfRetirement, RetirementDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetStaffAttendanceByLeaves(int StaffID, int Month, int Year)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffAttendanceByLeaves(StaffID, Month, Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetStaffPreviousPostings(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffPreviousPostings(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStaff_TrainingCourses(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaff_TrainingCourses(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStaffIdentification(int StaffID, string Mole1, string Mole2)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffIdentification(StaffID, Mole1, Mole2);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStaff_Identification(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaff_Identification(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetStaffAccount(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffAccount(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int UpdateStaff(int StaffID, string StaffNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int Nationality, int StaffType, string Religion, string HomeDistrict, int PhysicallyChallenged, int Caste, int MartialStatus, int AppointmentMode, string PostName, int Cader, int PostType, int PostSanction, decimal BasicSalary, DateTime DateOfJoining, DateTime CurrJD, string PermanentAddress, string PresentAddress, string Telephone, string Mobile)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaff(StaffID, StaffNo, AdmissionDate, FullName, DOB, MotherTounge, Gender, Nationality, StaffType, Religion, HomeDistrict, PhysicallyChallenged, Caste, MartialStatus, AppointmentMode, PostName, Cader, PostType, PostSanction, BasicSalary, DateOfJoining, CurrJD, PermanentAddress, PresentAddress, Telephone, Mobile);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaffQualification(int StaffID, int Degree, int Subject, string University, int Yearofpassing, int Percentage)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffQualification(StaffID, Degree, Subject, University, Yearofpassing, Percentage);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaff_Family(int staffid, string SpouseName, string SpousePlace, string SpouseContactNo, int SpouseEmpStatus, string ChildName, string ChildPlace, string ChildContactNo, int ChildEmpStatus, string ParentName, string ParentPlace, string ParentContactNo, int ParentEmpStatus)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaff_Family(staffid, SpouseName, SpousePlace, SpouseContactNo, SpouseEmpStatus, ChildName, ChildPlace, ChildContactNo, ChildEmpStatus, ParentName, ParentPlace, ParentContactNo, ParentEmpStatus);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaffIdentification(int StaffID, string Mole1, string Mole2)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffIdentification(StaffID, Mole1, Mole2);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, string NativePlace, int DateOfRetirement, DateTime RetirementDate)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffAccount(StaffID, Nominee, TerminalBenifits, GPFAccountNo, GslisRecordNO, CertificateSubmit, YearsOfExperience, NativePlace, DateOfRetirement, RetirementDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaffAccount(int StaffID, string Nominee, int TerminalBenifits, string GPFAccountNo, string GslisRecordNO, int CertificateSubmit, int YearsOfExperience, string NativePlace, int DateOfRetirement, DateTime RetirementDate)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffAccount(StaffID, Nominee, TerminalBenifits, GPFAccountNo, GslisRecordNO, CertificateSubmit, YearsOfExperience, NativePlace, DateOfRetirement, RetirementDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

         public DataSet GetStaffDetailsData(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffDetailsData(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }


        public DataSet GetLoanType()
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetLoanType();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStaffGrandsalary(int StaffId, int Month, int year, float AddTota, float DelTotal, float GrandTotal)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffGrandsalary(StaffId, Month, year, AddTota, DelTotal, GrandTotal);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffApplyForLoan(int StaffId, int LoanId, DateTime Date, decimal AmountSanctioned, int NumberOfInstallments, decimal FirstInstallmentAmount, decimal SecondInstallmentAmount, decimal RemainingAmountEMI, DateTime AmountRecoveryStartedFrom, int AuthorisedBy, int Status, string Remarks, DateTime AmountPaidDate)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffApplyForLoan(StaffId, LoanId, Date, AmountSanctioned, NumberOfInstallments, FirstInstallmentAmount, SecondInstallmentAmount, RemainingAmountEMI, AmountRecoveryStartedFrom, AuthorisedBy, Status, Remarks, AmountPaidDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }




        public int AddStaff(string StaffNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int Nationality, int StaffType, string Religion, string HomeDistrict, int PhysicallyChallenged, int Caste, int MartialStatus, int AppointmentMode, string PostName,int Cader, int PostType, int PostSanction, decimal BasicSalary, DateTime DateOfJoining, DateTime CurrJD, string PermanentAddress, string PresentAddress, string Telephone, string Mobile)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaff(StaffNo,AdmissionDate,FullName,DOB,MotherTounge,Gender,Nationality,StaffType,Religion,HomeDistrict,PhysicallyChallenged,Caste,MartialStatus,AppointmentMode,PostName,Cader,PostType,PostSanction,BasicSalary,DateOfJoining,CurrJD,PermanentAddress,PresentAddress,Telephone,Mobile);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffQualification(int StaffID, int Degree, int Subject, string University, int Yearofpassing, int Percentage)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffQualification(StaffID,Degree,Subject,University,Yearofpassing,Percentage);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
         public int AddStaffLeaves(int StaffID, int LeaveID, DateTime From,DateTime To,string Remarks)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffLeaves(StaffID,LeaveID,From,To,Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStaffDetails(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.spGetStaffDetails(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        
        }
        public DataSet GetStaff_Qualifiaction(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaff_Qualifiaction(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;

        }
        public DataSet GetStaff_Family(int StaffID)
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaff_Family(StaffID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStaff_Family(int staffid, string SpouseName, string SpousePlace, string SpouseContactNo, int SpouseEmpStatus, string ChildName, string ChildPlace, string ChildContactNo, int ChildEmpStatus, string ParentName, string ParentPlace, string ParentContactNo, int ParentEmpStatus)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaff_Family(staffid, SpouseName, SpousePlace, SpouseContactNo, SpouseEmpStatus, ChildName, ChildPlace, ChildContactNo, ChildEmpStatus, ParentName, ParentPlace, ParentContactNo, ParentEmpStatus);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetStaffType()
        {
            ds = new DataSet();
            try
            {
                ds = objStaff.GetStaffType();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStaffAttendance(int StudID, int month, int year, int DaysPresent, int NoOfWorkingDays)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffAttendance(StudID, month, year, DaysPresent,NoOfWorkingDays);

            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffTrainingCourses(int StaffId, string CourseName, string PlaceHeld, DateTime Fromdate, DateTime toDate)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffTrainingCourses(StaffId, CourseName, PlaceHeld, Fromdate, toDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStaffPreviousPostings(int StaffId, int NameOfPost, string WorkPlace, DateTime FromDate, DateTime ToDate, string ReasonForTransfer)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffPreviousPostings(StaffId, NameOfPost, WorkPlace, FromDate, ToDate, ReasonForTransfer);
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
                ds = objStaff.GetSalary();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int AddStaffMontlysalary(int StaffId, int Month, int year, int Type, int FailedId, float Failedvalue)
        {
            int i = 0;
            try
            {
                i = objStaff.AddStaffMontlysalary(StaffId, Month, year, Type, FailedId, Failedvalue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStaffTrainingCourses(int StaffId, string CourseName, string PlaceHeld, DateTime Fromdate, DateTime toDate)
        {
            int i = 0;
            try
            {
                i = objStaff.UpdateStaffTrainingCourses(StaffId, CourseName, PlaceHeld, Fromdate, toDate);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int DeleteStaffTrainingCourses(int StaffId, string TraingCoursName)
        {
            int i = 0;
            try
            {
                i = objStaff.DeleteStaffTrainingCourses(StaffId, TraingCoursName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditStaffPreviousPostings(int StaffId, int NameOfPost, string WorkPlace, DateTime FromDate, DateTime ToDate, string ReasonForTransfer, int recordID)
        {
            int i = 0;
            try
            {
                i = objStaff.EditStaffPreviousPostings(StaffId, NameOfPost, WorkPlace, FromDate, ToDate, ReasonForTransfer, recordID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
    }
}
