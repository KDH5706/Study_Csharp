using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace project2
{
    interface able_repair
    {

    }
    interface flyable
    {
        void lift_object(Unit obj);
        void move_object(Unit obj);
        void land_object(Unit obj);
        void stop_object(Unit obj);
    }

    class Unit
    {
        // Robotical or Mechanical or Biological or Cerebrate or SCV
        private string Unit_type;
        private int Max_Hp;
        private int Cur_Hp;
        private string Name;

        public Unit(string type, int Hp, string Name)
        {
            Unit_type = type;
            Max_Hp = Hp;
            Cur_Hp = Max_Hp;
            this.Name = Name;
        }

        public string GetUnitType()
        {
            return Unit_type;
        }
        public int GetMaxHp()
        {
            return Max_Hp;
        }
        public int GetCurHp()
        {
            return Cur_Hp;
        }
        public void Repaired(int Hp)
        {
            Cur_Hp += Hp;
            Console.WriteLine($"수리를 받았습니다. ({Name})");
            Console.WriteLine($"현재 생명력 : {this.Cur_Hp}, 최대 생명력 : {this.Max_Hp}\n");
        }
        public void Damaged(int D)
        {
            Cur_Hp -= D;
            Console.WriteLine($"데미지를 받았습니다. ({Name})");
            Console.WriteLine($"현재 생명력 : {this.Cur_Hp}, 최대 생명력 : {this.Max_Hp}\n");
        }

    }

    class GroundUnit : Unit
    {
        public GroundUnit(string Unit_Type, int Max_Hp, string Name)
            : base(Unit_Type, Max_Hp, Name)
        {

        }
    }
    class AirUnit : Unit
    {
        public AirUnit(int Max_Hp, string Name)
            : base("Mechanical", Max_Hp, Name)
        {

        }
    }

    class Marine : GroundUnit
    {
        public Marine()
            : base("Biological", 50, "Marine")
        {
        }

    }
    class SCV : GroundUnit, able_repair
    {

        public SCV()
            : base("SCV", 60, "SCV")
        {
        }

        public void Repair(able_repair obj)
        {
            Unit unit = obj as Unit;
            if(unit != null)
            {
                if (unit.GetCurHp() < unit.GetMaxHp())
                {
                    unit.Repaired(1);
                }
                else
                {
                    Console.WriteLine("현재 생명력이 최대이므로 수리를 하지 않습니다.");
                    Console.WriteLine($"현재 생명력 : {unit.GetCurHp()}, 최대 생명력 : {unit.GetMaxHp()}");
                }
            }
        }
    }
    class Tank
        : GroundUnit, able_repair
    {

        public Tank()
            : base("Mechanical", 150, "Tank")
        {
        }

    }
    class Dropship
        : AirUnit, able_repair
    {

        public Dropship() : base(150, "Dropship")
        {
        }

    }

    class Building : Unit
    {
        public Building(string Unit_Type, int Max_Hp, string Name)
             : base(Unit_Type, Max_Hp, Name)
        {

        }
    }

    class Academy
        : Building
    {
        public Academy()
            : base("Mechanical", 600, "Academy")
        {
        }
    }
    class Bunker
        : Building
    {
        public Banker()
            : base("Mechanical", 350, "Bunker")
        {
        }
    }
    class Barrack
        : Building, flyable
    {
        public Barrack()
            : base("Mechanical", 1000, "Barrack")
        {
        }

    }
    class Factory
        : Building, flyable
    {
        public Factory()
            : base("Mechanical", 1250, "Factory")
        {
        }
    }



    class MainApp
    {
        static void Main(string[] args)
        {
            Marine marine = new Marine();
            SCV scv = new SCV();
            Tank tank = new Tank();
            Dropship dropship = new Dropship();

            marine.Damaged(1);
            tank.Damaged(1);
            dropship.Damaged(1);

            //scv.Repair(marine);
            scv.Repair(tank);
            scv.Repair(dropship);
        }
    }
}
