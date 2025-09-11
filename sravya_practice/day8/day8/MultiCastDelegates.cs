using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8
{
    public delegate long SquareDelegate(int side);
    public delegate void UserDelegate(string message);
    class MultiCastDelegates
    {
        public static long AreaofSquare(int side)
        {
            return side * side;
        }
        public static long PerimeterofSquare(int side)
        {
            return 4 * side;
        }
    }
}
