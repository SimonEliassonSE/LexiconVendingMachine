using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public abstract class Products
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Cost { get; set; }
        public string Examine { get; set; }
        public string Use { get; set; }

        public virtual void UseProduct(string use)
        {
            throw new NotImplementedException();
        }

        public virtual void ExamineProduct(string examine)
        {
            throw new NotImplementedException();
        }

    }
}
