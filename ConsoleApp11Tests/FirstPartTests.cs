using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ConsoleApp11.Laba1;

namespace Laba1.Tests
{
    public class FirstPartTests
    {
        // тестирование конструктора класса, создание объекта с некорректными значениями
        [Theory]
        [InlineData(0, -10)]
        public void Test_IsWrongLengthVectorCreatingFailed(int a, int b)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstPart(a)); // проверяем, что при создании массива с длиной 0 выбрасывается исключение
            Assert.Throws<ArgumentOutOfRangeException>(() => new FirstPart(b)); // проверяем, что при создании массива с отрицательной длиной -10 выбрасывается исключение
        }


        // тестирование метода IndexMinElement
        [Fact]
        public void Test_IndexMinElement()
        {
            // Arrange
            var firstPart = new FirstPart(5);
            firstPart.array = new double[] { 1.0, -2.0, 0.5, -0.1, 3.0 }; // задаём массив
            int expected = 3;

            // Act
            int index = firstPart.IndexMinElement();

            // Assert
            Assert.Equal(expected, index); // проверка равенства ожидаемого и фактического результата
        }


        // тестирование метода SumAbsAfterNegative
        [Fact]
        public void Test_SumAbsAfterNegative()
        {
            // Arrange
            var firstPart = new FirstPart(5);
            firstPart.array = new double[] { 1.0, -2.0, 0.5, -0.1, 3.0 }; // задаём массив
            double expected = 3.6;

            // Act
            double sum = firstPart.SumAbsAfterNegative();

            // Assert
            Assert.Equal(expected, sum); // проверка равенства ожидаемого и фактического результата
        }


        // тестирование метода SumAbsAfterNegative, когда в массиве нет отрицательных элементов
        [Fact]
        public void Test_SumAbsAfterNegative_ReturnsZero()
        {
            // Arrange
            var firstPart = new FirstPart(5);
            firstPart.array = new double[] { 1.0, 2.0, 0.5, 0.1, 3.0 }; // задаём массив
            int expected = 0; // ожидаемая сумма модулей элементов равна 0, т.к. отрицательных элементов нет

            // Act
            double sum = firstPart.SumAbsAfterNegative();

            // Assert
            Assert.Equal(expected, sum); // проверка равенства ожидаемого и фактического результата
        }


        // тестирование метода PressArray
        [Theory]
        [InlineData(-5, 5)] // интервал [-5, 5]
        [InlineData(0, 10)] // интервал [0, 10]
        [InlineData(-10, -1)] // интервал [-10, -1]
        public void Test_PressArray(int a, int b)
        {
            // Arrange
            var firstPart = new FirstPart(5);
            firstPart.array = new double[] { 1.0, -2.0, 0.5, -0.1, 3.0 }; // задаём массив

            // Act
            double[] result = firstPart.PressArray(a, b);

            // Assert
            // проверяем, что массив сжат правильно в зависимости от интервала
            if (a == -5 && b == 5)
            {
                Assert.Equal(new double[] { 0.0, 0.0, 0.0, 0.0, 0.0 }, result);
            }
            else if (a == 0 && b == 10)
            {
                Assert.Equal(new double[] { -2.0, -0.1, 0.0, 0.0, 0.0 }, result);
            }
            else if (a == -10 && b == -1)
            {
                Assert.Equal(new double[] { 1.0, 0.5, -0.1, 3.0, 0.0 }, result);
            }
        }
    }
}