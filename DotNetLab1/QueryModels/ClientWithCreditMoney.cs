using System.Collections.Generic;
using DotNetLab1.Models;

namespace DotNetLab1.QueryModels
{
    internal class ClientWithCreditMoney
    {
        public Client Client { get; set; }
        public IEnumerable<decimal> Money { get; set; }
    }
}
