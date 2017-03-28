using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KnapsackShoppingOptimizer.Managers
{
    public class ValidationManager
    {
        public static bool IsNotEmptyValueValid(string strInput)
        {
            return ("" + strInput).Trim() != "";
        }

        public static bool IsCashValueValid(string strInput)
        {
            return new Regex("\\d{1,}\\.\\d{1,2}", RegexOptions.None).Match(strInput).Success;
        }
    }
}
