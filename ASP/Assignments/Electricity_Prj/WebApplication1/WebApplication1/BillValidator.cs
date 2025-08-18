using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class BillValidator
    {
        public string ValidateUnitsConsumed(int unitsConsumed)
        {
            return unitsConsumed < 0 ? "Given units is invalid" : "Valid";
        }
    }

}