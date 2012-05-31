using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace DAC
{
    public class StudentAdmissionDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public int AddSelectionApplication1(string RollNo, string FirstName, string MiddleName, string LastName, int Category, string DOB, int Nationality, string Religion, string Mole1, string Mole2, int Gender, int UrbnRural, int DisabledPH, int DisabledVI, int DisabledHI, string FatherName, string MotherName, string GuardianName, string RelationshipWithCandidate, string PersentPostalAddress, string PinCode1, string PermanentAddress, string PinCode2, string TelephoneNo, string EmailId)
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
            param[12] = new SqlParameter("@DisabledPH", SqlDbType.Int, 4);
            param[12].Value = DisabledPH;
            param[13] = new SqlParameter("@DisabledVI", SqlDbType.Int, 4);
            param[13].Value = DisabledVI;
            param[14] = new SqlParameter("@DisabledHI", SqlDbType.Int, 4);
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
            param[22] = new SqlParameter("@PinCode2", SqlDbType.VarChar, 20);
            param[22].Value = PinCode2;
            param[23] = new SqlParameter("@TelephoneNo", SqlDbType.VarChar, 20);
            param[23].Value = TelephoneNo;
            param[24] = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
            param[24].Value = EmailId;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddSelectionApplication1", param);
            return i;
            //int i = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spAddStudentAdmission1", param);
            //return i;
        }



        public int AddSelectionApplication2(string RollNo, string NameoftheSchoolIII, int CategoryofSchoolIII, int MonthofjoiningIII, int YearofjoingIII, int MonthofpassingIII, int YearofpassingIII, string NameofthevillageorTownIII, string NameoftheBlockIII, int NameoftheDistrictIII, int SchoollLocUrbanOrRuralIII, string NameoftheSchoolIV, int CategoryofSchoolIV, int MonthofjoiningIV, int YearofjoiningIV, int MonthofpassingIV, int YearofpassingIV, string NameofthevillageorTownIV, string NameoftheBlockIV, int NameoftheDistrictIV, int SchoollLocUrbanOrRuralIV, string NameoftheSchoolV, int CategoryofSchoolV, int MonthofjoiningV, int YearofjoiningV, int MonthofpassingV, int YearofpassingV, string NameofthevillageorTownV, string NameoftheBlockV, int NameoftheDistrictV, int SchoollLocUrbanOrRuralV)
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

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddSelectionApplication2", param);

            //int i = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spAddStudentAdmission1", param);
            return i;
        }
        

        public DataSet GetStudentDetailsByName(string FullName)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@FullName", SqlDbType.VarChar, 20);
            param[0].Value = FullName;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentDetailsByName", param);
            return ds;
        }
        public DataSet GetStudentDataTC(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
            param[0].Value = ClassID;
            param[1] = new SqlParameter("@BatchID", SqlDbType.Int, 8);
            param[1].Value = BatchID;
            param[2] = new SqlParameter("@SectionID", SqlDbType.Int, 8);
            param[2].Value = SectionID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStuDataTC", param);
            return ds;
        }

        public DataSet GetStudPromotionData(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
            param[0].Value = ClassID;
            param[1] = new SqlParameter("@BatchID", SqlDbType.Int, 8);
            param[1].Value = BatchID;
            param[2] = new SqlParameter("@SectionID", SqlDbType.Int, 8);
            param[2].Value = SectionID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStuPromotionData", param);
            return ds;
        }
        public DataSet GetStudentData(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
            param[0].Value = ClassID;
            param[1] = new SqlParameter("@BatchID", SqlDbType.Int, 8);
            param[1].Value = BatchID;
            param[2] = new SqlParameter("@SectionID", SqlDbType.Int, 8);
            param[2].Value = SectionID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentpromotion", param);
            return ds;
        }
        public int AddStudentPromotion(int StudId, int Batch, int Class, int Section)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudId", SqlDbType.Int, 4);
            param[0].Value = StudId;
            param[1] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[1].Value = Batch;
            param[2] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[2].Value = Class;
            param[3] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[3].Value = Section;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudentPromotion", param);
            return i;


        }
        public DataSet GetPromotionBatch()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPromotionBatch");
            return ds;
        }

        public DataSet GetPromotionClasses()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPromotionClass");
            return ds;
        }
        public DataSet GetPromotionSection()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPromotionSection");
            return ds;
        }

        public DataSet GetStud_PhysicalState(int Batch,int Class,int Section,int StudID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[0].Value = Batch;
            param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[1].Value = Class;
            param[2] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[2].Value = Section;
            param[3] = new SqlParameter("@StudId", SqlDbType.Int, 4);
            param[3].Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_PhysicalState", param);
            return ds;
        }




        public DataSet GetStudentCount()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentCount");
            return ds;
        }
        public DataSet GetStudentLeavesCount(DateTime Date)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[0].Value = Date;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentLeavesCount",param);
            return ds;
        }

        public DataSet CheckDuplicatesStudentAttendance(int StudID, int months, int year)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Months", SqlDbType.Int, 4);
            param[1].Value = months;
            param[2] = new SqlParameter("@Years", SqlDbType.BigInt, 4);
            param[2].Value = year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCheckStudentAttendanceDuplicates", param);
            return ds;
        }
        public DataSet GetStudentAttendanceData(int ClassID, int BatchID, int SectionID,int Month,int Year)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
            param[0].Value = ClassID;
            param[1] = new SqlParameter("@BatchID", SqlDbType.Int, 8);
            param[1].Value = BatchID;
            param[2] = new SqlParameter("@SectionID", SqlDbType.Int, 8);
            param[2].Value = SectionID;
            param[3] = new SqlParameter("@month", SqlDbType.Int, 8);
            param[3].Value = Month;
            param[4] = new SqlParameter("@Year", SqlDbType.Int, 8);
            param[4].Value = Year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentAttendanceData", param);
            return ds;
        }

        public int UpdateStudentAttendance(int StudID, int NoOfDays)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@NoOfDaysPresent", SqlDbType.Int, 4);
            param[1].Value = NoOfDays;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStudentAttendance", param);
            return i;
        }
        public DataSet GetEditStudentAttendance(int months, int year)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[0].Value = months;
            param[1] = new SqlParameter("@Year", SqlDbType.BigInt, 4);
            param[1].Value = year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentEditAttendance", param);
            return ds;
        }
        public DataSet GetStudentAttendanceByLeaves(int StudID, int Month, int Year)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Month", SqlDbType.Int, 4);
            param[1].Value = Month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = Year;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentAttendanceByStudentLeaves", param);
            return ds;
        }

        public int CheckStudAdmissionNo(string AdmissionNo)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar, 30);
            param[0].Value = AdmissionNo;
            param[1] = new SqlParameter("@count", SqlDbType.Int, 4);
            param[1].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCheckStudAdmissionNo", param);
            return Convert.ToInt32(param[1].Value);
        }
        public int AddStud_Extra(int StudID, int ExtraCurricular, string TcIssuedByJnv, DateTime DateOfIssue)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@ExtraCurricular", SqlDbType.Int, 250);
            param[1].Value = ExtraCurricular;
            param[2] = new SqlParameter("@TcIssuedByJnv", SqlDbType.VarChar, 50);
            param[2].Value = TcIssuedByJnv;
            param[3] = new SqlParameter("@DateOfIssue", SqlDbType.DateTime, 8);
            param[3].Value = DateOfIssue;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStud_Extra", param);
            return i;
        }
        public int UpdateStud_Extra(int StudID, int ExtraCurricular, string TcIssuedByJnv, DateTime DateOfIssue)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@ExtraCurricular", SqlDbType.Int, 250);
            param[1].Value = ExtraCurricular;
            param[2] = new SqlParameter("@TcIssuedByJnv", SqlDbType.VarChar, 50);
            param[2].Value = TcIssuedByJnv;
            param[3] = new SqlParameter("@DateOfIssue", SqlDbType.DateTime, 8);
            param[3].Value = DateOfIssue;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStud_Extra", param);
            return i;
        }
        public DataSet GetStud_Extra(int StudID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param.Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_Extra", param);
            return ds;
        }
        public int UpdateStudent(int StudID, string AdmissionNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int UrbanRural, string Mandal, string Nationality, int State, string Religion, int JoiningType, int PhysicallyChallenged, int Caste, string Games, string PreviousSchoolTCNo, DateTime TCIssuedDate, int AdmittedInClass, int Medium, string RollNoAlloted, int HouseAlloted, string CurrentHouse, int Section, int BatchId, string HallTicket,int Rank,string Region,int BloodGroup,int Year)
        {

            SqlParameter[] param = new SqlParameter[32];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar, 20);
            param[1].Value = AdmissionNo;
            param[2] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime, 8);
            param[2].Value = AdmissionDate;
            param[3] = new SqlParameter("@FullName", SqlDbType.VarChar, 75);
            param[3].Value = FullName;
            param[4] = new SqlParameter("@MotherTounge", SqlDbType.Int, 4);
            param[4].Value = MotherTounge;
            param[5] = new SqlParameter("@Gender", SqlDbType.Int, 4);
            param[5].Value = Gender;
            param[6] = new SqlParameter("@UrbanRural", SqlDbType.Int, 4);
            param[6].Value = UrbanRural;
            param[7] = new SqlParameter("@Mandal", SqlDbType.VarChar, 40);
            param[7].Value = Mandal;
            param[8] = new SqlParameter("@Nationality", SqlDbType.VarChar, 40);
            param[8].Value = Nationality;
            param[9] = new SqlParameter("@State", SqlDbType.Int, 4);
            param[9].Value = State;
            param[10] = new SqlParameter("@Religion", SqlDbType.VarChar, 30);
            param[10].Value = Religion;
            param[11] = new SqlParameter("@JoiningType", SqlDbType.Int, 4);
            param[11].Value = JoiningType;
            param[12] = new SqlParameter("@PhysicallyChallenged", SqlDbType.Int, 4);
            param[12].Value = PhysicallyChallenged;
            param[13] = new SqlParameter("@Caste", SqlDbType.Int, 4);
            param[13].Value = Caste;
            param[14] = new SqlParameter("@Games", SqlDbType.VarChar, 50);
            param[14].Value = Games;
            param[15] = new SqlParameter("@PreviousSchoolTCNo", SqlDbType.VarChar, 30);
            param[15].Value = PreviousSchoolTCNo;
            param[16] = new SqlParameter("@TCIssuedDate", SqlDbType.DateTime, 8);
            param[16].Value = TCIssuedDate;
            param[17] = new SqlParameter("@AdmittedInClass", SqlDbType.Int, 4);
            param[17].Value = AdmittedInClass;
            param[18] = new SqlParameter("@Medium", SqlDbType.Int, 4);
            param[18].Value = Medium;
            param[19] = new SqlParameter("@RollNoAlloted", SqlDbType.VarChar, 20);
            param[19].Value = RollNoAlloted;
            param[20] = new SqlParameter("@HouseAlloted", SqlDbType.Int, 4);
            param[20].Value = HouseAlloted;
            param[21] = new SqlParameter("@CurrentHouse", SqlDbType.VarChar, 40);
            param[21].Value = CurrentHouse;
            param[22] = new SqlParameter("@DOB", SqlDbType.DateTime, 8);
            param[22].Value = DOB;
            param[23] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[23].Value = Section;
            param[24] = new SqlParameter("@BatchId", SqlDbType.Int, 4);
            param[24].Value = BatchId;
            param[25] = new SqlParameter("@HallTicket", SqlDbType.VarChar, 20);
            param[25].Value = HallTicket;
            param[26] = new SqlParameter("@Rank", SqlDbType.Int, 4);
            param[26].Value = Rank;
            param[27] = new SqlParameter("@Region", SqlDbType.VarChar, 30);
            param[27].Value = Region;
            param[28] = new SqlParameter("@BloodGroup", SqlDbType.Int, 4);
            param[28].Value = BloodGroup;
            param[29] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[29].Value = Year;
            //param[26] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            //param[26].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStudent", param);
            //return Convert.ToInt32(param[26].Value.ToString());
            return i;
        }
        public int UpdateStudEduHistory(int StudID, string PrevSchoolName, DateTime Fromdate, DateTime Todate, int Medium, string Remarks)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@PrevSchoolName", SqlDbType.VarChar, 50);
            param[1].Value = PrevSchoolName;
            param[2] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[2].Value = Fromdate;
            param[3] = new SqlParameter("@Todate", SqlDbType.DateTime, 8);
            param[3].Value = Todate;
            param[4] = new SqlParameter("@Medium", SqlDbType.Int, 4);
            param[4].Value = Medium;
            param[5] = new SqlParameter("@Remarks", SqlDbType.VarChar, 50);
            param[5].Value = Remarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStudEduHistory", param);
            return i;
        }
        public int UpdateStudIdentification(int StudID, string Mole1, string Mole2, string Email)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Mole1", SqlDbType.VarChar, 250);
            param[1].Value = Mole1;
            param[2] = new SqlParameter("@Mole2", SqlDbType.VarChar, 250);
            param[2].Value = Mole2;
            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            param[3].Value = Email;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStudIdentification", param);
            return i;
        }

        public int UpdateStudentContactInfo(int StudID, string FatherName, string FatherAddress, string FatherPhone, int FatherQual, string FatherOccup, decimal FatherAnnualIncome)
        {

            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@FatherName", SqlDbType.VarChar, 50);
            param[1].Value = FatherName;
            param[2] = new SqlParameter("@FatherAddress", SqlDbType.VarChar, 100);
            param[2].Value = FatherAddress;
            param[3] = new SqlParameter("@FatherPhone", SqlDbType.VarChar, 20);
            param[3].Value = FatherPhone;
            param[4] = new SqlParameter("@FatherQual", SqlDbType.Int, 4);
            param[4].Value = FatherQual;
            param[5] = new SqlParameter("@FatherOccup", SqlDbType.VarChar, 40);
            param[5].Value = FatherOccup;
            param[6] = new SqlParameter("@FatherAnnualIncome", SqlDbType.Decimal, 8);
            param[6].Value = FatherAnnualIncome;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateStudContactInfo", param);
            return i;
        }

        public int AddStudent(string AdmissionNo, DateTime AdmissionDate, string FullName, DateTime DOB, int MotherTounge, int Gender, int UrbanRural, string Mandal, string Nationality, int State, string Religion, int JoiningType, int PhysicallyChallenged, int Caste, string Games, string PreviousSchoolTCNo, DateTime TCIssuedDate, int AdmittedInClass, int Medium, string RollNoAlloted, int HouseAlloted, string CurrentHouse, int Section, int BatchId, string HallTicketNo, int Rank, string Region,int BloodGroup,int Year)
        {

            SqlParameter[] param = new SqlParameter[32];
            param[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar, 20);
            param[0].Value = AdmissionNo;
            param[1] = new SqlParameter("@AdmissionDate", SqlDbType.DateTime, 8);
            param[1].Value = AdmissionDate;
            param[2] = new SqlParameter("@FullName", SqlDbType.VarChar, 75);
            param[2].Value = FullName;
            param[3] = new SqlParameter("@MotherTounge", SqlDbType.Int, 4);
            param[3].Value = MotherTounge;
            param[4] = new SqlParameter("@Gender", SqlDbType.Int, 4);
            param[4].Value = Gender;
            param[5] = new SqlParameter("@UrbanRural", SqlDbType.Int, 4);
            param[5].Value = UrbanRural;
            param[6] = new SqlParameter("@Mandal", SqlDbType.VarChar, 40);
            param[6].Value = Mandal;
            param[7] = new SqlParameter("@Nationality", SqlDbType.VarChar,40);
            param[7].Value = Nationality;
            param[8] = new SqlParameter("@State", SqlDbType.Int,4);
            param[8].Value = State;
            param[9] = new SqlParameter("@Religion", SqlDbType.VarChar,30);
            param[9].Value = Religion;
            param[10] = new SqlParameter("@JoiningType", SqlDbType.Int, 4);
            param[10].Value = JoiningType;
            param[11] = new SqlParameter("@PhysicallyChallenged", SqlDbType.Int, 4);
            param[11].Value = PhysicallyChallenged;
            param[12] = new SqlParameter("@Caste", SqlDbType.Int, 4);
            param[12].Value = Caste;
            param[13] = new SqlParameter("@Games", SqlDbType.VarChar,50);
            param[13].Value = Games;
            param[14] = new SqlParameter("@PreviousSchoolTCNo", SqlDbType.VarChar,30);
            param[14].Value = PreviousSchoolTCNo;
            param[15] = new SqlParameter("@TCIssuedDate", SqlDbType.DateTime, 8);
            param[15].Value = TCIssuedDate;
            param[16] = new SqlParameter("@AdmittedInClass", SqlDbType.Int,4);
            param[16].Value = AdmittedInClass;
            param[17] = new SqlParameter("@Medium", SqlDbType.Int,4);
            param[17].Value = Medium;
            param[18] = new SqlParameter("@RollNoAlloted", SqlDbType.VarChar, 20);
            param[18].Value = RollNoAlloted;
            param[19] = new SqlParameter("@HouseAlloted", SqlDbType.Int, 4);
            param[19].Value = HouseAlloted;
            param[20] = new SqlParameter("@CurrentHouse", SqlDbType.VarChar, 40);
            param[20].Value = CurrentHouse;
            param[21] = new SqlParameter("@DOB", SqlDbType.DateTime, 8);
            param[21].Value = DOB;
            param[22] = new SqlParameter("@Section", SqlDbType.Int,4);
            param[22].Value = Section;
            param[23] = new SqlParameter("@BatchId", SqlDbType.Int,4);
            param[23].Value = BatchId;
            param[24] = new SqlParameter("@HallTicket", SqlDbType.VarChar, 20);
            param[24].Value = HallTicketNo;
            param[25] = new SqlParameter("@Rank", SqlDbType.Int, 4);
            param[25].Value = Rank;
            param[26] = new SqlParameter("@Region", SqlDbType.VarChar, 30);
            param[26].Value = Region;
            param[27] = new SqlParameter("@BloodGroup", SqlDbType.Int, 4);
            param[27].Value = BloodGroup;
            param[28] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[28].Value = Year;
            param[29] = new SqlParameter("@StudID", SqlDbType.Int,4);
            param[29].Direction = ParameterDirection.Output;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudent", param);
            return Convert.ToInt32(param[29].Value.ToString());


        }
        public DataSet GetAlumniInfo(int YearOfPassing)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@YearOfPassing", SqlDbType.Int, 8);
            param[0].Value = YearOfPassing;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_AlumniInfo", param);
            return ds;
        }
        public int AddStudAlumniInfo(string AdmissionNo, string AlumniName, DateTime DOB, string FathersName, string PermanentAddress, string CorrespondingAddress, string TelephoneNo, string EmailId, string PresentAddress, string PresentTeleNo, string Qual, DateTime QualDate, int YearOfPassing, string JobStatus, DateTime JobDate, int JobCategory, int JobSubCategory, string Others, bool Inservice, string Designation, string OfficeAddress, string Remarks)
        {
            SqlParameter[] param = new SqlParameter[22];
            param[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar, 50);
            param[0].Value = AdmissionNo;
            param[1] = new SqlParameter("@AlumniName", SqlDbType.VarChar, 50);
            param[1].Value = AlumniName;
            param[2] = new SqlParameter("@DOB", SqlDbType.DateTime, 50);
            param[2].Value = DOB;
            param[3] = new SqlParameter("@FathersName", SqlDbType.VarChar, 50);
            param[3].Value = FathersName;
            param[4] = new SqlParameter("@PermanentAddress", SqlDbType.VarChar, 400);
            param[4].Value = PermanentAddress;
            param[5] = new SqlParameter("@CorrespondingAddress", SqlDbType.VarChar, 400);
            param[5].Value = CorrespondingAddress;
            param[6] = new SqlParameter("@TelephoneNo", SqlDbType.VarChar, 30);
            param[6].Value = TelephoneNo;
            param[7] = new SqlParameter("@EmailId", SqlDbType.VarChar, 50);
            param[7].Value = EmailId;
            param[8] = new SqlParameter("@PresentAddress", SqlDbType.VarChar, 400);
            param[8].Value = PresentAddress;
            param[9] = new SqlParameter("@PresentTeleNo", SqlDbType.VarChar, 30);
            param[9].Value = PresentTeleNo;
            param[10] = new SqlParameter("@Qual", SqlDbType.VarChar, 50);
            param[10].Value = Qual;
            param[11] = new SqlParameter("@QualDate", SqlDbType.DateTime, 50);
            param[11].Value = QualDate;
            param[12] = new SqlParameter("@YearOfPassing", SqlDbType.Int, 50);
            param[12].Value = YearOfPassing;
            param[13] = new SqlParameter("@JobStatus", SqlDbType.VarChar, 50);
            param[13].Value = JobStatus;
            param[14] = new SqlParameter("@JobDate", SqlDbType.DateTime, 50);
            param[14].Value = JobDate;
            param[15] = new SqlParameter("@JobCategory", SqlDbType.Int, 50);
            param[15].Value = JobCategory;
            param[16] = new SqlParameter("@JobSubCategory", SqlDbType.Int, 50);
            param[16].Value = JobSubCategory;
            param[17] = new SqlParameter("@Others", SqlDbType.NChar, 50);
            param[17].Value = Others;
            param[18] = new SqlParameter("@Inservice", SqlDbType.Bit, 50);
            param[18].Value = Inservice;
            param[19] = new SqlParameter("@Designation", SqlDbType.VarChar, 50);
            param[19].Value = Designation;
            param[20] = new SqlParameter("@OfficeAddress", SqlDbType.VarChar, 500);
            param[20].Value = OfficeAddress;
            param[21] = new SqlParameter("@Remarks", SqlDbType.VarChar, 50);
            param[21].Value = Remarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spStud_AlumniInformation", param);
            return i;
        }

        public int AddStudEduHistory(int StudID, string PrevSchoolName, DateTime Fromdate, DateTime Todate, int Medium, string Remarks)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int,4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@PrevSchoolName", SqlDbType.VarChar,50);
            param[1].Value = PrevSchoolName;
            param[2] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[2].Value = Fromdate;
            param[3] = new SqlParameter("@Todate", SqlDbType.DateTime, 8);
            param[3].Value = Todate;
            param[4] = new SqlParameter("@Medium", SqlDbType.Int, 4);
            param[4].Value = Medium;
            param[5] = new SqlParameter("@Remarks", SqlDbType.VarChar, 50);
            param[5].Value = Remarks;          
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudEduHistory", param);
            return i;


        }
        public int AddStudIdentification(int StudID, string Mole1, string Mole2, string Email)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Mole1", SqlDbType.VarChar, 250);
            param[1].Value = Mole1;
            param[2] = new SqlParameter("@Mole2", SqlDbType.VarChar, 250);
            param[2].Value = Mole2;
            param[3] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
            param[3].Value = Email;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudIdentification", param);
            return i;


        }

        public int AddStudPhysicalState(int StudID, DateTime Date, int height, int weight, string ChestMeasurement, string eyesight, string bloodGroup, string dietPreferred, string ailments, string allergies, string ChronicDiseases, string MedicalOpinion,int Batch,int Class,int Section)
        {

            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Date", SqlDbType.DateTime, 8);
            param[1].Value = Date;
            param[2] = new SqlParameter("@height", SqlDbType.Int, 4);
            param[2].Value = height;
            param[3] = new SqlParameter("@weight", SqlDbType.Int, 4);
            param[3].Value = weight;
            param[4] = new SqlParameter("@ChestMeasurement", SqlDbType.VarChar, 20);
            param[4].Value = ChestMeasurement;
            param[5] = new SqlParameter("@eyesight", SqlDbType.VarChar, 20);
            param[5].Value = eyesight;
            param[6] = new SqlParameter("@bloodGroup", SqlDbType.VarChar, 20);
            param[6].Value = bloodGroup;
            param[7] = new SqlParameter("@dietPreferred", SqlDbType.VarChar, 100);
            param[7].Value = dietPreferred;
            param[8] = new SqlParameter("@ailments", SqlDbType.VarChar, 50);
            param[8].Value = ailments;
            param[9] = new SqlParameter("@allergies", SqlDbType.VarChar, 50);
            param[9].Value = allergies;
            param[10] = new SqlParameter("@ChronicDiseases", SqlDbType.VarChar, 50);
            param[10].Value = ChronicDiseases;
            param[11] = new SqlParameter("@MedicalOpinion", SqlDbType.VarChar, 500);
            param[11].Value = MedicalOpinion;
            param[12] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[12].Value = Batch;
            param[13] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[13].Value = Class;
            param[14] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[14].Value = Section;

            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudPhysicalState", param);
            return i;


        }
        public int AddStudentContactInfo(int StudID, string FatherName, string FatherAddress, string FatherPhone, int FatherQual, string FatherOccup, decimal FatherAnnualIncome)
        {

            SqlParameter[] param = new SqlParameter[17];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@FatherName", SqlDbType.VarChar,50);
            param[1].Value = FatherName;
            param[2] = new SqlParameter("@FatherAddress", SqlDbType.VarChar,100);
            param[2].Value = FatherAddress;
            param[3] = new SqlParameter("@FatherPhone", SqlDbType.VarChar,20);
            param[3].Value = FatherPhone;
            param[4] = new SqlParameter("@FatherQual", SqlDbType.Int, 4);
            param[4].Value = FatherQual;
            param[5] = new SqlParameter("@FatherOccup", SqlDbType.VarChar, 40);
            param[5].Value = FatherOccup;
            param[6] = new SqlParameter("@FatherAnnualIncome", SqlDbType.Decimal,8);
            param[6].Value = FatherAnnualIncome;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStuedentContactInfo", param);
            return i;


        }
        public DataSet GetStud_ContactInfo(int StudID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param.Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_ContactInfo", param);
            return ds;
        }
        public DataSet GetStud_EducHistory(int StudID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param.Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_EducHistory", param);
            return ds;
        }
        public DataSet GetStud_Identification(int StudID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param.Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_Identification", param);
            return ds;
        }
        public DataSet GetStud_Leaves(int StudID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param.Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_Leaves", param);
            return ds;
        }
        //public DataSet GetStud_PhysicalState(int StudID)
        //{
        //    ds = new DataSet();
        //    SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
        //    param.Value = StudID;
        //    ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStud_PhysicalState", param);
        //    return ds;
        //}
        public DataSet GetStudent(int StudID)
        {
            ds = new DataSet();
            SqlParameter param = new SqlParameter("@StudID", SqlDbType.Int, 8);
            param.Value = StudID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudent", param);
            return ds;
        }
        public DataSet GetStudData(int ClassID, int BatchID, int SectionID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
            param[0].Value = ClassID;
            param[1] = new SqlParameter("@BatchID", SqlDbType.Int, 8);
            param[1].Value = BatchID;
            param[2] = new SqlParameter("@SectionID", SqlDbType.Int, 8);
            param[2].Value = SectionID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStuData", param);
            return ds;
        }

        public int DeletePhysicalState(int StudID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 5);
            param[0].Value = StudID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDelete_physicalState", param);
            return i;
        }
        public int AddStudentAttendance(int StudID, int month, int year, int DaysPresent, int NoofWorkingDays)
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
            param[4] = new SqlParameter("@NoofWorkingDays", SqlDbType.Int, 4);
            param[4].Value = NoofWorkingDays;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudentAttendance", param);
            return i;


        }
        public int EditStudentAttendance(int StudID, int month, int year, int DaysPresent)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@month", SqlDbType.Int, 4);
            param[1].Value = month;
            param[2] = new SqlParameter("@year", SqlDbType.Int, 4);
            param[2].Value = year;
            param[3] = new SqlParameter("@DaysPresent", SqlDbType.Int, 4);
            param[3].Value = DaysPresent;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditStudentattendance", param);
            return i;


        }
        public DataSet GetHouseMaster()
        {
            ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetHouseMaster");
            return ds;
        }
        public int AddStudFee(int StudID, string BillNo, int AmountPaid, int AuthorisedPerson, int Mode, string DDCheckNo, string BankName, string Date)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 5);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@BillNo", SqlDbType.VarChar, 50);
            param[1].Value = BillNo;
            param[2] = new SqlParameter("@AmountPaid", SqlDbType.Int, 5);
            param[2].Value = AmountPaid;
            param[3] = new SqlParameter("@AuthorisedPerson", SqlDbType.Int, 5);
            param[3].Value = AuthorisedPerson;
            param[4] = new SqlParameter("@Mode", SqlDbType.Int, 5);
            param[4].Value = Mode;
            param[5] = new SqlParameter("@DDCheckNo", SqlDbType.VarChar, 50);
            param[5].Value = DDCheckNo;
            param[6] = new SqlParameter("@BankName", SqlDbType.VarChar, 50);
            param[6].Value = BankName;
            param[7] = new SqlParameter("@Date", SqlDbType.VarChar, 50);
            param[7].Value = Date;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudentFee", param);
            return i;
        }

       public int AddStudLeaves(int StudID, DateTime Fromdate, DateTime Todate, int HouseMaster, int Class, int Section, string Reason)
        {

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Fromdate", SqlDbType.DateTime, 8);
            param[1].Value = Fromdate;
            param[2] = new SqlParameter("@Todate", SqlDbType.DateTime, 8);
            param[2].Value = Todate;
            param[3] = new SqlParameter("@HouseMaster", SqlDbType.Int, 4);
            param[3].Value = HouseMaster;
            param[4] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[4].Value = Class;
            param[5] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[5].Value = Section;
            param[6] = new SqlParameter("@Reason", SqlDbType.VarChar, 200);
            param[6].Value = Reason;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudLeaves", param);
            return i;


        }

       public DataSet GetHouse()
       {
           DataSet ds = new DataSet();

           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetHouses");

           return ds;
       }
       public DataSet GetActivities(int Activittype,int Club)
       {
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[3];
           param[0] = new SqlParameter("@Type", SqlDbType.Int, 4);
           param[0].Value = Activittype;
           param[1] = new SqlParameter("@Club", SqlDbType.Int, 4);
           param[1].Value = Club;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetActivities", param);
           return ds;
       }

       public DataSet GetStudentdataHousewise(int HouseId)
       {
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@HouseId", SqlDbType.Int, 4);
           param[0].Value = HouseId;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentHousewise", param);
           return ds;

       }
       public int AddStudentActivities(int StudID, int Activitytype, int Activity, string Date,int Club)
       {
           int i = 0;
           try
           {
               SqlParameter[] param = new SqlParameter[10];
               param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
               param[0].Value = StudID;

               param[1] = new SqlParameter("@Activitytype", SqlDbType.Int, 4);
               param[1].Value = Activitytype;
               param[2] = new SqlParameter("@Activity", SqlDbType.Int, 4);
               param[2].Value = Activity;
               param[3] = new SqlParameter("@Date", SqlDbType.VarChar, 20);
               param[3].Value = Date;
               param[4] = new SqlParameter("@Club", SqlDbType.Int, 4);
               param[4].Value = Club;
               i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudentActivities", param);

           }
           catch (Exception)
           {

               throw;
           }
           return i;
       }
       public DataSet GetStudentActivities(string Date, int Activitytype,int Club)
       {
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[4];
           param[0] = new SqlParameter("@Date", SqlDbType.VarChar, 20);
           param[0].Value = Date;
           param[1] = new SqlParameter("@Activitytype", SqlDbType.Int, 4);
           param[1].Value = Activitytype;
           param[2]=new SqlParameter("@Club",SqlDbType.Int,4);
           param[2].Value=Club;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentActivities", param);

           return ds;
       }
       public DataSet GetGroupStudentactivities(string Date, int Activitytype,int Club)
       {
           DataSet ds = new DataSet();
           SqlParameter[] param = new SqlParameter[4];
           param[0] = new SqlParameter("@Date", SqlDbType.VarChar, 20);
           param[0].Value = Date;
           param[1] = new SqlParameter("@Activitytype", SqlDbType.Int, 4);
           param[1].Value = Activitytype;
           param[2] = new SqlParameter("@Club", SqlDbType.Int, 4);
           param[2].Value = Club;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetGropuStudentactivite", param);

           return ds;
       }

       public int UpdateIndividualStudentActivities(int StudID, int Activity, string Date, string Prize ,int Club)
       {
           int i = 0;
           try
           {
               SqlParameter[] param = new SqlParameter[10];
               param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
               param[0].Value = StudID;
               param[1] = new SqlParameter("@Activity", SqlDbType.Int, 4);
               param[1].Value = Activity;
               param[2] = new SqlParameter("@Date", SqlDbType.VarChar, 20);
               param[2].Value = Date;
               param[3] = new SqlParameter("@Prize", SqlDbType.VarChar, 20);
               param[3].Value = Prize;
               param[4] = new SqlParameter("@Club", SqlDbType.Int, 4);
               param[4].Value = Club;
               i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateIndividualActivities", param);

           }
           catch (Exception)
           {

               throw;
           }
           return i;
       }

       public int UpdateGroupStudentActivities(string Housename, int Activity, string Date, string Prize,int Club)
       {
           int i = 0;
           try
           {
               SqlParameter[] param = new SqlParameter[10];
               param[0] = new SqlParameter("@Housename", SqlDbType.VarChar, 50);
               param[0].Value = Housename;


               param[1] = new SqlParameter("@Activity", SqlDbType.Int, 4);
               param[1].Value = Activity;
               param[2] = new SqlParameter("@Date", SqlDbType.VarChar, 20);
               param[2].Value = Date;
               param[3] = new SqlParameter("@Prize", SqlDbType.VarChar, 20);
               param[3].Value = Prize;
               param[4] = new SqlParameter("@Club", SqlDbType.Int, 4);
               param[4].Value = Club;
               i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spUpdateGroupActivities", param);

           }
           catch (Exception)
           {

               throw;
           }
           return i;
       }

       //public int AddStudentTC(int StudId, int LastStudied, string BoardExam, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, int NoofSchoolDays, int NoofDaysAttended, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
       //{
       //    SqlParameter[] param = new SqlParameter[19];
       //    param[0] = new SqlParameter("@StudId", SqlDbType.Int, 4);
       //    param[0].Value = StudId;
       //    param[1] = new SqlParameter("@LastStudied", SqlDbType.Int, 100);
       //    param[1].Value = LastStudied;
       //    param[2] = new SqlParameter("@BoardExam", SqlDbType.VarChar, 100);
       //    param[2].Value = BoardExam;
       //    param[3] = new SqlParameter("@Subjects", SqlDbType.VarChar, 100);
       //    param[3].Value = Subjects;
       //    param[4] = new SqlParameter("@Failed", SqlDbType.Int, 4);
       //    param[4].Value = Failed;
       //    param[5] = new SqlParameter("@QualifiedforPromotion", SqlDbType.Int, 4);
       //    param[5].Value = QualifiedforPromotion;
       //    param[6] = new SqlParameter("@FeePaidMonth", SqlDbType.VarChar, 50);
       //    param[6].Value = FeePaidMonth;
       //    param[7] = new SqlParameter("@FeeConcession", SqlDbType.Int, 4);
       //    param[7].Value = FeeConcession;
       //    param[8] = new SqlParameter("@LastAttendDate", SqlDbType.VarChar, 20);
       //    param[8].Value = LastAttendDate;
       //    param[9] = new SqlParameter("@NoofSchoolDays", SqlDbType.Int, 4);
       //    param[9].Value = NoofSchoolDays;
       //    param[10] = new SqlParameter("@NoofDaysAttended", SqlDbType.Int, 4);
       //    param[10].Value = NoofDaysAttended;
       //    param[11] = new SqlParameter("@DateofApply", SqlDbType.VarChar, 20);
       //    param[11].Value = DateofApply;
       //    param[12] = new SqlParameter("@DateofIssue", SqlDbType.VarChar, 20);
       //    param[12].Value = DateofIssue;
       //    param[13] = new SqlParameter("@Reason", SqlDbType.Int, 4);
       //    param[13].Value = Reason;
       //    param[14] = new SqlParameter("@Ncc", SqlDbType.VarChar, 100);
       //    param[14].Value = Ncc;
       //    param[15] = new SqlParameter("@Games", SqlDbType.VarChar, 150);
       //    param[15].Value = Games;
       //    param[16] = new SqlParameter("@Conduct", SqlDbType.VarChar, 50);
       //    param[16].Value = Conduct;
       //    param[17] = new SqlParameter("@Remarks", SqlDbType.VarChar, 100);
       //    param[17].Value = Remarks;
       //    param[18] = new SqlParameter("@TCNO", SqlDbType.VarChar, 50);
       //    param[18].Value = TCNO;
       //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudentTC", param);
       //    return i;
       //}




       public DataSet GetStdPersonaldetail(int StudId)
       {
           ds = new DataSet();
           SqlParameter param = new SqlParameter("@StudId", SqlDbType.Int, 8);
           param.Value = StudId;

           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStdPersonaldetails", param);
           return ds;
           //ds = new DataSet(EmpCode);
           //ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetPersonaldetails");
           //return ds;
       }


       //public int EditStudentTC(int StudId, int LastStudied, string BoardExam, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, int NoofSchoolDays, int NoofDaysAttended, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
       //{
       //    SqlParameter[] param = new SqlParameter[19];
       //    param[0] = new SqlParameter("@StudId", SqlDbType.Int, 4);
       //    param[0].Value = StudId;
       //    param[1] = new SqlParameter("@LastStudied", SqlDbType.Int, 4);
       //    param[1].Value = LastStudied;
       //    param[2] = new SqlParameter("@BoardExam", SqlDbType.VarChar, 100);
       //    param[2].Value = BoardExam;
       //    param[3] = new SqlParameter("@Subjects", SqlDbType.VarChar, 100);
       //    param[3].Value = Subjects;
       //    param[4] = new SqlParameter("@Failed", SqlDbType.Int, 4);
       //    param[4].Value = Failed;
       //    param[5] = new SqlParameter("@QualifiedforPromotion", SqlDbType.Int, 4);
       //    param[5].Value = QualifiedforPromotion;
       //    param[6] = new SqlParameter("@FeePaidMonth", SqlDbType.VarChar, 50);
       //    param[6].Value = FeePaidMonth;
       //    param[7] = new SqlParameter("@FeeConcession", SqlDbType.Int, 4);
       //    param[7].Value = FeeConcession;
       //    param[8] = new SqlParameter("@LastAttendDate", SqlDbType.VarChar, 20);
       //    param[8].Value = LastAttendDate;
       //    param[9] = new SqlParameter("@NoofSchoolDays", SqlDbType.Int, 4);
       //    param[9].Value = NoofSchoolDays;
       //    param[10] = new SqlParameter("@NoofDaysAttended", SqlDbType.Int, 4);
       //    param[10].Value = NoofDaysAttended;
       //    param[11] = new SqlParameter("@DateofApply", SqlDbType.VarChar, 20);
       //    param[11].Value = DateofApply;
       //    param[12] = new SqlParameter("@DateofIssue", SqlDbType.VarChar, 20);
       //    param[12].Value = DateofIssue;
       //    param[13] = new SqlParameter("@Reason", SqlDbType.Int, 4);
       //    param[13].Value = Reason;
       //    param[14] = new SqlParameter("@Ncc", SqlDbType.VarChar, 100);
       //    param[14].Value = Ncc;
       //    param[15] = new SqlParameter("@Games", SqlDbType.VarChar, 150);
       //    param[15].Value = Games;
       //    param[16] = new SqlParameter("@Conduct", SqlDbType.VarChar, 50);
       //    param[16].Value = Conduct;
       //    param[17] = new SqlParameter("@Remarks", SqlDbType.VarChar, 100);
       //    param[17].Value = Remarks;
       //    param[18] = new SqlParameter("@TCNO", SqlDbType.VarChar, 50);
       //    param[18].Value = TCNO;

       //    int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditStudentTC", param);
       //    return i;
       //}

       public DataSet GetStudentData1(int ClassID, int BatchID, int SectionID)
       {
           ds = new DataSet();
           SqlParameter[] param = new SqlParameter[3];
           param[0] = new SqlParameter("@ClassID", SqlDbType.Int, 8);
           param[0].Value = ClassID;
           param[1] = new SqlParameter("@BatchID", SqlDbType.Int, 8);
           param[1].Value = BatchID;
           param[2] = new SqlParameter("@SectionID", SqlDbType.Int, 8);
           param[2].Value = SectionID;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentData", param);
           return ds;
       }

       public DataSet GetStudentDetailsByAdmissionNo(string AdmissionNo)
       {
           ds = new DataSet();
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@AdmissionNo", SqlDbType.VarChar, 20);
           param[0].Value = AdmissionNo;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudentDetailsByAdmissionNo", param);
           return ds;

       }
       public DataSet GetSelectionApplicationUsingGrid(string RollNo)
       {
           ds = new DataSet();
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@RollNo", SqlDbType.VarChar, 20);
           param[0].Value = RollNo;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSelectionApplicationUsingGrid", param);
           return ds;
       }
       public DataSet GetSelectionApplicationByName(string FirstName)
       {
           ds = new DataSet();
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@FirstName", SqlDbType.VarChar, 20);
           param[0].Value = FirstName;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetSelectionApplicationByName", param);
           return ds;
       }

       public int EditStudentTC(int StudId, int LastStudied, string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
       {
           int i = 0;
           try
           {
               SqlParameter[] param = new SqlParameter[19];
               param[0] = new SqlParameter("@StudId", SqlDbType.Int, 4);
               param[0].Value = StudId;
               param[1] = new SqlParameter("@LastStudied", SqlDbType.Int, 100);
               param[1].Value = LastStudied;
               param[2] = new SqlParameter("@Subjects", SqlDbType.VarChar, 100);
               param[2].Value = Subjects;
               param[3] = new SqlParameter("@Failed", SqlDbType.Int, 4);
               param[3].Value = Failed;
               param[4] = new SqlParameter("@QualifiedforPromotion", SqlDbType.Int, 4);
               param[4].Value = QualifiedforPromotion;
               param[5] = new SqlParameter("@FeePaidMonth", SqlDbType.VarChar, 50);
               param[5].Value = FeePaidMonth;
               param[6] = new SqlParameter("@FeeConcession", SqlDbType.Int, 4);
               param[6].Value = FeeConcession;
               param[7] = new SqlParameter("@LastAttendDate", SqlDbType.VarChar, 20);
               param[7].Value = LastAttendDate;
               param[8] = new SqlParameter("@DateofApply", SqlDbType.VarChar, 20);
               param[8].Value = DateofApply;
               param[9] = new SqlParameter("@DateofIssue", SqlDbType.VarChar, 20);
               param[9].Value = DateofIssue;
               param[10] = new SqlParameter("@Reason", SqlDbType.Int, 4);
               param[10].Value = Reason;
               param[11] = new SqlParameter("@Ncc", SqlDbType.VarChar, 100);
               param[11].Value = Ncc;
               param[12] = new SqlParameter("@Games", SqlDbType.VarChar, 150);
               param[12].Value = Games;
               param[13] = new SqlParameter("@Conduct", SqlDbType.VarChar, 50);
               param[13].Value = Conduct;
               param[14] = new SqlParameter("@Remarks", SqlDbType.VarChar, 100);
               param[14].Value = Remarks;
               param[15] = new SqlParameter("@TCNO", SqlDbType.VarChar, 50);
               param[15].Value = TCNO;

               i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditStudentTC", param);

           }
           catch (Exception E)
           {
           }
           return i;
       }

       public int AddStudentTC(int StudId, int LastStudied,  string Subjects, int Failed, int QualifiedforPromotion, string FeePaidMonth, int FeeConcession, string LastAttendDate, string DateofApply, string DateofIssue, int Reason, string Ncc, string Games, string Conduct, string Remarks, string TCNO)
       {
           int i = 0;
           try
           {
               SqlParameter[] param = new SqlParameter[19];
               param[0] = new SqlParameter("@StudId", SqlDbType.Int, 4);
               param[0].Value = StudId;
               param[1] = new SqlParameter("@LastStudied", SqlDbType.Int, 100);
               param[1].Value = LastStudied;
               param[2] = new SqlParameter("@Subjects", SqlDbType.VarChar, 100);
               param[2].Value = Subjects;
               param[3] = new SqlParameter("@Failed", SqlDbType.Int, 4);
               param[3].Value = Failed;
               param[4] = new SqlParameter("@QualifiedforPromotion", SqlDbType.Int, 4);
               param[4].Value = QualifiedforPromotion;
               param[5] = new SqlParameter("@FeePaidMonth", SqlDbType.VarChar, 50);
               param[5].Value = FeePaidMonth;
               param[6] = new SqlParameter("@FeeConcession", SqlDbType.Int, 4);
               param[6].Value = FeeConcession;
               param[7] = new SqlParameter("@LastAttendDate", SqlDbType.VarChar, 20);
               param[7].Value = LastAttendDate;
               param[8] = new SqlParameter("@DateofApply", SqlDbType.VarChar, 20);
               param[8].Value = DateofApply;
               param[9] = new SqlParameter("@DateofIssue", SqlDbType.VarChar, 20);
               param[9].Value = DateofIssue;
               param[10] = new SqlParameter("@Reason", SqlDbType.Int, 4);
               param[10].Value = Reason;
               param[11] = new SqlParameter("@Ncc", SqlDbType.VarChar, 100);
               param[11].Value = Ncc;
               param[12] = new SqlParameter("@Games", SqlDbType.VarChar, 150);
               param[12].Value = Games;
               param[13] = new SqlParameter("@Conduct", SqlDbType.VarChar, 50);
               param[13].Value = Conduct;
               param[14] = new SqlParameter("@Remarks", SqlDbType.VarChar, 100);
               param[14].Value = Remarks;
               param[15] = new SqlParameter("@TCNO", SqlDbType.VarChar, 50);
               param[15].Value = TCNO;

               i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudentTC", param);

           }
           catch (Exception E)
           {
           }
           return i;
       }



       public int AddStudFee1(int Batch, int Class, int Section, int StudID, int FeeType, int HeaderID, decimal Amount, string PaymentDate, string FeeSlip, decimal Fine, decimal totalamount)
       {
           SqlParameter[] param = new SqlParameter[14];
           param[0] = new SqlParameter("@Batch", SqlDbType.Int, 4);
           param[0].Value = Batch;
           param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
           param[1].Value = Class;
           param[2] = new SqlParameter("@Section", SqlDbType.Int, 4);
           param[2].Value = Section;
           param[3] = new SqlParameter("@StudID", SqlDbType.Int, 4);
           param[3].Value = StudID;
           param[4] = new SqlParameter("@FeeType", SqlDbType.Int, 4);
           param[4].Value = FeeType;
           param[5] = new SqlParameter("@HeaderID", SqlDbType.Int, 4);
           param[5].Value = HeaderID;
           param[6] = new SqlParameter("@Amount", SqlDbType.Decimal, 8);
           param[6].Value = Amount;
           param[7] = new SqlParameter("@PaymentDate", SqlDbType.VarChar, 30);
           param[7].Value = PaymentDate;
           param[8] = new SqlParameter("@FeeSlip", SqlDbType.VarChar, 20);
           param[8].Value = FeeSlip;
           param[9] = new SqlParameter("@Fine", SqlDbType.Decimal);
           param[9].Value = Fine;
           param[10] = new SqlParameter("@TotalAmount", SqlDbType.Decimal);
           param[10].Value = totalamount;
           param[11] = new SqlParameter("@Status", SqlDbType.Int);
           param[11].Direction = ParameterDirection.Output;
           int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spAddStudFee", param);
           i = Convert.ToInt16(param[11].Value.ToString());
           return i;
       }
       public DataSet GetFeeDetails(int Category, int Class, int FeeType, int Type)
       {
           ds = new DataSet();
           SqlParameter[] param = new SqlParameter[4];
           param[0] = new SqlParameter("@Category", SqlDbType.Int, 8);
           param[0].Value = Category;
           param[1] = new SqlParameter("@Class", SqlDbType.Int, 8);
           param[1].Value = Class;
           param[2] = new SqlParameter("@FeeType", SqlDbType.Int, 8);
           param[2].Value = FeeType;
           param[3] = new SqlParameter("@Type", SqlDbType.Int, 4);
           param[3].Value = Type;
           ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetFeeDetails", param);
           return ds;
       }

       public DataSet GetStudentFee(int StudnetId, int FeeType)
       {
           DataSet ds = new DataSet();
           try
           {
               SqlParameter[] param = new SqlParameter[3];
               param[0] = new SqlParameter("@StudentId", SqlDbType.Int, 4);
               param[0].Value = StudnetId;
               param[1] = new SqlParameter("@FeeType", SqlDbType.Int, 4);
               param[1].Value = FeeType;
               ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spGetStudnetFee", param);
           }
           catch (Exception)
           {

               throw;
           }
           return ds;

       }

    }
}
