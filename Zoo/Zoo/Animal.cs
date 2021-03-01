using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo
{
    public enum AnimalType { tiger, elephant, fox, horse, lion, cattle }
    public class Animal
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public bool IsItDangerous { get; set; }
        public double MinWaterPerDay { get; set; }
        public double MaxWaterPerDay { get; set; }
        public double MinFoodPerDay { get; set; }
        public double MaxFoodPerDay { get; set; }
        public bool IsItHerbivorous { get; set; }
        public double ActualWater { get; set; }
        public double ActualFood { get; set; }
        public List<string> EnabledFood { get; set; }
    }
    public class Tiger : Animal
    {
        public Tiger()
        {
            Type = 0;
            MinWaterPerDay = 1;
            MaxWaterPerDay = 2;
            MinFoodPerDay = 20;
            MaxFoodPerDay = 30;
            IsItDangerous = true;
            EnabledFood = new List<string>();
            EnabledFood.Add("meat");
        }

    }

    public class Elephant : Animal
    {
        public Elephant()
        {
            Type = 1;
            MinWaterPerDay = 15;
            MaxWaterPerDay = 20;
            MinFoodPerDay = 20;
            MaxFoodPerDay = 35;
            IsItDangerous = false;
            EnabledFood = new List<string>();
            EnabledFood.Add("petFood");
            EnabledFood.Add("plant");
        }
    }
    public class Fox : Animal
    {
        public Fox()
        {
            Type = 2;
            MinFoodPerDay = 0.5;
            MaxFoodPerDay = 1;
            IsItDangerous = false;
            EnabledFood = new List<string>();
            EnabledFood.Add("meat");
        } 
    }
    public class Horse : Animal
    {
        public Horse()
        {
            Type = 3;
            MinFoodPerDay = 5;
            MaxFoodPerDay = 8;
            IsItDangerous = false;
            EnabledFood = new List<string>();
            EnabledFood.Add("petFood");
            EnabledFood.Add("plant");
        }
    
    
    }
    public class Lion : Animal
    {

        public Lion()
        {
            Type = 4;
            MinWaterPerDay = 1;
            MaxWaterPerDay = 1.5;
            MinFoodPerDay = 25;
            MaxFoodPerDay = 30;
            IsItDangerous = true;
            EnabledFood = new List<string>();
            EnabledFood.Add("meat");
        }
    }
    public class Cattle : Animal
    {
        public Cattle()
        {
            Type = 5;
            MinFoodPerDay = 15;
            MaxFoodPerDay = 20;
            IsItDangerous = false;
            EnabledFood = new List<string>();
            EnabledFood.Add("petFood");
            EnabledFood.Add("plant");
        }
    }

}
