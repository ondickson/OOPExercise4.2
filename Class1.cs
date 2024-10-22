using System;
using System.Collections.Generic;

namespace E42Owusu
{
    public class Account
    {

        // Attribute declaration
        private int accountNumber;
        private string name;
        private double balance;

        // Default constructor
        public Account() { }

        // Parameterized constructor
        public Account(int accountNumber, string name, double balance)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.balance = balance;
        }

        // Mutator methods (Setters)
        public void setAccountNumber(int accountNumber) { this.accountNumber = accountNumber; }
        public void setName(string name) { this.name = name;}
        public void setBalance(double balance) { this.balance = balance;}


        // Accessor methods (Getters)
        public int getAccountNumber() { return accountNumber; }
        public string GetName() { return name; }
        public double GetBalance() { return balance; }

        // Method to credit the account
        public void Credit(double amount)
        {
            balance += amount;
        }

        // Method to debit the account
        public bool Debit(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

    }
}
