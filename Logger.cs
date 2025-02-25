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
/// Класс для логирования.
/// </summary>
public class Logger : ILogger
{
    /// <summary>
    /// Инициализирует новый экземпляр класса.
    /// </summary>
    public Logger()
    {
        // Конструктор по умолчанию
    }

    /// <inheritdoc />
    public void Event(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;

        Console.WriteLine(message);
    }

    /// <inheritdoc />
    public void Error(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkRed;

        Console.WriteLine(message);
    }

    /// <inheritdoc />
    public void Question(string message)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;

        Console.Write(message);
    }
}