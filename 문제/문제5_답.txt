using System;
using System.Collections;

namespace Ex5ForClass
{
    abstract class Pizza
    {
        private string description = "기본 피자";

        public virtual string getDescription()
        {
            return description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public abstract int cost();
    }

    abstract class ToppingDecorator : Pizza
    {
        protected Pizza pizza;

        public void setPizza(Pizza pizza)
        {
            this.pizza = pizza;
        }
    }

    class ThickcrustPizza : Pizza
    {
        public ThickcrustPizza()
        {
            this.setDescription("두꺼운 크러스트 피자");
        }

        public override int cost()
        {
            return 30000;
        }
    }

    class ThincrustPizza : Pizza
    {
        public ThincrustPizza()
        {
            this.setDescription("얇은 크러스트 피자");
        }

        public override int cost()
        {
            return 25000;
        }
    }

    class Cheese : ToppingDecorator
    {
        public Cheese(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override string getDescription()
        {
            return pizza.getDescription() + ", 치즈";
        }

        public override int cost()
        {
            return pizza.cost() + 2000;
        }
    }

    class Olives : ToppingDecorator
    {
        public Olives(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public override string getDescription()
        {
            return pizza.getDescription() + ", 올리버";
        }

        public override int cost()
        {
            return pizza.cost() + 1500;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Pizza pizza = new ThincrustPizza();
            Pizza cheeseTopping = new Cheese(pizza);
            cheeseTopping = new Cheese(cheeseTopping);
            Pizza oliveTopping = new Olives(cheeseTopping);
            oliveTopping = new Olives(oliveTopping);

            Console.WriteLine("주문 내역 : " + oliveTopping.getDescription());
            Console.WriteLine("주문 금액 : " + oliveTopping.cost() + "원");
        }
    }
}
