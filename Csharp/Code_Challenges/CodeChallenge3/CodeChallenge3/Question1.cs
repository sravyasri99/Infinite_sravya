using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge3
{
    class CricketTeam
    {
        public (int CountOfMatchs, float AverageOfScores, int SumOfScores ) PointsCalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            for (int i = 0; i < no_of_matches; i++)
            {
                Console.Write($"Enter the Score for  the Match {i + 1}: ");
                scores[i] = Convert.ToInt32(Console.ReadLine());
                if(scores[i] < 0)
                {
                    Console.Write("The Score should be a non negative number : ");
                }
                else
                {
                    sum += scores[i];
                }
                
            }
            float average = (float)sum / no_of_matches;
            return (no_of_matches, average , sum);
        }
    }
    class Question1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Number of Matches Held : ");
            int NoOfMatches = Convert.ToInt32(Console.ReadLine());

            if(NoOfMatches <= 0)
            {
                Console.Write("The number of Matches should be a non nesgative number. ");
                Console.Read();
            }
            else
            {
                CricketTeam cricketTeam = new CricketTeam();
                var finalDetails = cricketTeam.PointsCalculation(NoOfMatches);
                Console.WriteLine("===========The Final Result===========");
                Console.WriteLine($"Total Count of the Matches Played: {finalDetails.CountOfMatchs}");
                Console.WriteLine($"Average of the total scores are: {finalDetails.AverageOfScores}");
                Console.WriteLine($"The sum of the Total Scores are: {finalDetails.SumOfScores}");
                Console.Read();
            }
            
        
        }
    }
}
