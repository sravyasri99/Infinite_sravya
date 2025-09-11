using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAY12
{
    class ExpressionTrees
    {
        Func<string, string, string> stringJoin = (s1, s2) => String.Concat(s1, s2);

        Expression<Func<string, string, string>> stringjoinExpr = (s1, s2) => String.Concat(s1, s2);

        //var result = stringjoinExpr.Compile()("Sravya", "Sri");

        Expression<Func<int, int, int>> sum = (s1, s2) => s1 + s2;

        

    }
}
