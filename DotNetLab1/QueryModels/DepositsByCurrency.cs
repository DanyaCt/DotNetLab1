using System.Collections.Generic;
using DotNetLab1.Models;

namespace DotNetLab1.QueryModels
{
    internal class DepositsByCurrency
    {
        public string CurrencyName { get; set; }
        public IEnumerable<Deposit> Deposits { get; set; }
    }
}
