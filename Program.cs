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
    /// <returns>Введеное значение</returns>
    static string InputStringValue()
    {
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

        // Создаем экземпляр логегра
        Logger logger = new Logger();

        logger.Event("Калькуляртор запущен.\nДля завершения работы калькулятора введите пустое значение.");

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
                logger.Question("Введите знак: ");
                
                valueString = InputStringValue();

                if (string.IsNullOrEmpty(valueString))
                    calculating = false;
                else if (valueString == "+" || valueString == "-" || valueString == "*" || valueString == "/")
                    currentOperation = valueString;
                else
                    logger.Error($"Введено некорректное значение операции: {valueString}, допустимые значения: +, -, *, /");

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
                logger.Question("Введите число: ");

                valueString = InputStringValue();

                if (string.IsNullOrEmpty(valueString))
                {
                    calculating = false;

                    break;
                }
                else try
                    {
                        valueDouble = Convert.ToDouble(valueString);

                        break;
                    }
                    catch (FormatException)
                    {
                        logger.Error($"Введено нечисловое значение: {valueString}");
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Ошибка: {ex.Message}");
                    }

                valueString = string.Empty;
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
                logger.Event($"Результат: {result}");
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
