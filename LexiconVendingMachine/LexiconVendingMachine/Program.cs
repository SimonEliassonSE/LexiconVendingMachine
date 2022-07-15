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


