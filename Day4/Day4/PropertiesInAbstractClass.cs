using System;

namespace PropertiesInAbstractClass
{
    //추상클래스 : 하나 이상의 추상메소드를 포함하고 있는 클래스
    abstract class Product
    {
        private static int serial = 0;
        public string SerialID
        {
            get { return String.Format("{0:d5}", serial++); }
        }

        //추상메소드 : 자식클래스에서 반드시 오버라이딩해야 사용가능한 메소드
        abstract public DateTime ProductDate    
        {
            get;
            set;
        }
    }

    class Myproduct : Product
    {
        public override DateTime ProductDate 
        { 
            get;
            set; 
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Product product_1 = new Myproduct()
            { ProductDate = new DateTime(2018, 1, 10) };

            Console.WriteLine("Product:{0}, Product Date :{1}",
                product_1.SerialID,
                product_1.ProductDate);

            Product product_2 = new Myproduct()
            { ProductDate = new DateTime(2018, 2, 3) };

            Console.WriteLine("Product:{0}, Product Date :{1}",
                product_2.SerialID,
                product_2.ProductDate);
        }
    }
}
