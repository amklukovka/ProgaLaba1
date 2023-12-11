using ConsoleApp11.Laba1;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// ЛАБОРАТОРНАЯ РАБОТА 1 // Вариант 10
// 1 часть
/* В одномерном массиве, состоящем из N вещественных элементов, вычислить:
номер минимального по модулю элемента массива
сумму модулей элементов массива, расположенных после первого отрицательного элемента.
Сжать массив, удалив из него все элементы, величина которых находится в интервале [а, b]. 
Освободившиеся в конце массива элементы заполнить нулями. */

// 2 часть
/* Коэффициенты системы линейных уравнений заданы в виде прямоугольной матрицы. 
С помощью допустимых преобразований привести систему к треугольному виду.
Найти количество строк, среднее арифметическое элементов которых меньше заданной величины. */

namespace ConsoleApp11.Laba1
{
    public static class Program
    {
        public static void Main()
        {

            Console.WriteLine("Часть 1:");

            Console.Write("Введите размер массива: ");
            int length = int.Parse(Console.ReadLine());

            FirstPart firstPart = new FirstPart(length); // создание массива

            Console.WriteLine("Исходный массив: ");
            PrintVector(firstPart.Vector); // вывод массива

            Console.WriteLine("Индекс минимального по модулю элемента:");
            Console.WriteLine(firstPart.IndexMinElement());

            Console.WriteLine("Сумма модулей элементов после первого отрицательного:");
            Console.WriteLine(firstPart.SumAbsAfterNegative()); // выводим сумму негативных элементов

            Console.Write("Введите число для интервала a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите число для интервала b: ");
            int b = int.Parse(Console.ReadLine());
            firstPart.PressArray(a, b); // сжимаем массив в интервале
            Console.WriteLine("Сжатый массив [a до b]:");
            PrintVector(firstPart.Vector); // вывод массива

            Console.WriteLine("Часть 2:");

            Console.Write("Введите количество строк матрицы: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов матрицы: ");
            int cols = int.Parse(Console.ReadLine());
            SecondPart secondPart = new SecondPart(rows, cols); // создание матрицы
            PrintMatrix(secondPart.Matrix); // вывод матрицы

            Console.WriteLine("Матрица в треугольном виде:");
            SecondPart.ToTriangleForm(secondPart.Matrix); // приводим матрицу к треугольному виду
            PrintMatrix(secondPart.Matrix); // вывод матрицы

            Console.Write("Введите число для сравнения с средним арифметическим элементов строк: ");
            int value = int.Parse(Console.ReadLine());
            // подсчитываем количество строк, среднее арифметическое элементов которых меньше value
            int count = SecondPart.CountRows(secondPart.Matrix, value);
            Console.WriteLine("Количество строк, среднее арифметическое элементов которых меньше {0} = {1}", value, count);
        }

        static void PrintVector(IEnumerable<double> vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }

        public static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0); // количество строк
            int cols = matrix.GetLength(1); // количество столбцов
            for (int i = 0; i < rows; i++) // цикл по строкам
            {
                for (int j = 0; j < cols; j++) // цикл по столбцам
                {
                    // выводим элемент с форматированием
                    Console.Write("{0,5:F2} ", matrix[i, j]);
                }
                Console.WriteLine(); // переходим на новую строку
            }
            Console.WriteLine(); // делаем пустую строку
        }
    }
}