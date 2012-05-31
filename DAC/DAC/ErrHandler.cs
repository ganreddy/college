using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.IO;
using System.Globalization;
using System.Web.UI;

/// <summary>
/// Summary description for ErrHandler
/// </summary>
public class ErrHandler
{
    public static void WriteError(string errorMessage)
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
                w.WriteLine("\r\nLogEntry :");
                w.WriteLine("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                //string err = "Error in:" + HttpContext.Current.Request.Url.ToString();
                string err2 = "Error in:" + HttpContext.Current.Application.ToString();
                string err1="Error Message:" + errorMessage;
                //w.WriteLine(err);
                w.WriteLine(err1);
                w.WriteLine(err2);
                w.WriteLine("---------------");
                w.Flush();
                w.Close();
            }
        }
        catch(Exception)
        {
        
        }
    }

}
