using System;


namespace Assignment3
{
    class Accounts
    {
        public int AccountNo;
        public string CustomerName;
        public string AccountType;
        public string TransactionType;
        public int Amount;
        public int Balance;


       public void GetData()
        {
            Console.WriteLine("Enter the Account number:");
            AccountNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Customer Name:");
            CustomerName = Console.ReadLine();
            Console.WriteLine("Enter the Account Tpye:");
            AccountType = Console.ReadLine();
            Console.WriteLine("Enter the Balance/Total amount in the account:");
            Balance = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Transaction Type as Deposit/Withdrawal:");
            TransactionType = Console.ReadLine();
            Console.WriteLine("Enter the Amount:");
            Amount = Convert.ToInt32(Console.ReadLine());
        }

        public void ShowData()
        {
            Console.WriteLine("=============== The Account Details Are: ===================");
            Console.WriteLine("Account Number is: " + AccountNo);
            Console.WriteLine("Customer Name is: " + CustomerName);
            Console.WriteLine("Account Type is: " + AccountType);
            Console.WriteLine("Total Balance in the Account is: {0}", Balance);
            Console.Read();
        }

    }

    class Details : Accounts
    {
        public void Credit(int amount)
        {
            Balance += Amount;
        }

        public void Debit(int amount)
        {
            Balance -= Amount;
        }
    }
    class AccountsProgram
    {
        static void Main(string[] args)
        {
            Details details = new Details();
            details.GetData();
            
            if (details.TransactionType == "Deposit")
            {
                details.Credit(details.Amount);
            }
            else
            {
                details.Debit(details.Amount);
            }
            details.ShowData();


        }
    }
}
