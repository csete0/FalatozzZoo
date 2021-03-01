using System;
using System.Collections.Generic;

namespace Zoo
{
    public class Program
    {
        public static ZooKeeper Z;
        public static bool simulateON;
        public static List<string> AllFood;
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            Z = new ZooKeeper();
            Z.ActualFood = new Food();
            simulateON = true;
            AllFood = new List<string>() { "Water", "Meat", "petfood" };
            Random R = new Random();
            List<Animal> ZooAnimals = new List<Animal>();

            GenerateZoo(ZooAnimals);

            List<Animal> NotDangerousAnimals = NotDangerous(ZooAnimals);
            List<Animal> DangerousAnimals = Dangerous(ZooAnimals);

            Console.WriteLine("Itt az ideje az állatok etetésének és itatásának");
            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("Kezdjük azokkal, akik nem veszélyesek");

            while (simulateON)
            {
                Z.ActualFood.Type = AllFood[R.Next(0, 3)].ToUpper();
                Z.Amount = R.Next(1, 2);
                Console.WriteLine("Szállított tápanyag: " + Z.ActualFood.Type);
                Console.WriteLine("Szállított mennyiség: " + Z.Amount);              
                IncreaseWaterFood(NotDangerousAnimals);
                if (simulateON)
                {
                    Z.ActualFood.Type = AllFood[R.Next(0, 3)].ToUpper();
                    Z.Amount = R.Next(1, 2);
                 
                    Console.WriteLine("A nem veszélyes állatok etetése sikeres volt!");
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Következik a veszélyes állatok etetése!");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("Szállított tápanyag: " + Z.ActualFood.Type);
                    Console.WriteLine("Szállított mennyiség: " + Z.Amount);
                    IncreaseWaterFood(DangerousAnimals);
                    if (simulateON)
                    {
                        Console.WriteLine("A veszélyes állatok etetése sikeres volt!");
                        Console.WriteLine("-------------------------------------------");
                    }
                }
            }
            
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
                Animals.Add(new Elephant() { Name = "Fox" + i, ActualWater = -1, ActualFood = RandomNumberBetween(0.5, 1) });
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
                Animals.Add(new Lion() { Name = "Lion" + i, ActualWater = RandomNumberBetween(1, 1.5), ActualFood = R.Next(25, 30) });
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
            return notDangerous;
        }
        public static List<Animal> Dangerous(List<Animal> Animals)
        {
            List<Animal> Dangerous = new List<Animal>();
            foreach (var animal in Animals)
            {
                if (animal.IsItDangerous)
                {
                    Dangerous.Add(animal);
                }
            }
            return Dangerous;
        }
        public static bool FoodIsOk(Animal a, string food)
        {
            List<string> EnabledFood = new List<string>();
            foreach (var item in a.EnabledFood)
            {
                EnabledFood.Add(item.ToUpper());
            }
            if (EnabledFood.Contains(food.ToUpper()))
            {
                return true;
            }
            return false;
        }

        public static void ListStatistic(List<Animal> Animals)
        {
            Console.WriteLine("Az állatok jelenlegi statisztikája: ");
            Console.WriteLine("--------------------------------------------");
            foreach (var animal in Animals)
            {
                Console.WriteLine(animal.Name + " " + "Aktuális / MaxVíz " + animal.ActualWater + " / " +animal.MaxWaterPerDay);
                Console.WriteLine("Aktuális / MaxFood " + animal.ActualFood + " / " + animal.MaxFoodPerDay);
                Console.WriteLine("--------------------------------------------");
            }
        }

        public static void IncreaseWaterFood(List<Animal> Animals)
        {
            foreach (var animal in Animals)
            {
                if (FoodIsOk(animal, Z.ActualFood.Type))
                {
                    if (Z.ActualFood.Type == "Water".ToUpper() && simulateON)
                    {
                        animal.ActualWater += Z.Amount;
                        if (animal.ActualWater > animal.MaxWaterPerDay)
                        {
                            simulateON = false;
                            Console.WriteLine("Sajnos " + animal.Name + " túlitatás miatt elpusztult");
                            break;
                        }
                    }
                    else if(Z.ActualFood.Type == "Meat".ToUpper() &&simulateON)
                    {
                        animal.ActualFood += Z.Amount;
                        if (animal.ActualFood > animal.MaxFoodPerDay)
                        {
                            simulateON = false;
                            Console.WriteLine("Sajnos " + animal.Name + " túletetés miatt elpusztult");
                            break;

                        }
                    }
                    else if (Z.ActualFood.Type == "petfood".ToUpper() && simulateON)
                    {
                        animal.ActualFood += Z.Amount;
                        if (animal.ActualFood > animal.MaxFoodPerDay)
                        {
                            simulateON = false;
                            Console.WriteLine("Sajnos " + animal.Name + " túletetés miatt elpusztult");
                            break;

                        }
                    }
                }           
            }
        }


    }


}
