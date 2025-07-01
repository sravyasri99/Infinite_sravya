using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8
{
    public class MobilePhone
    {
        public delegate void RingNotificationSyatem();

        public event RingNotificationSyatem Event;

        public void ReceiveCall()
        {
            Console.WriteLine("Incomig call");
            if (Event != null)
            {
                Event();
            }
        }
    }
    public class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    public class ScreenDisplay
    {
        public void CallerInformationDisplay()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    public class Vibration
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }
    class EventsProgram
    {
        static void Main()
        {
            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            Vibration vibration = new Vibration();

            phone.Event += ringtone.PlayRingtone;
            phone.Event += screen.CallerInformationDisplay;
            phone.Event += vibration.Vibrate;

            phone.ReceiveCall();
            Console.Read();
        }
    }
}
