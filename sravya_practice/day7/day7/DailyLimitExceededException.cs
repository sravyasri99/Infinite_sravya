using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class DailyLimitExceededException : ApplicationException
    {
        public DailyLimitExceededException(string message) : base(message)
        {

        }
    }

}
