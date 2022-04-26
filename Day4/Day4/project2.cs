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
        void lift_object(int zpos)
        {
            Console.WriteLine("이륙~");
        }
        void move_object(int xpos, int ypos)
        {
            Console.WriteLine("이동~");
        }
        void land_object()
        {
            Console.WriteLine("착륙~");
        }
        void stop_object()
        {
            Console.WriteLine("정지~");
        }
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
        public string GetName()
        {
            return Name;
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
        private int Xpos;
        private int Ypos;
        private int Zpos;

        public Building(string Unit_Type, int Max_Hp, string Name)
             : base(Unit_Type, Max_Hp, Name)
        {

        }
        public void Set_Position(int Xpos, int Ypos, int Zpos)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.Zpos = Zpos;
        }
        public void Get_Position()
        {
            Console.WriteLine(GetName());
            Console.WriteLine($"위치 : X({Xpos}) Y({Ypos}) Z({Zpos})\n");
        }
        public int Get_Xpos()
        {
            return Xpos;
        }
        public int Get_Ypos()
        {
            return Ypos;
        }
        public int Get_Zpos()
        {
            return Zpos;
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
        public Bunker()
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

        public void lift_object(int zpos)
        {
            Console.Write("이륙! ");
            int Zpos = Get_Zpos();
            Zpos += zpos;
            Set_Position(Get_Xpos(), Get_Ypos(), Zpos);
            Get_Position();
        }
        public void move_object(int xpos, int ypos)
        {
            Console.Write("이동! ");
            int Xpos = Get_Xpos();
            Xpos += xpos;
            int Ypos = Get_Ypos();
            Ypos += ypos;
            Set_Position(Xpos, Ypos, Get_Zpos());
            Get_Position();

        }
        public void land_object()
        {
            Console.Write("착륙! ");

            Set_Position(Get_Xpos(), Get_Ypos(), 0);
            Get_Position();
        }
        public void stop_object()
        {
            Console.Write("정지! ");
            Set_Position(Get_Xpos(), Get_Ypos(), Get_Zpos());
            Get_Position();
        }

    }
    class Factory
        : Building, flyable
    {
        public Factory()
            : base("Mechanical", 1250, "Factory")
        {
        }

        public void lift_object(int zpos)
        {
            Console.Write("이륙! ");
            int Zpos = Get_Zpos();
            Zpos += zpos;
            Set_Position(Get_Xpos(), Get_Ypos(), Zpos);
            Get_Position();
        }
        public void move_object(int xpos, int ypos)
        {
            Console.Write("이동! ");
            int Xpos = Get_Xpos();
            Xpos += xpos;
            int Ypos = Get_Ypos();
            Ypos += ypos;
            Set_Position(Xpos, Ypos, Get_Zpos());
            Get_Position();

        }
        public void land_object()
        {
            Console.Write("착륙~ ");

            Set_Position(Get_Xpos(), Get_Ypos(), 0);
            Get_Position();
        }
        public void stop_object()
        {
            Console.Write("정지~ ");
            Set_Position(Get_Xpos(), Get_Ypos(), Get_Zpos());
            Get_Position();
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


            Factory factory = new Factory();
            factory.lift_object(100);
            factory.move_object(200, 100);
            factory.land_object();

            Barrack barrack = new Barrack();
            barrack.lift_object(10);
            barrack.move_object(30, 200);
            barrack.land_object();
        }
    }
}
