using System;
using System.Linq;

namespace DotNetLab1
{
    internal class Program
    {
        static void Main()
        {
            var context = new Context();
            var queries = new Queries(context);
            var printer = new Printer();

            printer.PrintClientsFullNames(
                queries.GetClientsFullNames()
            );

            printer.PrintClientsWithAccountNumbers(
                queries.GetClientsWithAccountNumbers().Distinct()
            );

            printer.PrintCreditsAfter2022(
                queries.GetCreditsAfter2022()
            );

            printer.PrintDepositsGroupedByCurrency(
                queries.GetDepositsGroupedByCurrency()
            );

            printer.PrintNotRepayedCredits(
                queries.GetNotRepayedCredits()
            );

            printer.PrintDepositsAndTheirUsageQuantity(
                queries.GetDepositsAndTheirUsageQuantity()
            );

            printer.PrintClientWithCreditsWithoutDeposits(
                queries.GetClientWithCreditsWithoutDeposits()
            );

            printer.PrintClientAndNumberOfCredits(
                queries.GetClientAndNumberOfCredits()
            );

            printer.PrintAverageDurationDepositsAndActualAverageDuration(
                queries.GetAverageDurationDepositsAndActualAverageDuration()
            );

            printer.PrintQuantityOfClientsWithCreditNoLessThanInputMoneyUAH(
                queries.GetQuantityOfClientsWithCreditNoLessThanInputMoneyUAH(500m)
            );

            printer.PrintClientWithMostCreditsWithHisMoneyAndSortedMoney(
                queries.GetClientWithMostCreditsWithHisMoneyAndSortedMoney()
            );

            printer.PrintCreditsWithRepaymentNoLessInputMonth(
                queries.GetCreditsWithRepaymentNoLessInputMonth(6)
            );

            printer.PrintClientsWithoutDepositsAndCredits(
                queries.GetClientsWithoutDepositsAndCredits()
            );

            printer.PrintClientsSuccessfullyRepayedTheirCredits(
                queries.GetClientsSuccessfullyRepayedTheirCredits()
            );

            printer.PrintUnusedDeposits(
                queries.GetUnusedDeposits()
            );

            printer.PrintDepositsAndCredits(
                queries.GetDepositsAndCredits()
            );
        }
    }
}
