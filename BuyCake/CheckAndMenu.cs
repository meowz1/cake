using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyCake
{
    internal class CheckAndMenu
    {
        public static void MenuMain(int pose, Cake priceCake)
        {
            Console.WriteLine("Приветствуем в кондитерской, выберете параметры для тортика");
            Console.WriteLine("....................................................");
            Console.WriteLine("   Форма");
            Console.WriteLine("   Размер");
            Console.WriteLine("   Вкус");
            Console.WriteLine("   Количество");
            Console.WriteLine("   Глазурь");
            Console.WriteLine("   Декор");
            Console.WriteLine("   Конец заказа");
            Console.WriteLine();
            Console.WriteLine("Цена: " + priceCake.price + " шекелей");
            Console.WriteLine($"Ваш заказ: {priceCake.price} {priceCake.size} {priceCake.form} {priceCake.count}\t {priceCake.glaze} {priceCake.decor} {priceCake.taste}");
        }

        public static Cake checkMenu(int pose, Cake ck)
        {
            Dictionary<string, int> l1 = new Dictionary<string, int> { { "Треугольный", 300 }, { "Квадратный", 310 }, { "Круглый", 290 } };
            Dictionary<string, int> l2 = new Dictionary<string, int> { { "60 см", 3000 }, { "40 см", 2100 }, { "30 см", 1900 } };
            Dictionary<string, int> l3 = new Dictionary<string, int> { { "Клубника", 500 }, { "Шоколад", 400 }, { "Ваниль", 450 } };
            Dictionary<string, int> l4 = new Dictionary<string, int> { { "Розовая", 500 }, { "Чёрная", 500 }, { "Жёлтая", 500 } };
            Dictionary<string, int> l5 = new Dictionary<string, int> { { "Звёздочки", 100 }, { "Квыдратики", 100 } };
            switch (pose)
            {
                case 2:
                    Console.Clear();
                    ck = spawnForm(ck, l1, pose);
                    break;
                case 3:
                    Console.Clear();
                    ck = spawnForm(ck, l2, pose);
                    break;
                case 4:
                    Console.Clear();
                    ck = spawnForm(ck, l3, pose);
                    break;
                case 5:
                    ck = col(ck);
                    break;
                case 6:
                    Console.Clear();
                    ck = spawnForm(ck, l4, pose);
                    break;
                case 7:
                    Console.Clear();
                    ck = spawnForm(ck, l5, pose);
                    break;
                case 8:
                    ck = check(ck);
                    break;

            }
            return ck;
        }

        [STAThread]
        private static Cake check(Cake ck)
        {
            if (ck.price == 0)
            {
                Console.WriteLine("Вы ещё не выбрали ни одного пункта меню");
                return ck;
            }
            Console.Clear();
            string check = $"Заказ от: {DateTime.Now} \n Заказ: {ck.size} {ck.form} {ck.count} {ck.glaze} {ck.decor} {ck.taste} \n Цена: {ck.price * ck.count}";
            Console.WriteLine("Введите название файл:");
            string puti = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string put1 = Directory.GetCurrentDirectory().Substring(0, 36);

            string sav = Console.ReadLine();



            File.WriteAllText($"{puti}/{sav}", check);

            File.AppendAllText($"{put1}/allCheck.txt", $"\n ...................");
            File.AppendAllText($"{put1}/allCheck.txt", $"\n {check}");

            ck.price = 0;
            ck.form = "";
            ck.count = 1;
            ck.glaze = "";
            ck.size = "";
            ck.decor = "";
            ck.taste = "";
            return ck;
        }


        private static Cake col(Cake ck)
        {
            if (ck.price == 0)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Вы ещё не выбрали ни одного элемента, нажмите Esc, что бы выйти в меню");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }

                }
                return ck;
            }

            Console.Clear();
            Console.WriteLine("Введите количество тортов:");
            int colT = Convert.ToInt32(Console.ReadLine());
            ck.count = colT;



            return ck;
        }

        public static Cake spawnForm(Cake ck, Dictionary<string, int> form, int myPose)
        {
            int pose = 2;
            int lastPose = form.Count() + 1;
            int rasn = lastPose - pose;
            var keys = form.Keys;
            Dictionary<int, Dictionary<string, int>> price = new Dictionary<int, Dictionary<string, int>>();
            int count = 2;



            foreach (string zn in keys)
            {

                price.Add(count, new Dictionary<string, int> { { zn, form[zn] } });
                count++;
            }



            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (pose <= 2)
                    {
                        pose += rasn;
                    }
                    else
                    {
                        pose--;
                    }

                }
                else if (key.Key == ConsoleKey.DownArrow)
                {

                    if (pose >= lastPose)
                    {
                        pose -= rasn;
                    }
                    else
                    {
                        pose++;
                    }

                }

                else if (key.Key == ConsoleKey.Enter)
                {
                    var f1 = price[pose];
                    string key1 = "";
                    foreach (var i in f1.Keys)
                    {
                        key1 = i;
                    }

                    switch (myPose)
                    {
                        case 2:
                            if (ck.form != "")
                            {

                                ck.price -= form[ck.form];
                                ck.price += f1[key1];
                                ck.form = key1;
                            }
                            else if (ck.form == "")
                            {
                                ck.price += f1[key1];
                                ck.form = key1;
                            }
                            break;
                        case 3:
                            if (ck.size != "")
                            {

                                ck.price -= form[ck.size];
                                ck.price += f1[key1];
                                ck.size = key1;
                            }
                            else
                            {
                                ck.price += f1[key1];
                                ck.size = key1;
                            }
                            break;
                        case 4:
                            if (ck.taste != "")
                            {

                                ck.price -= form[ck.taste];
                                ck.price += f1[key1];
                                ck.taste = key1;
                            }
                            else
                            {
                                ck.price += f1[key1];
                                ck.taste = key1;
                            }
                            break;
                        case 6:
                            if (ck.glaze != "")
                            {

                                ck.price -= form[ck.glaze];
                                ck.price += f1[key1];
                                ck.glaze = key1;
                            }
                            else
                            {
                                ck.price += f1[key1];
                                ck.glaze = key1;
                            }
                            break;
                        case 7:
                            if (ck.decor != "")
                            {
                                ck.price -= form[ck.decor];
                                ck.price += f1[key1];
                                ck.decor = key1;
                            }
                            else
                            {
                                ck.price += f1[key1];
                                ck.decor = key1;
                            }
                            break;

                    }

                    break;
                }

                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.Clear();
                switch (myPose)
                {
                    case 2:
                        Console.WriteLine("Выберите форму");
                        break;
                    case 3:
                        Console.WriteLine("Выберите размер");
                        break;
                    case 4:
                        Console.WriteLine("Выберите вкус");
                        break;
                    case 6:
                        Console.WriteLine("Выберите глазурь");
                        break;
                    case 7:
                        Console.WriteLine("Выберите декор");
                        break;

                }
                Console.WriteLine("..........................");
                foreach (var znach in form)
                {
                    Console.WriteLine($"   {znach.Key} - {znach.Value} шекелей");
                }
                Console.SetCursorPosition(0, pose);
                Console.Write("->");
            }
            return ck;
        }
    }
}
