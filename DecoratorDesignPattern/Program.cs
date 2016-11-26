using System;
using System.Collections.Generic;

namespace DecoratorDesignPattern
{
    public abstract class BakedGood
    {
        protected string Name = "Derived class mistake";
        protected decimal Price = 0.00m;

        public virtual string GetName()
        {
            return Name;
        }
        public virtual decimal GetPrice()
        {
            return Price;
        }
    }

    public class CakeBasic : BakedGood
    {
        public CakeBasic()
        {
            Name = "Cake";
            Price = 20.00m;
        }
    }
        
    public abstract class Decorator : BakedGood
    {
        BakedGood bakedGood = null;

        public Decorator(BakedGood bakedGood)
        {
            this.bakedGood = bakedGood;
        }

        public override string GetName()
        {
            return $"{bakedGood.GetName()}, {Name}";
        }

        public override decimal GetPrice()
        {
            return bakedGood.GetPrice() + Price;
        }
    }

    public class CherryDecorator : Decorator
    {
        public CherryDecorator(BakedGood bakedGood) 
            : base(bakedGood)
        {
            Name = "Cherry";
            Price = 4.00m;
        }
    }

    public class NameDecorator : Decorator
    {
        public NameDecorator(BakedGood bakedGood)
            : base(bakedGood)
        {
            Name = "Name Card";
            Price = 5.00m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var Cakes = new List<BakedGood>();

            var Cake = new CakeBasic();
            var CherryCake = new CherryDecorator(Cake);
            var NameCaked = new NameDecorator(Cake);
            var NameCherryCaked = new NameDecorator(CherryCake);

            // Beauty is didn't have to make NameCherryDecorator class.
            // As more Decorators are added the combinations grows
            // exponentially 2^(Number of Decorators)

            Cakes.Add(Cake);
            Cakes.Add(CherryCake);
            Cakes.Add(NameCaked);
            Cakes.Add(NameCherryCaked);

            foreach (BakedGood bakedGood in Cakes)
            {
                Console.WriteLine($"{bakedGood.GetName()} Price = ${bakedGood.GetPrice()}");
            }

            Console.ReadKey();
        }
    }
}
