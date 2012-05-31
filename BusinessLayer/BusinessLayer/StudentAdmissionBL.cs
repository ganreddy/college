using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DAC;

namespace BusinessLayer
{
    public class StudentAdmissionBL
    {
        DataSet ds;
        DAC.StudentAdmissionDAC StudAdm = new DAC.StudentAdmissionDAC();
        public int AddSelectionApplication1(string RollNo, string FirstName, string MiddleName, string LastName, int Category, string DOB, int Nationality, string Religion, string Mole1, string Mole2, int Gender, int UrbnRural, int DisabledPH, int DisabledVI, int DisabledHI, string FatherName, string MotherName, string GuardianName, string RelationshipWithCandidate, string PersentPostalAddress, string PinCode1, string PermanentAddress, string PinCode2, string TelephoneNo, string EmailId)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddSelectionApplication1(RollNo, FirstName, MiddleName, LastName, Category, DOB, Nationality, Religion, Mole1, Mole2, Gender, UrbnRural, DisabledPH, DisabledVI, DisabledHI, FatherName, MotherName, GuardianName, RelationshipWithCandidate, PersentPostalAddress, PinCode1, PermanentAddress, PinCode2, TelephoneNo, EmailId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }




        public int AddSelectionApplication2(string RollNo, string NameoftheSchoolIII, int CategoryofSchoolIII, int MonthofjoiningIII, int YearofjoingIII, int MonthofpassingIII, int YearofpassingIII, string NameofthevillageorTownIII, string NameoftheBlockIII, int NameoftheDistrictIII, int SchoollLocUrbanOrRuralIII, string NameoftheSchoolIV, int CategoryofSchoolIV, int MonthofjoiningIV, int YearofjoiningIV, int MonthofpassingIV, int YearofpassingIV, string NameofthevillageorTownIV, string NameoftheBlockIV, int NameoftheDistrictIV, int SchoollLocUrbanOrRuralIV, string NameoftheSchoolV, int CategoryofSchoolV, int MonthofjoiningV, int YearofjoiningV, int MonthofpassingV, int YearofpassingV, string NameofthevillageorTownV, string NameoftheBlockV, int NameoftheDistrictV, int SchoollLocUrbanOrRuralV)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddSelectionApplication2(RollNo, NameoftheSchoolIII, CategoryofSchoolIII, MonthofjoiningIII, YearofjoingIII, MonthofpassingIII, YearofpassingIII, NameofthevillageorTownIII, NameoftheBlockIII, NameoftheDistrictIII, SchoollLocUrbanOrRuralIII, NameoftheSchoolIV, CategoryofSchoolIV, MonthofjoiningIV, YearofjoiningIV, MonthofpassingIV, YearofpassingIV, NameofthevillageorTownIV, NameoftheBlockIV, NameoftheDistrictIV, SchoollLocUrbanOrRuralIV, NameoftheSchoolV, CategoryofSchoolV, MonthofjoiningV, YearofjoiningV, MonthofpassingV, YearofpassingV, NameofthevillageorTownV, NameoftheBlockV, NameoftheDistrictV, SchoollLocUrbanOrRuralV);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetStudentDetailsByName(string FullName)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentDetailsByName(FullName);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudentDataTC(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentDataTC(ClassID, BatchID, SectionID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetStudPromotionData(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudPromotionData(ClassID, BatchID, SectionID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetPromotionBatch()
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetPromotionBatch();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetPromotionClasses()
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetPromotionClasses();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetPromotionSection()
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetPromotionSection();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }



        public DataSet GetStudentLeavesCount(DateTime Date)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentLeavesCount(Date);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudentCount()
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentCount();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet CheckDuplicatesStudentAttendance(int StudID, int months, int year)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.CheckDuplicatesStudentAttendance(StudID, months, year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudentAttendanceData(int ClassID, int BatchID, int SectionID, int Month, int Year)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentAttendanceData(ClassID, BatchID, SectionID, Month, Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int UpdateStudentAttendance(int StudID, int NoOfDays)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateStudentAttendance(StudID, NoOfDays);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetEditStudentAttendance(int months, int year)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetEditStudentAttendance(months, year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudentAttendanceByLeaves(int StudID, int Month, int Year)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentAttendanceByLeaves(StudID, Month, Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int CheckStudAdmissionNo(string AdmissionNo)
        {
            int i = 0;
            try
            {
                i = StudAdm.CheckStudAdmissionNo(AdmissionNo);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public int AddStud_Extra(int StudID, int ExtraCurricular, string TcIssuedByJnv, DateTime DateOfIssue)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStud_Extra(StudID, ExtraCurricular, TcIssuedByJnv, DateOfIssue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public int UpdateStud_Extra(int StudID, int ExtraCurricular, string TcIssuedByJnv, DateTime DateOfIssue)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateStud_Extra(StudID, ExtraCurricular, TcIssuedByJnv, DateOfIssue);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public DataSet GetStud_Extra(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStud_Extra(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int UpdateStudent(int StudID, string AdmissionNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int UrbanRural, string Mandal, string Nationality, int State, string Religion, int JoiningType, int PhysicallyChallenged, int Caste, string Games, string PreviousSchoolTCNo, DateTime TCIssuedDate, int AdmittedInClass, int Medium, string RollNoAlloted, int HouseAlloted, string CurrentHouse, int Section, int BatchId, string HallTicket, int Rank, string Region,int BloodGroup,int Year)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateStudent(StudID, AdmissionNo, AdmissionDate, FullName, DOB, MotherTounge, Gender, UrbanRural, Mandal, Nationality, State, Religion, JoiningType, PhysicallyChallenged, Caste, Games, PreviousSchoolTCNo, TCIssuedDate, AdmittedInClass, Medium, RollNoAlloted, HouseAlloted, CurrentHouse, Section, BatchId,HallTicket,Rank,Region,BloodGroup,Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStudEduHistory(int StudID, string PrevSchoolName, DateTime Fromdate, DateTime Todate, int Medium, string Remarks)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateStudEduHistory(StudID, PrevSchoolName, Fromdate, Todate, Medium, Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int UpdateStudIdentification(int StudID, string Mole1, string Mole2, string Email)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateStudIdentification(StudID, Mole1, Mole2, Email);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int UpdateStudentContactInfo(int StudID, string FatherName, string FatherAddress, string FatherPhone, int FatherQual, string FatherOccup, decimal FatherAnnualIncome)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateStudentContactInfo(StudID, FatherName, FatherAddress, FatherPhone, FatherQual, FatherOccup, FatherAnnualIncome);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int AddStudent(string AdmissionNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int UrbanRural, string Mandal, string Nationality, int State, string Religion, int JoiningType, int PhysicallyChallenged, int Caste, string Games, string PreviousSchoolTCNo, DateTime TCIssuedDate, int AdmittedInClass, int Medium, string RollNoAlloted, int HouseAlloted, string CurrentHouse, int Section, int BatchId, string HallTicketNo, int Rank, string Region,int BloodGroup,int Year)
        {
            int i=0;
            try
            {
                i = StudAdm.AddStudent(AdmissionNo, AdmissionDate, FullName, DOB, MotherTounge, Gender, UrbanRural, Mandal, Nationality, State, Religion, JoiningType, PhysicallyChallenged, Caste, Games, PreviousSchoolTCNo, TCIssuedDate, AdmittedInClass, Medium, RollNoAlloted, HouseAlloted, CurrentHouse, Section, BatchId,HallTicketNo,Rank,Region,BloodGroup,Year);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStudAlumniInfo(string AdmissionNo, string AlumniName, DateTime DOB, string FathersName, string PermanentAddress, string CorrespondingAddress, string TelephoneNo, string EmailId, string PresentAddress, string PresentTeleNo, string Qual, DateTime QualDate, int YearOfPassing, string JobStatus, DateTime JobDate, int JobCategory, int JobSubCategory, string Others, bool Inservice, string Designation, string OfficeAddress, string Remarks)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudAlumniInfo(AdmissionNo, AlumniName, DOB, FathersName, PermanentAddress, CorrespondingAddress, TelephoneNo, EmailId, PresentAddress, PresentTeleNo, Qual, QualDate, YearOfPassing, JobStatus, JobDate, JobCategory, JobSubCategory, Others, Inservice, Designation, OfficeAddress, Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetAlumniInfo(int YearOfPassing)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetAlumniInfo(YearOfPassing);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStudEduHistory(int StudID, string PrevSchoolName, DateTime Fromdate, DateTime Todate, int Medium, string Remarks)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudEduHistory(StudID, PrevSchoolName, Fromdate, Todate, Medium, Remarks);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public int AddStudIdentification(int StudID, string Mole1, string Mole2, string Email)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudIdentification(StudID, Mole1, Mole2, Email);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddStudLeaves(int StudID, DateTime Fromdate, DateTime Todate, int HouseMaster,int Class,int Section, string Reason)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudLeaves(StudID,Fromdate,Todate,HouseMaster,Class,Section,Reason);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddStudPhysicalState(int StudID, DateTime Date, int height, int weight, string ChestMeasurement, string eyesight, string bloodGroup, string dietPreferred, string ailments, string allergies, string ChronicDiseases, string MedicalOpinion, int Batch, int Class, int Section)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudPhysicalState(StudID,Date,height,weight,ChestMeasurement,eyesight,bloodGroup,dietPreferred,ailments,allergies,ChronicDiseases,MedicalOpinion,Batch,Class,Section);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddStudentContactInfo(int StudID, string FatherName, string FatherAddress, string FatherPhone, int FatherQual, string FatherOccup, decimal FatherAnnualIncome)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudentContactInfo(StudID,FatherName,FatherAddress,FatherPhone,FatherQual,FatherOccup,FatherAnnualIncome);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStud_ContactInfo(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStud_ContactInfo(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStud_EducHistory(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm. GetStud_EducHistory(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStud_Identification(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStud_Identification(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStud_Leaves(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStud_Leaves(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStud_PhysicalState(int Batch, int Class, int Section, int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStud_PhysicalState(Batch, Class, Section, StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudent(int StudID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudent(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudData(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudData(ClassID, BatchID, SectionID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int DeletePhysicalState(int StudID)
        {
            int i = 0;
            try
            {
                i = StudAdm.DeletePhysicalState(StudID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddStudentAttendance(int StudID, int month, int year, int DaysPresent, int NoofWorkingDays)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudentAttendance(StudID, month, year, DaysPresent,NoofWorkingDays);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditStudentAttendance(int StudID, int month, int year, int DaysPresent)
        {
            int i = 0;
            try
            {
                i = StudAdm.EditStudentAttendance(StudID, month, year, DaysPresent);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetHouseMaster()
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetHouseMaster();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public int AddStudFee(int StudID, string BillNo, int AmountPaid, int AuthorisedPerson, int Mode, string DDCheckNo, string BankName, string Date)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudFee(StudID, BillNo, AmountPaid, AuthorisedPerson, Mode, DDCheckNo, BankName, Date);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public DataSet GetHouse()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = StudAdm.GetHouse();
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetActivities(int Activittype,int Club)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetActivities(Activittype, Club);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }

        public DataSet GetStudentdataHousewise(int HouseId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentdataHousewise(HouseId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;

        }
        public int AddStudentActivities(int StudID, int Activitytype, int Activity, string Date,int Club)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudentActivities(StudID, Activitytype, Activity, Date,Club);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetStudentActivities(string Date, int Activitytype,int Club)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentActivities(Date, Activitytype, Club);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetGroupStudentactivities(string Date, int Activitytype,int Club)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = StudAdm.GetGroupStudentactivities(Date, Activitytype, Club);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int UpdateIndividualStudentActivities(int StudID, int Activity, string Date, string Prize,int Club)
        {
            int i = 0;
            try
            {
                i = StudAdm.UpdateIndividualStudentActivities(StudID, Activity, Date, Prize,Club);

            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int UpdateGroupStudentActivities(string Housename, int Activity, string Date, string Prize,int Club)
        {
            int i = 0;
            try
            {

                i = StudAdm.UpdateGroupStudentActivities(Housename, Activity, Date, Prize,Club);
            }
            catch (Exception Ex)
            {

                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }

        public int AddStudentPromotion(int StudId, int Batch, int Class, int Section)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudentPromotion(StudId, Batch, Class, Section);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public DataSet GetStudentData(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentData(ClassID, BatchID, SectionID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        //public int AddStudentTC(int StudId, int LastStudied, string BoardExam, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, int NoofSchoolDays, int NoofDaysAttended, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = StudAdm.AddStudentTC(StudId, LastStudied, BoardExam, Subjects,Failed, QualifiedforPromotion, FeePaidMonth, FeeConcession, LastAttendDate, NoofSchoolDays, NoofDaysAttended, DateofApply, DateofIssue, Reason, Ncc, Games, Conduct, Remarks, TCNO);
        //    }
        //    catch (Exception Ex)
        //    {
        //        ErrHandler.WriteError(Ex.Message);
        //    }
        //    return i;
        //}
        public DataSet GetStdPersonaldetail(int StudId)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStdPersonaldetail(StudId);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        //public int EditStudentTC(int StudId, int LastStudied, string BoardExam, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, int NoofSchoolDays, int NoofDaysAttended, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
        //{
        //    int i = 0;
        //    try
        //    {
        //        i = StudAdm.EditStudentTC(StudId, LastStudied, BoardExam, Subjects, Failed, QualifiedforPromotion, FeePaidMonth, FeeConcession, LastAttendDate, NoofSchoolDays, NoofDaysAttended, DateofApply, DateofIssue, Reason, Ncc, Games, Conduct, Remarks, TCNO);
        //    }
        //    catch (Exception Ex)
        //    {
        //        ErrHandler.WriteError(Ex.Message);
        //    }
        //    return i;

        //}

        public DataSet GetStudentData1(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentData1(ClassID, BatchID, SectionID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public DataSet GetStudentDetailsByAdmissionNo(string AdmissionNo)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetStudentDetailsByAdmissionNo(AdmissionNo); 
            }
            catch (Exception)
            {
                
                throw;
            }
            
            return ds;

        }
        public DataSet GetSelectionApplicationUsingGrid(string RollNo)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetSelectionApplicationUsingGrid(RollNo);
            }
            catch (Exception Ex)
            {
                //ErrorLogFile.WriteError(Ex.Message, Ex.StackTrace);
            }
            return ds;
        }
        public DataSet GetSelectionApplicationByName(string FirstName)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetSelectionApplicationByName(FirstName);
            }
            catch (Exception Ex)
            {
                //ErrorLogFile.WriteError(Ex.Message, Ex.StackTrace);
            }
            return ds;
        }

        public int EditStudentTC(int StudId, int LastStudied, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
        {
            int i = 0;
            try
            {
                i = StudAdm.EditStudentTC(StudId, LastStudied,  Subjects, Failed, QualifiedforPromotion, FeePaidMonth, FeeConcession, LastAttendDate,   DateofApply, DateofIssue, Reason, Ncc, Games, Conduct, Remarks, TCNO);
            }
            catch (Exception Ex)
            {
                //ErrHandler.WriteError(Ex.Message);
            }
            return i;

        }
        public int AddStudentTC(int StudId, int LastStudied, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudentTC(StudId, LastStudied, Subjects, Failed, QualifiedforPromotion, FeePaidMonth, FeeConcession, LastAttendDate, DateofApply, DateofIssue, Reason, Ncc, Games, Conduct, Remarks, TCNO);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }


        public int AddStudFee1(int Batch, int Class, int Section, int StudID, int FeeType, int HeaderID, decimal Amount, string PaymentDate, string FeeSlip, decimal Fine, decimal totalamount)
        {
            int i = 0;
            try
            {
                i = StudAdm.AddStudFee1(Batch, Class, Section, StudID, FeeType, HeaderID, Amount, PaymentDate, FeeSlip, Fine, totalamount);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }

        public DataSet GetFeeDetails(int Category, int Class, int FeeType, int Type)
        {
            ds = new DataSet();
            try
            {
                ds = StudAdm.GetFeeDetails(Category, Class, FeeType, Type);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetStudentFee(int StudnetId, int FeeType)
        {
            DataSet ds;
            ds = StudAdm.GetStudentFee(StudnetId, FeeType);
            return ds;
        }
    }
}
