using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public class Snacks : Products
    {

        public override void ExamineProduct()
        {
            Console.WriteLine("\nThe product contain some kind of snacks\n");
        }
        public override void UseProduct()
        {
            Console.WriteLine("\nYou eat the snack\nThe snack is tasty!\n");
        }

    }
}
