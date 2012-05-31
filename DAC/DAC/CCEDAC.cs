using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace DAC
{
    public class CCEDAC
    {
        SqlConnection objCon = new SqlConnection(ConfigurationSettings.AppSettings["ConnStr"].ToString());
        DataSet ds;
        public int DeleteCoscholasticDescriptors(int DescriptId)
        {
            int i;
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@DescriptId", SqlDbType.Int, 4);
            param[0].Value = DescriptId;

            //i = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoscholasticDescriptors", param);
            i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spDeleteCoscholasticDescriptors", param);
            return i;
        }

        public int EditCoscholasticDescriptors(int DescriptId, string Descriptor, int CoScholasticID, int AssesmentID)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@DescriptId", SqlDbType.Int, 4);
            param[0].Value = DescriptId;
            param[1] = new SqlParameter("@Descriptor", SqlDbType.VarChar, 500);
            param[1].Value = Descriptor;
            param[2] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[2].Value = CoScholasticID;
            param[3] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[3].Value = AssesmentID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spEditCoscholasticDescriptors", param);
            return i;


        }

        public int EditScholasticArea1(int ScholasticID, string ScholasticArea, int MaxMarks)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@ScholasticID", SqlDbType.Int, 4);
            param[0].Value = ScholasticID;
            param[1] = new SqlParameter("@ScholasticArea", SqlDbType.VarChar, 50);
            param[1].Value = ScholasticArea;
            param[2] = new SqlParameter("@MaxMarks", SqlDbType.Int, 4);
            param[2].Value = MaxMarks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEEditScholasticAreas1", param);
            return i;
        }
        public int DeleteScholasticAreas1(int ScholasticID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ScholasticID", SqlDbType.Int, 4);
            param[0].Value = ScholasticID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEDeleteScholasticAreas1", param);
            return i;
        }
        public DataSet GetScholasticArea1(int Year, int Subject, int Exam, int Classes)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[0].Value = Year;
            param[1] = new SqlParameter("@Subject", SqlDbType.Int, 4);
            param[1].Value = Subject;
            param[2] = new SqlParameter("@Exam", SqlDbType.Int, 4);
            param[2].Value = Exam;
            param[3] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[3].Value = Classes;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetScholasticArea1", param);
            return ds;
        }
        public int AddCoScholasticTotalMarks(int StudID, int Batch, int Class, int Section, int CoScholasticArea, int AssesmentId, string Grade, decimal TotalMarks, decimal Average)
        {

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[1].Value = Batch;
            param[2] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[2].Value = Class;
            param[3] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[3].Value = Section;
            param[4] = new SqlParameter("@CoScholasticArea", SqlDbType.Int, 4);
            param[4].Value = CoScholasticArea;
            param[5] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[5].Value = AssesmentId;
            param[6] = new SqlParameter("@Grade", SqlDbType.VarChar, 10);
            param[6].Value = Grade;
            param[7] = new SqlParameter("@TotalMarks", SqlDbType.Decimal, 8);
            param[7].Value = TotalMarks;
            param[8] = new SqlParameter("@Average", SqlDbType.Decimal, 8);
            param[8].Value = Average;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoScholasticTotalMarks", param);
            return i;
        }

        public int AddCoScholasticMarks(int StudID, int Batch, int Class, int Section, int CoScholasticArea, int AssesmentId, int DescriptorId, decimal Marks)
        {

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[1].Value = Batch;
            param[2] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[2].Value = Class;
            param[3] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[3].Value = Section;
            param[4] = new SqlParameter("@CoScholasticArea", SqlDbType.Int, 4);
            param[4].Value = CoScholasticArea;
            param[5] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[5].Value = AssesmentId;
            param[6] = new SqlParameter("@DescriptorID", SqlDbType.Int, 4);
            param[6].Value = DescriptorId;
            param[7] = new SqlParameter("@Marks", SqlDbType.Decimal, 8);
            param[7].Value = Marks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoScholasticMarks", param);
            return i;
        }
        public int AddCoscholasticDescriptors(string Descriptor, int CoScholasticID, int AssesmentID)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Descriptor", SqlDbType.VarChar, 500);
            param[0].Value = Descriptor;
            param[1] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[1].Value = CoScholasticID;
            param[2] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[2].Value = AssesmentID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoscholasticDescriptors", param);
            return i;
        }
        public DataSet GetCoscholasticDescriptors(int CoScholasticID, int AssesmentID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            param[1] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[1].Value = AssesmentID;

            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoscholasticDescriptors", param);
            return ds;
        }
        public DataSet GetIndicatorsByID(int IndicatorID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IndicatorID", SqlDbType.Int, 4);
            param[0].Value = IndicatorID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetIndicatorsByID", param);
            return ds;
        }
        public int DeleteCoScholasticGrades(int GradeID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@GradeID", SqlDbType.Int, 4);
            param[0].Value = GradeID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEDeleteCoScholasticGrades", param);
            return i;


        }
        public int EditCoscholasticGrades(int GradeID, string Grade, int CoScholasticID, int AssesmentID, string Indicators)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@GradeID", SqlDbType.Int, 4);
            param[0].Value = GradeID;
            param[1] = new SqlParameter("@Grade", SqlDbType.VarChar, 10);
            param[1].Value = Grade;
            param[2] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[2].Value = CoScholasticID;
            param[3] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[3].Value = AssesmentID;
            param[4] = new SqlParameter("@Indicators", SqlDbType.VarChar, 100);
            param[4].Value = Indicators;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEEditCoScholasticGrades", param);
            return i;


        }
        public int AddCoscholasticGrades(string Grade, int CoScholasticID, int AssesmentID, string Indicators)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Grade", SqlDbType.VarChar, 10);
            param[0].Value = Grade;
            param[1] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[1].Value = CoScholasticID;
            param[2] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[2].Value = AssesmentID;
            param[3] = new SqlParameter("@Indicators", SqlDbType.VarChar, 100);
            param[3].Value = Indicators;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoscholasticGrades", param);
            return i;


        }
        public DataSet GetCoscholasticGrades(int CoScholasticID, int AssesmentID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            param[1] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[1].Value = AssesmentID;

            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoscholasticGrades", param);
            return ds;
        }
        public DataSet GetAssesmentArea(int CoScholasticID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetAssesmentArea", param);
            return ds;
        }
        public DataSet GetCoScholasticIndicators(int CoScholasticID, int AssesmentID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            param[1] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[1].Value = AssesmentID;

            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoScholasticIndicators", param);
            return ds;
        }






        public int AddCoScholasticIndicators(string Indicator, int CoScholasticID)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Indicator", SqlDbType.VarChar, 300);
            param[0].Value = Indicator;
            param[1] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[1].Value = CoScholasticID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoScholasticIndicators", param);
            return i;


        }

        public int AddCoScholasticIndicators(string Indicator, int CoScholasticID, int AssesmentID)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Indicator", SqlDbType.VarChar, 300);
            param[0].Value = Indicator;
            param[1] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[1].Value = CoScholasticID;
            param[2] = new SqlParameter("@AssesmentID", SqlDbType.Int, 4);
            param[2].Value = AssesmentID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoScholasticIndicators", param);
            return i;


        }
        public DataSet GetCoScholasticIndicators(int CoScholasticID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoScholasticIndicators", param);
            return ds;
        }

        public int DeleteCoScholasticIndicators(int IndicatorID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IndicatorID", SqlDbType.Int, 4);
            param[0].Value = IndicatorID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEDeleteCoScholasticIndicators", param);
            return i;


        }
        public int EditCoScholasticIndicators(int IndicatorID, string Indicator, int CoScholasticID)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IndicatorID", SqlDbType.Int, 4);
            param[0].Value = IndicatorID;
            param[1] = new SqlParameter("@Indicator", SqlDbType.VarChar, 300);
            param[1].Value = Indicator;
            param[2] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[2].Value = CoScholasticID; int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEUpdateCoScholasticIndicators", param);
            return i;


        }
        public int AddCoScholasticArea(string CoScholasticArea)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CoScholasticArea", SqlDbType.VarChar, 50);
            param[0].Value = CoScholasticArea;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoScholasticArea", param);
            return i;


        }


        public DataSet GetCoScholasticArea(int CoScholasticID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoScholasticArea", param);
            return ds;
        }

        public int DeleteCoScholasticArea(int CoScholasticID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEDeleteCoScholasticArea", param);
            return i;


        }
        public int EditCoScholasticArea(int CoScholasticID, string CoScholasticArea)
        {

            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@CoScholasticID", SqlDbType.Int, 4);
            param[0].Value = CoScholasticID;
            param[1] = new SqlParameter("CoScholasticArea", SqlDbType.VarChar, 50);
            param[1].Value = CoScholasticArea;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEEditCoScholasticArea", param);
            return i;


        }
        public int AddExam(int TermID, string Exam, int Weightage)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@TermID", SqlDbType.Int, 4);
            param[0].Value = TermID;
            param[1] = new SqlParameter("@ExamName", SqlDbType.VarChar, 50);
            param[1].Value = Exam;
            param[2] = new SqlParameter("@Weightage", SqlDbType.Int, 4);
            param[2].Value = Weightage;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddExams", param);
            return i;


        }
        public DataSet GetExam(int ExamID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[0].Value = ExamID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetExam", param);
            return ds;
        }
        public int DeleteExam(int ExamID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[0].Value = ExamID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEDeleteExam", param);
            return i;


        }
        public int EditExam(int ExamID, int TermID, string Exam, int Weightage)
        {

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[0].Value = ExamID;
            param[1] = new SqlParameter("@ExamName", SqlDbType.VarChar, 50);
            param[1].Value = Exam;
            param[2] = new SqlParameter("@TermID", SqlDbType.Int, 4);
            param[2].Value = TermID;
            param[3] = new SqlParameter("@Weightage", SqlDbType.Int, 4);
            param[3].Value = Weightage;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEEditExam", param);
            return i;


        }
        public int AddScholasticArea(string ScholasticArea, int ExamID, int AcadYear, int Class, int Maxmarks, int SubjectID)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ScholasticArea", SqlDbType.VarChar, 50);
            param[0].Value = ScholasticArea;
            param[1] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[1].Value = ExamID;
            param[2] = new SqlParameter("@AcadYear", SqlDbType.Int, 4);
            param[2].Value = AcadYear;
            param[3] = new SqlParameter("@ClassID", SqlDbType.Int, 4);
            param[3].Value = Class;
            param[4] = new SqlParameter("@Maxmarks", SqlDbType.Int, 4);
            param[4].Value = Maxmarks;
            param[5] = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param[5].Value = SubjectID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddScholasticArea", param);
            return i;


        }
        public DataSet GetScholasticAreaByExamID(int ExamID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[0].Value = ExamID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetScholasticAreaByExamID", param);
            return ds;
        }

        public DataSet GetScholasticArea(int ExamID, int Year, int SubjectID, int ClassID)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[0].Value = ExamID;
            param[1] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[1].Value = Year;
            param[2] = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param[2].Value = SubjectID;
            param[3] = new SqlParameter("@ClassID", SqlDbType.Int, 4);
            param[3].Value = ClassID;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetScholasticArea", param);
            return ds;
        }

        public int DeleteScholasticArea(int ScholasticID)
        {

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ScholasticID", SqlDbType.Int, 4);
            param[0].Value = ScholasticID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEDeleteScholasticArea", param);
            return i;


        }
        public int EditScholasticArea(int ScholasticID, string ScholasticArea, int ExamID, int AcadYear, int Class, int Maxmarks, int SubjectID)
        {

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@ScholasticID", SqlDbType.Int, 4);
            param[0].Value = ScholasticID;
            param[1] = new SqlParameter("@ScholasticArea", SqlDbType.VarChar, 50);
            param[1].Value = ScholasticArea;
            param[2] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[2].Value = ExamID;
            param[3] = new SqlParameter("@AcadYear", SqlDbType.Int, 4);
            param[3].Value = AcadYear;
            param[4] = new SqlParameter("@ClassID", SqlDbType.Int, 4);
            param[4].Value = Class;
            param[5] = new SqlParameter("@Maxmarks", SqlDbType.Int, 4);
            param[5].Value = Maxmarks;
            param[5] = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param[5].Value = SubjectID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEEditScholasticArea", param);
            return i;


        }
        public int AddStudentMarks(int Batch, int Class, int Section, int StudId, int ScholasticID, decimal Marks)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[0].Value = Batch;
            param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[1].Value = Class;
            param[2] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[2].Value = Section;
            param[3] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[3].Value = StudId;
            param[4] = new SqlParameter("@ScholasticID", SqlDbType.Int, 4);
            param[4].Value = ScholasticID;
            param[5] = new SqlParameter("@Marks", SqlDbType.Decimal, 8);
            param[5].Value = Marks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddStudentMarks", param);
            return i;


        }
        public int EditStudentMarks(int StudId, int Batch, int Class, int Section, int ScholasticID, decimal Marks)
        {

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[0].Value = StudId;
            param[1] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[1].Value = Batch;
            param[2] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[2].Value = Class;
            param[3] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[3].Value = Section;
            param[4] = new SqlParameter("@ScholasticID", SqlDbType.Int, 4);
            param[4].Value = ScholasticID;
            param[5] = new SqlParameter("@Marks", SqlDbType.Decimal, 8);
            param[5].Value = Marks;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEUpdate_StudentMarks", param);
            return i;


        }
        public int AddStudentTotalMarks(int Batch, int Class, int Section, int StudId, int ExamID, int SubjectID, decimal Total, string Grade, decimal Reduced)
        {

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[0].Value = Batch;
            param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[1].Value = Class;
            param[2] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[2].Value = Section;
            param[3] = new SqlParameter("@StudID", SqlDbType.Int, 4);
            param[3].Value = StudId;
            param[4] = new SqlParameter("@ExamID", SqlDbType.Int, 4);
            param[4].Value = ExamID;
            param[5] = new SqlParameter("@Total", SqlDbType.Decimal, 8);
            param[5].Value = Total;
            param[6] = new SqlParameter("@Grade", SqlDbType.VarChar, 5);
            param[6].Value = Grade;
            param[7] = new SqlParameter("@Reduced", SqlDbType.Decimal, 4);
            param[7].Value = Reduced;
            param[8] = new SqlParameter("@SubjectID", SqlDbType.Int, 4);
            param[8].Value = SubjectID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddStudentTotalMarks", param);
            return i;


        }
        public DataSet GetMarks(int Year, int SubjectID, int ExamID, int Batch, int Class, int Section)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[0].Value = Year;
            param[1] = new SqlParameter("@ExamType", SqlDbType.Int, 4);
            param[1].Value = ExamID;
            param[2] = new SqlParameter("@Subject", SqlDbType.Int, 4);
            param[2].Value = SubjectID;
            param[3] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[3].Value = Batch;
            param[4] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[4].Value = Class;
            param[5] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[5].Value = Section;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetMarks", param);
            return ds;
        }
        public DataSet GetCoScholasticMarks(int Year, int CoScholasticID, int Skills, int Batch, int Class, int Section)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@Year", SqlDbType.Int, 4);
            param[0].Value = Year;
            param[1] = new SqlParameter("@CoScholasticArea", SqlDbType.Int, 4);
            param[1].Value = CoScholasticID;
            param[2] = new SqlParameter("@Skills", SqlDbType.Int, 4);
            param[2].Value = Skills;
            param[3] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[3].Value = Batch;
            param[4] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[4].Value = Class;
            param[5] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[5].Value = Section;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGEtCoScholasticMarks", param);
            return ds;
        }
        public DataSet GetCoScholasticMarksDisplay(int Batch, int Class, int Section, int CoScholasticArea)
        {
            ds = new DataSet();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[0].Value = Batch;
            param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[1].Value = Class;
            param[2] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[2].Value = Section;
            param[3] = new SqlParameter("@CoScholasticArea", SqlDbType.Int, 4);
            param[3].Value = CoScholasticArea;
            ds = SqlHelper.ExecuteDataset(objCon, CommandType.StoredProcedure, "spCCEGetCoScholasticMarksDisplay", param);
            return ds;
        }
        public int UpdateCoScholasticMarks(int Batch, int Class, int Section, int CoScholasticArea, string IndicatorID)
        {

            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[0].Value = Batch;
            param[1] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[1].Value = Class;
            param[2] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[2].Value = Section;
            param[3] = new SqlParameter("@CoScholasticArea", SqlDbType.Int, 4);
            param[3].Value = CoScholasticArea;
            param[4] = new SqlParameter("@IndicatorID", SqlDbType.VarChar, 50);
            param[4].Value = IndicatorID;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEUpdateCoScholasticMarks", param);
            return i;


        }

        public int AddCoScholasticMarks(int StudID, int Caste, int Gender, string Indicators, string Grade, int Batch, int Class, int Section, int CoScholasticArea)
        {

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@StudID", SqlDbType.VarChar, 300);
            param[0].Value = StudID;
            param[1] = new SqlParameter("@Caste", SqlDbType.Int, 4);
            param[1].Value = Caste;
            param[2] = new SqlParameter("@Gender", SqlDbType.Int, 4);
            param[2].Value = Gender;
            param[3] = new SqlParameter("@Indicators", SqlDbType.VarChar, 50);
            param[3].Value = Indicators;
            param[4] = new SqlParameter("@Grade", SqlDbType.VarChar, 50);
            param[4].Value = Grade;
            param[5] = new SqlParameter("@Batch", SqlDbType.Int, 4);
            param[5].Value = Batch;
            param[6] = new SqlParameter("@Class", SqlDbType.Int, 4);
            param[6].Value = Class;
            param[7] = new SqlParameter("@Section", SqlDbType.Int, 4);
            param[7].Value = Section;
            param[8] = new SqlParameter("@CoScholasticArea", SqlDbType.Int, 4);
            param[8].Value = CoScholasticArea;
            int i = SqlHelper.ExecuteNonQuery(objCon, CommandType.StoredProcedure, "spCCEAddCoScholasticMarks", param);
            return i;


        }

    }

}
