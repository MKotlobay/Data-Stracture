using System;
using Build_Base.MainClasses;

namespace Build_Base.CustomClasses
{
    public class TrainRoad
    {
        public static void Task()
        {
            Stack<RailroadCar> st = new Stack<RailroadCar>();
            int num = 100;
            int railCarsAmount = 0;

            for (int i = 0; i < 10; i++)
            {
                st.Push(new RailroadCar(num));
                num++;
                railCarsAmount++;
            }

            Locomotive loco = new Locomotive();
            loco.ToString();

            TrainRoadCars train = new TrainRoadCars(loco, st, railCarsAmount);


            Console.WriteLine("Before");
            Stack<RailroadCar> temp = new Stack<RailroadCar>();
            while (!st.IsEmpty())
            {
                st.Top().ToString();
                temp.Push(st.Pop());
            }
            while (!temp.IsEmpty())
                st.Push(temp.Pop());

            train.ReduceCarriages();

            Console.WriteLine("");

            Console.WriteLine("After");

            while (!st.IsEmpty())
            {
                st.Top().ToString();
                temp.Push(st.Pop());
            }
            while (!temp.IsEmpty())
                st.Push(temp.Pop());

        }

        public class RailroadCar
        {
            public string SerialNumber { get; set; }
            public int PresentPassengers { get; set; } = 0;
            private int MaxPassengers = 50;

            public RailroadCar(int serialNumber)
            {
                Random rnd = new Random();
                PresentPassengers = rnd.Next(5, 50 + 1);
            }

            public void ToString()
            {
                Console.WriteLine($"Serial number of Rail road car is: {SerialNumber} with Amount of passengers: {PresentPassengers}");
            }
        }

        public class Locomotive
        {
            private int Id { get; set; }
            private int DateManufactured { get; set; }

            public Locomotive()
            {
                DateManufactured = 1990;

                Random rnd = new Random();
                Id = rnd.Next(1000, 9999 + 1);
            }
            public void ToString()
            {
                Console.WriteLine($"ID of Locomotive is: {Id}, that been manufactured in year: {DateManufactured}");
            }
        }

        public class TrainRoadCars
        {
            private Locomotive Locomotive { get; set; }
            private Stack<RailroadCar> St { get; set; }
            private int RailCarsAmount { get; set; }

            public TrainRoadCars(Locomotive locomotive, Stack<RailroadCar> st, int railCarsAmount)
            {
                Locomotive = locomotive;
                St = st;
                RailCarsAmount = railCarsAmount;
            }

            public void ToString()
            {
                Console.WriteLine($"Locomotive is: ");
                Locomotive.ToString();
                Console.WriteLine($"Amount of rails cars: {RailCarsAmount}");
                Console.WriteLine("");

                Stack<RailroadCar> temp = new Stack<RailroadCar>();
                while (!St.IsEmpty())
                {
                    St.Top().ToString();
                    temp.Push(St.Pop());
                }
                while (!temp.IsEmpty())
                    St.Push(temp.Pop());
            }

            public void AddRailRoadCar(RailroadCar railCar)
            {
                St.Push(railCar);
            }

            public void RemoveRailRoadCar(string serialNumber)
            {
                Stack<RailroadCar> temp = new Stack<RailroadCar>();

                while (!St.IsEmpty())
                {
                    if (St.Top().SerialNumber == serialNumber)
                    {
                        St.Pop();
                    }
                    else
                        temp.Push(St.Pop());
                }
                while (!temp.IsEmpty())
                    St.Push(temp.Pop());
            }

            public void ReduceCarriages()
            {
                Stack<RailroadCar> temp = new Stack<RailroadCar>();

                while (!St.IsEmpty())
                {
                    var currentCar = St.Pop();

                    if (currentCar.PresentPassengers == 0) // Cleans zeroed railcars
                    {
                        continue; // Skip to the next iteration
                    }

                    if (temp.IsEmpty() || temp.Top().PresentPassengers == 50) // First car or already full
                    {
                        temp.Push(currentCar);
                    }
                    else if (temp.Top().PresentPassengers + currentCar.PresentPassengers == 50)
                    {
                        temp.Top().PresentPassengers = 50;
                    }
                    else if (temp.Top().PresentPassengers + currentCar.PresentPassengers < 50)
                    {
                        temp.Top().PresentPassengers += currentCar.PresentPassengers;
                    }
                    else if (temp.Top().PresentPassengers + currentCar.PresentPassengers > 50)
                    {
                        int passengersNeededForTemp = 50 - temp.Top().PresentPassengers;
                        temp.Top().PresentPassengers = 50;

                        currentCar.PresentPassengers -= passengersNeededForTemp;

                        if (currentCar.PresentPassengers > 0) // Still has passengers left
                        {
                            temp.Push(currentCar);
                        }
                    }
                }

                while (!temp.IsEmpty()) // Resets order
                {
                    St.Push(temp.Pop());
                }
            }
        }
    }
}
