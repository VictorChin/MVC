﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.LocationServiceClient client = new ServiceReference1.LocationServiceClient();
            var re = client.GetLocationByLocality("Flushing, NY");
            Console.WriteLine(re);
            Console.Read();

        }
    }
}