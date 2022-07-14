using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public class SoftDrink : Products
    {
        public override void UseProduct(string use)
        {
            Console.WriteLine(use);
        }

        public override void ExamineProduct(string examine)
        {
            Console.WriteLine(examine);
        }
    }
}
