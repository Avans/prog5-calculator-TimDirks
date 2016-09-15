using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program: IAgeCalculator
    {

        static void Main(string[] args)
        {
            IAgeCalculator obj = new Program();
            bool result;
            String input;
            DateTime testDate = new DateTime(2000,01,01);
            String input2 = "open";
            while (!input2.Equals("close"))
            {
                result = false;
                while (!result)
                {
                    Console.WriteLine("Date of birth (dd-mm-yyyy):");
                    input = Console.ReadLine();
                    result = obj.ParseInput(input, out testDate);
                }

                int age = obj.CalculateAge(testDate);
                Console.WriteLine("Your age is: {0}", age);
                Console.WriteLine("Hit enter to calculate again or type 'close' to exit.");
                input2 = Console.ReadLine();
            }
        }

        public bool ParseInput(string input, out DateTime result)
        {
            if (DateTime.TryParse(input, out result))
            {
                String.Format("{0:d/MM/yyyy}", result);
                return true;
            }
            else
            {
                Console.WriteLine("Invalid date, try again.");
                return false;
            }
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            DateTime localDate = DateTime.Now;
            int age = localDate.Year - dateOfBirth.Year;
            if (dateOfBirth.DayOfYear > localDate.DayOfYear)
            {
                age--;
            }
            return age;
        }
    }
}
