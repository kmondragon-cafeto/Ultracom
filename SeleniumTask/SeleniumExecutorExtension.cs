using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTask
{
    public class SeleniumExecutorExtension
    {
        public static string GetTextToAssert_Positive()
        {
            return "You pass!!!";
        }
        public static string GetTextToAssert_Negative()
        {
            return "WRONG!!!";
        }
    }

}
