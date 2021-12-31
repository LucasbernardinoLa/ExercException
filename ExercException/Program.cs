using System;
using System.Globalization;
using ExercException.Entities;
using ExercException.Entities.Exceptions;

namespace ExercException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter account data: ");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Holder: ");
            string holder = Console.ReadLine();
            Console.Write("Initial balance: ");
            double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Withdraw limit: ");
            double WithdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Account acc = new Account(number, holder, balance, WithdrawLimit);

            Console.WriteLine();
            Console.Write("Enter the amount for the withdraw: ");
            double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            try
            {
                acc.Withdraw(amount);
                Console.WriteLine($"New balance {acc.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }


            catch (DomainExceptions e)
            {
                Console.WriteLine($"Withdraw error: {e.Message} ");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error:" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

        }
    }
}
