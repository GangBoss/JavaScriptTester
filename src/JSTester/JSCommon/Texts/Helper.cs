using System.Collections.Generic;
using System.Linq;

/*!
\file
\brief Заголовочный файл с описанием классов
Данный файл содержит в себе определения основных
классов, используемых в демонстрационной программе
*/
namespace JSTester.JSCommon.Texts
{
    /*!
     \defgroup helper служебный класс
    */
    /*!
     \brief Служебный класс
      Класс содержащий полезные методы для работы с текстами
    */
    class Helper
    {
        /*!
         Получает алфавит(набор букв) из исходной строки
         \param line входная строка
         \return {коллекция строк}
        \code
             return text.Split("").ToHashSet();
        \endcode
        */
        public static IEnumerable<string> GetAlphabet(string text)
        {
            return text.Split("").ToHashSet();
        }

        public static IEnumerable<string> TextCropper(string poem)
        {
            yield return poem;
            yield return poem.Substring(0, poem.Length / 2);
            yield return poem.Substring(0, poem.Length / 4);
            yield return poem.Substring(poem.Length / 4);
        }
    }
}