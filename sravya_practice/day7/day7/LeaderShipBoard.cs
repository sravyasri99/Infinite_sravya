using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class Player
    {
        public int Score { get; set; }

        public void Compare_Scores(Player p1, Player p2)
        {
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Equals(p2));
            Console.WriteLine((p1.Score).CompareTo(p2.Score));
            Console.Read();
        }
    }
    class LeaderShipBoard
    {
        static void Main()
        {
            Player p1 = new Player();
            Player p2 = new Player();
            Player p3 = new Player();
            p1.Score = 20;
            p2.Score = 30;
            p3.Compare_Scores(p1, p2);

        }
    }
}
