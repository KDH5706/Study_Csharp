﻿using System;
using System.Collections;

namespace Ex1ForClass
{
    class Product
    {
        private string proName;
        private int price;
        private int bonusPoint;

        public Product(string proName, int price)
        {
            this.proName = proName;
            this.price = price;
            bonusPoint = (int)(price / 10.0);
        }

        public string getProName()
        {
            return this.proName;
        }

        public int getPrice()
        {
            return this.price;
        }

        public int getBonusPoint()
        {
            return this.bonusPoint;
        }
    }

    class Tv : Product
    {
        public Tv(int price) : base("TV", price)
        {
            Console.WriteLine("Tv() 생성자 호출됨.");
        }
    }

    class Computer : Product
    {
        public Computer(int price) : base("Computer", price)
        {
            Console.WriteLine("Computer() 생성자 호출됨.");
        }
    }

    class Audio : Product
    {
        public Audio(int price) : base("Audio", price)
        {
            Console.WriteLine("Audio() 생성자 호출됨.");
        }
    }

    class Buyer
    {
        private int money;
        private int bonusPoint = 0;
        ArrayList buyItemList = new ArrayList();

        public Buyer(int money)
        {
            this.money = money;
        }

        public void buy(Product product)
        {
            if (this.money < product.getPrice())
            {
                Console.WriteLine("잔액이 부족하여 물건을 살수 없습니다.");
                return;
            }

            money -= product.getPrice();
            bonusPoint += product.getBonusPoint();
            buyItemList.Add(product);

            Console.WriteLine(product.getProName() + "를 구입하셨습니다.");
            Console.WriteLine($"보너스 포인트는 {bonusPoint} 입니다.");
            Console.WriteLine($"잔액은 {money} 입니다.");
        }

        public void summary()
        {
            int sum = 0;
            String itemList = "";

            foreach (Product product in this.buyItemList)
            {
                sum += product.getPrice();
                itemList += product.getProName() + ", ";
            }

            Console.WriteLine($"구입하신 물품의 총금액은 {sum} 만원입니다.");
            Console.WriteLine($"구입하신 제품은 {itemList} 입니다.");
        }

    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Buyer b = new Buyer(300);

            b.buy(new Tv(100));
            Console.WriteLine();

            b.buy(new Computer(200));
            Console.WriteLine();

            b.buy(new Audio(50));
            Console.WriteLine();

            b.summary();
        }
    }
}
