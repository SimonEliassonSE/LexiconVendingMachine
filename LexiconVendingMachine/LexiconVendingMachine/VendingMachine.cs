using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{

  
    public class VendingMachine /*: IVending*/
    {
        public readonly int[] denominationArray = new int[11] { 0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
        public readonly string[] productIDArray = new string[9] {"sd1", "sd2", "sd3", "sn1", "sn2", "sn3","ca1","ca2","ca3"};        
        public List<Products> productsList = new List<Products>();
        public List<Products> itemBag = new List<Products>();        
        public Dictionary<int, string> remaningChange = new Dictionary<int, string>();
        public bool goAgain = true;
        public int currentWallet = 0;
        public void ProductList()
        {
            CreateProductList();
;
        }
        
        private void CreateProductList()
        {
            SoftDrink softDrink = new SoftDrink();
            softDrink.ID = "sd1";
            softDrink.Name = "Pepsi Max";
            softDrink.Type = "Soft Drink";
            softDrink.Cost = 20;
            softDrink.Examine = "Contains a black suagary liquid";
            softDrink.Use = "Drinks the drink \nthe drink is cold and refreshing";
            productsList.Add(softDrink);

            SoftDrink softDrink2 = new SoftDrink();
            softDrink2.ID = "sd2";
            softDrink2.Name = "Fanta";
            softDrink2.Type = "Soft Drink";
            softDrink2.Cost = 25;
            softDrink2.Examine = "Contains a yellow orange tasting liquid";
            softDrink2.Use = "Drinks the drink \nthe drink is cold and refreshing";
            productsList.Add(softDrink2);

            SoftDrink softDrink3 = new SoftDrink();
            softDrink3.ID = "sd3";
            softDrink3.Name = "Sprite";
            softDrink3.Type = "Soft Drink";
            softDrink3.Cost = 20;
            softDrink3.Examine = "Contains a translusent citrus tasking liquid";
            softDrink3.Use = "Drinks the drink \nthe drink is cold and refreshing";
            productsList.Add(softDrink3);

            Snacks snacks = new Snacks();
            snacks.ID = "sn1";
            snacks.Name = "Pringels";
            snacks.Type = "Snack";
            snacks.Cost = 40;
            snacks.Examine = "Contains thinly compressed potato chips";
            snacks.Use = "Eats the chips \nthe chips are lightly salty and crunchy";
            productsList.Add(snacks);

            Snacks snacks2 = new Snacks();
            snacks2.ID = "sn2";
            snacks2.Name = "Lays potato chip";
            snacks2.Type = "Snack";
            snacks2.Cost = 35;
            snacks2.Examine = "Contains thinly sliced potato chips";
            snacks2.Use = "Eats the chips \nthe chips are lightly salty and crunchy";
            productsList.Add(snacks2);

            Snacks snacks3 = new Snacks();
            snacks3.ID = "sn3";
            snacks3.Name = "Bag of peanuts";
            snacks3.Type = "Snack";
            snacks3.Cost = 50;
            snacks3.Examine = "Contains salted peanuts";
            snacks3.Use = "Eats peanuts \nit taste like a peanut butter jelly toast without the toast or jelly";
            productsList.Add(snacks3);

            Candy candy = new Candy();
            candy.ID = "ca1";
            candy.Name = "Snicker";
            candy.Type = "Candy";
            candy.Cost = 30;
            candy.Examine = "Contains a choclate bar with peanuts inside";
            candy.Use = "Eats the candy \nthe choclate bar is sweet and cruncy";
            productsList.Add(candy);

            Candy candy2 = new Candy();
            candy2.ID = "ca2";
            candy2.Name = "Mars";
            candy2.Type = "Candy";
            candy2.Cost = 30;
            candy2.Examine = "Contains a choclate bar with a creamy & smooth texture inside";
            candy2.Use = "Eats the candy \nthe choclate bar is sweet and creamy";
            productsList.Add(candy2);

            Candy candy3 = new Candy();
            candy3.ID = "ca3";
            candy3.Name = "Bounty";
            candy3.Type = "Candy";
            candy3.Cost = 30;
            candy3.Examine = "Contains a choclate bar with coconutflake's inside";
            candy3.Use = "Eats the candy \nthe choclate bar is sweet and taste like coconut!";
            productsList.Add(candy3);

            
        }

        public void MainMenu()
        {
            Console.Clear();
        Console.WriteLine(
                              "|---------------------------------|\n" +
                              "|  Welcome to my vending machine  |\n" +
                              "|---------------------------------|\n" +
                              "|                                 |\n" +
                              "|  ------- Menu chooise --------  |\n" +
                              "| 1. Insert money                 |\n" +
                              "| 2. Purchase product's           |\n" +
                              "|   - Contains examine function's |\n" +
                              "| 3. Show owned product's         |\n" +
                              "|   - Contains use function's     |\n" +
                              "| 4. End transaction              |\n" +
                              "|   - Contains money return       |\n" +
                              "|---------------------------------|\n\n" +
                              $"Current funds: {currentWallet} kr\n\n" +
                              "\n Please enter a menu chooise\n");
        }
        
        public void MenuChooise(int input)
        {
            switch (input)
            {
                case 1:
                    {
                        int money;
                        money = InsertMoney();
                        currentWallet = currentWallet + money;
                        
                        break;
                    }

                case 2:
                    {
                        Purchase(currentWallet);
                        break;
                    }

                case 3:
                    {
                        ShowAll();
                        break;
                    }

                case 4:
                    {
                        int money;
                        Console.WriteLine($"Saldo befor money return {currentWallet} kr");
                        money = EndTransaction(currentWallet);
                        currentWallet = money;
                        Console.WriteLine(currentWallet);
                        
                        break;
                    }

                default:
                    {

                        Console.WriteLine($"Wrong Input: {input}, dose not exist in menu");
                        break;
                    }
            }
        }

        public void Purchase(int wallet)
        {
            string userId;
            int userInput;
            int totalCost;
            Console.WriteLine("The following items can be bought\n");
            foreach(var item in productsList)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Type:{item.Type}, Cost: {item.Cost} Kr");
            }
            do
            {
                Console.WriteLine("\nPlease enter the ID of the product that you wish to inspect further");
                userId = InputCollection.GetStringFromUser();

                if (!productIDArray.Contains(userId)) 
                    { 
                        Console.WriteLine("Your input is not valid! Try again");
                    }

            } while (!productIDArray.Contains(userId));
            Console.Clear();
           
            do
            {
                Products result = productsList.Find(x => x.ID == userId);
                Console.WriteLine($"ID: {result.ID}, Name: {result.Name}, Type:{result.Type}, Cost: {result.Cost} Kr");
                Console.WriteLine
                    ("1. Examine product\n" +
                    "2. Buy product\n" +
                    "0. Go back to main menu\n\n");
                userInput = InputCollection.GetIntFromUser();

                if (userInput == 1)
                {
                    Console.WriteLine($"{result.Examine}");
                }
                else if (userInput == 2)
                {
                    Console.WriteLine($"Current saldo {currentWallet}\n" +
                        $"{result.Name} cost: {result.Cost}\n" +
                        $"How many would you like to buy?");
                    userInput = InputCollection.GetIntFromUser();
                    totalCost = (userInput * result.Cost);
                    if(totalCost <= currentWallet)
                    {
                        Console.WriteLine($"You have purchased a total of {userInput} {result.Name}");
                        currentWallet = currentWallet - totalCost;
                        for (int i = 0; i < userInput; i++)
                        {
                            itemBag.Add(result);
                        }
                    }

                    else if (totalCost > currentWallet)
                    {
                        Console.WriteLine("You funds are insuficent, please insert more money or buy less of the product");
                    }
                    
                }

                else if (userInput == 0)
                {
                    Console.WriteLine("Going back to main ment");
                }
            } while ( userInput != 0);

        }
        public void ShowAll()
        {
            foreach (var item in itemBag)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Type:{item.Type}, Cost: {item.Cost} Kr");
            }
            Console.ReadKey();
        }

        public int InsertMoney()
        {
            bool stopAddingToWallet = true;
            bool correctInput = false;            
            int moneyInput;
            int wallet = 0;

            while (stopAddingToWallet)
            {
                do
                {
                    Console.WriteLine("Please insert your money, Acceptebal currency is: 1,2,5,10,20,50,100,200,500,1000" +
                        "\nTo stop adding money to the vending machine enter 0");
                    moneyInput = InputCollection.GetIntFromUser();

                }
                while (!correctInput && !denominationArray.Contains(moneyInput));

                if (moneyInput == 0)
                {
                    stopAddingToWallet = false;

                }

                else
                {
                    wallet = wallet + moneyInput;
                    Console.WriteLine(wallet);
                }
            }
            return wallet;

        }
        public int EndTransaction(int currentSum)
        {
            VendingMachine start = new VendingMachine();

            int tusenLappar = 1;
            int femHundraLappar = 1;
            int tvåHundraLappar = 1;
            int hundraLappar = 1;
            int femtioLappar = 1;
            int tjugoLappar = 1;
            int tioKrona = 1;
            int femKrona = 1;
            int tvåKrona = 1;
            int enKrona = 1;
            int index = 0;

            do
            {                
                if (currentSum >= 1000)
                {

                    currentSum -= 1000;
                    remaningChange.Add(index, $"Amount: {tusenLappar} 1000 Bill");
                    tusenLappar++;
                    index++;

                }

                else if (currentSum >= 500) 
                {
                    
                    currentSum -= 500;
                    remaningChange.Add(index, $"Amount: {femHundraLappar} 500 Bill");
                    femHundraLappar++;
                    index++;
                }

                else if (currentSum >= 200)
                {
                    
                    currentSum -= 200;
                    remaningChange.Add(index, $"Amount: {tvåHundraLappar} 200 Bill");
                    tvåHundraLappar++;
                    index++;
                }

                else if (currentSum >= 100)
                {
                    
                    currentSum -= 100;
                    remaningChange.Add(index, $"Amount: {hundraLappar} 100 Bill");
                    hundraLappar++;
                    index++;
                }

                else if (currentSum >= 50)
                {
                    
                    currentSum -= 50;
                    remaningChange.Add(index, $"Amount: {femtioLappar} 50 Bill");
                    femtioLappar++;
                    index++;
                }

                else if (currentSum >= 20)
                {
                    
                    currentSum -= 20;
                    remaningChange.Add(index, $"Amount: {tjugoLappar} 20 Bill");
                    tjugoLappar++;
                    index++;
                }

                else if (currentSum >= 10)
                {
                   
                    currentSum -= 10;
                    remaningChange.Add(index, $"Amount: {tioKrona} 10 Coin");
                    tioKrona++;
                    index++;
                }
                else if (currentSum >= 5)
                {
                    
                    currentSum -= 5;
                    remaningChange.Add(index, $"Amount: {femKrona} 5 Coin");
                    femKrona++;
                    index++;
                }
                else if (currentSum >= 2)
                {
                    
                    currentSum -= 2;
                    remaningChange.Add(index, $"Amount: {tvåKrona} 2 Coin");
                    tvåKrona++;
                    index++;
                }
                else if (currentSum >= 1)
                {
                    
                    currentSum -= 1;
                    remaningChange.Add(index, $"Amount: {enKrona} 1 Coin");
                    enKrona++;
                    index++;
                }

                else { Console.WriteLine("Start return of funds"); }
            } while (currentSum != 0);

            Console.WriteLine("Returned Change's");

            foreach(KeyValuePair<int, string> change in remaningChange)
            {
                Console.WriteLine($"{change.Value}");
            }

                  tusenLappar = 0;
                  femHundraLappar = 0;
                  tvåHundraLappar = 0;
                  hundraLappar = 0;
                  femtioLappar = 0;
                  tjugoLappar = 0;
                  tioKrona = 0;
                  femKrona = 0;
                  tvåKrona = 0;
                  enKrona = 0;
                  index = 0;
                  remaningChange.Clear();
            Console.ReadKey();
            return currentSum;

        }
    }
}
