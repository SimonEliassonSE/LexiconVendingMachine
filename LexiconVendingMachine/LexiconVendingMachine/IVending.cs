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

        int InsertMoney(int currentWallet)
        {
            int wallet = 0;
            return wallet;
            
        }

        Dictionary<int, int> EndTransaction(int[] validDenominations, int valueToBeDenominated)
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();
            return myDictionary;
        }

    }
}
