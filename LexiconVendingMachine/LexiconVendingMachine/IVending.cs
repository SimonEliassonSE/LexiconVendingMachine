using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{
    public interface IVending
    {
        void Purchase(int wallet)
        {
            
        }

        void ShowAll()
        {
            
        }

        int InsertMoney()
        {
            int wallet = 0;
            return wallet;
            
        }

        int EndTransaction(int money)
        {
            int transaction = 0;
            return transaction; 
        }

    }
}
