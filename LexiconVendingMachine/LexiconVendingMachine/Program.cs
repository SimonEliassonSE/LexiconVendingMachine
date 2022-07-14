

using LexiconVendingMachine;


int userInput;
VendingMachine start = new VendingMachine();
start.ProductList();

while (start.goAgain)
{
    start.MainMenu();
    userInput = InputCollection.GetIntFromUser();
    start.MenuChooise(userInput);
    
}
//foreach(var item in start.productsList)
//{
//    Console.WriteLine
//       ($"Name: {item.Name}\n" +
//        $"Type: {item.Type}\n" +
//        $"Cost: {item.Cost}\n" +
//        $"Examine: {item.Examine}\n" +
//        $"Use: {item.Use}\n\n" );
//}


//static int UpdateWallet()
//{
//    bool stopAddingToVallet = true;
//    bool correctInput = false;
//    List<int> list = new List<int>() { 0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };    
//    int moneyInput;
//    int wallet = 0;

//    while (stopAddingToVallet)
//    {
//        do
//        {           
//            Console.WriteLine("Please insert your money, Acceptebal currency is: 1,2,5,10,20,50,100,200,500,1000" +
//                "\nTo stop adding money to the vending machine enter 0");
//            moneyInput = GetIntFromUser();           

//        }
//        while (!correctInput && !list.Contains(moneyInput));

//        if (moneyInput == 0)
//        {
//            stopAddingToVallet = false;

//        }

//        else
//        {
//            wallet = wallet + moneyInput;            
//            Console.WriteLine(wallet);
//        }        
//    }
//    return wallet;
//}


//static void EndTransaction(int finalSum)
//{
//    int result;
//    if (finalSum < 1000)
//    {
//        finalSum = finalSum - 1000;
//        result = 1000;

//    } 
//}

