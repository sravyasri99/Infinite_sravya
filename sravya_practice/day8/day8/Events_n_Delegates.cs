using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8
{
    public delegate void DisplayDelegate(string message);
    
    class Events_n_Delegates
    {
        public static void DisplayRingtone(string Message)
        {
            Console.WriteLine($"{Message}");
        }

        public static void Display(string Message)
        {
            Console.WriteLine($"{Message}");
        }

        public static void DisplayVibration(string Message)
        {
            Console.WriteLine($"{Message}");
        }

        static void Main()
        {
            DisplayDelegate displayDelegate = new DisplayDelegate(DisplayRingtone);
            displayDelegate += Display;
            displayDelegate += DisplayVibration;

            displayDelegate.Invoke("Playing ringtone...");
            displayDelegate.Invoke("Displaying caller information...");

            Console.Read();
        }
    }
}
