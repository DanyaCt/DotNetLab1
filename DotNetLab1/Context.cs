using System.Collections.Generic;
using DotNetLab1.Models;

namespace DotNetLab1
{
    internal class Context
    {
        public List<Client> Clients { get; set; }
        public List<Currency> Currencies { get; set; }
        public List<Credit> Credits { get; set; }
        public List<Deposit> Deposits { get; set; }
        public List<ClientToCredit> ClientsToCredits { get; set; }
        public List<ClientToDeposit> ClientsToDeposits { get; set; }

        public Context()
        {
            Clients = Seed.Clients;
            Currencies = Seed.Currencies;
            Credits = Seed.Credits;
            Deposits = Seed.Deposits;
            ClientsToCredits = Seed.ClientsToCredits;
            ClientsToDeposits = Seed.ClientsToDeposits;
        }
    }
}
