using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public class SoftDrink : Products
    {

        public override void ExamineProduct()
        {
            Console.WriteLine("\nContains some sort of liquid\n");
        }
        public override void UseProduct()
        {
            Console.WriteLine("You drink the drink\nIts very refreshing!\n");
        }
    }
}
