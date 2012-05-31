using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Collections;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web;




/// <summary>
/// Summary description for ErrorLogFile
/// </summary>
public class ErrorLogFile
{

    public static void WriteError(Exception EX,string Pagename,string procedurename)
    {
        try
        {
            string path = "~/Error/" + DateTime.Today.ToString("dd-mm-yy") + ".txt";
            if (!File.Exists(HttpContext.Current.Server.MapPath(path)))
            {
                File.Create(HttpContext.Current.Server.MapPath(path)).Close();
            }
            using (StreamWriter w = File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                // string mappedPath = Request.MapPath(inputPath.Text,
                // Request.ApplicationPath, false);
                w.WriteLine("\r\nLog Entry : ");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                //string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() + "Class Name :" + s +
                //              ". Error Message:" + errorMessage;

                //string err = "Error in: " + System.Web.HttpContext.Current.Request.Url.ToString() + "Class Name :" + StackTrace +
                //    ". Error Message:" + errorMessage;
                //w.WriteLine("Message:" + EX.Message() + ",Pagename:" Pagename.ToString() + ",procedurename:" procedurename.ToString());
                w.WriteLine("Error:" + EX.Message);
                w.WriteLine("procedure Name:" + procedurename);
                w.WriteLine("Page Name:" + Pagename);
                w.WriteLine("__________________________");
                w.Flush();
                w.Close();
            }
        }
        catch (Exception ex)
        {
            // ex.error("Error (" + StackTrace + ") Exception while processing incoming event: " + ex, ex);
            WriteError(ex,Pagename,procedurename);
        }

    }
  
}
