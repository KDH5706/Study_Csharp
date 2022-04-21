using System;

namespace AbstractClass
{
    abstract class AbstractBase
    {
        protected void PrivateMethodA()
        {
            Console.WriteLine("AbstractBase.PrivateMethodA()");
        }

        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }

        public abstract void AbstractMethodA();
    }

    class Dervied : AbstractBase
    {
        public override void AbstractMethodA()
        {
            Console.WriteLine("Dervied.PrivateMethodA()");
            PrivateMethodA();
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            AbstractBase obj = new Dervied();
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }
    }
}
