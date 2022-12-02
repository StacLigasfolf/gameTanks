using System;

namespace Game
{
    class Items
    {
        public int armor;
        public double health;
        public int bullet;
        public double domage;

        public Items(int armor, double health, int bullet, double domage)
        {
            this.armor = armor;
            this.health = health;
            this.bullet = bullet;
            this.domage = domage;
        }

        /* Функция регистрации урона и изменения ЗДОРОВЬЯ, ПАТРОНОВ, УРОНА
         Дублирующиеся (Console.WriteLine) чисто для красоты и удобства пользователя*/
        public void Shooting(int bullet, double domage)
        {
            // Диапазон вероятности промаха
            Random rndprobability = new Random();
            int probability = rndprobability.Next(0, 101);
            // Диапазон вероятности критического урона
            Random randDomage = new Random();
            int probabilityDomage = randDomage.Next(0, 101);

            if (probability >= 80)
            {
                Console.WriteLine("ВЫ ПРОМАХНУЛИСЬ");
                this.bullet -= 1;
                Console.WriteLine($"ПАТРОНЫ: {this.bullet}");
            }
            // Условие вероятности критического урона
            else if (probabilityDomage >= 90)
            {
                this.bullet -= 1;
                this.health = this.health - this.domage + this.armor;
                this.domage += this.domage * 0.2;

                Console.WriteLine("*******************************************************************");
                if (this.armor < 7)
                {
                    this.armor += 1;
                }
                Console.WriteLine("Броня противника: " + this.armor);
                Console.WriteLine($"КРИТИЧЕСКИЙ УРОН: {this.domage}");
                Console.WriteLine($"Ваш УРОН теперь: {this.domage}");
                Console.WriteLine($"У оппонента {this.health}hp");
                Console.WriteLine($"ПАТРОНЫ: {this.bullet}");
            }
            else if (this.bullet == 0)
            {
                Console.WriteLine("У ВАС НЕТ БОЕПРИПАСОВ!!!");
            }
            else
            {
                this.bullet -= 1;
                this.health = this.health - domage + this.armor;
                Console.WriteLine("*******************************************************************");
                if (this.armor < 7)
                {
                    this.armor += 1;
                }
                Console.WriteLine("Броня противника: " + this.armor);
                Console.WriteLine($"Урон: {domage}");
                Console.WriteLine($"У оппонента {this.health}hp");
                Console.WriteLine($"ПАТРОНЫ: {this.bullet}");
            }
        }

        /* Функция лечения принимающая случайное количество hp и прибовляет его к текущему
        Так-же установлен предел для значения health в 100 */
        public void Mending(double health, int hp)
        {
            if (this.health + hp > 100)
            {
                this.health = 100;
                Console.WriteLine($"Вылечился до {this.health} hp");
            }
            else
            {
                this.health = health + hp;
                Console.WriteLine($"Вылечился до {this.health} hp");
            }
        }

        /* Функция покупки патронов, прибовляет у текущему значению случайное в определенном диапазоне*/
        public void ByBullet(int bullet)
        {
            this.bullet += bullet;
            Console.WriteLine($"куплено {bullet} боеприпасов, ОБЩЕЕ КОЛИЧЕСТВО: {this.bullet} ");
        }

        class Program
        {
            public static void Main(string[] args)
            {
                Items tank = new Items(4, 100, 10, 15);
                Items robot = new Items(4, 100, 10, 15);
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
                                Console.WriteLine("\n**************************** ХОД ТАНКА ****************************\n");
                                Console.WriteLine("1. Огонь \n2. Ремонт\n3. Купить патроны");
                                int user = Convert.ToInt32(Console.ReadLine());
                                // Выстрел
                                if (user == 1)
                                {
                                    Console.WriteLine($"ЗДОРОВЬЕ: {tank.health}");
                                    robot.Shooting(tank.bullet, robot.domage);
                                }
                                // Лечение
                                else if (user == 2)
                                {
                                    Random appHeals = new Random();
                                    int hp = appHeals.Next(5, 18);
                                    tank.Mending(tank.health, hp);
                                }
                                // Покупка припасов
                                else if (user == 3)
                                {
                                    Random bul = new Random();
                                    int bullet = bul.Next(1, 4);
                                    robot.ByBullet(bullet);
                                }
                                Console.WriteLine("\n************************ ХОД ТАНКА ЗАКОНЧЕН ***********************\n");
                                move = !move;
                                break;
                            // false - ход робота
                            case false:
                                Console.WriteLine("\n**************************** ХОД РОБОТА ***************************\n");
                                Random choose = new Random();
                                int choosed = choose.Next(1, 4);
                                // Выстрел противника
                                if (choosed == 1)
                                {
                                    Console.WriteLine($"HP: {robot.health}");
                                    tank.Shooting(robot.bullet, tank.domage);
                                }
                                // Лечение противника
                                else if (choosed == 2)
                                {
                                    Random appHeals = new Random();
                                    int hp = appHeals.Next(5, 18);
                                    robot.Mending(robot.health, hp);
                                }
                                // Покупка припасов противника
                                else if (choosed == 3)
                                {
                                    Random bul = new Random();
                                    int bullet = bul.Next(1, 4);
                                    tank.ByBullet(bullet);
                                }
                                Console.WriteLine("\n************************ ХОД РОБОТА ЗАКОНЧЕН **********************\n");
                                move = true;
                                break;
                        }
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("ПОЖАЛУЙСТА ИСПОЛЬЗУЙТЕ ТОЛЬКО ЗНАЧЕНИЯ ИЗ ПРЕДЛОЖЕННЫХ!!!!");
                    }


                }

            }

        }
    }
}