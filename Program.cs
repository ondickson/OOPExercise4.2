using System;
using System.Collections.Generic;
using E42Owusu;

class Program
{
    // Moved the accounts list to the class level so it can be accessed throughout the program
    static List<Account> accounts = new List<Account>();

    static void Main(string[] args)
    {
        // Create some accounts
        Account acct1 = new Account(1542, "Freddie", 2500);
        Account acct2 = new Account(6234, "Juliet", 3000);
        Account acct3 = new Account(1243, "Katy", 2000);

        // Add the accounts to the list
        accounts.Add(acct1);
        accounts.Add(acct2);
        accounts.Add(acct3);

        // Main loop
        bool continueProgram = true;

        while (continueProgram)
        {
            DisplayMenu();

            // Read user input
            Console.Write("\nEnter code: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int result))
            {
                switch (result)
                {
                    case 1:
                        CreditAccount();
                        break;
                    case 2:
                        DebitAccount();
                        break;
                    case 3:
                        TransferFunds();
                        break;
                    case 4:
                        InquireBalance();
                        break;
                    case 5:
                        Console.WriteLine("Exit");
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    // Method to display the menu
    static void DisplayMenu()
    {
        Console.WriteLine("\n*** Choose Transaction ***");
        Console.WriteLine("[1] Credit");
        Console.WriteLine("[2] Debit");
        Console.WriteLine("[3] Transfer");
        Console.WriteLine("[4] Inquire");
        Console.WriteLine("[5] Exit");
    }

    // Method to find an account by account number
    static Account FindAccount(int accountNumber)
    {
        foreach (Account account in accounts)
        {
            if (account.getAccountNumber() == accountNumber)
            {
                return account;
            }
        }
        return null;
    }

    // Method to credit an account
    static void CreditAccount()
    {
        Console.Write("Enter Account No: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Account account = FindAccount(accountNumber);

        Console.Write("Amount to Credit: ");
        double amount = double.Parse(Console.ReadLine());

        account.Credit(amount);
    }

    // Method to debit an account
    static void DebitAccount()
    {
        Console.Write("Enter Account No: ");
        int accountNumber = int.Parse(Console.ReadLine());

        Account account = FindAccount(accountNumber);
        Console.Write("Amount to Credit: ");

        double amount = double.Parse(Console.ReadLine());

        account.Debit(amount);
    }

    // Method to transfer funds between accounts
    static void TransferFunds()
    {
        Console.Write("Enter Source Account No: ");
        int sourceAccountNumber = int.Parse(Console.ReadLine());
        Account sourceAccount = FindAccount(sourceAccountNumber);

        // Ask for the receiver account number
        Console.Write("Enter Receiver Account No: ");
        int receiverAccountNumber = int.Parse(Console.ReadLine());
        Account receiverAccount = FindAccount(receiverAccountNumber);

        // Ask for the amount to transfer
        Console.Write("Enter amount to transfer: ");
        double amount = double.Parse(Console.ReadLine());

        sourceAccount.Debit(amount);
        receiverAccount.Credit(amount);

        Console.WriteLine("Transfer Completed!");
    }

    // Method to inquire about account balance
    static void InquireBalance()
    {
        Console.Write("\nEnter Account No: ");
        int inquireAcountNumber = int.Parse(Console.ReadLine());
        Account inquireAccount = FindAccount(inquireAcountNumber);
        Console.WriteLine("Current Balance is " + inquireAccount.GetBalance());
    }
}
