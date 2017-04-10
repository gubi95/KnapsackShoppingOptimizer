using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.IO;
using System.Windows.Controls;
using System.Collections;

namespace KnapsackShoppingOptimizer
{
    public class HelperMethods
    {
        public static DataManager DataManager = new DataManager();

        public static string MapPath(string strRelativePath)
        {
            // move from bin/debug 2 folders up
            string strBasePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\"));
            string strMappedPath = Path.Combine(strBasePath, ("" + strRelativePath).Trim().Replace("/", "\\"));
            return strMappedPath;            
        }

        public static IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
        
    }
}
