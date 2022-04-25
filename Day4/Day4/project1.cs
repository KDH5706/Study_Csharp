using System;

namespace project1
{
    abstract class Product
    {
        private int price;
        private int bonus;
        private string kind;

        public void setPrice(int p)
        {
            price = p;
        }

        public int getPrice
        {
            get { return price; }
        }

        public void setBonus(int b)
        {
            bonus = b;
        }

        public int getBonus
        {
            get { return bonus; }
        }

        public void setKind(string k)
        {
            kind = k;
        }

        public string getKind
        {
            get { return kind; }
        }

        abstract public void printLog();
    }

    class Customer
    {
        private int budget;
        private int bonus = 0;
        private int purchasedPrice = 0;
        private int purchasedAmt = 0;                     //구매한 물품의 개수(밑 배열의 인덱스값)
        private string[] purchased = new string[10];      //구매 목록 저장할 배열

        public Customer(int bg)
        {
            budget = bg;
        }

        public int getBudget
        {
            get { return budget; }
        }

        public int getBonus
        {
            get { return bonus; }
        }

        public int getPurchasedPrice
        {
            get { return purchasedPrice; }
        }

        public string[] getPurchased
        {
            get { return purchased; }
        }

        public void addPurchased(Product obj)
        {
            //소유 금액보다 제품이 비쌀 경우 return
            if (budget < obj.getPrice)
            {
                Console.WriteLine("소유 금액보다 비싼 제품을 구매할 수 없습니다.");
                return;
            }

            string kind = obj.getKind;

            budget -= obj.getPrice;
            bonus += obj.getBonus;
            purchasedPrice += obj.getPrice;

            purchased[purchasedAmt] = kind;
            purchasedAmt++;

            //뭘 샀는지 로그 출력 위해 kind 체크........코드 개더러움
            if (kind.Equals("TV"))
            {
                TV tv = (TV)obj;
                tv.printLog();
            }
            else if (kind.Equals("Computer"))
            {
                Computer computer = (Computer)obj;
                computer.printLog();
            }
            else if (kind.Equals("Audio"))
            {
                Audio audio = (Audio)obj;
                audio.printLog();
            }
        }
    }

    class TV : Product
    {
        public TV(int price, int bonus)
        {
            base.setKind("TV");
            base.setPrice(price);
            base.setBonus(bonus);
        }

        public override void printLog()
        {
            Console.WriteLine("TV를 구입하셨습니다.");
        }
    }

    class Computer : Product
    {
        public Computer(int price, int bonus)
        {
            base.setKind("Computer");
            base.setPrice(price);
            base.setBonus(bonus);
        }

        public override void printLog()
        {
            Console.WriteLine("Computer를 구입하셨습니다.");
        }
    }

    class Audio : Product
    {
        public Audio(int price, int bonus)
        {
            base.setKind("Audio");
            base.setPrice(price);
            base.setBonus(bonus);
        }

        public override void printLog()
        {
            Console.WriteLine("Audio를 구입하셨습니다.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //상품정보 객체 생성
            Product tv1 = new TV(6000, 10);
            Product computer1 = new Computer(1200, 12);
            Product audio1 = new Audio(500, 5);

            //고객 객체 생성
            Customer cus1 = new Customer(5000);

            //구매
            cus1.addPurchased(tv1);
            cus1.addPurchased(computer1);
            cus1.addPurchased(audio1);

            Console.WriteLine("구입하신 물품의 총금액은 {0}만원입니다.", cus1.getPurchasedPrice);
            Console.Write("구입하신 제품은 ");
            for (int i = 0; i < cus1.getPurchased.Length; i++)
            {
                if (string.IsNullOrEmpty(cus1.getPurchased[i]))
                {
                    break;
                }
                Console.Write("{0}, ", cus1.getPurchased[i]);
            }
            Console.WriteLine("입니다.");
        }
    }
}