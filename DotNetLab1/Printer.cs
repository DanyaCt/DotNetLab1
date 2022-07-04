using System;
using System.Collections.Generic;
using DotNetLab1.Models;
using DotNetLab1.QueryModels;

namespace DotNetLab1
{
    internal class Printer
    {
        public void PrintClientsFullNames(IEnumerable<string> fullNames)
        {
            Console.WriteLine("1. Clients full names:");
            foreach (var name in fullNames)
            {
                Console.WriteLine(name);
            }
        }

        public void PrintClientsWithAccountNumbers(IEnumerable<ClientWithAccountNumber> clients)
        {
            Console.WriteLine("\n2. Clients with deposit account numbers:");
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.FullName} - {client.AccountCode}");
            }
        }

        public void PrintCreditsAfter2022(IEnumerable<Credit> credits)
        {
            Console.WriteLine("\n3. Credits issued in 2022 and later:");
            foreach (var credit in credits)
            {
                Console.WriteLine($"Id = {credit.Id}, {credit.RepaymentDurationInMonths} month, {credit.PercentRate:0.00}%");
            }
        }

        public void PrintDepositsGroupedByCurrency(IEnumerable<DepositsByCurrency> deposits)
        {
            Console.WriteLine("\n4. Deposits grouped by currency:");
            foreach (var depositByCurrency in deposits)
            {
                Console.WriteLine($"{depositByCurrency.CurrencyName}:");
                foreach (var deposit in depositByCurrency.Deposits)
                {
                    Console.WriteLine($"\t{deposit.Id} - minimal investment: {deposit.MinimalInvestment} - {deposit.PercentRate:0.00}%");
                }
            }
        }

        public void PrintNotRepayedCredits(IEnumerable<Credit> credits)
        {
            Console.WriteLine("\n5. Credits that haven`t repayed yet:");
            foreach (var credit in credits)
            {
                Console.WriteLine($"Id = {credit.Id} - {credit.PercentRate:0.00}%");
            }
        }

        public void PrintDepositsAndTheirUsageQuantity(IEnumerable<UsageOfDeposit> usagesOfDeposits)
        {
            Console.WriteLine("\n6. Deposits and their usages quantity:");
            foreach (var usage in usagesOfDeposits)
            {
                Console.WriteLine($"Deposit {usage.Deposit.Id} - {usage.Deposit.PercentRate:0.00}%, usages: {usage.Quantity}");
            }
        }

        public void PrintClientWithCreditsWithoutDeposits(IEnumerable<Client> clients)
        {
            Console.WriteLine("\n7.Clients with credits and without deposits:");
            foreach (var client in clients)
            {
                Console.WriteLine($"Id = {client.Id}, {client.FullName}");
            }
        }

        public void PrintClientAndNumberOfCredits(IEnumerable<ClientWithQuantity> clientsWithQuantity)
        {
            Console.WriteLine("\n8. Clients and number of credits they have:");
            foreach (var client in clientsWithQuantity)
            {
                Console.WriteLine($"Id = {client.Client.Id}, {client.Client.FullName}, quantity: {client.Quantity}");
            }
        }

        public void PrintAverageDurationDepositsAndActualAverageDuration((float, float) averages)
        {
            Console.WriteLine("\n9. Predefined average duration and actual duration of deposits in days:");
            Console.WriteLine($"Predefined: {averages.Item1:0.00} days, Actual: {averages.Item2:0.00} days");
        }

        public void PrintQuantityOfClientsWithCreditNoLessThan50000UAH(int quantity)
        {
            Console.WriteLine("\n10. Quantity of clients with credits of more than 50000 UAH:");
            Console.WriteLine($"Quantity of clients: {quantity}");
        }

        public void PrintClientWithMostCreditsWithHisMoneyAndSortedMoney(ClientWithCreditMoney client)
        {
            Console.WriteLine("\n11. Client with most credits and those money:");
            Console.WriteLine($"{client.Client.Id} {client.Client.FullName}, Money in credits:");
            foreach (var money in client.Money)
            {
                Console.WriteLine($"\t{money}");
            }
        }

        public void PrintCreditsWithRepaymentNoLess6Month(IEnumerable<Credit> credits)
        {
            Console.WriteLine("\n12. Credits with repayment no less for 6 months:");
            foreach (var credit in credits)
            {
                Console.WriteLine($"Id = {credit.Id} - {credit.PercentRate:0.00}%, {credit.RepaymentDurationInMonths} months");
            }
        }

        public void PrintClientsWithoutDepositsAndCredits(IEnumerable<Client> clients)
        {
            Console.WriteLine("\n13. Clients without deposits and credits:");
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} - {client.FullName}");
            }
        }

        public void PrintClientsSuccessfullyRepayedTheirCredits(IEnumerable<Client> clients)
        {
            Console.WriteLine("\n14. Clients who has not any credits to repay:");
            foreach (var client in clients)
            {
                Console.WriteLine($"{client.Id} - {client.FullName}");
            }
        }

        public void PrintUnusedDeposits(IEnumerable<Deposit> deposits)
        {
            Console.WriteLine("\n15. Deposits that are not used by the clients:");
            foreach (var deposit in deposits)
            {
                Console.WriteLine($"{deposit.Id} - {deposit.PercentRate:0.00}%, minimal investment = {deposit.MinimalInvestment}");
            }
        }
    }
}
