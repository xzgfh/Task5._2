using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task5._2
{

    class AutoPark
    {
        private List<string> ListOfCars;
        private List<string> ListOfDrivers;
        private List<TripInformation> ListOfTripInformation;

        public delegate void ForUpdateShowHistory(TripInformation obj);
        public event ForUpdateShowHistory ForHistoryOfTrips;
        protected virtual void OnForHistoryOfTrips(TripInformation obj)
        {

            if (ForHistoryOfTrips != null)
            {
                ForHistoryOfTrips(obj);
            }
        }


        /*public event ForHistoryOfTrips EndEvent;
        public event ForHistoryOfTrips RequestEvent;

        public void OnEndEvent() { EndEvent();}
        public void OnRequestEvent() { RequestEvent(); }*/


        public AutoPark()
        {

            ListOfCars = new List<string>();
            ListOfDrivers = new List<string>();
            ListOfTripInformation = new List<TripInformation>();

            ListOfCars.Add("BMW");
            ListOfCars.Add("Mercedece");
            ListOfCars.Add("Opel");
            ListOfCars.Add("Nissan");
            ListOfCars.Add("Skoda");

            ListOfDrivers.Add("Петров");
            ListOfDrivers.Add("Иванов");
            ListOfDrivers.Add("Сидоров");
            ListOfDrivers.Add("Степанов");
            ListOfDrivers.Add("Степин");
            ListOfDrivers.Add("Пореченков");
            ListOfDrivers.Add("Погорелов");
            ListOfDrivers.Add("Куис");
            ListOfDrivers.Add("Кононович");
        }
        public string SetCar()
        {
            Console.WriteLine("\t\tList of avaliable cars \n\n");
            for (int i = 0; i < ListOfCars.Count; i++)
            {
                Console.WriteLine(i + ". " + ListOfCars[i]);
            }

            Console.WriteLine("\n\nEnter the number of car : ");
            int num = Int32.Parse(Console.ReadLine());

            return ListOfCars[num];
        }
        public List<string> SetDrivers()
        {

            int EnterDrivers = default(int);
            List<string> ForPr = new List<string>();


            Console.WriteLine("\t\tList of avaliable drivers \n\n");
            for (int i = 0; i < ListOfDrivers.Count; i++)
            {
                Console.WriteLine(i + ". " + ListOfDrivers[i]);
            }

            Console.WriteLine("\nEnter the count of driver(s) : ");
            int p = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of driver(s) : ");

            for (int i = 0; i < p; i++)
            {
                EnterDrivers = Int32.Parse(Console.ReadLine());
                ForPr.Add(ListOfDrivers[EnterDrivers]);
            }

            return ForPr;
        }
        public string SetDirection()
        {
            Console.WriteLine("Enter  direction : ");
            string str = Console.ReadLine();

            return str;
        }




        public struct TripInformation
        {

            public int NumberOfTrip;
            public string Car;
            public string Direction;
            public List<string> Drivers;
            public bool RepairedAMachine;
            public TripInformation(int NumberOfTrip, string Car, string Direction, List<string> Drivers)
            {
                this.NumberOfTrip = NumberOfTrip;
                this.Car = Car;
                this.Direction = Direction;
                this.Drivers = Drivers;
                this.RepairedAMachine = false;
            }
        }

        public void RequestForRepair(ref TripInformation TObj)
        {

            Console.WriteLine("Received a request for repairs! Wait until there is a repair...");

            Timer obj = new Timer();
            obj.Elapsed += delegate (object sender, ElapsedEventArgs e)
            {
                Console.WriteLine("Car repaired!");
            };

            obj.AutoReset = false;
            obj.Interval = 5000;
            obj.Enabled = true;
            TObj.RepairedAMachine = true;
        }
        public void UpdateHistoryOfTrips(TripInformation obj)
        {
            ListOfTripInformation.Add(obj);
            OnForHistoryOfTrips(obj);
        }
        public void ShowHistoryOfTrips(TripInformation obj)
        {

            Console.WriteLine("\t\tList of all trips");

            foreach (TripInformation p in ListOfTripInformation)
            {

                Console.WriteLine("Number of trip : {0}", p.NumberOfTrip);
                Console.WriteLine("Car make : {0}", p.Car);
                Console.WriteLine("Direction : {0}", p.Direction);
                Console.Write("Driver(s) : ");

                foreach (string str in p.Drivers)
                {
                    Console.Write(str + " ; ");
                }

                Console.WriteLine("\nRepaired a machine : {0}\n\n", p.RepairedAMachine);


            }


        }




    }
}