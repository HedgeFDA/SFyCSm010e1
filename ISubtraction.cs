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
/// Определяет контракт для выполнения арифметической операции вычитания.
/// </summary>
public interface ISubtraction
{
    /// <summary>
    /// Выполняет вычитание двух чисел.
    /// </summary>
    /// <param name="a">Первое число.</param>
    /// <param name="b">Второе число.</param>
    /// <returns>Результат вычитания двух чисел.</returns>
    double Subtract(double a, double b);
}