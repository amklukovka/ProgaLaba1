// 2 часть
/* Коэффициенты системы линейных уравнений заданы в виде прямоугольной матрицы. 
С помощью допустимых преобразований привести систему к треугольному виду.
Найти количество строк, среднее арифметическое элементов которых меньше заданной величины. */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp11.Laba1;

namespace ConsoleApp11.Laba1
{
    public class SecondPart
    {
        private readonly double[,] matrix = new double[10, 10];
        public SecondPart(int rows, int cols)
        {
            if (rows < 0 || cols < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows) + "or" + nameof(cols));
            }
            else
            {
                matrix = new double[rows, cols];
                var random = new Random();
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = random.Next(-10, 10);
                    }
                }
            }
        }
        public double[,] Matrix
        {
            get
            {
                return matrix;
            }
        }

        public static void ToTriangleForm(double[,] matrix) // метод приведения матрицы к треугольному виду
        {
            int rows = matrix.GetLength(0); // количество строк
            int cols = matrix.GetLength(1); // количество столбцов
            for (int k = 0; k < rows - 1; k++) // цикл по диагональным элементам
            {
                // проверяем, что диагональный элемент не равен нулю
                if (matrix[k, k] != 0)
                {
                    for (int i = k + 1; i < rows; i++) // цикл по строкам ниже диагонали
                    {
                        // находим коэффициент для вычитания строк
                        double coef = matrix[i, k] / matrix[k, k];
                        // вычитаем из строки i строку k, умноженную на коэффициент
                        for (int j = k; j < cols; j++)
                        {
                            matrix[i, j] -= coef * matrix[k, j];
                        }
                    }
                }
                else
                {
                    // если диагональный элемент равен нулю, то ищем строку ниже, в которой элемент в том же столбце не равен нулю
                    int index = -1; // индекс такой строки
                    for (int m = k + 1; m < rows; m++)
                    {
                        if (matrix[m, k] != 0)
                        {
                            index = m;
                            break;
                        }
                    }
                    // если такая строка найдена, то меняем её местами со строкой k
                    if (index != -1)
                    {
                        for (int n = k; n < cols; n++)
                        {
                            double x = matrix[k, n];
                            matrix[k, n] = matrix[index, n];
                            matrix[index, n] = x;
                        }
                    }
                    // повторяем шаг вычитания строк для новой строки k
                    k--;
                }
            }
        }


        // метод для подсчёта количества строк, среднее арифметическое элементов которых меньше заданной величины
        public static int CountRows(double[,] matrix, double value)
        {
            int rows = matrix.GetLength(0); // количество строк
            int cols = matrix.GetLength(1); // количество столбцов
            int count = 0; // счётчик строк
            for (int i = 0; i < rows; i++) // цикл по строкам
            {
                double sum = 0; // сумма элементов строки
                for (int j = 0; j < cols; j++) // цикл по столбцам
                {
                    sum += matrix[i, j]; // добавление элемента к сумме
                }
                double average = sum / cols; // среднее арифметическое элементов строки
                if (average < value) // проверка условия
                {
                    count++; // увеличение счётчика
                }
            }
            return count; // возврат результата
        }
    }
}