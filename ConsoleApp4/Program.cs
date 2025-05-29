using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    using System;

    namespace ProductApp
    {
        // Определяем структуру Product с необходимыми полями
        struct Product
        {
            public string Name;          // Наименование товара
            public string Manufacturer;  // Изготовитель
            public int Quantity;         // Количество
            public double Price;         // Цена за единицу
            public int Year;             // Год выпуска

            // Метод для вычисления общей стоимости товара
            public double TotalCost()
            {
                return Quantity * Price;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Введите количество товаров: ");
                int n = int.Parse(Console.ReadLine());

                if (n <= 0)
                {
                    Console.WriteLine("Нет данных для обработки.");
                    return;
                }

                Product[] products = new Product[n];

                // Ввод данных товаров
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nТовар #{i + 1}");

                    Console.Write("Наименование: ");
                    products[i].Name = Console.ReadLine();

                    Console.Write("Изготовитель: ");
                    products[i].Manufacturer = Console.ReadLine();

                    products[i].Quantity = ReadInt("Количество");

                    products[i].Price = ReadDouble("Цена");

                    products[i].Year = ReadInt("Год выпуска");
                }

                int currentYear = DateTime.Now.Year;

                // Задача 1: Определить общую стоимость товаров, выпущенных в текущем году
                double totalCostCurrentYear = 0;
                bool foundCurrentYearProducts = false;

                Console.WriteLine($"\nТовары, выпущенные в текущем году ({currentYear}):");
                Console.WriteLine("{0,-20} {1,-15} {2,10} {3,10} {4,10} {5,15}",
                    "Наименование", "Изготовитель", "Кол-во", "Цена", "Год", "Общ. стоимость");

                foreach (var product in products)
                {
                    if (product.Year == currentYear)
                    {
                        double cost = product.TotalCost();
                        totalCostCurrentYear += cost;
                        foundCurrentYearProducts = true;
                        Console.WriteLine("{0,-20} {1,-15} {2,10} {3,10:F2} {4,10} {5,15:F2}",
                            product.Name, product.Manufacturer, product.Quantity, product.Price, product.Year, cost);
                    }
                }

                if (!foundCurrentYearProducts)
                {
                    Console.WriteLine("Нет товаров, выпущенных в текущем году.");
                }
                else
                {
                    Console.WriteLine($"\nОбщая стоимость товаров текущего года: {totalCostCurrentYear:F2}");
                }

                // Задача 2: Найти товары с максимальной и минимальной общей стоимостью
                if (n == 0)
                {
                    Console.WriteLine("\nНет товаров для анализа стоимости.");
                    return;
                }

                double maxCost = products[0].TotalCost();
                double minCost = products[0].TotalCost();

                // Для хранения названий товаров с макс/мин стоимостью (может быть несколько)
                string maxCostNames = products[0].Name;
                string minCostNames = products[0].Name;

                for (int i = 1; i < n; i++)
                {
                    double cost = products[i].TotalCost();

                    if (cost > maxCost)
                    {
                        maxCost = cost;
                        maxCostNames = products[i].Name;
                    }
                    else if (cost == maxCost)
                    {
                        maxCostNames += ", " + products[i].Name;
                    }

                    if (cost < minCost)
                    {
                        minCost = cost;
                        minCostNames = products[i].Name;
                    }
                    else if (cost == minCost)
                    {
                        minCostNames += ", " + products[i].Name;
                    }
                }

                Console.WriteLine($"\nТовар(ы) с максимальной общей стоимостью ({maxCost:F2}): {maxCostNames}");
                Console.WriteLine($"Товар(ы) с минимальной общей стоимостью ({minCost:F2}): {minCostNames}");

                Console.ReadKey();
            }

            // Вспомогательный метод для корректного ввода целого числа
            static int ReadInt(string fieldName)
            {
                int value;
                while (true)
                {
                    Console.Write($"{fieldName}: ");
                    if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    {
                        return value;
                    }
                    Console.WriteLine("Некорректный ввод. Введите неотрицательное целое число.");
                }
            }

            // Вспомогательный метод для корректного ввода числа с плавающей точкой
            static double ReadDouble(string fieldName)
            {
                double value;
                while (true)
                {
                    Console.Write($"{fieldName}: ");
                    if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                    {
                        return value;
                    }
                    Console.WriteLine("Некорректный ввод. Введите неотрицательное число.");
                }
            }
        }
    }
}
