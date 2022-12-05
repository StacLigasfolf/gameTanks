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
            Console.WriteLine("ВЫСТРЕЛ!!!");
            Console.WriteLine("/////////////////////////////////");
            Console.WriteLine($"БРОНЯ ПРОТИВНИКА: {personal.armor}");
            Console.WriteLine($"УРОН: {personal.domage}");
            Console.WriteLine($"ПАТРОНЫ: {personal.bullet}");
        }

        /* Функция регистрации урона и изменения ЗДОРОВЬЯ, ПАТРОНОВ, УРОНА
         Дублирующиеся (Console.WriteLine) чисто для красоты и удобства пользователя*/
        public void Shooting(Items personal, Items enemy, Random random)
        {
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

        // Human
        public void StepHuman(Items tank, Items robot, int step, Random random)
        {
            Console.WriteLine("\n**************************** ХОД ТАНКА ****************************\n");
            // Выстрел
            if (step == 1)
            {
                tank.Shooting(tank, robot, random);
            }
            // Лечение
            else if (step == 2)
            {
                int hp = random.Next(5, 10);
                tank.Mending(tank, robot, hp);
            }
            // Покупка припасов
            else if (step == 3)
            {
                int bullets = random.Next(1, 4);
                tank.ByBullet(bullets, tank, robot);
            }
        }

        // Robot
        public void StepRobot(Items tank, Items robot, Random random)
        {
            Console.WriteLine("\n**************************** ХОД РОБОТА ***************************\n");
            int choosed = random.Next(1, 4);
            // Выстрел противника 
            if (choosed == 1)
            {
                robot.Shooting(robot, tank, random);
            }
            // Лечение противника 
            else if (choosed == 2)
            {
                int hp = random.Next(5, 18);
                robot.Mending(robot, tank, hp);
            }
            // Покупка припасов противника 
            else if (choosed == 3)
            {
                int bullets = random.Next(1, 4);
                tank.ByBullet(bullets, robot, tank);
            }
            Console.WriteLine("\n*******************************************************************\n");
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
                        {   // true - ход человека
                            case true:

                                Console.WriteLine("1. Огонь \n2. Ремонт\n3. Купить патроны");
                                int step = Convert.ToInt32(Console.ReadLine());
                                tank.StepHuman(tank, robot, step, random);
                                move = !move;
                                break;

                            // false - ход робота
                            case false:
                                robot.StepRobot(tank, robot, random);
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