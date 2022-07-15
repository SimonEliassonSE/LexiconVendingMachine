using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public class Candy : Products
    {
        
        public override void ExamineProduct()
        {
            Console.WriteLine("\nThe product contains some sort of candy\n");
        }
        public override void UseProduct()
        {
            Console.WriteLine("\nYou eat the candy\nThe candy is sweet and tasty!\n");
        }

    }
}
