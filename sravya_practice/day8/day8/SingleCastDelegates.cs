﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day8
{
    delegate void NotificationDelegate(string message);

    class User
    {
        public string Message { get; set; }

        public void DisplayMessage(string msg)
        {
            Message = msg;
            Console.WriteLine(Message);
        }
    }
    class SingleCastDelegates
    {
        public static void Main()
        {
            User user = new User();

            NotificationDelegate notificationDelegate = new NotificationDelegate(user.DisplayMessage);

            notificationDelegate("WelcomeUser!");
            Console.Read();
        }
    }
}
