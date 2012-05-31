using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAC;
namespace BusinessLayer
{
   public class CCEBL
    {
        DataSet ds;
        DAC.CCEDAC objCCE = new CCEDAC();
        public int DeleteCoscholasticDescriptors(int DescriptId)
        {
            int i = 0;
            try
            {
                i = objCCE.DeleteCoscholasticDescriptors(DescriptId);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int EditCoscholasticDescriptors(int DescriptId, string Descriptor, int CoScholasticID, int AssesmentID)
        {
            int i = 0;
            try
            {
                i = objCCE.EditCoscholasticDescriptors(DescriptId, Descriptor, CoScholasticID, AssesmentID);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }


        public int AddCoScholasticIndicators(string Indicator, int CoScholasticID, int AssesmentID)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoScholasticIndicators(Indicator, CoScholasticID, AssesmentID);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int EditScholasticArea1(int ScholasticID, string ScholasticArea, int MaxMarks)
        {
            int i = 0;
            try
            {
                i = objCCE.EditScholasticArea1(ScholasticID, ScholasticArea, MaxMarks);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int DeleteScholasticAreas1(int ScholasticID)
        {
            int i = 0;
            try
            {
                i = objCCE.DeleteScholasticAreas1(ScholasticID);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public DataSet GetScholasticArea1(int Year, int Subject, int Exam, int Classes)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetScholasticArea1(Year, Subject, Exam, Classes);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public int AddCoScholasticTotalMarks(int StudID, int Batch, int Class, int Section, int CoScholasticArea, int AssesmentId, string Grade, decimal TotalMarks, decimal Average)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoScholasticTotalMarks(StudID, Batch, Class, Section, CoScholasticArea, AssesmentId, Grade, TotalMarks, Average);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int AddCoScholasticMarks(int StudID, int Batch, int Class, int Section, int CoScholasticArea, int AssesmentId, int DescriptorId, decimal Marks)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoScholasticMarks(StudID, Batch, Class, Section, CoScholasticArea, AssesmentId, DescriptorId, Marks);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int AddCoscholasticDescriptors(string Descriptor, int CoScholasticID, int AssesmentID)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoscholasticDescriptors(Descriptor, CoScholasticID, AssesmentID);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }

        public DataSet GetCoscholasticDescriptors(int CoScholasticID, int AssesmentID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetCoscholasticDescriptors(CoScholasticID, AssesmentID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetIndicatorsByID(int IndicatorID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetIndicatorsByID(IndicatorID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public int DeleteCoScholasticGrades(int GradeID)
        {
            int i = 0;
            try
            {
                i = objCCE.DeleteCoScholasticGrades(GradeID);
            }
            catch (Exception Ex)
            {

            }
            return i;
        }
        public int EditCoscholasticGrades(int GradeID, string Grade, int CoScholasticID, int AssesmentID, string Indicators)
        {
            int i = 0;
            try
            {
                i = objCCE.EditCoscholasticGrades(GradeID, Grade, CoScholasticID, AssesmentID, Indicators);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public int AddCoscholasticGrades(string Grade, int CoScholasticID, int AssesmentID, string Indicators)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoscholasticGrades(Grade, CoScholasticID, AssesmentID, Indicators);
            }
            catch (Exception Ex)
            {
            }
            return i;
        }
        public DataSet GetCoscholasticGrades(int CoScholasticID, int AssesmentID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetCoscholasticGrades(CoScholasticID, AssesmentID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetAssesmentArea(int CoScholasticID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetAssesmentArea(CoScholasticID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public DataSet GetCoScholasticIndicators(int CoScholasticID, int AssesmentID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetCoScholasticIndicators(CoScholasticID, AssesmentID);
            }
            catch (Exception Ex)
            {
            }
            return ds;
        }
        public int AddCoScholasticIndicators(string Indicator, int CoScholasticID)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoScholasticIndicators(Indicator,CoScholasticID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetCoScholasticIndicators(int CoScholasticID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE. GetCoScholasticIndicators(CoScholasticID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int DeleteCoScholasticIndicators(int IndicatorID)
        {
            int i = 0;
            try
            {
                i = objCCE.DeleteCoScholasticIndicators(IndicatorID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditCoScholasticIndicators(int IndicatorID, string Indicator, int CoScholasticID)
        {
            int i = 0;
            try
            {
                i = objCCE.EditCoScholasticIndicators(IndicatorID,Indicator,CoScholasticID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddCoScholasticArea(string CoScholasticArea)
        {
            int i = 0;
            try
            {
                i = objCCE.AddCoScholasticArea(CoScholasticArea);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public DataSet GetCoScholasticArea(int CoScholasticID)
        {
            ds = new DataSet();
            try
            {
                ds = objCCE.GetCoScholasticArea(CoScholasticID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return ds;
        }
        public int DeleteCoScholasticArea(int CoScholasticID)
        {
            int i = 0;
            try
            {
                i = objCCE.DeleteCoScholasticArea(CoScholasticID);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int EditCoScholasticArea(int CoScholasticID, string CoScholasticArea)
        {
            int i = 0;
            try
            {
                i = objCCE.EditCoScholasticArea(CoScholasticID,CoScholasticArea);
            }
            catch (Exception Ex)
            {
                ErrHandler.WriteError(Ex.Message);
            }
            return i;
        }
        public int AddExam(int TermID, string Exam, int Weightage)
       {
           int i = 0;
           try
           {
               i = objCCE.AddExam(TermID,Exam,Weightage);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }

           return i;
       }
       public DataSet GetExam(int ExamID)
       {
           ds = new DataSet();
           try
           {
               ds = objCCE.GetExam(ExamID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return ds;
       }
       public int DeleteExam(int ExamID)
       {
           int i = 0;
           try
           {
               i = objCCE.DeleteExam(ExamID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);

           }
           return i;
       }
       public int EditExam(int ExamID, int TermID, string Exam, int Weightage)
       {
           int i = 0;
           try
           {
               i = objCCE.EditExam(ExamID,TermID,Exam,Weightage);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }

       public int AddScholasticArea(string ScholasticArea, int ExamID, int AcadYear, int Class, int Maxmarks,int SubjectID)
       {
           int i = 0;
           try
           {
               i = objCCE.AddScholasticArea(ScholasticArea,ExamID,AcadYear,Class,Maxmarks,SubjectID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public DataSet GetScholasticAreaByExamID(int ExamID)
       {
           ds = new DataSet();
           try
           {
               ds = objCCE.GetScholasticAreaByExamID(ExamID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return ds;
       }

       public DataSet GetScholasticArea(int ExamID, int Year, int SubjectID, int ClassID)
       {
           ds = new DataSet();
           try
           {
               ds = objCCE.GetScholasticArea(ExamID, Year, SubjectID, ClassID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return ds;
       }

       public int DeleteScholasticArea(int ScholasticID)
       {
           int i = 0;
           try
           {
               i = objCCE.DeleteScholasticArea(ScholasticID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public int EditScholasticArea(int ScholasticID, string ScholasticArea, int ExamID, int AcadYear, int Class, int Maxmarks,int SubjectID)
       {
           int i = 0;
           try
           {
               i = objCCE.EditScholasticArea(ScholasticID, ScholasticArea, ExamID, AcadYear, Class, Maxmarks,SubjectID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public int AddStudentMarks(int Batch, int Class, int Section, int StudId, int ScholasticID, decimal Marks)
       {
           int i = 0;
           try
           {
               i = objCCE.AddStudentMarks(Batch,Class,Section,StudId,ScholasticID,Marks);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public int EditStudentMarks(int StudId, int Batch, int Class, int Section, int ScholasticID, decimal Marks)
       {
           int i = 0;
           try
           {
               i = objCCE.EditStudentMarks(StudId,Batch,Class,Section,ScholasticID,Marks);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public int AddStudentTotalMarks(int Batch, int Class, int Section, int StudId, int ExamID,int SubjectID, decimal Total, string Grade, decimal Reduced)
       {
           int i = 0;
           try
           {
               i = objCCE.AddStudentTotalMarks(Batch, Class, Section, StudId, ExamID,SubjectID, Total, Grade,Reduced);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public DataSet GetMarks(int Year, int SubjectID, int ExamID, int Batch, int Class, int Section)
       {
           ds = new DataSet();
           try
           {
               ds = objCCE.GetMarks(Year, SubjectID, ExamID, Batch, Class, Section);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return ds;
       }
       public DataSet GetCoScholasticMarks(int Year, int CoScholasticID, int Skills, int Batch, int Class, int Section)
       {
           ds = new DataSet();
           try
           {
               ds = objCCE.GetMarks(Year, CoScholasticID, Skills, Batch, Class, Section);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return ds;
       }
       public DataSet GetCoScholasticMarksDisplay(int Batch, int Class, int Section, int CoScholasticArea)
       {
           ds = new DataSet();
           try
           {
               ds = objCCE.GetCoScholasticMarksDisplay(Batch, Class, Section, CoScholasticArea);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return ds;
       }
       public int UpdateCoScholasticMarks(int Batch, int Class, int Section, int CoScholasticArea, string IndicatorID)
       {
           int i = 0;
           try
           {
               i = objCCE.UpdateCoScholasticMarks(Batch, Class, Section, CoScholasticArea, IndicatorID);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }
       public int AddCoScholasticMarks(int StudID, int Caste, int Gender, string Indicators, string Grade, int Batch, int Class, int Section, int CoScholasticArea)
       {
           int i = 0;
           try
           {
               i = objCCE.AddCoScholasticMarks(StudID, Caste, Gender, Indicators, Grade, Batch, Class, Section, CoScholasticArea);
           }
           catch (Exception Ex)
           {
               ErrHandler.WriteError(Ex.Message);
           }
           return i;
       }

    }
}
