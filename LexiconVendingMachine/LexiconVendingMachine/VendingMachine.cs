using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconVendingMachine
{

  
    public class VendingMachine : IVending
    {
        public readonly int[] denominationArray = new int[11] { 0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };        
        public readonly int[] denominationArrayWithout0 = new int[10] {1000, 500, 200, 100, 50, 20, 10, 5, 2, 1 };
            // Second dictionary was created as the first one accept 0 to be able to stop loops at a few places.
            // However i needed a dictionary that did not accept 0 to be able to return the changes in correct denomination.

        //public readonly string[] productIDArray = new string[9] {"sd1", "sd2", "sd3", "sn1", "sn2", "sn3","ca1","ca2","ca3"};        
            // Removed this pice of code as it's no longer neccisary since im using the (!productsList.Any(Products => Products.ID == userInput)) to search
            // In the existing productList, this is also a loot more dynamic!
        public List<Products> productsList = new List<Products>();
        public List<Products> itemBag = new List<Products>();        
        public Dictionary<int, string> remaningChange = new Dictionary<int, string>();
        public bool goAgain = true;
        public int currentWallet = 2888; // Changed from 0 to 2888 for testing purpose
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
                              "| 0. Shut down Vending machine    |\n" +
                              "|---------------------------------|\n\n" +
                              $"Current funds: {currentWallet} kr\n\n" +
                              "\n Please enter a menu chooise\n");
        }
        
        public void MenuChooise(int input)
        {
            switch (input)
            {

                case 0:
                    {
                        Console.WriteLine("\nRequest to end vending machine process engaged!\n" +
                                          "Forcing money return process!\n");

                        // Code contains the "old" EndTranscation
                        //int money;
                        //Console.WriteLine($"Saldo befor money return {currentWallet} kr");
                        //money = EndTransaction(currentWallet);
                        //currentWallet = money;
                        //Console.WriteLine(currentWallet);
                        //goAgain = false;
                        //break;

                        Dictionary<int, int> returnedChange = new Dictionary<int, int>();
                        returnedChange = EndTransaction(denominationArrayWithout0, currentWallet);
                        foreach (KeyValuePair<int, int> kvp in returnedChange) { Console.WriteLine($"{kvp.Key}: {kvp.Value}"); }
                        Console.WriteLine($"\nA total of {currentWallet} kr was returned.");
                        currentWallet = 0;
                        goAgain = false;
                        break;
                    }

                case 1:
                    {
                        bool stopAddingToWallet = true;                       
                        int money;
                        int moneyInput = 0;
                        while (stopAddingToWallet)
                        {
                            do
                            {
                                Console.WriteLine("\nPlease insert your money, Acceptebal currency is: 1,2,5,10,20,50,100,200,500,1000" +
                                    "\nTo stop adding money to the vending machine enter 0");
                                moneyInput = InputCollection.GetIntFromUser();

                            }
                            while (!denominationArray.Contains(moneyInput));

                            money = InsertMoney(moneyInput);
                            

                            if(money == 0)
                            {
                                stopAddingToWallet = false;
                            }

                            else 
                            {
                                currentWallet = currentWallet + money;
                            }
                        }
                        Console.WriteLine(currentWallet);
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
                        // Code contains the "old" EndTranscation
                        //int money;
                        //Console.WriteLine($"Saldo befor money return {currentWallet} kr");
                        //money = EndTransaction(currentWallet);
                        //currentWallet = money;
                        //Console.WriteLine("Press any key to exit money return process");
                        //Console.ReadKey();

                        Dictionary<int, int> returnedChange = new Dictionary<int, int>();
                        returnedChange = EndTransaction(denominationArrayWithout0, currentWallet);
                        foreach (KeyValuePair<int, int> kvp in returnedChange) { Console.WriteLine($"{kvp.Key}: {kvp.Value}"); }
                        Console.WriteLine($"\nA total of {currentWallet} kr was returned.");
                        Console.ReadLine();
                        currentWallet = 0;
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
                
                if (!productsList.Any(Products => Products.ID == userId)) //!productIDArray.Contains(userId)) 
                    // Added a more effective way to search if user input (userId) exist inside the product list. 
                    // My string array with hardcoded ID's wont be necisary anymore. 
                { 
                        Console.WriteLine("Your input is not valid! Try again");
                    }

            } while (!productsList.Any(Products => Products.ID == userId));
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
                    //Console.WriteLine($"\n{result.Examine}\n");
                    result.ExamineProduct();
                }
                else if (userInput == 2)
                {
                    Console.WriteLine($"Current saldo {currentWallet}\n" +
                        $"{result.Name} cost: {result.Cost}\n" +
                        $"How many would you like to buy?\n");
                    userInput = InputCollection.GetIntFromUser();
                    totalCost = (userInput * result.Cost);
                    if(totalCost <= currentWallet)
                    {
                        Console.WriteLine($"\nYou have purchased a total of {userInput} {result.Name}\n");
                        currentWallet = currentWallet - totalCost;
                        for (int i = 0; i < userInput; i++)
                        {
                            itemBag.Add(result);
                        }
                        Console.WriteLine("\nPress any key to return to main menu");
                        Console.ReadKey();
                        userInput = 0;
                    }

                    else if (totalCost > currentWallet)
                    {
                        Console.WriteLine("You funds are insuficent, please insert more money or buy less of the product");
                    }
                    
                }

                else if (userInput == 0)
                {
                    Console.WriteLine("Going back to main menu");
                }
            } while ( userInput != 0);

            

        }
        public void ShowAll() // shows al products bought, lets user "use" the product aswell
                              // Hase a get input (int) from user, to let the user diced to use item or go back to main menu
                              // if use is choosen user gets in to a loop that loops until 
        {
            bool isDead = false;
            if (itemBag.Count <= 0)
            {
                Console.WriteLine("There is no items in your bag to use!\n" +
                                  "Returning to main menu\n" +
                                  "Enter any key to return to main menu");
                Console.ReadLine();
                isDead = true;
            }
            while (!isDead) 
            { 
            int index = 0;
            int input;
            string userInput;
               
                    Console.WriteLine($"\n Items in bag: {itemBag.Count}\n\n");
                    Console.WriteLine("0. Press [0] to return to main menu\n" +
                                      "1. Press [Any other number] to use an item\n");
                    input = InputCollection.GetIntFromUser();

                if (input == 0)
                {
                    Console.WriteLine("Returning to main menu");
                    isDead = true;
                }                

                else {
                        if (itemBag.Count > 0) 
                        { 
                            Console.WriteLine("This is al the items you have bought so far!\n");
                            foreach (var item in itemBag)
                            {
                                Console.WriteLine($"{index}. ID: {item.ID}, Name: {item.Name}, Type:{item.Type}, Cost: {item.Cost} Kr");
                                index++;
                            }

                        do
                        {
                            Console.WriteLine("Please enter the ID of the item you wish to use");
                            userInput = InputCollection.GetStringFromUser();

                            if (!productsList.Any(Products => Products.ID == userInput))
                            //(!productIDArray.Contains(userInput))
                            {
                                Console.WriteLine("The ID you enter is not correct. Try again!");
                            }

                        } while (!productsList.Any(Products => Products.ID == userInput));

                            Products result = productsList.Find(Products => Products.ID == userInput);
                            result.UseProduct();
                            //Console.WriteLine($"\n{result.Use}");
                            itemBag.Remove(result);
                        }

                    else { Console.WriteLine("Your item bag is empty, there is no item left to use\n" +
                                             "Press any key to return to the main menu"); Console.ReadLine(); isDead = true; }
                     }
                }
            }   

        public int InsertMoney(int moneyInput) 
        {
            int wallet = 0;
            
                if (moneyInput == 0)
                {
                    return 0;
                }

                else
                {
                    wallet = wallet + moneyInput;
                }
                
            return wallet;
        }
        // This Code have been commeted out as of to reminde me how one can do this code more effectiv 
        //public int EndTransaction(int currentSum) 
        //{


        //VendingMachine start = new VendingMachine();

        //int tusenLappar = 1;
        //int femHundraLappar = 1;
        //int tvåHundraLappar = 1;
        //int hundraLappar = 1;
        //int femtioLappar = 1;
        //int tjugoLappar = 1;
        //int tioKrona = 1;
        //int femKrona = 1;
        //int tvåKrona = 1;
        //int enKrona = 1;
        //int index = 0;

        //do
        //{
        //    if (currentSum >= 1000)
        //    {

        //        currentSum -= 1000;
        //        remaningChange.Add(index, $"Amount: {tusenLappar}, 1000 Bill");
        //        index++;

        //    }

        //    else if (currentSum >= 500)
        //    {

        //        currentSum -= 500;
        //        remaningChange.Add(index, $"Amount: {femHundraLappar}, 500 Bill");
        //        index++;
        //    }

        //    else if (currentSum >= 200)
        //    {

        //        currentSum -= 200;
        //        remaningChange.Add(index, $"Amount: {tvåHundraLappar}, 200 Bill");
        //        index++;
        //    }

        //    else if (currentSum >= 100)
        //    {

        //        currentSum -= 100;
        //        remaningChange.Add(index, $"Amount: {hundraLappar}, 100 Bill");
        //        index++;
        //    }

        //    else if (currentSum >= 50)
        //    {

        //        currentSum -= 50;
        //        remaningChange.Add(index, $"Amount: {femtioLappar}, 50 Bill");
        //        index++;
        //    }

        //    else if (currentSum >= 20)
        //    {

        //        currentSum -= 20;
        //        remaningChange.Add(index, $"Amount: {tjugoLappar}, 20 Bill");
        //        index++;
        //    }

        //    else if (currentSum >= 10)
        //    {

        //        currentSum -= 10;
        //        remaningChange.Add(index, $"Amount: {tioKrona}, 10 Coin");
        //        index++;
        //    }
        //    else if (currentSum >= 5)
        //    {

        //        currentSum -= 5;
        //        remaningChange.Add(index, $"Amount: {femKrona}, 5 Coin");
        //        index++;
        //    }
        //    else if (currentSum >= 2)
        //    {

        //        currentSum -= 2;
        //        remaningChange.Add(index, $"Amount: {tvåKrona}, 2 Coin");
        //        index++;
        //    }
        //    else if (currentSum >= 1)
        //    {

        //        currentSum -= 1;
        //        remaningChange.Add(index, $"Amount: {enKrona}, 1 Coin");
        //        index++;
        //    }

        //} while (currentSum != 0);

        //Console.WriteLine("Returned Change");

        //foreach (KeyValuePair<int, string> change in remaningChange)
        //{
        //    Console.WriteLine($"{change.Value}");
        //}

        //tusenLappar = 0;
        //femHundraLappar = 0;
        //tvåHundraLappar = 0;
        //hundraLappar = 0;
        //femtioLappar = 0;
        //tjugoLappar = 0;
        //tioKrona = 0;
        //femKrona = 0;
        //tvåKrona = 0;
        //enKrona = 0;
        //index = 0;
        //remaningChange.Clear();

        //return currentSum;

        //} 

        static Dictionary<int, int> EndTransaction(int[] validDenominations, int valueToBeDenominated)
        {
            Dictionary<int, int> myDictionary = new Dictionary<int, int>();

            int integerPart = 0;
            for (int i = 0; i < validDenominations.Length; i++)
            {
                integerPart = valueToBeDenominated / validDenominations[i];
                myDictionary.Add(validDenominations[i], integerPart);
                valueToBeDenominated = valueToBeDenominated % validDenominations[i];
            }
            
            return myDictionary;
        }
    }
}
