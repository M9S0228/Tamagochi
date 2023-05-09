using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace Tamagochi
{
    public delegate void Tamagotchi();
    public class Zver
    {
        public string name { get; set; }
        public int hp { get; set; }
       
        public override string ToString()
        {
            return $"Name: {name} | HP: {hp}";
        }
        public void GetHp()
        {
            Console.WriteLine($"HP: {hp}");
        }
        public void Ill()
        {
            if (hp < 10)
            {
                Console.WriteLine("\nDino захворiв  (ʘᗩʘ')");
                Console.WriteLine("Вилiкувати: 1 - Yes | 0 - No");
                int s = Convert.ToInt32(Console.ReadLine());
                if (s == 1)
                {
                    hp = 100;
                    Console.WriteLine("Dino здоровий (づ￣ ³￣)づ");
                }
                else
                {
                    Console.WriteLine("Dino помер (x_x)");
                    Console.WriteLine("\nВоскресити Dino? 1 - Yes | 2 - No");
                    int s2 = Convert.ToInt32(Console.ReadLine());
                    if (s2 == 1)
                    {
                        hp = 100;
                        Console.WriteLine("Dino знову живий (づ￣ ³￣)づ");
                    }
                    else
                    {
                        Console.WriteLine("Dino помер остаточно (-_-Q)");
                    }
                }
            }
        }
        public void Eat()
        {
            Console.WriteLine("\nDino хоче їсти (^.^)");
            Console.WriteLine("Покормити: 1 - Yes | 0 - No");
            int s = Convert.ToInt32(Console.ReadLine());
            if (s == 1)
            {
                hp = 100;
                Console.WriteLine("Dino ситий (=_=)");
            }
            if (s == 0)
            {
                hp -= 33;
                Console.WriteLine("Dino голодний (o)_(o)");
            }
            if (hp < 10)
            {
                Ill();
            }

        }
        public void Sleep()
        {
            Console.WriteLine("\nDino хоче спати (─‿‿─)");
            Console.WriteLine("Покласти спати: 1 - Yes | 0 - No");
            int s = Convert.ToInt32(Console.ReadLine());
            if (s == 1)
            {
                hp = 100;
                Console.WriteLine("Dino виспався ᕦ(ò_óˇ)ᕤ");
            }
            else
            {
                hp -= 33;
                Console.WriteLine("Dino соний (~.~)");
            }
            if (hp < 10)
            {
                Ill();
            }
        }
        public void Walk()
        {
            Console.WriteLine("\nDino хоче гуляти (╯°□°)╯");
            Console.WriteLine("Погуляти: 1 - Yes | 0 - No");
            int s = Convert.ToInt32(Console.ReadLine());
            if (s == 1)
            {
                hp = 100;
                Console.WriteLine("Dino добрий (◕‿◕)");
            }
            else
            {
                hp -= 33;
                Console.WriteLine("Dino злий ┌(ಠ_ಠ)┘");
            }
            if (hp < 10)
            {
                Ill();
            }
        }
        public void Play()
        {
            Console.WriteLine("\nDino хоче пограти (>^_^)> <(^_^<)");
            Console.WriteLine("Погратися: 1 - Yes | 0 - No");
            int s = Convert.ToInt32(Console.ReadLine());
            if (s == 1)
            {
                hp = 100;
                Console.WriteLine("Dino довольний (♡-_-♡)");
            }
            else
            {
                hp -= 33;
                Console.WriteLine("Dino скоро нас заб'є  (╬ Ò_Ó)");
            }
            if (hp < 10)
            {
                Ill();
            }
        }
    }
    class Program
    {
        private delegate void RandomTamagotchi();
        static void Main(string[] args)
        {
            Zver dino = new Zver()
            {
                name = "Dino",
                hp = 100
            };
            Tamagotchi tamagotchi = null;
            Console.WriteLine(dino.ToString());

            List<RandomTamagotchi> tm = new List<RandomTamagotchi>();
            tm.Add(dino.Eat);
            tm.Add(dino.Sleep);
            tm.Add(dino.Walk);
            tm.Add(dino.Play);
            tm.Add(dino.Ill);

            while (true)
            {
                Random rand = new Random();
                tm[rand.Next(0, 5)]();
                while (dino.hp < 9)
                {
                    var Option = Console.ReadLine();
                    switch (int.Parse(Option))
                    {
                        case 1:
                            tamagotchi = dino.Eat;
                            break;
                        case 2:
                            tamagotchi = dino.Sleep;
                            break;
                        case 3:
                            tamagotchi = dino.Walk;
                            break;
                        case 4:
                            tamagotchi = dino.Play;
                            break;
                        case 5:
                            Console.WriteLine(dino.hp);
                            tamagotchi = dino.Ill;
                            break;
                        default:
                            break;
                    }
                }
            }

            Console.Read();

            
        }
        
        
    }
}
