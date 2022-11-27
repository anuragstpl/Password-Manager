using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace DataLayer.Helper
{
    public class LogHelper
    {
        public static void writelog(string message)
        {
            //System.IO.StreamWriter file = new System.IO.StreamWriter(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"));
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Logs/logdata.txt"),message+Environment.NewLine);
            //file.(message);
            //file.Dispose();
        }
    }
}
