using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }
    public class BankingSystem
    {
        double balance;

        public BankingSystem(double presentBalance)
        {
            balance = presentBalance;
        }

        public void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine($"The Deposited amount is: {amount}, and the available balance is: {balance}");
        }

        public void Withdraw(double amount)
        {
            if(amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"The Withdrawal amount is: {amount}, and the available balance is: {balance}");
            }
            else
            {
                throw new InsufficientBalanceException("Withdrawal amount is Exceeding the Balance Amount");
            }
            
        }
    }

    public class Bank
    {
        static void Main()
        {
            Console.WriteLine("Enter the Present or the Initial Balance");
            double presentBalance = Convert.ToDouble(Console.ReadLine());

            BankingSystem bankingSystem = new BankingSystem(presentBalance);

            Console.WriteLine("Enter the amount to be Deposited");
            double DepositAmount = Convert.ToDouble(Console.ReadLine());
            bankingSystem.Deposit(DepositAmount);

            try
            {
                Console.WriteLine("Enter the Withdrawal amount");
                double WithdrawAmount = Convert.ToDouble(Console.ReadLine());
                bankingSystem.Withdraw(WithdrawAmount);

            }
            catch(InsufficientBalanceException exc)
            {
                Console.WriteLine($"Exception: { exc.Message}");
            }
            Console.Read();

        }
    }
}
