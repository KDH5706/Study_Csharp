using System;
using System.Collections;

namespace Ex6ForClass
{
    abstract class Pizza
    {
        protected string name;
        protected string dough;
        protected string sauce;
        protected ArrayList toppings = new ArrayList();

        public string getName()
        {
            return name;
        }

        public void prepare()
        {
            Console.WriteLine("준비 중 " + name);
        }

        public void bake()
        {
            Console.WriteLine("굽는 중 " + name);
        }

        public void cut()
        {
            Console.WriteLine("자르는 중 " + name);
        }

        public void box()
        {
            Console.WriteLine("포장 중 " + name);
        }

        public void printOrderDetails()
        {
            string orderToppings = null;

            Console.WriteLine();
            Console.WriteLine($"피자명 : {this.name}, 도우 : {this.dough}, " +
                $"소스 : {this.sauce}");

            foreach (string topping in this.toppings)
                orderToppings = orderToppings + ", " + topping;

            Console.WriteLine($"토핑 : {orderToppings}");
        }
    }

    class CheesePizza : Pizza
    {
        public CheesePizza()
        {
            this.name = "치즈 피자";
            this.dough = "보통 크러스트";
            this.sauce = "토마토";
            this.toppings.Add("모짜렐라");
            this.toppings.Add("파마산");
        }
    }

    class PepperoniPizza : Pizza
    {
        public PepperoniPizza()
        {
            this.name = "페퍼로니 피자";
            this.dough = "크러스트";
            this.sauce = "마리나 소스";
            this.toppings.Add("페퍼로니 조각");
            this.toppings.Add("양파 조각");
            this.toppings.Add("파마산 치즈");
        }
    }

    class VeggiePizza : Pizza
    {
        public VeggiePizza()
        {
            this.name = "야채 피자";
            this.dough = "크러스트";
            this.sauce = "마리나 소스";
            this.toppings.Add("버섯 조각");
            this.toppings.Add("매운 고추 조각");
            this.toppings.Add("블랙 올리버");
        }
    }

    class PizzaStore
    {
        PizzaFactory factory;

        public PizzaStore(PizzaFactory factory)
        {
            this.factory = factory;
        }

        public Pizza order(string type)
        {
            Pizza pizza = null;

            pizza = factory.createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();

            return pizza;
        }
    }

    class PizzaFactory
    {
        public Pizza createPizza(string type)
        {
            Pizza pizza = null;

            if ("cheese".Equals(type))
                pizza = new CheesePizza();
            else if ("pepperoni".Equals(type))
                pizza = new PepperoniPizza();
            else if ("veggie".Equals(type))
                pizza = new VeggiePizza();

            return pizza;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            PizzaFactory factory = new PizzaFactory();

            PizzaStore store = new PizzaStore(factory);

            Pizza cheesePizza = store.order("cheese");
            cheesePizza.printOrderDetails();

            Console.WriteLine();

            Pizza pepperoniPizza = store.order("pepperoni");
            pepperoniPizza.printOrderDetails();
        }
    }
}
