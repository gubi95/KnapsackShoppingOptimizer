using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.IO;                         

namespace KnapsackShoppingOptimizer
{
    public class HelperMethods
    {
        public static string MapPath(string strRelativePath)
        {
            // move from bin/debug 2 folders up
            string strBasePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string strMappedPath = Path.Combine(strBasePath, ("" + strRelativePath).Trim().Replace("/", "\\"));
            return strMappedPath;            
        }

        public static DataManager DataManager = new DataManager();
    }
}
