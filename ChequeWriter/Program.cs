using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeWriter
{
    internal class Program
    {
        public static string[,] array_string_rus = new string[4, 3] 
        {
            { " миллиард", " миллиарда", " миллиардов" },
            { " миллион", " миллиона", " миллионов" },
            { " тысяча", " тысячи", " тысяч" },
            { "", "", "" }
        };
        public static string[] array_string_eng = new string[4] 
        {
            "billion", 
            "million",
            "thousand",
            ""
        };
        static void Main(string[] args)
        {
            int maxValue = 2000000000, dollarNum = 0, centNum = 0;
            string result = string.Empty, lang = string.Empty; // строка для вывода результата
            #region Получаем значения
            try
            {
                Console.WriteLine("Выберите язык вывода: rus\\eng");
                lang = Console.ReadLine().ToLower();
                if (!lang.Equals("rus") && !lang.Equals("eng"))
                {
                    throw new Exception("Выбранный язык не найден");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Язык по умолчанию rus");
            }
            while (true)
            {
                try
                {
                    if (lang.Equals("eng"))
                        Console.WriteLine("Enter the number of dollars");
                    else
                        Console.WriteLine("Введите сумму долларов");
                    dollarNum = int.Parse(Console.ReadLine()); // получаем $
                    if (dollarNum < 0 || dollarNum > maxValue)
                        throw new Exception();
                    break;
                }
                catch
                {
                    if (lang.Equals("eng"))
                        Console.WriteLine("Check the correctness of the entered amount");
                    else
                        Console.WriteLine("Введено некорректное значение");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    if (lang.Equals("eng"))
                        Console.WriteLine("Enter the number of cents");
                    else
                        Console.WriteLine("Введите сумму центов");
                    centNum = int.Parse(Console.ReadLine());// получаем ¢
                    if (centNum < 0 || centNum > 99)
                        throw new Exception();
                    break;
                }
                catch
                {
                    if (lang.Equals("eng"))
                        Console.WriteLine("Check the correctness of the entered amount");
                    else
                        Console.WriteLine("Введено некорректное значение");
                    continue;
                }
            }
            #endregion

            int[] array_int = new int[4]; // нужно для разбивания число по сотням типа 123123123 == 123 123 123 в массиве            
            Spliter(dollarNum, out array_int);
            IntInWord inWord = new IntInWord();
            for (int i = 0; i < array_int.Length; i++)
            {
                if (array_int[i] != 0) //array_int[0] != 0 если число больше миллиарда, array_int[1] != 0 если число больше миллиона , array_int[2] != 0 если число больше сто тысяч
                {
                    if (lang.Equals("eng"))
                    {
                        result += inWord.TranscriptEng(array_int[i]);
                        result += array_string_eng[i];
                    }
                    else
                    {
                        result += inWord.TranscriptRus(array_int[i]);
                        if (array_int[i] % 100 >= 10 && array_int[i] % 100 <= 19) result += " " + array_string_rus[i, 2] + " ";
                        else
                            switch (array_int[i] % 10)
                            {
                                case 1: result += " " + array_string_rus[i, 0] + " "; break; // 1 тысяча, 1 миллион, 1 миллиард
                                case 2:
                                case 3:
                                case 4: result += " " + array_string_rus[i, 1] + " "; break;// 3 тысячи , 3 миллиона, 3 миллиарда
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9: result += " " + array_string_rus[i, 2] + " "; break;// 9 тысяч , 9 миллионов, 9 миллиардов
                            }
                    }
                }
            }
            if (dollarNum != 0)
            {
                if (lang.Equals("eng"))
                    result += "dollars";
                else
                    switch (dollarNum % 10)
                    {
                        case 1: result += " доллар"; break;
                        case 2: 
                        case 3:
                        case 4: result += " доллара"; break;
                        case 5: 
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10: result += " долларов"; break;

                    }
            }
            // перевод в текст центов
            if (centNum != 0)
            {
                if (lang.Equals("eng"))
                {
                    result += inWord.TranscriptEng(centNum);
                    result += " cents";
                }
                else
                {
                    result += inWord.TranscriptRus(centNum);
                    switch (centNum % 10)
                    {
                        case 1: result += " цент"; break;
                        case 2: 
                        case 3:
                        case 4: result += " цента"; break;
                        case 5: 
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10: result += " центов"; break;
                    }
                }                
            }
            Console.WriteLine(result.Trim());
            Console.ReadKey();
        }

        static void Spliter(int dollarNum, out int[] outArray)
        {
            outArray = new int[4];
            outArray[0] = (dollarNum - (dollarNum % 1000000000)) / 1000000000; // здесь мы разбиваем наше число по элементам массива по 3 цифры
            outArray[1] = ((dollarNum % 1000000000) - (dollarNum % 1000000)) / 1000000;// допустим мы ввели 123345, значит  array_int[3] == 345  ,  array_int[2] == 123  
            outArray[2] = ((dollarNum % 1000000) - (dollarNum % 1000)) / 1000;
            outArray[3] = dollarNum % 1000;
        }
    }
}
