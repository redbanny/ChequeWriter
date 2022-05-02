using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeWriter
{
    internal class IntInWord
    {
        public IntInWord() { }

        public string TranscriptEng(int num)
        {
            string result = string.Empty;

            if (((num - (num % 100)) / 100) != 0) // проверяем имеет ли число третьий разряд
                switch (((num - (num % 100)) / 100))
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
            if (((num % 100) - ((num % 100) % 10)) / 10 != 1)// проверяем имеет ли число второй разряд
            {
                switch (((num % 100) - ((num % 100) % 10)) / 10)
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
                switch (num % 10)
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
            else switch (num % 100) // здесь проверяем второй разряд | если второй разряд >= 10 && второй разряд <= 19
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
            return result;
        }

        public string TranscriptRus(int num)
        {
            string result = string.Empty;

            if (((num - (num % 100)) / 100) != 0) // проверяем имеет ли число третьий разряд
            {
                switch (((num - (num % 100)) / 100))
                {
                    case 1: result += " сто"; break;
                    case 2: result += " двести"; break;
                    case 3: result += " триста"; break;
                    case 4: result += " четыреста"; break;
                    case 5: result += " пятьсот"; break;
                    case 6: result += " шестьсот"; break;
                    case 7: result += " семьсот"; break;
                    case 8: result += " восемьсот"; break;
                    case 9: result += " девятьсот"; break;
                }
            }
            if (((num % 100) - ((num % 100) % 10)) / 10 != 1)// проверяем имеет ли число второй разряд
            {
                switch (((num % 100) - ((num % 100) % 10)) / 10)
                {
                    case 2: result += " двадцать"; break;
                    case 3: result += " тридцать"; break;
                    case 4: result += " сорок"; break;
                    case 5: result += " пятьдесят"; break;
                    case 6: result += " шестьдесят"; break;
                    case 7: result += " семьдесят"; break;
                    case 8: result += " восемьдесят"; break;
                    case 9: result += " девяносто"; break;
                }
                switch (num % 10)
                {
                    case 1: result += " один"; break;//условие нужно для чисел больше миллиона
                    case 2: result += " два"; break;
                    case 3: result += " три"; break;
                    case 4: result += " четыре"; break;
                    case 5: result += " пять"; break;
                    case 6: result += " шесть"; break;
                    case 7: result += " семь"; break;
                    case 8: result += " восемь"; break;
                    case 9: result += " девять"; break;
                }
            }            
            else
                switch (num % 100) // здесь проверяем второй разряд | если второй разряд >= 10 && второй разряд <= 19
                {
                    case 10: result += " десять"; break;
                    case 11: result += " одиннадцать"; break;
                    case 12: result += " двенадцать"; break;
                    case 13: result += " тринадцать"; break;
                    case 14: result += " четырнадцать"; break;
                    case 15: result += " пятнадцать"; break;
                    case 16: result += " шестнадцать"; break;
                    case 17: result += " семнадцать"; break;
                    case 18: result += " восемннадцать"; break;
                    case 19: result += " девятнадцать"; break;
                }
            return result;
        }
    }
}
