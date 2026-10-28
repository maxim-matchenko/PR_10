//****************************************************************************
//* Практическая работа N10                                                  *
//* Выполнил: Матченко M.C., группа 2-ИСП-оКФ                                *
//* Вариант 3                                                                *
//* Задание: Обработка двухмерных массивов.                                  *
//****************************************************************************
using System;
namespace PR_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Практическая работа № 10";
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Здравствуйте!");
            try
            {
                string Select;// Переменная для контроля повторного запуска
                do // внешний цикл для повторного запуска 
                {
                    Console.WriteLine("\n--- Новый расчет ---");
                    const int row = 4; // задание массива
                    const int col = 3;
                    int[,] array = new int[row, col]; // объявление массива 
                    Random rand = new Random();
                    // Заполнение двумерного массива случайными числами на интервале [-27, 38]
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = rand.Next(-27, 39);
                        }
                    }
                    // Поиск наибольшего нечетного числа в массиве
                    int maxOdd = -27;
                    int maxRow = -1;
                    int maxCol = -1;
                    bool hasOdd = false;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] % 2 != 0)// Проверка на нечетность 
                            {
                                if (array[i, j] > maxOdd)
                                {
                                    maxOdd = array[i, j];
                                    maxRow = i;
                                    maxCol = j;
                                    hasOdd = true;
                                }
                            }
                        }
                    }
                    Console.WriteLine("\nСгенерированный массив:");// Вывод результирующего массива на экран
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (hasOdd && i == maxRow && j == maxCol)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;// Подсвечиваем наибольший нечетный элемент зеленым
                                Console.Write(array[i, j] + "\t");
                                Console.ForegroundColor = ConsoleColor.Black;
                            }
                            else
                            {
                                Console.Write(array[i, j] + "\t");
                            }
                        }
                        Console.WriteLine();
                    }
                    Console.Write("\nХотите выполнить программу еще раз? (да - 1/нет - любая клавиша): ");
                    Select = Console.ReadLine();
                }
                while (Select == "1");
            }
            catch (IndexOutOfRangeException iOOREx)// Обработка ошибок с использованием производного класса исключений
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВозникла ошибка: {iOOREx.Message}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (Exception ex) // Обработка исключений
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВозникла ошибка: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}