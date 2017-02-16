using System;
using static System.Console;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account(100);
            WriteLine(
                    account.Balance()
                );

            account.Deposit(50);
            WriteLine(
                    account.Deposit(200).Balance()
                );

            // new Application(
            //     new UserInterface(
            //         new DomainServices(
            //             new AccountService(),
            //             new UserService()
            //         )
            //     )
            // ).Run(Exit.Never);
        }
    }
}