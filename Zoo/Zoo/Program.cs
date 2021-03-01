using System;
using System.Collections.Generic;

namespace Zoo
{
   public class Program
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Random R = new Random();
            ZooKeeper Z = new ZooKeeper();
            List<Animal> ZooAnimals = new List<Animal>();
            List<Animal> NotDangerousAnimals = NotDangerous(ZooAnimals);
            List<Animal> DangerousAnimals = Dangerous(ZooAnimals);
            GenerateZoo(ZooAnimals);
            Console.WriteLine("Itt az ideje az állatok etetésének és itatásának");
            Console.WriteLine("--------------------------------------------------------------");
            Z.ActualFood = "Water";
            Z.Amount = R.Next(0, 11);
            Console.WriteLine("Kezdjük azokkal, akik nem veszélyesek");
            Console.WriteLine("Szállított tápanyag: " + Z.ActualFood);
            Console.WriteLine("Szállított mennyiség: " + Z.Amount);


            Console.ReadLine();
        }
        private static double RandomNumberBetween(double minValue, double maxValue)
        {
            var next = random.NextDouble();

            return minValue + (next * (maxValue - minValue));
        }
        public static void GenerateZoo(List<Animal> Animals)
        {
            Random R = new Random();
            int number = R.Next(0, 10);

            //Tigers
            for (int i = 0; i < number; i++)
            {
                Animals.Add(new Tiger() { Name = "Tiger" + i, ActualWater = R.Next(1, 3), ActualFood = R.Next(20, 31) });
            }

            //Elephants
            number = R.Next(0, 10);
            for (int i = 0; i < number; i++)
            {
                Animals.Add(new Elephant() { Name = "Elephant" + i, ActualWater = R.Next(15, 21), ActualFood = R.Next(20, 35) });
            }
            //Foxes
            number = R.Next(0, 10);
            for (int i = 0; i < number; i++)
            {
                Animals.Add(new Elephant() { Name = "Fox" + i, ActualWater = -1, ActualFood = RandomNumberBetween(0.5,1) });
            }

            //Horses
            number = R.Next(0, 10);
            for (int i = 0; i < number; i++)
            {
                Animals.Add(new Horse() { Name = "Horse" + i, ActualWater = -1, ActualFood = R.Next(5, 9) });
            }
            //Lions
            number = R.Next(0, 10);
            for (int i = 0; i < number; i++)
            {
                Animals.Add(new Lion() { Name = "Lion" + i, ActualWater = RandomNumberBetween(1,1.5), ActualFood = R.Next(25, 30) });
            }

            //Cattle
            number = R.Next(0, 10);
            for (int i = 0; i < number; i++)
            {
                Animals.Add(new Cattle() { Name = "Cattle" + i, ActualWater = -1, ActualFood = R.Next(15, 20) });
            }


        }

        public static List<Animal> NotDangerous(List<Animal> Animals)
        {
            List<Animal> notDangerous = new List<Animal>();
            foreach (var animal in Animals)
            {
                if (!animal.IsItDangerous)
                {
                    notDangerous.Add(animal);
                }
            }
            return Animals;
        }
        public static List<Animal> Dangerous(List<Animal> Animals)
        {
            List<Animal> Dangerous = new List<Animal>();
            foreach (var animal in Animals)
            {
                if (animal.IsItDangerous)
                {
                    notDangerous.Add(animal);
                }
            }
            return Animals;
        }
    }

    
}
