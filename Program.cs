using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weight_for_weight_5
{
    class Program
    {
        public static string orderWeight(string strng)
        {
            //супер коротко, у меня все проходит, а в тестах нет...
            var text = Regex.Replace(strng, @"\D+", " ");
            var arr = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //var arr = strng.Trim('.').Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //var resArr=new List<int>();
            //var resArr1=new List<int>();
            // то же что и newArr
            //foreach (var number in arr)
            //{
            //    /*var digitSum = number.Select(i => int.Parse(i.ToString())).ToArray().Sum();// вместо цикла
            //    resArr.Add(digitSum);*/ 

            //    //то же самое, столько с циклом
            //    var sum = 0;
            //    foreach (char i in number)
            //    {
            //        sum += int.Parse(i.ToString());
            //    }
            //    resArr1.Add(sum);
            //}
            /*Array.Sort(resArr1.ToArray(), arr);
            var res = string.Join(' ', arr);*/

            //норм вариант, пишут, что Array.Sort не стабильно работает
            /*Array.Sort(arr);
            var newArr = arr.Select(i => i.Select(i => int.Parse(i.ToString())).ToArray().Sum()).ToArray();
            Array.Sort(newArr, arr);*/

            //этот вариант сработал
            /*arr = arr.OrderBy(x => x).ToArray();
            var arr1 = arr.OrderBy(i => i.Select(i => int.Parse(i.ToString())).ToArray().Sum()).ToArray();*/

            //вариант другой - делает массив строк удаляя пробелы ---------- сортирует  --- берет каждый элемент массива, разбивает его на отдельные символы и берет численное значение(если символ является числом) символа, суммирует символы-числа, сортирует по возрастанию чисел, а потом по возрастанию изначальные элементы представленные как строковые.
            var result = text.Split(' ',StringSplitOptions.RemoveEmptyEntries).OrderBy(w => w.Sum(c => char.GetNumericValue(c))).ThenBy(w => w);

            return string.Join(' ', result);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(orderWeight("...27 18 72 180 81 9 91 425 90 7920 67407 31064 96488 34608557 71899703..."));
            Console.WriteLine("18 180 27 72 81 9 90 91 425 31064 7920 67407 96488 34608557 71899703");
        }
    }
}
