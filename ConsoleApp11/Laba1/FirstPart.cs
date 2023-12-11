// 1 часть
/* В одномерном массиве, состоящем из N вещественных элементов, вычислить:
номер минимального по модулю элемента массива
сумму модулей элементов массива, расположенных после первого отрицательного элемента.
Сжать массив, удалив из него все элементы, величина которых находится в интервале [а, b]. 
Освободившиеся в конце массива элементы заполнить нулями. */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp11.Laba1;


namespace ConsoleApp11.Laba1
{
    public class FirstPart
    {
        //public double[] array { get; private set; }
        //private readonly double[] array;
        public double[] array;
        public FirstPart(int length)
        {
            if (length <= 0)
            {
                //throw new ArgumentOutOfRangeException(nameof(length));
                throw new ArgumentOutOfRangeException("Длина массива должна быть больше 0");
            }
            var random = new Random();
            array = new double[length];
            for (int i = 0; i < array.Length; i++)
                //array[i] = random.Next(-10, 10);
                array[i] = random.NextDouble() * 20 - 10;
        }
        public IReadOnlyList<double> Vector
        {
            get
            {
                return array;
            }
        }

        public int IndexMinElement()
        { // метод, вычисляющий номер минимального по модулю элемента массива

            int minIndex = 0;
            double minAbs = Math.Abs(array[0]);

            for (int i = 1; i < array.Length; i++)
            {
                double abs = Math.Abs(array[i]);
                if (abs < minAbs)
                {
                    minIndex = i;
                    minAbs = abs;
                }
            }
            return minIndex;

        }

        public double SumAbsAfterNegative()  // метод, вычисляющий сумму модулей элементов массива после первого отриц элемента
        {
            double sum = 0;
            bool firstNegative = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (firstNegative == true)
                    sum += Math.Abs(array[i]);
                if (array[i] < 0)
                    firstNegative = true;

                //else if (firstNegative)
                //  sum += Math.Abs(array[i]);
            }

            return sum;
        }

        public double[] PressArray(int a, int b)
        {
            int j = 0; // индекс для сдвига влево
            for (int i = 0; i < array.Length; i++) // сжимаем массив
            {

                if (array[i] < a || array[i] > b) // если элемент вне интервала
                {
                    array[j] = array[i]; // двигаем его влево (ставим на место удалённого элемента)
                    j++; // переходим к следующему индексу
                }

            }

            for (int i = j; i < array.Length; i++) // заполняем массив нулями, начинаем с индекса j = первый индекс после всех сдвинутых влево элементов
            {
                array[i] = 0;
            }
            return array;
        }
    }
}
