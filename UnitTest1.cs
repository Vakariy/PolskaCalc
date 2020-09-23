using System;
using CalcInputString;
using NUnit.Framework;

namespace UnitTestStringCalc
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(" ", true, Description = "Метод возвращает true, если проверяемый символ - разделитель (пробел или равно)")]
        [TestCase("=", true, Description = "Метод возвращает true, если проверяемый символ - разделитель (пробел или равно)")]
        public static void IsDelimeterTest(char c, bool expectedResult)
        {
            bool actualResult = CalcLogic.IsDelimeter(c);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("+", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        [TestCase("-", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        [TestCase("*", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        [TestCase("/", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        [TestCase("^", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        [TestCase("(", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        [TestCase(")", true, Description = "Метод возвращает true, если проверяемый символ - оператор")]
        public static void IsOperatorTest(char c, bool expectedResult)
        {
            bool actualResult = CalcLogic.IsOperator(c);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("(", 0, Description = "Метод возвращает приоритет оператора")]
        [TestCase(")", 1, Description = "Метод возвращает приоритет оператора")]
        [TestCase("+", 2, Description = "Метод возвращает приоритет оператора")]
        [TestCase("-", 3, Description = "Метод возвращает приоритет оператора")]
        [TestCase("*", 4, Description = "Метод возвращает приоритет оператора")]
        [TestCase("/", 4, Description = "Метод возвращает приоритет оператора")]
        [TestCase("^", 5, Description = "Метод возвращает приоритет оператора")]
        [TestCase(" ", 6, Description = "Метод возвращает приоритет оператора. Если ввести любой другой оператор, то по умолчанию вернется приоритет - 6.")]
        public void GetPriorityTest(char s, byte expectedResult)
        {
            byte actualResult = CalcLogic.GetPriority(s);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("(1+2)*4+3", "1 2 + 4 * 3 + ", Description = "Принимает поток выражения с консоли и возвращает выражение в постфиксной записи")]
        [TestCase("(1+2)*0+3", "1 2 + 0 * 3 + ", Description = "Принимает поток выражения с консоли и возвращает выражение в постфиксной записи")]
        [TestCase("10+0-11/2*5", "10 0 11 2 / 5 * - + ", Description = "Принимает поток выражения с консоли и возвращает выражение в постфиксной записи")]
        [TestCase("10+2*(5-3)+11", "10 2 5 3 - * 11 + + ", Description = "Принимает поток выражения с консоли и возвращает выражение в постфиксной записи")]
        public void GetExpressionTest(string input, string expectedResult)
        {
            string actualResult = CalcLogic.GetExpression(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("1 2 + 4 * 3 + ", 15, Description = "Решение задачи с постсуфиксной формы записи")]
        [TestCase("1 2 + 0 * 3 + ", 3, Description = "Решение задачи с постсуфиксной формы записи")]
        [TestCase("10 0 11 2 / 5 * - + ", -17.5, Description = "Решение задачи с постсуфиксной формы записи")]
        [TestCase("10 2 5 3 - * 11 + + ", 25, Description = "Решение задачи с постсуфиксной формы записи")]
        public void CoutingTest(string input, double expectedResult)
        {
            double actualResult = CalcLogic.Counting(input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("(1+2)*4+3", 15, Description = "Решение выражения посредством алгоритма польской нотации. Прогонка метода который принимает выражение и выводит результат просчета")]
        [TestCase("(1+2)*0+3", 3, Description = "Решение выражения посредством алгоритма польской нотации. Прогонка метода который принимает выражение и выводит результат просчета")]
        [TestCase("10+0-11/2*5", -17.5, Description = "Решение выражения посредством алгоритма польской нотации. Прогонка метода который принимает выражение и выводит результат просчета")]
        [TestCase("10+2*(5-3)+11", 25, Description = "Решение выражения посредством алгоритма польской нотации. Прогонка метода который принимает выражение и выводит результат просчета")]
        [TestCase("3+4*2/(1-5)^2", 3.5, Description = "Решение выражения посредством алгоритма польской нотации. Решение примера с таска с ДЗ")]
        public void CalculateTest(string input, double expectedResult)
        {
            double actualResult = CalcLogic.Calculate(input);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
