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

        public void PrintInfo(Items personal, Items enemy)
        {
            Console.WriteLine($"ЗДОРОВЬЕ: {personal.health}");
            Console.WriteLine("/////////////////////////////////");
            Console.WriteLine($"БРОНЯ ПРОТИВНИКА: {personal.armor}");
            Console.WriteLine($"УРОН: {personal.domage}");
            Console.WriteLine($"ПАТРОНЫ: {personal.bullet}");
        }

        /* Функция регистрации урона и изменения ЗДОРОВЬЯ, ПАТРОНОВ, УРОНА
         Дублирующиеся (Console.WriteLine) чисто для красоты и удобства пользователя*/
        public void Shooting(Items personal, Items enemy, Random random)
        {
            Console.WriteLine("ВЫСТРЕЛ!!!");
            // Диапазон вероятности промаха 
            int probability = random.Next(0, 101);

            if (probability >= 80)
            {
                personal.bullet -= 1;
                Console.WriteLine("ПРОМАХ!!!");
                PrintInfo(personal, enemy);
            }
            // Условие вероятности критического урона 
            else if (probability >= 90)
            {
                personal.bullet -= 1;
                enemy.health = enemy.health - personal.domage + personal.armor;
                personal.domage += personal.domage * 0.2;

                if (enemy.armor < 7)
                {
                    enemy.armor += 1;
                }

                Console.WriteLine($"КРИТИЧЕСКИЙ УРОН: + {personal.domage}");
                PrintInfo(personal, enemy);
            }
            else if (personal.bullet == 0)
            {
                Console.WriteLine("У ВАС НЕТ БОЕПРИПАСОВ!!!");
                PrintInfo(personal, enemy);
            }
            else
            {
                personal.bullet -= 1;
                enemy.health = enemy.health - enemy.domage + enemy.armor;

                if (enemy.armor < 7)
                {
                    enemy.armor += 1;
                }
                PrintInfo(personal, enemy);
            }

        }

        /* Функция лечения принимающая случайное количество hp и прибовляет его к текущему
        Так-же установлен предел для значения health в 100 */
        public void Mending(Items personal,Items enemy, int hp)
        {
            if (personal.health + hp > 100)
            {
                personal.health = 100;
                Console.WriteLine($"Вылечился до {personal.health} hp");
                PrintInfo(personal, enemy);
            }
            else
            {
                personal.health = personal.health + hp;
                Console.WriteLine($"Вылечился до {personal.health} hp");
                PrintInfo(personal, enemy);
            }
        }

        /* Функция покупки патронов, прибовляет у текущему значению случайное в определенном диапазоне*/
        public void ByBullet(int addBullet, Items personal, Items enemy)
        {
            personal.bullet += addBullet;
            Console.WriteLine($"куплено {addBullet} боеприпасов");
            PrintInfo(personal, enemy);
        }

        // Функция хода
        public void Steps(Items personal, Items enemy, int step, Random random)
        {
            if(step == 1)
            {
                personal.Shooting(personal, enemy, random);
            }else if(step == 2) 
            {
                int hp = random.Next(5, 10);
                personal.Mending(personal, enemy, hp);
            }else if(step == 3)
            {
                int bullets = random.Next(1, 4);
                personal.ByBullet(bullets, personal, enemy);
            }
        }

        class Program
        {
            public static void Main(string[] args)
            {
                Items tank = new(4, 100, 10, 20);
                Items robot = new(4, 100, 10, 20);
                Random random = new();

                bool move = true;
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
                        switch (move)
                        {   
                            case true:

                                Console.WriteLine("***************************** ТАНК *****************************");
                                Console.WriteLine("1. Огонь \n2. Ремонт\n3. Купить патроны");
                                int step = Convert.ToInt32(Console.ReadLine());
                                tank.Steps(tank, robot, step, random);
                                move = !move;
                                break;

                            case false:

                                Console.WriteLine("***************************** РОБОТ *****************************");
                                int steps = random.Next(1, 4);
                                robot.Steps(robot, tank, steps, random);
                                move = true;
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