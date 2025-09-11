﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleTonClass trainer = SingleTonClass.GetInstance();

            trainer.Show("Working with single object instance of the trainer..");

            SingleTonClass trainee = SingleTonClass.GetInstance();

            trainee.Show("Working with single object instance of the trainee..");

            SingleTonClass manager = SingleTonClass.GetInstance();
            manager.Show("Invoking the object for the third time..");
            Console.Read();
        }
    }
}
