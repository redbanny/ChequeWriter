using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeWriter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxValue = 2000000000, dollarNum = 0, centNum = 0;
            string result = ""; // строка для вывода результата
            #region Получаем значения
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the number of dollars");
                    dollarNum = int.Parse(Console.ReadLine()); // получаем $
                    if (dollarNum < 0 || dollarNum > maxValue)
                        throw new Exception();
                    break;
                }
                catch
                {
                    Console.WriteLine("Check the correctness of the entered amount");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the number of cents");
                    centNum = int.Parse(Console.ReadLine());// получаем ¢
                    if (centNum < 0 || centNum > 99)
                        throw new Exception();
                    break;
                }
                catch
                {
                    Console.WriteLine("Check the correctness of the entered amount");
                    continue;
                }
            }
            #endregion

            int[] array_int = new int[4]; // нужно для разбивания число по сотням типа 123123123 == 123 123 123 в массиве
            string[] array_string = new string[4] {"billion", // нужно для чисел больше миллиона
                "million",
                "thousand",
                ""};
            array_int[0] = (dollarNum - (dollarNum % 1000000000)) / 1000000000; // здесь мы разбиваем наше число по элементам массива по 3 цифры
            array_int[1] = ((dollarNum % 1000000000) - (dollarNum % 1000000)) / 1000000;// допустим мы ввели 123345, значит  array_int[3] == 345  ,  array_int[2] == 123  
            array_int[2] = ((dollarNum % 1000000) - (dollarNum % 1000)) / 1000;
            array_int[3] = dollarNum % 1000;

            for (int i = 0; i < 4; i++)
            {
                if (array_int[i] != 0) //array_int[0] != 0 если число больше миллиарда, array_int[1] != 0 если число больше миллиона , array_int[2] != 0 если число больше сто тысяч
                {
                    if (((array_int[i] - (array_int[i] % 100)) / 100) != 0) // проверяем имеет ли число третьий разряд
                        switch (((array_int[i] - (array_int[i] % 100)) / 100))
                        {
                            case 1: result += " one hundred"; break;
                            case 2: result += " two hundred"; break;
                            case 3: result += " three hundred"; break;
                            case 4: result += " four hundred"; break;
                            case 5: result += " five hundred"; break;
                            case 6: result += " six hundred"; break;
                            case 7: result += " seven hundred"; break;
                            case 8: result += " eight hundred"; break;
                            case 9: result += " nine hundred"; break;
                        }
                    if (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 != 1)// проверяем имеет ли число второй разряд
                    {
                        switch (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10)
                        {
                            case 2: result += " twenty"; break;
                            case 3: result += " thirty"; break;
                            case 4: result += " forty"; break;
                            case 5: result += " fifty"; break;
                            case 6: result += " sixty"; break;
                            case 7: result += " seventy"; break;
                            case 8: result += " eighty"; break;
                            case 9: result += " ninety"; break;
                        }
                        switch (array_int[i] % 10)
                        {
                            case 1: result += " one"; break;
                            case 2: result += " two"; break;
                            case 3: result += " three"; break;
                            case 4: result += " four"; break;
                            case 5: result += " five"; break;
                            case 6: result += " six"; break;
                            case 7: result += " seven"; break;
                            case 8: result += " eight"; break;
                            case 9: result += " nine"; break;
                        }
                    }                    
                    else switch (array_int[i] % 100) // здесь проверяем второй разряд | если второй разряд >= 10 && второй разряд <= 19
                    {
                        case 10: result += " ten"; break;
                        case 11: result += " eleven"; break;
                        case 12: result += " twelve"; break;
                        case 13: result += " thirteen"; break;
                        case 14: result += " fourteen"; break;
                        case 15: result += " fifteen"; break;
                        case 16: result += " sixteen"; break;
                        case 17: result += " seventeen"; break;
                        case 18: result += " eighteen"; break;
                        case 19: result += " nineteen"; break;
                    }
                    result += " " + array_string[i] + " dollars ";
                }
            }
            // перевод в текст центов
            if (centNum != 0)
            {
                if (((centNum % 100) - ((centNum % 100) % 10)) / 10 != 1)// проверяем имеет ли число второй разряд
                {
                    switch (((centNum % 100) - ((centNum % 100) % 10)) / 10)
                    {
                        case 2: result += " twenty"; break;
                        case 3: result += " thirty"; break;
                        case 4: result += " forty"; break;
                        case 5: result += " fifty"; break;
                        case 6: result += " sixty"; break;
                        case 7: result += " seventy"; break;
                        case 8: result += " eighty"; break;
                        case 9: result += " ninety"; break;
                    }
                    switch (centNum % 10)
                    {
                        case 1: result += " one"; break;
                        case 2: result += " two"; break;
                        case 3: result += " three"; break;
                        case 4: result += " four"; break;
                        case 5: result += " five"; break;
                        case 6: result += " six"; break;
                        case 7: result += " seven"; break;
                        case 8: result += " eight"; break;
                        case 9: result += " nine"; break;
                    }
                }
                else switch (centNum % 100) // здесь проверяем второй разряд | если второй разряд >= 10 && второй разряд <= 19
                {
                    case 10: result += " ten"; break;
                    case 11: result += " eleven"; break;
                    case 12: result += " twelve"; break;
                    case 13: result += " thirteen"; break;
                    case 14: result += " fourteen"; break;
                    case 15: result += " fifteen"; break;
                    case 16: result += " sixteen"; break;
                    case 17: result += " seventeen"; break;
                    case 18: result += " eighteen"; break;
                    case 19: result += " nineteen"; break;
                }
                result += " cents";
            }            
            Console.WriteLine(result.Trim());
            Console.ReadKey();
        }
    }
}
