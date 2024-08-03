using System.Globalization;
using System.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Date date = new Date(24 ,2, 1999);
            Console.WriteLine(date.PrintDate());

            Date date2 = new Date(2002);
            Console.WriteLine(date2.PrintDate());

            Console.ReadLine();
        }


    }
    // dd/mm/yyyy dd→ (int)[01-31]  mm→(int)[01-12] yyyy→(int)[0001-9999]
    public class Date
    {
        //Readonly refuse any change for the variable except in constructor
        private static readonly int[] DaysToMonth365 = {31,28,31,30,31,30,31,31,30,31,30,31};
        private int _day { get; set; }
        private int _month { get; set; }
        private int _year { get; set; }

      
        //Parameterized Constructor
        public Date(int day,int month, int year)
        {
            if (month > 0 && month <= 12 && year > 0)
            {
                if (day > 0 && day <= DaysToMonth365[month - 1])
                {
                    _day = day;
                    _month = month;
                    _year = year;
                }
                else
                {
                    Console.WriteLine($"The entered day is out of the range of month {month} which have max number of days of {DaysToMonth365[month - 1]}");
                }
            }
            else
            {
                Console.WriteLine("Entered Date is out of Range");
            }
        }
        //Constructor to take year and make month+day default of 01
        public Date(int year) : this(01,01,year)
        {
            if (year > 0)
            {
                _year = year;
            }
            else
            {
                Console.WriteLine("Entered Date is out of Range");
            }
        }
        public string PrintDate()
            {
                //To get format dd/mm/yyyy using padleft to fill 0 in empty spots
                return $"Date is: {_day.ToString().PadLeft(2, '0')}/{_month.ToString().PadLeft(2, '0')}/{_year.ToString().PadLeft(4, '0')}";
            }
    }
}