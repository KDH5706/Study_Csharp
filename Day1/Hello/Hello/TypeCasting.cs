using System;

namespace TypeCasting
{
    class Mammal
    {
        public void Nurse()
        {
            Console.WriteLine("Nurse()");
        }
    }

    class Dog : Mammal
    {
        public void Bark()
        {
            Console.WriteLine("Bark()");
        }
    }

    class Cat : Mammal
    {
        public void Meow()
        {
            Console.WriteLine("Meow()");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Dog();
            Dog dog;

            //is 연산자 : 객체가 해당 형식에 해당하는지 검사하여 그 결과를 bool 값으로 변환한다.
            if (mammal is Dog)
            {
                //Down Casting(부모클래스인 객체의 타입을 자식클래스의 객체의 타입으로 변경
                //자식의 매서드를 사용하기 위해서 Down Casting을 한다.
                dog = (Dog)mammal;
                dog.Bark();
            }

            //as 연산자 : 형식 변환 연산자와 같은 역활한다. 단, 형식 변환 실패 시 null로 변환한다.
            Mammal mammal2 = new Cat();
            Cat cat = mammal2 as Cat;  //mammal2를 Cat으로 캐스팅 (포유류(고양이)를 고양이로 변환 가능)
            if (cat != null)
                cat.Meow();

            Cat cat2 = mammal as Cat;  //mammal를 Cat으로 캐스팅 (포유류(개)를 고양이로 변환 불가 -> null로 변환)
            if (cat2 != null)
                cat2.Meow();
            else
                Console.WriteLine("cat2 is not a Cat");
        }
    }
}
