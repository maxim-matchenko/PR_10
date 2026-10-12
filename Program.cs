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
            bool select = true;// Флаг для организации многократного выполнения программы
            while (select)
            {
                try
                {
                    const int row = 4;// Объявление размеров матрицы (M = 4, N = 3)
                    const int col = 3;
                    int[,] array = new int[row, col];
                    Random rand = new Random();// Инициализация генератора случайных чисел
                    // Заполнение матрицы случайными числами на интервале [-27, 38]
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = rand.Next(-27, 39);// 39 не включается в диапазон rand.Next, то есть генерируются числа до 38
                        }
                    }
                    // Поиск наибольшего нечетного числа в матрице
                    int maxOdd = -27;
                    int maxRow = -1;
                    int maxCol = -1;
                    bool hasOdd = false;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] % 2 != 0)// Проверка на нечетность (остаток от деления на 2 не равен 0)
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
                            // Подсвечиваем наибольший нечетный элемент зеленым
                            if (hasOdd && i == maxRow && j == maxCol)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                    Console.WriteLine("\nРезультат поиска:");// Вывод результата поиска
                    if (hasOdd)
                    {
                        Console.Write("Наибольшее нечетное число в матрице: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(maxOdd);
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.WriteLine("Нечетных чисел в матрице не обнаружено.");
                    }
                }
                // Обработка ошибок с использованием производного класса исключений
                catch (IndexOutOfRangeException iOOREx)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВозникла ошибка: {iOOREx.Message}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                // Обработка ошибок с использованием базового класса исключений
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nВозникла ошибка: {ex.Message}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                // Организация многократного выполнения программы без повторного запуска
                Console.WriteLine("\nХотите запустить программу еще раз? (y/n):");
                string answer = Console.ReadLine();
                if (answer != "y" && answer != "н")
                {
                    select = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Повторный запуск программы...");
                }
            }
            Console.WriteLine("\nПрограмма завершена. Нажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
}