using System;

namespace Game
{

    class Items
    {
        public int armor;
        public double health;
        public int bullet;
        public double domage;

        public Items(int arm, double heal, int bull, double dom)
        {
            armor = arm;
            health = heal;
            bullet = bull;
            domage = dom;
        }
        enum UnitStep 
        { 
            human,
            robot  
        }

        public void PrintInfo(Items personal)
        {
            Console.WriteLine($"ЗДОРОВЬЕ: {personal.health}");
            Console.WriteLine("/////////////////////////////////");
            Console.WriteLine($"БРОНЯ ПРОТИВНИКА: {personal.armor}");
            Console.WriteLine($"УРОН: {personal.domage}");
            Console.WriteLine($"ПАТРОНЫ: {personal.bullet}");
        }

        public void DamageOrginazer(Items personal, Items enemy)
        {
            personal.bullet -= 1;
            enemy.health = enemy.health - personal.domage + personal.armor;
            personal.domage += personal.domage * 0.2;

            if (enemy.armor < 7)
            {
                enemy.armor += 1;
            }

            Console.WriteLine($"КРИТИЧЕСКИЙ УРОН: + {personal.domage}");
        }

        /* Функция регистрации урона и изменения ЗДОРОВЬЯ, ПАТРОНОВ, УРОНА
         Дублирующиеся (Console.WriteLine) чисто для красоты и удобства пользователя*/
        public void Shooting(Items personal, Items enemy, Random random)
        {
            Console.WriteLine("ВЫСТРЕЛ!!!");
            // Диапазон вероятности промаха 


            if (random.Next(0, 101) >= 80)
            {
                personal.bullet -= 1;
                Console.WriteLine("ПРОМАХ!!!");
                PrintInfo(personal);
            }
            // Условие вероятности критического урона 
            else if (random.Next(0, 101) >= 90)
            {
                DamageOrginazer(personal, enemy);
                PrintInfo(personal);
            }
            else if (personal.bullet - 1 < 0)
            {
                Console.WriteLine("У ВАС НЕТ БОЕПРИПАСОВ!!!");
                PrintInfo(personal);
            }
            else
            {
                personal.bullet -= 1;
                enemy.health = enemy.health - enemy.domage + enemy.armor;

                if (enemy.armor < 7)
                {
                    enemy.armor += 1;
                }
                PrintInfo(personal);
            }

        }

        /* Функция лечения принимающая случайное количество hp и прибовляет его к текущему
        Так-же установлен предел для значения health в 100 */
        public void Mending(Items personal, int hp)
        {
            if (personal.health + hp >= 100)
            {
                personal.health = 100;
                Console.WriteLine($"У ВАС ПОЛНОЕ ЗДОРОВЬЕ!!!");
                PrintInfo(personal);
            }
            else
            {
                personal.health += hp;
                Console.WriteLine($"+{hp} hp");
                PrintInfo(personal);
            }
        }

        /* Функция покупки патронов, прибовляет у текущему значению случайное в определенном диапазоне*/
        public void ByBullet(int addBullet, Items personal)
        {
            personal.bullet += addBullet;
            Console.WriteLine($"+{addBullet} ПАТРОНОВ");
            PrintInfo(personal);
        }

        // Функция хода
        public void Steps(Items personal, Items enemy, int step, Random random)
        {
            switch (step)
            {
                case 1:
                    personal.Shooting(personal, enemy, random);
                    break;
                case 2:
                    int hp = random.Next(5, 10);
                    personal.Mending(personal, hp);
                    break;
                case 3:
                    int bullets = random.Next(1, 4);
                    personal.ByBullet(bullets, personal);
                    break;
            }
        }

        class Program
        {
            public static void Main(string[] args)
            {
                Items tank = new(4, 100, 10, 20);
                Items robot = new(4, 100, 10, 20);

                UnitStep unit = new();
                Random random = new();

                
                // Основной цикл игры 
                while (true)
                {
                    // Условие для завершение игры
                    if (tank.health <= 0 && robot.health > tank.health)
                    {
                        Console.WriteLine("ВЫ ПРОИГРАЛИ :(");
                        break;
                    }
                    else if (tank.health > robot.health && robot.health <= 0)
                    {
                        Console.WriteLine("ПОЗДРАВЛЯЕМ, ВЫ ВЫИГРАЛИ :)");
                        break;
                    }
                    // Проверка корректности введенных пользователем данных
                    try
                    {
                        switch (unit)
                        {   
                            case UnitStep.human:

                                Console.WriteLine("***************************** ТАНК *****************************");
                                Console.WriteLine("1. Огонь \n2. Ремонт\n3. Купить патроны");
                                int step = Convert.ToInt32(Console.ReadLine());
                                tank.Steps(tank, robot, step, random);
                                goto case UnitStep.robot;                    
                                
                            case UnitStep.robot:

                                Console.WriteLine("***************************** РОБОТ *****************************");
                                int steps = random.Next(1, 4);
                                robot.Steps(robot, tank, steps, random);
                                break;

                            default:
                                break;
                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("ПОЖАЛУЙСТА ВЫБЕРИТЕ ПРАВИЛЬНОЕ ДЕЙСТВИЕ !!!");
                    }


                }

            }

        }
    }
}