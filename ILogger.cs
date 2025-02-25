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
/// Определяет контракт для логирования.
/// </summary>
public interface ILogger
{
    /// <summary>
    /// Сообщение о событии.
    /// </summary>
    /// <param name="message">Текст сообщения.</param>
    void Event(string message);

    /// <summary>
    /// Сообщение об ошибке.
    /// </summary>
    /// <param name="message">Текст ошибки.</param>
    void Error(string message);

    /// <summary>
    /// Сообщение-вопрос (запрос ввода данных).
    /// </summary>
    /// <param name="message">Текст вопроса.</param>
    void Question(string message);
}