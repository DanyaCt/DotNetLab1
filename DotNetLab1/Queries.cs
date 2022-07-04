using System.Collections.Generic;
using System.Linq;
using DotNetLab1.Models;
using DotNetLab1.QueryModels;

namespace DotNetLab1
{
    internal class Queries
    {
        private readonly Context _context;

        public Queries(Context context)
        {
            _context = context;
        }

        public IEnumerable<string> GetClientsFullNames()
        {
            return from client in _context.Clients
                   select client.FullName;
        }

        public IEnumerable<ClientWithAccountNumber> GetClientsWithAccountNumbers()
        {
            return from client in _context.Clients
                   join clientToDeposit in _context.ClientsToDeposits on client.Id equals clientToDeposit.ClientId
                   select new ClientWithAccountNumber()
                   {
                       AccountCode = clientToDeposit.AccountNumber,
                       FullName = client.FullName
                   };
        }

        public IEnumerable<Credit> GetCreditsAfter2022()
        {
            return from credit in _context.Credits
                   join creditToClient in _context.ClientsToCredits on credit.Id equals creditToClient.CreditId
                   where creditToClient.DateOfIssue.Year >= 2022
                   select credit;
        }

        public IEnumerable<DepositsByCurrency> GetDepositsGroupedByCurrency()
        {
            return from deposit in _context.Deposits
                   join currency in _context.Currencies on deposit.CurrencyId equals currency.Id
                   group deposit by currency.Name
                into grouped
                   select new DepositsByCurrency()
                   {
                       CurrencyName = grouped.Key,
                       Deposits = grouped
                   };
        }

        public IEnumerable<Credit> GetNotRepayedCredits()
        {
            return from credits in _context.Credits
                   join clientToCredit in _context.ClientsToCredits on credits.Id equals clientToCredit.CreditId
                   where clientToCredit.DateOfRepayment is null
                   select credits;
        }

        public IEnumerable<UsageOfDeposit> GetDepositsAndTheirUsageQuantity()
        {
            return from deposit in _context.Deposits
                   join clientToDeposit in _context.ClientsToDeposits on deposit.Id equals clientToDeposit.DepositId
                   group clientToDeposit by deposit
                into grouped
                   select new UsageOfDeposit()
                   {
                       Deposit = grouped.Key,
                       Quantity = grouped.Count()
                   };
        }

        public IEnumerable<Client> GetClientWithCreditsWithoutDeposits()
        {
            var clientsWithoutDeposits = _context.Clients.Except(
                _context.Clients.Join(_context.ClientsToDeposits,
                    client => client.Id,
                    deposit => deposit.ClientId,
                    (client, deposit) => (client, deposit))
                .GroupBy(x => x.client)
                .Select(x => x.Key)
                .Distinct()
                );

            var clientsWithCredits = _context.Clients.Join(_context.ClientsToCredits,
                    client => client.Id,
                    credit => credit.ClientId,
                    (client, credit) => (client, credit))
                .GroupBy(x => x.client)
                .Where(x => x.Any())
                .Select(x => x.Key);

            return clientsWithCredits.Intersect(clientsWithoutDeposits);
        }

        public IEnumerable<ClientWithQuantity> GetClientAndNumberOfCredits()
        {
            return from client in _context.Clients
                   join clientsToCredit in _context.ClientsToCredits on client.Id equals clientsToCredit.ClientId
                   group clientsToCredit by client
                into clientGroup
                   select new ClientWithQuantity()
                   {
                       Client = clientGroup.Key,
                       Quantity = clientGroup.Count()
                   };
        }

        public (float, float) GetAverageDurationDepositsAndActualAverageDuration()
        {
            var average = _context.Deposits
                .Select(x => x.DurationInMonths * 30)
                .Average();

            var actualAverage = _context.Deposits.Join(_context.ClientsToDeposits,
                    deposit => deposit.Id,
                    clientToDeposit => clientToDeposit.DepositId,
                    (deposit, clientToDeposit) => (deposit, clientToDeposit))
                .Where(x => x.clientToDeposit.DateOfEnding is not null)
                .Select(x =>
                    (float)(x.clientToDeposit.DateOfEnding - x.clientToDeposit.DateOfBeginning).Value.Days)
                .Average();

            return (average, actualAverage);
        }

        public int GetQuantityOfClientsWithCreditNoLessThan50000UAH()
        {
            return _context.ClientsToCredits
                .Join(_context.Credits,
                    ctc => ctc.CreditId,
                    credit => credit.Id,
                    (ctc, credit) => (ctc, credit))
                .Join(_context.Currencies,
                    credit => credit.credit.CurrencyId,
                    currency => currency.Id,
                    (credit, currency) => (credit.ctc, credit.credit, currency))
                .Count(x => x.currency.Name.Equals("UAH")
                            && x.ctc.AmountOfMoneyTaken >= 50000m);
        }

        public ClientWithCreditMoney GetClientWithMostCreditsWithHisMoneyAndSortedMoney()
        {
            var groups = _context.Clients
                .Join(_context.ClientsToCredits,
                    client => client.Id,
                    credit => credit.ClientId,
                    (client, credit) => (client, credit.AmountOfMoneyTaken))
                .GroupBy(x => x.client)
                .Select(x => new ClientWithCreditMoney()
                {
                    Client = x.Key,
                    Money = x.Select(x => x.AmountOfMoneyTaken)
                        .OrderByDescending(money => money),
                });

            var maxQuantity = groups
                .Select(x => x.Money.Count())
                .Max();

            return groups.FirstOrDefault(x => x.Money.Count() == maxQuantity);
        }

        public IEnumerable<Credit> GetCreditsWithRepaymentNoLess6Month()
        {
            return _context.Credits
                .Where(x => x.RepaymentDurationInMonths >= 6);
        }

        public IEnumerable<Client> GetClientsWithoutDepositsAndCredits()
        {
            var clientsWithCreditHistory = _context.ClientsToCredits
                .Join(_context.Clients,
                    credit => credit.ClientId,
                    client => client.Id,
                    (credit, client) => (credit, client))
                .Select(x => x.client)
                .Distinct();

            var clientsWithDepositHistory = _context.ClientsToDeposits
                .Join(_context.Clients,
                    deposit => deposit.ClientId,
                    client => client.Id,
                    (deposit, client) => (deposit, client))
                .Select(x => x.client)
                .Distinct();

            return _context.Clients.Except(
                clientsWithDepositHistory.Union(clientsWithCreditHistory)
            );
        }

        public IEnumerable<Client> GetClientsSuccessfullyRepayedTheirCredits()
        {
            return _context.Clients
                .Join(_context.ClientsToCredits,
                    client => client.Id,
                    credit => credit.ClientId,
                    (client, credit) => (client, credit))
                .GroupBy(x => x.client)
                .Select(x => (x.Key, x.Select(y => y.credit)))
                .Where(x =>
                    !x.Item2.Any(ctc => ctc.DateOfRepayment is null))
                .Select(x => x.Key);
        }

        public IEnumerable<Deposit> GetUnusedDeposits()
        {
            return _context.Deposits
                .Except(
                    _context.ClientsToDeposits
                        .Join(_context.Deposits,
                            ctd => ctd.DepositId,
                            deposit => deposit.Id,
                            (ctd, deposit) => (ctd, deposit))
                        .Select(x => x.deposit)
                );
        }
    }
}
