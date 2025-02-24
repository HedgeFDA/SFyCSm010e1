using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SFyCSm010e1;

class Program
{
    /// <summary>
    /// Функция реализующая запрос ввода у пользоватеся строкового значения
    /// </summary>
    /// <param name="message">Текст запроса ввода строки к пользователю</param>
    /// <returns>Введеное значение</returns>
    static string InputStringValue(string message)
    {
        Console.Write(message);

        return Console.ReadLine() ?? string.Empty;
    }

    /// <summary>
    /// Процедура реализующая основной алгоритм работы программы "Калькулятора".
    /// </summary>
    static void MainCalculator()
    {
        // Переменная хранящая результат вычисления
        double result = 0;

        // Создаем экземпляр калькулятора
        Calculator сalculator = new Calculator();

        Console.WriteLine("Калькуляртор запущен.\nДля завершения работы калькулятора введите пустое значение.");

        string currentOperation = "+";
        bool calculating        = true;
        bool firstInput         = true;

        while (calculating)
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            // Ввод пользователем арифметической операции

            string valueString = string.Empty;

            while (string.IsNullOrEmpty(currentOperation))
            {
                valueString = InputStringValue("Введите знак: ");

                if (string.IsNullOrEmpty(valueString))
                    calculating = false;
                else if (valueString == "+" || valueString == "-" || valueString == "*" || valueString == "/")
                    currentOperation = valueString;
                else
                    Console.WriteLine("Введено некорректное значение операции: {0}, допустимые значения: +, -, *, /", valueString);

                if (!calculating)
                    break;
            }

            if (!calculating)
                break;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            // Ввод пользователем числа

            valueString = string.Empty;
            double valueDouble  = 0;

            while (string.IsNullOrEmpty(valueString))
            {
                valueString = InputStringValue("Введите число: ");

                if (string.IsNullOrEmpty(valueString))
                    calculating = false;
                else try
                {
                    valueDouble = Convert.ToDouble(valueString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено нечисловое значение: {0}", valueString);

                    valueString = string.Empty;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: {0}", ex.Message);

                    valueString = string.Empty;
                }

                if (!calculating)
                    break;
            }

            if (!calculating)
                break;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            // Вычисление результата

            result = сalculator.Calculate(result, valueDouble, currentOperation);

            currentOperation = "";

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //
            // Вывод результата вычисления

            if (firstInput)
                firstInput = false;
            else
                Console.WriteLine("Результат: {0}", result);
        }

    }

    /// <summary>
    /// Главная точка входа приложения
    /// </summary>
    /// <param name="args">Аргументы командной строки при запуске приложения.</param>
    static void Main(string[] args)
    {
        MainCalculator();
    }
}
