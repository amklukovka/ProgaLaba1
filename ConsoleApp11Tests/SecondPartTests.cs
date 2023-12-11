using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApp11.Laba1;

namespace Laba1.Tests
{
    public class SecondPartTests
    {

        // тестирование конструктора класса, создание объекта с некорректными значениями
        [Fact]
        public void SecondPart_Constructor_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            int rows = -1; // неверное значение для количества строк
            int cols = 10; // верное значение для количества столбцов

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SecondPart(rows, cols)); // проверяем, что выбрасывается исключение
        }


        // тестовый метод для проверки метода ToTriangleForm
        [Fact]
        public void Test_ToTriangleForm()
        {
            // Arrange
            double[,] matrix = new double[,] // задаём матрицу
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            double[,] expected = new double[,] // ожидаемая матрица в треугольном виде
            {
                { 1, 2, 3 },
                { 0, -3, -6 },
                { 0, 0, 0 }
            };

            // Act
            SecondPart.ToTriangleForm(matrix); // приводим матрицу к треугольному виду

            // Assert
            Assert.Equal(expected, matrix); // проверка равенства ожидаемого и фактического результата
        }


        // тест для проверки метода CountRows
        [Fact]
        public void Test_CountRows()
        {
            // Arrange
            double[,] matrix = new double[,] // задаём матрицу
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };

            double value = 5; // задаём величину
            int expected = 1;

            // Act
            int actual = SecondPart.CountRows(matrix, value);

            //Assert
            Assert.Equal(expected, actual); // проверка равенства ожидаемого и фактического результата
        }
    }
}
