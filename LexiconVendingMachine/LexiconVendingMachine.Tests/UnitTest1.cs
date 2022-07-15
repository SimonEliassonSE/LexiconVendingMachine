namespace LexiconVendingMachine.Tests;
    using System.IO;


    public class UnitTest1
    {
        [Fact]
        public void ReturnChangeTest()
        {
            // Arrrenge
            int num1 = 1523;
            int expected = 0;
            int actual; 

            // Act

            VendingMachine start = new VendingMachine();
            actual = start.EndTransaction(num1);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReturnZeroChangeTest()
        {
            // Arrrenge
            int num1 = 0;
            int expected = 0;
            int actual;

            // Act

            VendingMachine start = new VendingMachine();
            actual = start.EndTransaction(num1);

            //Assert
            Assert.Equal(expected, actual);
        }

    [Fact]
    public void Input1000ToWalletTest()
    {
        // Arrrenge
        int num1 = 1000;
        int expected = 1000;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input500ToWalletTest()
    {
        // Arrrenge
        int num1 = 500;
        int expected = 500;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input200ToWalletTest()
    {
        // Arrrenge
        int num1 = 200;
        int expected = 200;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input100ToWalletTest()
    {
        // Arrrenge
        int num1 = 100;
        int expected = 100;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input50ToWalletTest()
    {
        // Arrrenge
        int num1 = 50;
        int expected = 50;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input20ToWalletTest()
    {
        // Arrrenge
        int num1 = 20;
        int expected = 20;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input10ToWalletTest()
    {
        // Arrrenge
        int num1 = 10;
        int expected = 10;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input5ToWalletTest()
    {
        // Arrrenge
        int num1 = 5;
        int expected = 5;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input2ToWalletTest()
    {
        // Arrrenge
        int num1 = 2;
        int expected = 2;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input1ToWalletTest()
    {
        // Arrrenge
        int num1 = 1;
        int expected = 1;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Input0ToExitWalletTest() // Works like this, returns 0, in the case there is an IF that ends the loop if the returned int is = 0;
    {
        // Arrrenge
        int num1 = 0;
        int expected = 0;
        int actual;

        // Act

        VendingMachine start = new VendingMachine();
        actual = start.InsertMoney(num1);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ListInitiationTest() // Checks if list is 9, if it isent 9 it havent been initsialised
    {
        // Arrrenge
        
        int expected = 9;
        int actual;

        // Act
        VendingMachine start = new VendingMachine();
        start.ProductList();
        actual =  start.productsList.Count();


        //Assert
        Assert.Equal(expected, actual);

    }

    [Fact]
    public void denominationArray() // We are dubbel checking that the denominationArray contains what is should contain
                                    // the 0 is added to ensure that the program can "exit" the loop but wont be caught in the wallet
    {
        // Arrrenge

        int[] expected = new int[] { 0, 1, 2, 5, 10, 20, 50, 100, 200, 500, 1000 };
        int[] actual; 

        // Act
        VendingMachine start = new VendingMachine();
        start.ProductList();
        actual = start.denominationArray;


        //Assert
        Assert.Equal(expected, actual);

    }
                                    


}

