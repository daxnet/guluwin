using System;
using System.Collections.Generic;
using System.Text;

namespace vergen
{
    class Program
    {
        public void Init()
        {
            Console.WriteLine();
            Console.WriteLine("Version Generation Utility for Gulu");
            Console.WriteLine("Copyright (C) 2007-2008 SunnyChen.ORG, all rights reserved.");
            Console.WriteLine();
        }

        public void Run()
        {
            DateTime dateTime = DateTime.Now;
            if (!DateTime.TryParse("9/23/1980", out dateTime))
                throw new Exception("Cannot parse the date-time value.");
            TimeSpan ts = DateTime.Now - dateTime;
            int major = ts.Days;

            ts = DateTime.Now - DateTime.Today;
            int minor = ts.Minutes * 60 + ts.Seconds;

            Console.WriteLine(string.Format("Major: {0} , Minor: {1}", major, minor));
        }

        static void Main(string[] args)
        {
            try
            {
                Program program = new Program();
                program.Init();
                program.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
