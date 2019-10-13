using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBankAccounts
{
    abstract class Accounts
    {
        private int id, balance;
        private string type;

        public Accounts(int i, int b, String t)
        {
            id = i;
            balance = b;
            type = t;
        }

        abstract public int accBalance();

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }
    }

    class Checking : Accounts
    {

        public Checking(int i, int b, String t)
            : base(i, b, t)
        { }


        public override int accBalance()
        {
            return base.Balance;
        }

        public int withdraw(int amount)
        {
            if(base.Balance <= 0)
            {
                Console.WriteLine("Enable to withdraw, your account is overdraft");
                return base.Balance;
            } else if(base.Balance - amount <= 10)
            {
                int total = (base.Balance -= amount) + 10;
                Console.WriteLine("Your account will overdraft by {0}", total);
                return base.Balance;
            }
            else
            {
                return base.Balance -= amount;
            }

        }
    }

    class Savings : Accounts
    {
        private int sbalance;
        public Savings(int i, int b, String t, int s)
            : base(i, b, t)
        {
            sbalance = s;
        }
        public override int accBalance()
        {
            return base.Balance;
        }
        public void savingsBalance()
        {
            Console.WriteLine("Saving Balance: {0}", sbalance);
        }

        public void transfer(int amount)
        {
            int totransfer = sbalance -= amount;
            if (sbalance <= 300)
            {
                Console.WriteLine("Your saving will be {0} below 300", totransfer);
                Console.WriteLine("Balance on Checking account after transfer is: {0}", base.Balance += amount);
            } else
            {
                Console.WriteLine("Balance on Savings account after transfer is: {0}", totransfer);
                Console.WriteLine("Balance on Checking account after transfer is: {0}", base.Balance += amount);
            }
        }
        public int SBalance
        {
            get
            {
                return sbalance;
            }
            set
            {
                sbalance = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Checking acc1 = new Checking(1, 1000, "Checking");
            Savings sacc1 = new Savings(1, 2000, "Savings", 3000);
            Console.WriteLine(acc1.accBalance());
            acc1.withdraw(999);
            Console.WriteLine(acc1.accBalance());
            sacc1.savingsBalance();
            sacc1.transfer(100);
            sacc1.savingsBalance();
            sacc1.transfer(300);
            sacc1.savingsBalance();
            Console.WriteLine("Done");
            Console.ReadKey();
            

        }
    }
}
