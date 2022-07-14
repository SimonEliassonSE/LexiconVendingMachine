using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public class InputCollection
    {
        public static string GetStringFromUser()
        {
            string userString;

            do
            {
                userString = Console.ReadLine().ToLower();
                if (string.IsNullOrWhiteSpace(userString)) { Console.WriteLine("Inccorect input, may not be empty!"); }

            } while (string.IsNullOrWhiteSpace(userString));

            return userString;
        }

        public static int GetIntFromUser()
        {
            bool isNumeric;
            int num;
            do
            {
                string input = GetStringFromUser();
                isNumeric = int.TryParse(input, out num);

                if (isNumeric)
                { return num; }
                else { Console.WriteLine("The input was not correct, try again!(may not contain letters)"); }



            } while (!isNumeric);
            return num;
        }

    }
}
