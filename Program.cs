using System;

namespace LB5_3
{
    class Shop
    {
        public string[] sizeClothes = { "XXS", "XS", "S", "M", "L" };
        public string euroSize;

        public Shop(string euroSize)
        {
            this.euroSize = euroSize;
        }

        public string GetSize
        {
            get
            {
                return euroSize;
            }
        }

        public string EuroSize
        {
            set
            {
                euroSize = value;
                if (euroSize == "32")
                {
                    euroSize = sizeClothes[0];
                }
                else if (euroSize == "34")
                {
                    euroSize = sizeClothes[1];
                }
                else if (euroSize == "36")
                {
                    euroSize = sizeClothes[2];
                }
                else if (euroSize == "38")
                {
                    euroSize = sizeClothes[3];
                }
                else if (euroSize == "40")
                {
                    euroSize = sizeClothes[4];
                }
            }
        }
        public void getDescription()
        {
            if (euroSize == sizeClothes[0])
            {
                Console.WriteLine("Дитячий розмiр");
            }
            else
            {
                Console.WriteLine("Дорослий розмiр");
            }
            Console.WriteLine();
        }
    }
    interface IMenswear
    {
        void dressMan();
    }

    interface IWomenswear
    {
        void dressWoman();
    }

    abstract class Clothes
    {
        protected int sizeClothes;
        protected double price;
        protected string color;
        protected Clothes(int s, double p, string c)
        {
            sizeClothes = s;
            price = p;
            color = c;
        }
    }

    class TShirt : Clothes, IMenswear, IWomenswear
    {
        public TShirt(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressMan()
        {
            Console.WriteLine("Футболка:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
        public void dressWoman()
        {
            Console.WriteLine("Футболка:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Pants : Clothes, IMenswear, IWomenswear
    {
        public Pants(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressMan()
        {
            Console.WriteLine("Штани:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
        public void dressWoman()
        {
            Console.WriteLine("Штани:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Skirt : Clothes, IWomenswear
    {
        public Skirt(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressWoman()
        {
            Console.WriteLine("Спiдниця:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Necktie : Clothes, IMenswear
    {
        public Necktie(int sizeClothes, double price, string color) : base(sizeClothes, price, color) { }
        public void dressMan()
        {
            Console.WriteLine("Краватка:");
            Console.WriteLine($"Розмiр: {sizeClothes}, Колiр: {color}, Цiна {price}");
        }
    }

    class Atelier
    {
        public void dressMan()
        {
            Console.WriteLine("Одягаю чоловiка");
            IMenswear[] wear = { new TShirt(40, 400, "Чорний"), new Pants(44, 800, "Чорний"), new Necktie(8, 100, "Червоний") };
            foreach (IMenswear men in wear)
            {
                men.dressMan();
            }
            Console.WriteLine();
        }
        public void dressWoman()
        {
            Console.WriteLine("Одягаю жiнку: ");
            IWomenswear[] wear = { new TShirt(34, 250, "Зелений"), new Pants(36, 850, "Коричневий"), new Skirt(5, 150, "Червоний") };
            foreach (IWomenswear women in wear)
            {
                women.dressWoman();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть розмiр (32, 34, 36, 38, 40): ");
            string size = Console.ReadLine();
            var shop = new Shop(size);
            shop.EuroSize = shop.GetSize;
            shop.getDescription();
            var atelier = new Atelier();
            atelier.dressMan();
            atelier.dressWoman();
        }
    }
}