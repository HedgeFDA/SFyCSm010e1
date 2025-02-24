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

/// <summary>
/// Класс-калькулятора для выполнения базовых арифметических операций.
/// </summary>
public class Calculator : IAddition, ISubtraction, IMultiplication, IDivision
{
    /// <summary>
    /// Инициализирует новый экземпляр класса.
    /// </summary>
    public Calculator()
    {
        // Конструктор по умолчанию
    }

    /// <inheritdoc />
    public double Add(double a, double b)
    {
        return a + b;
    }

    /// <inheritdoc />
    public double Subtract(double a, double b)
    {
        return a - b;
    }

    /// <inheritdoc />
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    /// <inheritdoc />
    public double Divide(double a, double b)
    {
        return b == 0 ? 0 : a / b;
    }

    /// <summary>
    /// Выполняет арифметическую операцию с двумя переданными числами.
    /// Доступные операции: +, -, *, /
    /// </summary>
    /// <param name="a">Первое число</param>
    /// <param name="b">Второе число</param>
    /// <param name="operation">Операция</param>
    /// <returns>Результат вычисления.</returns>
    public double Calculate(double a, double b, string operation)
    {
        return operation switch
        {
            "+" => Add(a, b),
            "-" => Subtract(a, b),
            "*" => Multiply(a, b),
            "/" => Divide(a, b),
            _ => a
        };
    }
}