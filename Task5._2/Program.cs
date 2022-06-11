using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 1;
            AutoPark obj = new AutoPark();

            obj.ForHistoryOfTrips += obj.UpdateHistoryOfTrips;
            obj.ForHistoryOfTrips += obj.ShowHistoryOfTrips;


            System.Timers.Timer ForTrip = new System.Timers.Timer();
            ForTrip.AutoReset = false;
            ForTrip.Interval = 5000;
            ForTrip.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
            {
                Console.Write("The machine has successfully returned from a trip.\n\n");
            };



            while (num != 10)
            {
                Console.WriteLine("\t\tTrip number " + num);

                Console.WriteLine("\n\n");
                AutoPark.TripInformation TripObj = new AutoPark.TripInformation(num, obj.SetCar(), obj.SetDirection(), obj.SetDrivers());
                Console.WriteLine("\n");

                Random rand = new Random();       //с таймером трабла
                if (rand.Next(0, 2) == 1)
                {
                    obj.RequestForRepair(ref TripObj);
                    Thread.Sleep(5500);
                }





            }






            Console.ReadKey();
        }
    }
}